 
/*------------------------------------------------------------------------
   File        : OpenEdgeRepositoryModel
   Purpose     : 
   Syntax      : 
   Description : 
   Author(s)   : Tom
   Created     : Sun Mar 04 18:28:30 CET 2018
   Notes       : 
 ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING combit.Reporting.Repository.IRepository    FROM ASSEMBLY.
USING combit.Reporting.Repository.RepositoryItem FROM ASSEMBLY.
USING System.IO.FileMode FROM ASSEMBLY.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelDemo.Sports2000RepositoryModel IMPLEMENTS IRepository:
    
    DEFINE TEMP-TABLE ttRepository NO-UNDO
        FIELD RepositoryGuid        AS CHARACTER 
        FIELD RepositoryId          AS CHARACTER 
        FIELD RepositoryName        AS CHARACTER 
        FIELD RepositoryDescription AS CHARACTER
        INDEX pix IS PRIMARY UNIQUE RepositoryGuid
        INDEX ak IS UNIQUE RepositoryId.  
   
    DEFINE TEMP-TABLE ttRepositoryItem NO-UNDO
        FIELD RepositoryGuid            AS CHARACTER 
        FIELD RepositoryItemID          AS CHARACTER 
        FIELD RepositoryItemType        AS CHARACTER 
        FIELD RepositoryItemDescriptor  AS CHARACTER 
        FIELD RepositoryItemTimeStamp   AS DATETIME 
        FIELD RepositoryItemContent     AS BLOB
        INDEX pix IS PRIMARY UNIQUE RepositoryGuid RepositoryItemID.

    DEFINE DATASET dsRepository FOR ttRepository, ttRepositoryItem
        DATA-RELATION RepositoryItem FOR ttRepository, ttRepositoryItem
            RELATION-FIELDS (RepositoryGuid , RepositoryGuid ).

    
    DEFINE PUBLIC PROPERTY RepositoryId AS CHARACTER NO-UNDO 
        GET.
        PRIVATE SET. 
    
    DEFINE PRIVATE VARIABLE mcRepositoryGuid AS CHARACTER NO-UNDO.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    CONSTRUCTOR PUBLIC Sports2000RepositoryModel ( pcRepositoryId AS CHARACTER ):
        SUPER ().
        
        RepositoryId = pcRepositoryId.
        
        DO TRANSACTION:
            FIND ttRepository WHERE ttRepository.RepositoryId = RepositoryId EXCLUSIVE NO-ERROR.
            IF NOT AVAILABLE ttRepository THEN 
            DO:
                CREATE ttRepository.
                ASSIGN 
                    ttRepository.RepositoryGuid = GUID
                    ttRepository.RepositoryId   = pcRepositoryId
                    ttRepository.RepositoryName = "Repository " + ttRepository.RepositoryId.
            END.
            
            mcRepositoryGuid = ttRepository.RepositoryGuid.
        END.
        FINALLY:
            RELEASE ttRepository.
        END FINALLY.
        
    END CONSTRUCTOR.

    METHOD PUBLIC LOGICAL ContainsItem( INPUT id AS CHARACTER ):
        
        FIND ttRepositoryItem WHERE ttRepositoryItem.RepositoryGuid   = mcRepositoryGuid
            AND   ttRepositoryItem.RepositoryItemId = id NO-LOCK NO-ERROR.
                              
        RETURN AVAILABLE ttRepositoryItem.

    END METHOD.

    METHOD PUBLIC VOID CreateOrUpdateItem( INPUT item AS RepositoryItem, 
                                           INPUT importUserData AS CHARACTER, 
                                           INPUT sourceStream   AS System.IO.Stream ):
        
        DEFINE VARIABLE oFileStream AS System.IO.FileStream NO-UNDO.
        DEFINE VARIABLE cTempFile   AS CHARACTER            NO-UNDO.
        DEFINE VARIABLE lContent    AS LOGICAL              NO-UNDO.

        IF VALID-OBJECT(sourceStream) AND sourceStream:LENGTH > 0 THEN 
        DO:
            /* Write the content from sourceStream to a temp-file on the disk */
            cTempFile = OETempFileName().
            oFileStream = System.IO.File:Create(cTempFile).
            sourceStream:CopyTo(oFileStream).
            oFileStream:Close().
            lContent = TRUE.
        END.
        
        DO TRANSACTION:
            FIND ttRepositoryItem WHERE ttRepositoryItem.RepositoryGuid   = mcRepositoryGuid
                AND   ttRepositoryItem.RepositoryItemId = Item:InternalID EXCLUSIVE NO-ERROR.
            IF NOT AVAILABLE ttRepositoryItem THEN 
            DO:
                CREATE ttRepositoryItem.
                ASSIGN ttRepositoryItem.RepositoryGuid     = mcRepositoryGuid
                       ttRepositoryItem.RepositoryItemId   = Item:InternalID.
                    
            END.                
            ASSIGN ttRepositoryItem.RepositoryItemType         = item:Type
                   ttRepositoryItem.RepositoryItemDescriptor   = Item:Descriptor
                   ttRepositoryItem.RepositoryItemTimestamp    = Item:LastModificationUTC.
            
            IF lContent = TRUE THEN 
                COPY-LOB FROM FILE cTempFile TO ttRepositoryItem.RepositoryItemContent.
        END.

        IF lContent AND cTempFile > "" THEN 
            OS-DELETE VALUE (cTempFile).
        
        RETURN.
        FINALLY:
            RELEASE ttRepositoryItem.
            
        END FINALLY.

    END METHOD.

    METHOD PUBLIC VOID DeleteItem( INPUT id AS CHARACTER ):
        DO TRANSACTION:
            FIND ttRepositoryItem WHERE ttRepositoryItem.RepositoryGuid   = mcRepositoryGuid
                                  AND   ttRepositoryItem.RepositoryItemId = id EXCLUSIVE NO-ERROR.
            IF AVAILABLE ttRepositoryItem THEN 
                DELETE ttRepositoryItem.
        END.    

    END METHOD.

    METHOD PUBLIC "System.Collections.Generic.IEnumerable<combit.Reporting.Repository.RepositoryItem>" GetAllItems(  ):
        
        DEFINE VARIABLE oItems AS "System.Collections.Generic.List<combit.Reporting.Repository.RepositoryItem>" NO-UNDO.
        
        oItems = NEW "System.Collections.Generic.List<combit.Reporting.Repository.RepositoryItem>"().
        
        DEFINE VARIABLE oItem AS RepositoryItem NO-UNDO.
        
        FOR EACH ttRepositoryItem WHERE ttRepositoryItem.RepositoryGuid = mcRepositoryGuid NO-LOCK:

            oItem = NEW RepositoryItem(ttRepositoryItem.RepositoryItemId,
                                       ttRepositoryItem.RepositoryItemDescriptor,
                                       ttRepositoryItem.RepositoryItemType,
                                       ttRepositoryItem.RepositoryItemTimestamp).     
            oItem:IsEmpty = IF LENGTH(ttRepositoryItem.RepositoryItemContent) > 0 THEN FALSE ELSE TRUE.
            oItems:add(oItem).            
        END.
        
        RETURN oItems.

    END METHOD.

    METHOD PUBLIC combit.Reporting.Repository.RepositoryItem GetItem( INPUT id AS CHARACTER ):
        
        DEFINE VARIABLE oItem AS RepositoryItem NO-UNDO.
        
        FIND ttRepositoryItem WHERE ttRepositoryItem.RepositoryGuid   = mcRepositoryGuid 
                              AND   ttRepositoryItem.RepositoryItemId = id NO-LOCK NO-ERROR.
                              
        IF AVAILABLE ttRepositoryItem THEN 
        DO:
            oItem = NEW RepositoryItem(ttRepositoryItem.RepositoryItemId,
                                       ttRepositoryItem.RepositoryItemDescriptor,
                                       ttRepositoryItem.RepositoryItemType,
                                       ttRepositoryItem.RepositoryItemTimestamp).  
            oItem:IsEmpty = IF LENGTH(ttRepositoryItem.RepositoryItemContent) > 0 THEN FALSE ELSE TRUE.
        END.
        
        RETURN oItem.                          

    END METHOD.

    METHOD PUBLIC VOID LoadItem( INPUT id AS CHARACTER, 
        INPUT destinationStream AS System.IO.Stream, 
        INPUT cancelToken       AS System.Threading.CancellationToken ):

        DEFINE VARIABLE oItem     AS RepositoryItem NO-UNDO.
        DEFINE VARIABLE cTempFile AS CHARACTER      NO-UNDO.
        DEFINE VARIABLE oFileStream AS System.IO.FileStream NO-UNDO.

        FIND ttRepositoryItem WHERE ttRepositoryItem.RepositoryGuid   = mcRepositoryGuid 
                              AND   ttRepositoryItem.RepositoryItemId = id NO-LOCK NO-ERROR.

        IF AVAILABLE ttRepositoryItem AND LENGTH (ttRepositoryItem.RepositoryItemContent) > 0 THEN 
        DO:
            cTempFile = OETempFileName().
            COPY-LOB FROM ttRepositoryItem.RepositoryItemContent TO FILE cTempFile.
            oFileStream = System.IO.File:Open(cTempFile,FileMode:Open).
            oFileStream:CopyTo(destinationStream).
            oFileStream:Close().
            /*OS-DELETE VALUE (cTempFile).*/
        END.

    END METHOD.

    METHOD PUBLIC LOGICAL LockItem( INPUT id AS CHARACTER ):
        
        RETURN TRUE.

    END METHOD.


    METHOD PUBLIC VOID UnlockItem( INPUT id AS CHARACTER ):
        
        RETURN.

    END METHOD.
    
    METHOD PRIVATE CHARACTER OETempFileName(  ):
        
        DEFINE VARIABLE cFilename AS CHARACTER NO-UNDO.
        
        cFilename =  SUBSTITUTE("&1_LLPRO-&2.blb",SESSION:TEMP-DIRECTORY,GUID). 

        RETURN cFilename.

    END METHOD.
    
END CLASS.
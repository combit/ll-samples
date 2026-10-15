/**********************************************************************
 * Copyright (C) 2021 by Taste IT Consulting ("TIC") -                *
 * www.taste-consulting.de and other contributors as listed           *
 * below.  All Rights Reserved.                                       *
 *                                                                    *
 *  Software is distributed on an "AS IS", WITHOUT WARRANTY OF ANY    *
 *   KIND, either express or implied.                                 *
 *                                                                    *
 *  Contributors:                                                     *
 *                                                                    *
 **********************************************************************/  
 
 /*------------------------------------------------------------------------
    File        : OpenEdgePostContent
    Purpose     : Container for the HTTP Post Content
    Syntax      : 
    Description : This container holds Name / Value pairs for all 
                  parameters that the OpenEdgeGateway needs to have.
                  "ServiceName" - the classname of the service
                  "MethodName"  - "ping"|"getData"|"getSchema"|...
                  "OpenEdgeServiceParameter" - String with Json
                  "OpenEdgeDataRequest" - String with Json 
                  
                  This container is used by OpenEdgeHttpEndpoint.p.
                  The Post content (Body) goes to the constructor here.
                  After we have the Data in the dataset, we can ask for
                  the parameters with getContent().
                  
                  cMethodName = getContent("MethodName").
                  
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Fri Jan 15 17:06:34 CET 2021
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgePostContent: 
    
    {ListLabel/OpenEdgeAdapter/dsOpenEdgePostContent.i}

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    CONSTRUCTOR PUBLIC OpenEdgePostContent (  ):
        SUPER ().
    END CONSTRUCTOR.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    CONSTRUCTOR PUBLIC OpenEdgePostContent ( plcContentJson AS LONGCHAR ):
        SUPER ().
        DATASET dsOpenEdgePostContent:READ-JSON ("LONGCHAR", plcContentJson, "EMPTY").
    END CONSTRUCTOR.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC LONGCHAR getContent( pcOEContentName AS CHARACTER ):
        
        DEFINE VARIABLE lcContentData AS LONGCHAR NO-UNDO.

        FIND OEPostContent WHERE OEPostContent.OEContentName = pcOEContentName NO-ERROR.
        IF AVAILABLE OEPostContent THEN 
            COPY-LOB FROM OEPostContent.OEContentData TO lcContentData.

        RETURN lcContentData.

    END METHOD.
    
    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID setContent( pcOEContentName  AS CHARACTER, 
                                   plcOEContentData AS LONGCHAR ):
       
        FIND OEPostContent WHERE OEPostContent.OEContentName = pcOEContentName NO-ERROR.
        IF NOT AVAILABLE OEPostContent THEN 
        DO:
            CREATE OEPostContent.
            ASSIGN OEPostContent.OEContentName = pcOEContentName.
        END.    
        
        COPY-LOB FROM plcOEContentData TO OEPostContent.OEContentData.
        
        RETURN.

    END METHOD.
    
    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC VOID getDataset( OUTPUT DATASET dsOpenEdgePostContent ):
        
        RETURN.

    END METHOD.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    METHOD PUBLIC LONGCHAR getJson(  ):
        
        DEFINE VARIABLE lcData AS LONGCHAR NO-UNDO.
        DATASET dsOpenEdgePostContent:WRITE-JSON ("LONGCHAR",lcData,TRUE).
        RETURN lcData.

    END METHOD.
    

END CLASS.
 /**********************************************************************
 * Copyright (C) 2018 by Taste IT Consulting ("TIC") -                *
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
    File        : OpenEdgeFileCache
    Purpose     : Filecache for (Dataset) Json data.
    Syntax      : 
    Description : If a service needs to cache data between client requests,
                  this is a sample to use the data provider clientid and
                  the service name to create a unique cache.
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Oct 02 12:06:54 CEST 2018
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.IOpenEdgeCache FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabel.OpenEdgeAdapter.OpenEdgeFileCache IMPLEMENTS IOpenEdgeCache:

    DEFINE PUBLIC PROPERTY ClientId AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET.

    DEFINE PUBLIC PROPERTY ServiceName   AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET.

    DEFINE PUBLIC PROPERTY CacheFilename AS CHARACTER NO-UNDO 
    GET.
    PRIVATE SET.

    /*------------------------------------------------------------------------------
     Purpose:
     Notes:
    ------------------------------------------------------------------------------*/
    CONSTRUCTOR PUBLIC OpenEdgeFileCache ( pcServiceName AS CHARACTER, pcClientId AS CHARACTER ):
        SUPER ().
        ClientId      = pcClientId.
        /* Use only the last entry - that's enough */
        ServiceName   = ENTRY(NUM-ENTRIES(pcServiceName,"."),pcServiceName,".").
        CacheFilename = SUBSTITUTE("&1_&2_&3.cache",SESSION:TEMP-DIRECTORY,ServiceName,ClientId).
        RETURN.        
    END CONSTRUCTOR.

    METHOD PUBLIC LOGICAL CacheExists(  ):
        DEFINE VARIABLE lExists AS LOGICAL NO-UNDO.
        FILE-INFO:FILE-NAME = CacheFilename.
        IF FILE-INFO:FULL-PATHNAME <> ? THEN 
            lExists = TRUE.
        RETURN lExists.
    END METHOD.

    METHOD PUBLIC LOGICAL DeleteCache(  ):
        DEFINE VARIABLE lSuccess AS LOGICAL NO-UNDO.
        DEFINE VARIABLE iError   AS INTEGER NO-UNDO.
        FILE-INFO:FILE-NAME = CacheFilename.
        IF FILE-INFO:FULL-PATHNAME <> ? THEN 
        DO:
            OS-DELETE VALUE (FILE-INFO:FULL-PATHNAME).
            iError = OS-ERROR.
            IF iError = 0 THEN 
                ASSIGN lSuccess = TRUE.
        END.        
        RETURN lSuccess.
    END METHOD.

    METHOD PUBLIC LONGCHAR ReadCache(  ):
        DEFINE VARIABLE lcContent AS LONGCHAR NO-UNDO.
        FILE-INFO:FILE-NAME = CacheFilename.
        IF FILE-INFO:FULL-PATHNAME <> ? THEN 
        DO:
            COPY-LOB FROM FILE FILE-INFO:FULL-PATHNAME TO lcContent NO-ERROR.
        END.        
        RETURN lcContent.
    END METHOD.

    METHOD PUBLIC LOGICAL WriteCache( INPUT plcJsonData AS LONGCHAR ):
        COPY-LOB FROM plcJsonData TO FILE CacheFilename.
        RETURN TRUE.
    END METHOD.
    
    

END CLASS.
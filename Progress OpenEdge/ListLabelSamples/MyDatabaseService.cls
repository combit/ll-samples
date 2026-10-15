/**********************************************************************
 * Copyright (C) 2016 by Taste IT Consulting ("TIC") -                *
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
    File        : MyDatabaseService
    Purpose     : Template for your own Service.
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Jan 26 11:28:25 CET 2016
    Notes       : 
  ----------------------------------------------------------------------*/
USING Progress.Lang.*.
USING ListLabel.OpenEdgeAdapter.OpenEdgeService FROM PROPATH.

BLOCK-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelSamples.MyDatabaseService INHERITS OpenEdgeService: 

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	CONSTRUCTOR PUBLIC MyDatabaseService (  ):
		SUPER ().
	END CONSTRUCTOR.

	METHOD OVERRIDE PUBLIC VOID registerSchema(  ):
		
		ServiceSchema:DatabaseName = "<DatabaseName>".

        /*		
		/* Register your tables and relations here */
        FOR EACH <DatabaseName>._file WHERE _file._hidden = FALSE NO-LOCK:
              ServiceSchema:registerFile(_file._file-name).
        END.
        ServiceSchema:registerFileRelation("<ParentTableName>","<ChildTableName>","<RelationFields>","<RelationName>").
		*/ 

	END METHOD.

END CLASS.
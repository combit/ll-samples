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
    File        : dsOpenEdgeServiceParameter
    Purpose     : Dataset to pass name value pairs for service parameter
                  to the service.
    Syntax      :

    Description : 

    Author(s)   : 
    Created     : Fri Feb 12 06:05:50 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */
DEFINE TEMP-TABLE OEServiceParameter NO-UNDO 
    FIELD OEParameterName  AS CHARACTER 
    FIELD OEParameterValue AS CHARACTER 
    INDEX pk IS PRIMARY UNIQUE OEParameterName.
    
DEFINE DATASET dsOpenEdgeServiceParameter SERIALIZE-NAME "OpenEdgeServiceParameter"
       FOR OEServiceParameter.
       
           

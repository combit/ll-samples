 /**********************************************************************
  * Copyright (C) 2025 by Taste IT Consulting ("TIC") -                *
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
    File        : OpenEdgeServiceHelper.p
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Mar 25 06:06:53 CET 2025
    Notes       :
  ----------------------------------------------------------------------*/

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING ListLabel.OpenEdgeAdapter.OpenEdgeService FROM PROPATH.

DEFINE INPUT PARAMETER poOpenEdgeServiceInstance AS ListLabel.OpenEdgeAdapter.OpenEdgeService NO-UNDO.

PROCEDURE BeforeRowFillHandler:
    DEFINE INPUT PARAMETER DATASET-HANDLE phDataset.
    poOpenEdgeServiceInstance:BeforeRowFillCallback().
END.


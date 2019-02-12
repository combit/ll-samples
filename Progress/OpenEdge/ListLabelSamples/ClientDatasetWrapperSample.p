/**********************************************************************
 * Copyright (C) 2017 by Taste IT Consulting ("TIC") -                *
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
    File        : ClientDatasetWrapperSample.p
    Purpose     : Sample how to design / print an existing dataset on
                  an ABL Client. 
                  If you want to print on the client, you may pass a
                  handle of a dataset to the wrapper. 
    Syntax      :

    Description : 

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : Tue Dec 06 16:39:16 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING ListLabelSamples.ClientDatasetWrapper FROM PROPATH.

DEFINE VARIABLE oWrapper AS ClientDatasetWrapper NO-UNDO.

DEFINE TEMP-TABLE ttCustomer NO-UNDO LIKE Customer.
DEFINE DATASET dsCustomer FOR ttCustomer.

FOR EACH Customer NO-LOCK:
    CREATE ttCustomer.
    BUFFER-COPY Customer TO ttCustomer.
END.    

oWrapper = NEW ClientDatasetWrapper().
oWrapper:PrintDataset(DATASET dsCustomer:HANDLE, TRUE ).



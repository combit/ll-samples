
/*------------------------------------------------------------------------
    File        : ttFieldPair.i
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : 
    Created     : Sun Jan 31 05:51:54 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/

/* ***************************  Definitions  ************************** */
    DEFINE TEMP-TABLE ttFieldPair NO-UNDO 
        FIELD Pair        AS INTEGER 
        FIELD ParentField AS CHARACTER LABEL "Parent Field" 
        FIELD ChildField  AS CHARACTER LABEL "Child Field"
        INDEX pk IS PRIMARY UNIQUE Pair.

    
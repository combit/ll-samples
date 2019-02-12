
/*------------------------------------------------------------------------
    File        : ttField.i
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : 
    Created     : Wed Feb 03 06:14:51 CET 2016
    Notes       :
  ----------------------------------------------------------------------*/
  DEFINE TEMP-TABLE ttField NO-UNDO 
     FIELD FieldOrder    AS INTEGER
     FIELD FieldName     AS CHARACTER 
     FIELD DataType      AS CHARACTER 
     FIELD FieldExtent   AS INTEGER
     FIELD FieldSelected AS LOGICAL 
     INDEX pk IS PRIMARY UNIQUE FieldName.
        
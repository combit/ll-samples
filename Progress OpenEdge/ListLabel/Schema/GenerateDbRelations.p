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
/* GenerateDbRelations.p 
   Helps to generate relations for your db service.
*/
USING ListLabel.Schema.dbschema FROM PROPATH.

DEFINE VARIABLE oSchema   AS dbschema  NO-UNDO.
DEFINE VARIABLE cFilename AS CHARACTER NO-UNDO.
DEFINE STREAM s.

{ListLabel/Schema/dbschema.i}

/* Set your dbname here */
CREATE ALIAS DICTDB FOR DATABASE VALUE ("sports2000").

/* This generates all relations for DICTDB */
oSchema = NEW dbschema().
oSchema:getSchema(OUTPUT DATASET dsDbInfo).

/* Generate include */
cFilename = SUBSTITUTE("&1_relations.i", LDBNAME("DICTDB")).

OUTPUT STREAM s TO VALUE (cFilename).

PUT STREAM s UNFORMATTED 
      (SUBSTITUTE("/* &1_relations.i */", LDBNAME("DICTDB"))) SKIP
      SUBSTITUTE("/* Generated: &1 */", STRING(NOW,"99.99.9999 HH:MM:SS")) SKIP 
      "/* Parent -> Child : the first table is a foreign key in the second table */" SKIP.
      
FOR EACH ttRelationInfo WHERE ttRelationInfo.Inactive = FALSE BREAK BY ttRelationInfo.ParentTableName:
    
    IF FIRST-OF (ttRelationInfo.ParentTableName) THEN 
    PUT STREAM s UNFORMATTED SKIP(1)
       SUBSTITUTE("/* &1 */",ttRelationInfo.ParentTableName)
       SKIP.

    PUT STREAM s UNFORMATTED 
       SUBSTITUTE('ServiceSchema:registerFileRelation("&1","&2","&3","&4").',
                ttRelationInfo.ParentTableName,ttRelationInfo.ChildTableName,ttRelationInfo.RelationFields,ttRelationInfo.RelationName) 
       SUBSTITUTE (' /* &5Indexes: &1.&1 <->> &3.&4 */', 
                    ttRelationInfo.ParentTableName,
                    ttRelationInfo.ParentIndexName,
                    ttRelationInfo.ChildTableName,
                    IF ttRelationInfo.ChildIndexName > "" THEN ttRelationInfo.ChildIndexName ELSE "<none>",
                    IF ttRelationInfo.ChildIndexed THEN "" ELSE "** "
                    )                  
                SKIP.
END.  

OUTPUT STREAM s CLOSE.

MESSAGE "Done"
VIEW-AS ALERT-BOX.


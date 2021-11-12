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
    File        : TreeSample.p
    Purpose     : 

    Syntax      :

    Description : Sample for a temp-table with a recursive relation.
                  Works also for db tables with recursive relations.

    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : 2021
    Notes       : LL27
  ----------------------------------------------------------------------*/

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING combit.Reporting.ListLabel FROM ASSEMBLY.
USING TasteITConsulting.Reporting.OpenEdgeDataProvider FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetService   FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetServiceAdapter FROM PROPATH.

DEFINE TEMP-TABLE ttProject NO-UNDO 
    FIELD ProjectNumber AS INTEGER 
    FIELD ProjectName   AS CHARACTER 
    INDEX pix IS PRIMARY UNIQUE ProjectNumber.

DEFINE TEMP-TABLE ttTask NO-UNDO
    FIELD TaskNumber       AS INTEGER
    FIELD ProjectNumber    AS INTEGER 
    FIELD ParentTaskNumber AS INTEGER
    FIELD ParentSort       AS INTEGER
    FIELD TaskName         AS CHARACTER
    FIELD TaskTypeId       AS CHARACTER
    /* Calculated */ 
    FIELD TaskIndex        AS CHARACTER
    FIELD TaskLevel        AS INTEGER 
    INDEX pix IS PRIMARY UNIQUE TaskNumber
    INDEX ixParent ParentTaskNumber ParentSort
    INDEX ixProject ProjectNumber
    INDEX ixTaskType TaskTypeId.
    .
    
DEFINE TEMP-TABLE ttTaskType NO-UNDO 
    FIELD TaskTypeId AS CHARACTER 
    FIELD TaskType AS CHARACTER 
    INDEX pix IS PRIMARY UNIQUE TaskTypeId.    
    
DEFINE DATASET dsData FOR ttProject, ttTask, ttTaskType
    DATA-RELATION ProjectTask FOR ttProject, ttTask
        RELATION-FIELDS(ProjectNumber, ProjectNumber)
    /* Recursive Relation - needs to be NOT-ACTIVE in a dataset */
    DATA-RELATION ChildTask FOR ttTask, ttTask 
        RELATION-FIELDS(TaskNumber, ParentTaskNumber) NOT-ACTIVE
    DATA-RELATION TaskType FOR ttTask, ttTaskType 
        RELATION-FIELDS (TaskTypeId, TaskTypeId).    

DEFINE VARIABLE oLL             AS ListLabel              NO-UNDO.
DEFINE VARIABLE oProvider       AS OpenEdgeDataProvider   NO-UNDO.
DEFINE VARIABLE oDatasetService AS OpenEdgeDatasetService NO-UNDO.

CREATE ttTaskType.
ASSIGN ttTaskType.TaskTypeId = "S"
       ttTaskType.TaskType   = "Simple".

CREATE ttTaskType.
ASSIGN ttTaskType.TaskTypeId = "A"
       ttTaskType.TaskType   = "Advanced".

CREATE ttProject.
ASSIGN ttProject.ProjectNumber = 1
       ttProject.ProjectName   = "List&Label Reporting".

CREATE ttTask.
ASSIGN ttTask.TaskNumber       = 1
       ttTask.ParentTaskNumber = 0
       ttTask.ParentSort       = 1
       ttTask.Taskname         = "Write Sourcecode"
       ttTask.ProjectNumber    = 1
       ttTask.TaskTypeId       = "A".
       
CREATE ttTask.
ASSIGN ttTask.TaskNumber       = 2
       ttTask.ParentTaskNumber = 0
       ttTask.ParentSort       = 1
       ttTask.Taskname         = "Design your Layout"
       ttTask.ProjectNumber    = 1
       ttTask.TaskTypeId       = "A".
       .

CREATE ttTask.
ASSIGN ttTask.TaskNumber       = 3
       ttTask.ParentTaskNumber = 0
       ttTask.ParentSort       = 3
       ttTask.Taskname         = "Run Report"
       ttTask.ProjectNumber    = 1
       ttTask.TaskTypeId       = "S"
       .
       
CREATE ttTask.
ASSIGN ttTask.TaskNumber       = 4
       ttTask.ParentTaskNumber = 1
       ttTask.ParentSort       = 1
       ttTask.Taskname         = "Create OpenEdgeService"
       ttTask.ProjectNumber    = 1
       ttTask.TaskTypeId       = "A"
       .

CREATE ttTask.
ASSIGN ttTask.TaskNumber       = 5
       ttTask.ParentTaskNumber = 1
       ttTask.ParentSort       = 2
       ttTask.Taskname         = "Create Form"
       ttTask.ProjectNumber    = 1
       ttTask.TaskTypeId       = "A"
       .

RUN Numbering (0,0).

oProvider = NEW OpenEdgeDataProvider().
oLL       = NEW ListLabel().

oDatasetService = NEW OpenEdgeDatasetService(DATASET dsData:HANDLE ).
oDatasetService:TablePrefixToRemove = "tt".

oProvider:ServiceName    = oDatasetService:ServiceName.
oProvider:ServiceAdapter = NEW OpenEdgeDatasetServiceAdapter(oDatasetService).
oProvider:Initialize().

oLL:DataSource           = oProvider.
oLL:ForceSingleThread    = TRUE.

oLL:Design().
oLL:Dispose().

RETURN.

PROCEDURE Numbering:
    DEFINE INPUT PARAMETER piParentTaskNumber AS INTEGER NO-UNDO.
    DEFINE INPUT PARAMETER piLevel            AS INTEGER NO-UNDO.
    DEFINE BUFFER ttParent FOR ttTask.
    DEFINE BUFFER ttTask   FOR ttTask.
    
    DEFINE VARIABLE cParentIndex AS CHARACTER NO-UNDO.
    DEFINE VARIABLE iNumber      AS INTEGER   NO-UNDO.
    
    piLevel = piLevel + 1.
    /* Just in case ... :-) */
    IF piLevel > 3 THEN 
        RETURN.
    
    FIND ttParent WHERE ttParent.TaskNumber = piParentTaskNumber NO-ERROR.
    IF AVAILABLE ttParent THEN 
        ASSIGN cParentIndex = ttParent.TaskIndex.
    
    FOR EACH ttTask WHERE ttTask.ParentTaskNumber = piParentTaskNumber BY ttTask.ParentSort:
        iNumber = iNumber + 1.
        ASSIGN ttTask.TaskLevel = piLevel
               ttTask.TaskIndex = SUBSTITUTE("&1&2.",cParentIndex,iNumber). 
        RUN Numbering (ttTask.TaskNumber,piLevel).       
    END.
END.    
    
    



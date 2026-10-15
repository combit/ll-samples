
/*------------------------------------------------------------------------
    File        : RSTest.p
    Purpose     : 

    Syntax      :

    Description : 

    Author(s)   : Tom
    Created     : Mon Jan 07 08:28:44 CET 2019
    Notes       :
  ----------------------------------------------------------------------*/

BLOCK-LEVEL ON ERROR UNDO, THROW.

USING combit.Reporting.ListLabel FROM ASSEMBLY.
USING TasteITConsulting.Reporting.OpenEdgeDataProvider      FROM ASSEMBLY.
USING ListLabel.OpenEdgeAdapter.OpenEdgeDatasetServiceAdapter FROM PROPATH.
USING ListLabelSamples.RSTestService FROM PROPATH.

DEFINE VARIABLE oLL             AS ListLabel            NO-UNDO.
DEFINE VARIABLE oProvider       AS OpenEdgeDataProvider NO-UNDO.
DEFINE VARIABLE oDatasetService AS RSTestService        NO-UNDO.

oProvider = NEW OpenEdgeDataProvider().
oLL = NEW ListLabel().

oDatasetService          = NEW RSTestService().
oProvider:ServiceName    = oDatasetService:ServiceName.
oProvider:ServiceAdapter = NEW OpenEdgeDatasetServiceAdapter(oDatasetService).
oProvider:Initialize().

oLL:DataSource           = oProvider.
oLL:ForceSingleThread    = TRUE.

oLL:Design().

FINALLY: 
    oLL:Dispose().
    oProvider:Dispose().
END.

Use Windows.pkg
Use DFRptVw.pkg
Use cListLabel.pkg
Use llpreview.dg
use lltableselect.dg

ACTIVATE_VIEW Activate_oReportView1 FOR oReportView1

Object oReportView1 is a cListLabelReportView
    Set Location to 6 6
    Set Size to 56 197
    
    Property Integer piReportProjectType LL_PROJECT_LIST

    Object oReportType is a RadioGroup
        Set Size to 27 187
        Set Location to 6 5
        Set Label to "Report Type"
        Set peAnchors to anBottomLeftRight

        Object oTypeList is a Radio
            Set Label to "List"
            Set Size to 10 39
            Set Location to 12 10
            Set Status_Help to "Print a List Project"
        End_Object

        Object oTypeLabel is a Radio
            Set Label to "Label"
            Set Size to 10 37
            Set Location to 12 77
            Set Status_Help to "Print a Label Project"
        End_Object

        Object oTypeCard is a Radio
            Set Label to "Card"
            Set Size to 10 27
            Set Location to 12 151
            Set Status_Help to "Print a Card Project"
        End_Object
        
        Procedure Notify_Select_State Integer iToItem Integer iFromItem
            Forward Send Notify_Select_State iToItem iFromItem
            Case Begin
                Case (iToItem=1) 
                    Set piReportProjectType to LL_PROJECT_LABEL
                    Case Break
                Case (iToItem=2)
                    Set piReportProjectType to LL_PROJECT_CARD
                    Case Break
                Case Else
                    Set piReportProjectType to LL_PROJECT_LIST
                    Case Break
            Case End
        End_Procedure        
        
    End_Object

    Object oPrintButton is a Button
        Set Label to "&Print"
        Set Location to 38 34
        Set Default_State to TRUE
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send StartReport
        End_Procedure

    End_Object

    Object oLayoutButton is a Button
        Set Label to "&Edit Layout"
        Set Location to 38 88
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send EditLayout
        End_Procedure

    End_Object

    Object oCancelButton is a Button
        Set Label to "&Cancel"
        Set Location to 38 142
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send Request_Cancel
        End_Procedure

    End_Object
    
    Object oListLabelReport is a cListLabelReport
        // Uncomment this Line and set the Property to your personal License Code (perslic.txt located in your List & Label Folder)
        //Set psLicensingInfo to "123456"
        
        If (ghoApplication<>0) Begin
            Set psDefaultLayoutDirectory to (psProgramPath(phoWorkspace(ghoApplication)))
        End
        
        // Properties for the Preview-Object
        Set piPreviewPanel to oPreviewPanel
        Set piPreviewObject to (oPreview(oPreviewPanel))
        Set pbIncrementalPreview to True
        
        // If you want Drilldown's in your Report uncomment the next two Lines. The piDrilldownDatabaseFiltering is used to
        // filter the Databases that are available in Drilldown-Reports
        //Set pbUseDrilldown to True
        //Set piDrilldownDatabaseFiltering to LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ALL_TABLES        
        
        // Support the Designer Preview based on real data
        Set pbDesignerPreview to True
        Set piDesignerPreviewStartMessage to msg_StartReport
        
        // For augmentation. In DefineAllFields and DefineAllVariables you can define additional Fields/Variables (Properties, Databases 
        // not available via DDO's ...) with the DefineLLField or the DefineLLVariable Command
        // Syntax: DefineLLField Database
        //         DefineLLField Database AS AliasnameforListLabel(string)
        //         DefineLLField Database.Field
        //         DefineLLField Property {of object} NameForListLabel(string) ListLabelType(ListLabelConstant i.E. LL_TEXT)
        //         DefineLLField Image.N NameForListLabel(string)        
        Procedure DefineAllFields
            Forward Send DefineAllFields
            //DefineLLField Flexerrs
            //DefineLLField psProperty "MyPropertyField" LL_TEXT
        End_Procedure
        Procedure DefineAllVariables
            Forward Send DefineAllVariables
            //DefineLLVariable Flexerrs
            //DefineLLVariable psProperty "MyPropertyVariable" LL_TEXT
        End_Procedure
        
    End_Object

    Procedure StartReport
    	Integer iRet iDest iProjectType 
        String sFile 
        Handle hoLL hoMain hWnd
        
        Move oListLabelReport to hoLL
        // Find a window as a parent for all List & Label Windows
        Get SuggestedParentWindowHandle of hoLL (Self) to hWnd
        // Get the Project Type selected
        Get piReportProjectType to iProjectType
        // Open Print Job
        Get LLJobOpen of hoLL to iRet
        // Let the user select a Layout
        Get LLSelectFileDlgTitleEx of hoLL hWnd "Select Layout" iProjectType to sFile
        If (trim(sFile)="") Begin
            Get LLJobClose of hoLL to iRet
            Procedure_Return
        End
        // Start the Print
        Get LLPrintWithBoxStart of hoLL iProjectType sFile LL_PRINT_USERSELECT LL_BOXTYPE_EMPTYABORT hWnd "Printing Records" to iRet
        If (iRet<>0) Begin
            Get LLPrintEnd of hoLL to iRet
            Get LLJobClose of hoLL to iRet
            Procedure_Return
        End
        // Let the User select Options
        Get LLPrintOptionsDialog of hoLL hWnd "" to iRet
        If (iRet=LL_ERR_USER_ABORTED) Begin
            Get LLPrintEnd of hoLL to iRet
            Get LLJobClose of hoLL to iRet
            Procedure_Return
        End
        // Remember the selected Destination
    	Get LLPrintGetOption of hoLL LL_PRNOPT_PRINTDLG_DEST to iDest
    	// Print the whole Report
        Get DoPrintList of hoLL to iRet
        // End the Printjob
        Get LLPrintEnd of hoLL to iRet
        // If Preview, display the Preview and let the Class doing some Cleanup
        If (iDest=LL_DESTINATION_PRV) Begin
            Get LLPreviewDisplay of hoLL sFile "" hWnd to iRet
            Get LLPreviewDeleteFiles of hoLL sFile "" to iRet
        End
        // Close the Job
    	Get LLJobClose of hoLL to iRet        
    End_Procedure
    
    Procedure EditLayout
        Integer iRet iProjectType
        String sFile
        Handle hoLL hWnd hoMain
        
        Move oListLabelReport to hoLL
        // Find a window as a parent for all List & Label Windows
        Get SuggestedParentWindowHandle of hoLL (Self) to hWnd
        // Get the Project Type selected
        Get piReportProjectType to iProjectType
        // Open Job
        Get LLJobOpen of hoLL to iRet
        // Let the user select a Layout or create a new one (LL_FILE_ALSONEW)
        Get LLSelectFileDlgTitleEx of hoLL hWnd "Select Layout" (iProjectType ior LL_FILE_ALSONEW) to sFile
        If (trim(sFile)<>"") Begin
            // Start the Designer
            Get LLDefineLayout of hoLL hWnd "Edit Layout" iProjectType sFile to iRet
        End
        // Close the Job
        Get LLJobClose of hoLL to iRet        
    End_Procedure
    
    On_Key Key_Alt+Key_P Send KeyAction of oPrintButton
    On_Key Key_Alt+Key_E Send KeyAction of oLayoutButton
    On_Key Key_Alt+Key_C Send KeyAction of oCancelButton

End_Object

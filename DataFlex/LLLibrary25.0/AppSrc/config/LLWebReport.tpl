Use cWebView.pkg
Use cWebPanel.pkg
Use cWebButton.pkg
Use cWebCombo.pkg
Use cWebIFrame.pkg
Use cListLabel.pkg

Object oLLReportView1 is a cWebView
    
    Set psCaption to "List & Label Reports"
    Set piMinWidth to 800
    Set piColumnCount to 10       
    
    Object oLLReport is a cListLabelReport
        // Uncomment this Line and set the Property to your personal 
        // License Code (perslic.txt located in your List & Label Folder)
        // Set psLicensingInfo to "123456"
        
        // Initialize Settings for Webreporting.
        Procedure DoInitSettings
            String sPath
            // All Preview-Features who need to interact with the Report during the Preview like 
            // Incremental Preview, Drilldown Reporting have to be disabled.
            Set pbIncrementalPreview to False
            Set pbUseDrilldown to False
            Set pbUseExpandableRegions to False
            Set pbDesignerPreview to False
            // Set the Directory containing the Report Projects (psDefaultLayoutDirectory). 
            // Defaults to Workspace-Home\Report\Layouts
            Move (psHome(phoWorkspace(ghoApplication))) to sPath
            If (Right(sPath,1)<>"\") Move (sPath+"\") to sPath
            Move (sPath+"Reports\Layouts") to sPath
            Set psDefaultLayoutDirectory to sPath
        End_Procedure
        Send DoInitSettings
    End_Object

    // This Method exports the Report as a PDF and loads the Result in an cWebIFrame
    Procedure RunReport
        String sUrl sProject
        // Get the selected Project from the Combo-Box
        WebGet psValue of oProjectSelection to sProject
        If (Trim(sProject)="") Procedure_Return
        // Export the Project and deliver the Result as a Temporary Download-URL
        Get ExportReportForWeb of oLLReport sProject to sUrl
        If (sUrl="") Begin
            Send ShowInfoBox "The Report could not be generated"
        End
        Else Begin 
            // Load the PDF-Result in the cWebIFrame
            WebSet psUrl of oReportResult to sUrl
        End
    End_Procedure

    Object oWebPanelTop is a cWebPanel
        Set peRegion to prTop
        
        Set piColumnCount to 10
        
        Object oProjectSelection is a cWebCombo
            Set psLabel to "Report:"
            Set piLabelOffset to 70
            Set piColumnSpan to 5
            // Load all existing List Projects (*.lst) into the Combo
            Procedure OnFill
                String sFile
                Forward Send OnFill
                Direct_Input ("DIR:"+(psDefaultLayoutDirectory(oLLReport)))
                While (not(SeqEof))
                    Readln sFile
                    If ( (Trim(sFile)<>"") and (Left(sFile,1)<>"[") and (Pos(".LST",(Uppercase(sFile)))<>0) ) Begin
                        Send AddComboItem sFile sFile
                    End
                Loop
                Close_Input
            End_Procedure
        End_Object

        Object oRunButton is a cWebButton
            Set psCaption to "Run Report"
            Set piColumnSpan to 2
            Set piColumnIndex to 5
            
            // Start the selected Report
            Procedure OnClick
                Send RunReport
            End_Procedure        
        End_Object        
    End_Object

    Object oWebPanelCenter is a cWebPanel
        Set peRegion to prCenter
        // cWebIFrame used to display the exported PDF Report.
        Object oReportResult is a cWebIFrame
           Set pbFillHeight to True
           Set pbShowBorder to True
        End_Object
    End_Object
End_Object

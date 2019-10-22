/**********************************************************************
 * Copyright (C) 2014 by Taste IT Consulting ("TIC") -                *
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
    File        : Sports2000ReportsForm
    Purpose     : 
    Syntax      : 
    Description : 
    Author(s)   : Thomas Wurl, Taste IT Consulting
    Created     : January 2016
    Notes       : 
  ----------------------------------------------------------------------*/

USING Progress.Lang.*.
USING Progress.Windows.Form.
/*USING combit.ListLabel22.*.*/
USING combit.ListLabel25.DataProviders.IDataProvider FROM ASSEMBLY.
USING TasteITConsulting.ListLabel25.OpenEdgeDataProvider FROM ASSEMBLY.
USING ListLabelDemo.Sports2000ServiceAdapter FROM PROPATH.
USING ListLabelDemo.Sports2000Service FROM PROPATH.
USING ListLabel.OpenEdgeAdapter.OpenEdgeSchema FROM PROPATH.
USING combit.ListLabel25.LlCore FROM ASSEMBLY.
USING combit.ListLabel25.LlVersion FROM ASSEMBLY.
USING combit.ListLabel25.ListLabel FROM ASSEMBLY.
USING combit.ListLabel25.LlProject FROM ASSEMBLY.
USING combit.ListLabel25.LlAutoMasterMode FROM ASSEMBLY.
USING combit.ListLabel25.ListLabelException FROM ASSEMBLY.
USING combit.ListLabel25.LlLanguage FROM ASSEMBLY.

ROUTINE-LEVEL ON ERROR UNDO, THROW.

CLASS ListLabelDemo.Sports2000DemoForm INHERITS Form: 
	
    DEFINE PRIVATE VARIABLE DataMember AS System.Windows.Forms.ComboBox NO-UNDO.
    DEFINE PRIVATE VARIABLE groupBox2 AS System.Windows.Forms.GroupBox NO-UNDO.
	
    DEFINE PRIVATE VARIABLE btnAbout AS System.Windows.Forms.Button NO-UNDO.
    DEFINE PRIVATE VARIABLE btnDesigner AS System.Windows.Forms.Button NO-UNDO.
    DEFINE PRIVATE VARIABLE btnPrint AS System.Windows.Forms.Button NO-UNDO.
	DEFINE PRIVATE VARIABLE components AS System.ComponentModel.IContainer NO-UNDO.
    DEFINE PRIVATE VARIABLE groupBox1 AS System.Windows.Forms.GroupBox NO-UNDO.
    DEFINE PRIVATE VARIABLE groupBox3 AS System.Windows.Forms.GroupBox NO-UNDO.
    DEFINE PRIVATE VARIABLE MasterAsFields AS System.Windows.Forms.RadioButton NO-UNDO.
    DEFINE PRIVATE VARIABLE MasterAsVariables AS System.Windows.Forms.RadioButton NO-UNDO.
    DEFINE PRIVATE VARIABLE txtMaxRows AS System.Windows.Forms.MaskedTextBox NO-UNDO.
    DEFINE PRIVATE VARIABLE TypeLabel AS System.Windows.Forms.RadioButton NO-UNDO.
    DEFINE PRIVATE VARIABLE TypeCard AS System.Windows.Forms.RadioButton NO-UNDO.
    DEFINE PRIVATE VARIABLE TypeList AS System.Windows.Forms.RadioButton NO-UNDO.

    DEFINE PRIVATE VARIABLE moServiceAdapter AS Sports2000ServiceAdapter NO-UNDO.
    DEFINE PRIVATE VARIABLE useAppserver AS System.Windows.Forms.CheckBox NO-UNDO.
    DEFINE PRIVATE VARIABLE mcServiceName AS CHARACTER NO-UNDO INIT "ListLabelDemo.Sports2000Service".
    DEFINE PRIVATE VARIABLE useInvariantCulture AS System.Windows.Forms.CheckBox NO-UNDO.
    DEFINE PRIVATE VARIABLE useMaxRows AS System.Windows.Forms.CheckBox NO-UNDO.
    DEFINE PRIVATE VARIABLE ViewName AS System.Windows.Forms.ComboBox NO-UNDO.
    DEFINE PRIVATE VARIABLE moProvider AS OpenEdgeDataProvider NO-UNDO.

	CONSTRUCTOR PUBLIC Sports2000DemoForm (  ):
		
		DEFINE VARIABLE iView     AS INTEGER   NO-UNDO.
		DEFINE VARIABLE cViews    AS LONGCHAR  NO-UNDO.
		DEFINE VARIABLE lcSchema  AS LONGCHAR  NO-UNDO.
        DEFINE VARIABLE oSchema   AS OpenEdgeSchema NO-UNDO.
        
        SUPER().
        
        InitializeComponent().

        IF NOT CONNECTED ("sports2000") THEN 
        DO:
            useAppserver:CHECKED = TRUE.
            useAppserver:ENABLED = FALSE.
        END.    

        /* Default */
        TypeList:CHECKED = TRUE.

        /* Fill with tables from service */
        DataMember:Items:Add("").
        
        /* Ask the provider for the registered tables */
        moProvider = NEW OpenEdgeDataProvider().
        moProvider:ServiceName         = mcServiceName.
        moProvider:UseInvariantCulture = useInvariantCulture:CHECKED.
  
        addServiceParameter(moProvider).
         
        IF NOT VALID-OBJECT (moServiceAdapter) THEN 
        DO:
           moServiceAdapter = NEW Sports2000ServiceAdapter(useAppserver:Checked).
        END.    
        moProvider:ServiceAdapter = moServiceAdapter.
        moProvider:Initialize().
        cViews  = moProvider:DefinedViews.

        ViewName:Items:Add("").
        DO iView = 1 TO NUM-ENTRIES(cViews):
            ViewName:Items:Add(ENTRY(iView,cViews)).
        END.

        initDataMember ("").

        CATCH e AS Progress.Lang.Error:
            UNDO, THROW e.
        END CATCH.

	END CONSTRUCTOR.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID DataMember_SelectedIndexChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
		
		RETURN.

	END METHOD.

    /*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID initDataMember( pcViewName AS CHARACTER ):

        DEFINE VARIABLE iTable    AS INTEGER   NO-UNDO.
        DEFINE VARIABLE iView     AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cTables   AS LONGCHAR  NO-UNDO.
		
		DataMember:SelectedItem = -1.
		DataMember:TEXT = "".
		DataMember:Items:Clear().
		DataMember:Items:Add("").
		
		IF pcViewName = "" THEN 
		   cTables = moProvider:DefinedTables.
		ELSE 
		   cTables = moProvider:ViewTables(pcViewName).

        IF cTables > "" THEN        
        DO iTable = 1 TO NUM-ENTRIES(cTables):
            DataMember:Items:Add(ENTRY(iTable,cTables)).
        END.
		
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID About( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
				
        DEFINE VARIABLE cLLVersion AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cBit       AS CHARACTER NO-UNDO INIT "32".
        
        IF "{&PROCESS-ARCHITECTURE}" = "64" THEN 
            cBit = "64".

        cLLVersion = SUBSTITUTE("&1.&2",LlCore:LlGetVersion(LlVersion:Major), LlCore:LlGetVersion(LlVersion:Minor)).			
				
        MESSAGE "OpenEdge DataProviderPro.Net for List & Label Sample" SKIP
                "OpenEdge Version:" PROVERSION + getPatchLevel() SUBSTITUTE("(&1bit)",cBit) SKIP 
                "List & Label Version:" cLLVersion
                SKIP(1)
                "Proudly presented by:" SKIP
                "Thomas Wurl" SKIP
                "Taste IT Consulting" SKIP
                "www.taste-consulting.de" VIEW-AS ALERT-BOX INFORMATION TITLE "About".
		
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID btnDesigner_Click( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
	    
        LLAction("Design").
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID btnPrint_Click( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
	
	    LLAction("Print").
		RETURN.

	END METHOD.



	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	METHOD PRIVATE CHARACTER getPatchLevel(  ):
	    
    DEFINE VARIABLE i          AS INTEGER   NO-UNDO.
    DEFINE VARIABLE dlcValue   AS CHARACTER NO-UNDO. /* DLC */
    DEFINE VARIABLE inp        AS CHARACTER NO-UNDO. /* hold 1st line of version file */
    DEFINE VARIABLE patchLevel AS CHARACTER NO-UNDO.
  
    IF OPSYS BEGINS "Win":U THEN /* Get DLC from Registry */
        GET-KEY-VALUE SECTION "Startup":U KEY "DLC":U VALUE dlcValue.

    IF (dlcValue = "" OR dlcValue = ?) THEN 
    DO:
        ASSIGN dlcValue = OS-GETENV("DLC":U). /* Get DLC from environment */
        IF (dlcValue = "" OR dlcValue = ?) THEN 
        DO: /* Still nothing? */
            ASSIGN patchLevel = "".
            RETURN "".
        END.
    END.
    FILE-INFO:FILE-NAME = dlcValue + "/version":U.
    IF FILE-INFO:FULL-PATHNAME NE ? THEN DO: /* Read the version file */
        INPUT FROM VALUE(FILE-INFO:FULL-PATHNAME).
        IMPORT UNFORMATTED inp. /* Get the first line */
        INPUT CLOSE.
        /* 
         * As of version 9.1D just append everything from the version file
         * after the version from PROVERSION property
         */
        LEVEL:
        DO i = 2 TO NUM-ENTRIES(inp," ":U):
          IF ENTRY(i,inp," ") BEGINS PROVERSION THEN DO:
            ASSIGN patchLevel = REPLACE(ENTRY(i,inp," "),PROVERSION,"").
            LEAVE LEVEL.
          END.
        END.
    END.
    
    RETURN patchLevel.
    
	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose: Add some service Parameter to see how values reach the service
	 Notes:
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID addServiceParameter( poProvider AS OpenEdgeDataProvider  ):
		/*
		DEFINE VARIABLE i64 AS INT64 NO-UNDO INIT 4711.
        DEFINE VARIABLE d   AS DATE  NO-UNDO INIT "12/24/2016".
        DEFINE VARIABLE dt  AS DATETIME-TZ INIT NOW.

        poProvider:SetServiceParameter("Character","Hello World!").
        poProvider:SetServiceParameter("Integer",123).
        poProvider:SetServiceParameter("Int64",i64).
        poProvider:SetServiceParameter("PI",3.141592).
        poProvider:SetServiceParameter("Is this true?", TRUE ).
        poProvider:SetServiceParameter("Today", TODAY  ).
        poProvider:SetServiceParameter("Now", NOW ).
        poProvider:SetServiceParameter("Now-TZ", NOW ).
        poProvider:SetServiceParameter("Next Christmas", d ).
		*/
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	METHOD PUBLIC VOID LLAction( pcAction AS CHARACTER):
	    
        DEFINE VARIABLE cLayout       AS CHARACTER NO-UNDO.
        DEFINE VARIABLE lDesign       AS LOGICAL   NO-UNDO.
        DEFINE VARIABLE cDir          AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cSubDir       AS CHARACTER NO-UNDO.
        DEFINE VARIABLE cExt          AS CHARACTER NO-UNDO.
        DEFINE VARIABLE iFilter       AS INTEGER   NO-UNDO.
        DEFINE VARIABLE cDataMember   AS CHARACTER NO-UNDO.
        
        DEFINE VARIABLE oProvider     AS OpenEdgeDataProvider   NO-UNDO.
        
        DEFINE VARIABLE oLL AS ListLabel NO-UNDO.
 
        CASE pcAction:
            WHEN "Design" THEN lDesign = TRUE.
            WHEN "Print"  THEN lDesign = FALSE.
            OTHERWISE DO:
                MESSAGE "Unknown Action:" pcAction
                VIEW-AS ALERT-BOX ERROR.
                RETURN.
            END.    
        END CASE.
        
        IF TypeList:CHECKED THEN
        DO:
           IF MasterAsFields:CHECKED THEN     
           DO:   
               cDataMember = DataMember:TEXT.
               IF cDataMember > "" THEN 
                  ASSIGN cSubDir = "\ListMasterAsVariables\" + cDataMember.
               ELSE 
                  ASSIGN cSubDir = "\ListMasterAsFields".
               /*       cDataMember = "".*/
           END.              
           ELSE DO:
                  cDataMember = DataMember:TEXT.
                  IF cDataMember = "" THEN 
                  DO:
                        MESSAGE "Please select the data member to be registered as variables."
                        VIEW-AS ALERT-BOX INFORMATION.
                        RETURN.
                  END.    
                  ASSIGN cSubDir = "\ListMasterAsVariables\" + cDataMember.
           END.
        END.          
        ELSE IF TypeCard:CHECKED THEN
        DO:
           cDataMember = DataMember:TEXT.
           IF cDataMember = "" THEN 
           DO:
               MESSAGE "Please select the data member for your 'Card' project."
               VIEW-AS ALERT-BOX INFORMATION.
               RETURN.
           END.    
           ASSIGN cSubDir = "\Card\" + cDataMember.
        END.          
        ELSE IF TypeLabel:CHECKED THEN
        DO:
           cDataMember = DataMember:TEXT.
           IF cDataMember = "" THEN 
           DO:
               MESSAGE "Please select the data member for your 'Label' project."
               VIEW-AS ALERT-BOX INFORMATION.
               RETURN.
           END.    
           ASSIGN cSubDir = "\Label\" + cDataMember.
        END.          

        cDir = "ListLabelDemo\Layouts".
        FILE-INFO:FILE-NAME = cDir.
        cDir = FILE-INFO:FULL-PATHNAME.
        IF FILE-INFO:FULL-PATHNAME = ? THEN 
        DO:
            MESSAGE "Sub directory structure:" cDir " not found!"
            VIEW-AS ALERT-BOX ERROR.
            RETURN.
        END.
        
        oProvider = NEW OpenEdgeDataProvider().
        oProvider:ServiceName = mcServiceName.
        oProvider:UseInvariantCulture = useInvariantCulture:CHECKED.
        IF ViewName:TEXT > "" THEN 
           oProvider:ViewName = ViewName:TEXT.
        addServiceParameter(oProvider).

        IF NOT VALID-OBJECT (moServiceAdapter) THEN 
        DO:
           moServiceAdapter = NEW Sports2000ServiceAdapter(useAppserver:Checked).
        END.    
        
        oProvider:ServiceAdapter = moServiceAdapter.
        oProvider:DebugMode = TRUE.
        oProvider:Initialize().

        oLL = NEW ListLabel().
        /*oLL:Language = LlLanguage:English.*/
        oLL:ForceSingleThread = TRUE. /* :-( */
        oLL:DataSource = oProvider. 
        
        cDir = cDir + cSubDir.
        ensureDirectory(cDir).
        FILE-INFO:FILE-NAME = cDir.
        cDir = FILE-INFO:FULL-PATHNAME.
        IF cDir <> ? THEN 
          cDir = FILE-INFO:FULL-PATHNAME.
                
        IF TypeCard:CHECKED THEN
            ASSIGN oLL:AutoProjectType = LlProject:Card
                   oLL:AutoMasterMode  = LlAutoMasterMode:None
                   cExt                = "crd".
        ELSE IF TypeLabel:CHECKED THEN
            ASSIGN oLL:AutoProjectType = LlProject:Label
                   oLL:AutoMasterMode  = LlAutoMasterMode:None
                   cExt                = "lbl".
        ELSE IF TypeList:CHECKED THEN 
            ASSIGN oLL:AutoProjectType = LlProject:List
                   oLL:AutoMasterMode  = (IF MasterAsVariables:CHECKED THEN LlAutoMasterMode:AsVariables ELSE LlAutoMasterMode:AsFields)
                   cExt                = "lst".

        IF cDataMember > "" THEN
            oLL:DataMember = cDataMember.                              
                              
        IF cDir > "" THEN 
            oLL:AutoProjectFile = SUBSTITUTE("&1\*.&2",cDir,cExt).
        oLL:AutoShowSelectFile = TRUE.
       
        DO ON ERROR UNDO, THROW:
       
            IF lDesign THEN
            DO:
               IF useMaxRows:CHECKED THEN 
                 oProvider:MaxRows = INTEGER(txtMaxRows:Text).
               oLL:Design().
            END.
            ELSE
               oLL:Print().
     		 	
  	        CATCH oLLException AS ListLabelException:
                MESSAGE oLLException:MESSAGE 
                VIEW-AS ALERT-BOX INFORMATION TITLE "List & Label".
            END CATCH.
 	
 		END. 		
 		 		
		RETURN.
		
		FINALLY:
		      IF VALID-OBJECT (oLL) THEN
		      DO:
            	 oLL:dispose().
            	 DELETE OBJECT oLL NO-ERROR.	
              END.
              IF VALID-OBJECT (oProvider) THEN
              DO: 
                 oProvider:Dispose(). /* since LL24 */	 
            	 DELETE OBJECT oProvider NO-ERROR.
              END.	   
        END FINALLY.

	END METHOD.

	METHOD PRIVATE VOID InitializeComponent(  ):
		
        /* NOTE: The following method is automatically generated.
        
        We strongly suggest that the contents of this method only be modified using the
        Visual Designer to avoid any incompatible modifications.
        
        Modifying the contents of this method using a code editor will invalidate any support for this file. */
        @VisualDesigner.FormMember (NeedsInitialize="true").
        DEFINE VARIABLE resources AS Progress.Util.ResourceManager NO-UNDO.
        resources = NEW Progress.Util.ResourceManager("ListLabelDemo.Sports2000DemoForm").
        THIS-OBJECT:btnDesigner = NEW System.Windows.Forms.Button().
        THIS-OBJECT:TypeCard = NEW System.Windows.Forms.RadioButton().
        THIS-OBJECT:TypeLabel = NEW System.Windows.Forms.RadioButton().
        THIS-OBJECT:TypeList = NEW System.Windows.Forms.RadioButton().
        THIS-OBJECT:groupBox1 = NEW System.Windows.Forms.GroupBox().
        THIS-OBJECT:DataMember = NEW System.Windows.Forms.ComboBox().
        THIS-OBJECT:btnPrint = NEW System.Windows.Forms.Button().
        THIS-OBJECT:btnAbout = NEW System.Windows.Forms.Button().
        THIS-OBJECT:groupBox2 = NEW System.Windows.Forms.GroupBox().
        THIS-OBJECT:MasterAsFields = NEW System.Windows.Forms.RadioButton().
        THIS-OBJECT:MasterAsVariables = NEW System.Windows.Forms.RadioButton().
        THIS-OBJECT:useAppserver = NEW System.Windows.Forms.CheckBox().
        THIS-OBJECT:useInvariantCulture = NEW System.Windows.Forms.CheckBox().
        THIS-OBJECT:useMaxRows = NEW System.Windows.Forms.CheckBox().
        THIS-OBJECT:txtMaxRows = NEW System.Windows.Forms.MaskedTextBox().
        THIS-OBJECT:ViewName = NEW System.Windows.Forms.ComboBox().
        THIS-OBJECT:groupBox3 = NEW System.Windows.Forms.GroupBox().
        THIS-OBJECT:groupBox1:SuspendLayout().
        THIS-OBJECT:groupBox2:SuspendLayout().
        THIS-OBJECT:groupBox3:SuspendLayout().
        THIS-OBJECT:SuspendLayout().
        /*  */
        /* btnDesigner */
        /*  */
        THIS-OBJECT:btnDesigner:Location = NEW System.Drawing.Point(34, 298).
        THIS-OBJECT:btnDesigner:Name = "btnDesigner".
        THIS-OBJECT:btnDesigner:Size = NEW System.Drawing.Size(75, 23).
        THIS-OBJECT:btnDesigner:TabIndex = 0.
        THIS-OBJECT:btnDesigner:Text = "Design".
        THIS-OBJECT:btnDesigner:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:btnDesigner:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:btnDesigner:Click:Subscribe(THIS-OBJECT:btnDesigner_Click).
        /*  */
        /* TypeCard */
        /*  */
        THIS-OBJECT:TypeCard:Location = NEW System.Drawing.Point(13, 19).
        THIS-OBJECT:TypeCard:Name = "TypeCard".
        THIS-OBJECT:TypeCard:Size = NEW System.Drawing.Size(84, 24).
        THIS-OBJECT:TypeCard:TabIndex = 1.
        THIS-OBJECT:TypeCard:Text = "Card".
        THIS-OBJECT:TypeCard:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:TypeCard:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:TypeCard:CheckedChanged:Subscribe(THIS-OBJECT:TypeCard_CheckedChanged).
        /*  */
        /* TypeLabel */
        /*  */
        THIS-OBJECT:TypeLabel:Location = NEW System.Drawing.Point(121, 19).
        THIS-OBJECT:TypeLabel:Name = "TypeLabel".
        THIS-OBJECT:TypeLabel:Size = NEW System.Drawing.Size(59, 24).
        THIS-OBJECT:TypeLabel:TabIndex = 2.
        THIS-OBJECT:TypeLabel:Text = "Label".
        THIS-OBJECT:TypeLabel:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:TypeLabel:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:TypeLabel:CheckedChanged:Subscribe(THIS-OBJECT:TypeLabel_CheckedChanged).
        /*  */
        /* TypeList */
        /*  */
        THIS-OBJECT:TypeList:Location = NEW System.Drawing.Point(209, 19).
        THIS-OBJECT:TypeList:Name = "TypeList".
        THIS-OBJECT:TypeList:Size = NEW System.Drawing.Size(52, 24).
        THIS-OBJECT:TypeList:TabIndex = 3.
        THIS-OBJECT:TypeList:Text = "List".
        THIS-OBJECT:TypeList:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:TypeList:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:TypeList:CheckedChanged:Subscribe(THIS-OBJECT:TypeList_CheckedChanged).
        /*  */
        /* groupBox1 */
        /*  */
        THIS-OBJECT:groupBox1:Controls:Add(THIS-OBJECT:TypeList).
        THIS-OBJECT:groupBox1:Controls:Add(THIS-OBJECT:TypeLabel).
        THIS-OBJECT:groupBox1:Controls:Add(THIS-OBJECT:TypeCard).
        THIS-OBJECT:groupBox1:Location = NEW System.Drawing.Point(34, 12).
        THIS-OBJECT:groupBox1:Name = "groupBox1".
        THIS-OBJECT:groupBox1:Size = NEW System.Drawing.Size(304, 52).
        THIS-OBJECT:groupBox1:TabIndex = 5.
        THIS-OBJECT:groupBox1:TabStop = FALSE.
        THIS-OBJECT:groupBox1:Text = "Project Type".
        THIS-OBJECT:groupBox1:UseCompatibleTextRendering = TRUE.
        /*  */
        /* DataMember */
        /*  */
        THIS-OBJECT:DataMember:DropDownHeight = 212.
        THIS-OBJECT:DataMember:DropDownStyle = System.Windows.Forms.ComboBoxStyle:DropDownList.
        THIS-OBJECT:DataMember:FormattingEnabled = TRUE.
        THIS-OBJECT:DataMember:IntegralHeight = FALSE.
        THIS-OBJECT:DataMember:Location = NEW System.Drawing.Point(13, 53).
        THIS-OBJECT:DataMember:Name = "DataMember".
        THIS-OBJECT:DataMember:Size = NEW System.Drawing.Size(274, 21).
        THIS-OBJECT:DataMember:TabIndex = 5.
        THIS-OBJECT:DataMember:SelectedIndexChanged:Subscribe(THIS-OBJECT:DataMember_SelectedIndexChanged).
        /*  */
        /* btnPrint */
        /*  */
        THIS-OBJECT:btnPrint:Location = NEW System.Drawing.Point(115, 298).
        THIS-OBJECT:btnPrint:Name = "btnPrint".
        THIS-OBJECT:btnPrint:Size = NEW System.Drawing.Size(75, 23).
        THIS-OBJECT:btnPrint:TabIndex = 6.
        THIS-OBJECT:btnPrint:Text = "Print".
        THIS-OBJECT:btnPrint:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:btnPrint:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:btnPrint:Click:Subscribe(THIS-OBJECT:btnPrint_Click).
        /*  */
        /* btnAbout */
        /*  */
        THIS-OBJECT:btnAbout:Location = NEW System.Drawing.Point(263, 298).
        THIS-OBJECT:btnAbout:Name = "btnAbout".
        THIS-OBJECT:btnAbout:Size = NEW System.Drawing.Size(75, 23).
        THIS-OBJECT:btnAbout:TabIndex = 7.
        THIS-OBJECT:btnAbout:Text = "About".
        THIS-OBJECT:btnAbout:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:btnAbout:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:btnAbout:Click:Subscribe(THIS-OBJECT:About).
        /*  */
        /* groupBox2 */
        /*  */
        THIS-OBJECT:groupBox2:Controls:Add(THIS-OBJECT:MasterAsFields).
        THIS-OBJECT:groupBox2:Controls:Add(THIS-OBJECT:MasterAsVariables).
        THIS-OBJECT:groupBox2:Controls:Add(THIS-OBJECT:DataMember).
        THIS-OBJECT:groupBox2:Location = NEW System.Drawing.Point(34, 132).
        THIS-OBJECT:groupBox2:Name = "groupBox2".
        THIS-OBJECT:groupBox2:Size = NEW System.Drawing.Size(304, 90).
        THIS-OBJECT:groupBox2:TabIndex = 8.
        THIS-OBJECT:groupBox2:TabStop = FALSE.
        THIS-OBJECT:groupBox2:Text = "Master Table".
        THIS-OBJECT:groupBox2:UseCompatibleTextRendering = TRUE.
        /*  */
        /* MasterAsFields */
        /*  */
        THIS-OBJECT:MasterAsFields:Location = NEW System.Drawing.Point(133, 22).
        THIS-OBJECT:MasterAsFields:Name = "MasterAsFields".
        THIS-OBJECT:MasterAsFields:Size = NEW System.Drawing.Size(62, 24).
        THIS-OBJECT:MasterAsFields:TabIndex = 7.
        THIS-OBJECT:MasterAsFields:TabStop = TRUE.
        THIS-OBJECT:MasterAsFields:Text = "Fields".
        THIS-OBJECT:MasterAsFields:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:MasterAsFields:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:MasterAsFields:CheckedChanged:Subscribe(THIS-OBJECT:MasterAsFields_CheckedChanged).
        /*  */
        /* MasterAsVariables */
        /*  */
        THIS-OBJECT:MasterAsVariables:Location = NEW System.Drawing.Point(13, 23).
        THIS-OBJECT:MasterAsVariables:Name = "MasterAsVariables".
        THIS-OBJECT:MasterAsVariables:Size = NEW System.Drawing.Size(104, 24).
        THIS-OBJECT:MasterAsVariables:TabIndex = 6.
        THIS-OBJECT:MasterAsVariables:TabStop = TRUE.
        THIS-OBJECT:MasterAsVariables:Text = "Variables".
        THIS-OBJECT:MasterAsVariables:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:MasterAsVariables:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:MasterAsVariables:CheckedChanged:Subscribe(THIS-OBJECT:MasterAsVariables_CheckedChanged).
        /*  */
        /* useAppserver */
        /*  */
        THIS-OBJECT:useAppserver:Location = NEW System.Drawing.Point(47, 228).
        THIS-OBJECT:useAppserver:Name = "useAppserver".
        THIS-OBJECT:useAppserver:Size = NEW System.Drawing.Size(154, 24).
        THIS-OBJECT:useAppserver:TabIndex = 11.
        THIS-OBJECT:useAppserver:Text = "Use Appserver".
        THIS-OBJECT:useAppserver:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:useAppserver:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:useAppserver:CheckedChanged:Subscribe(THIS-OBJECT:useAppserver_CheckedChanged).
        /*  */
        /* useInvariantCulture */
        /*  */
        THIS-OBJECT:useInvariantCulture:Location = NEW System.Drawing.Point(194, 228).
        THIS-OBJECT:useInvariantCulture:Name = "useInvariantCulture".
        THIS-OBJECT:useInvariantCulture:Size = NEW System.Drawing.Size(164, 24).
        THIS-OBJECT:useInvariantCulture:TabIndex = 12.
        THIS-OBJECT:useInvariantCulture:Text = "Use Invariant Culture".
        THIS-OBJECT:useInvariantCulture:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:useInvariantCulture:UseVisualStyleBackColor = TRUE.
        /*  */
        /* useMaxRows */
        /*  */
        THIS-OBJECT:useMaxRows:Checked = TRUE.
        THIS-OBJECT:useMaxRows:CheckState = System.Windows.Forms.CheckState:Checked.
        THIS-OBJECT:useMaxRows:Location = NEW System.Drawing.Point(47, 256).
        THIS-OBJECT:useMaxRows:Name = "useMaxRows".
        THIS-OBJECT:useMaxRows:Size = NEW System.Drawing.Size(222, 36).
        THIS-OBJECT:useMaxRows:TabIndex = 13.
        THIS-OBJECT:useMaxRows:Text = "Limit Designer Queries to MAX-ROWS:".
        THIS-OBJECT:useMaxRows:UseCompatibleTextRendering = TRUE.
        THIS-OBJECT:useMaxRows:UseVisualStyleBackColor = TRUE.
        THIS-OBJECT:useMaxRows:CheckedChanged:Subscribe(THIS-OBJECT:useMaxRows_CheckedChanged).
        /*  */
        /* txtMaxRows */
        /*  */
        THIS-OBJECT:txtMaxRows:Location = NEW System.Drawing.Point(275, 258).
        THIS-OBJECT:txtMaxRows:Mask = "999".
        THIS-OBJECT:txtMaxRows:Name = "txtMaxRows".
        THIS-OBJECT:txtMaxRows:PromptChar = ' '.
        THIS-OBJECT:txtMaxRows:Size = NEW System.Drawing.Size(63, 20).
        THIS-OBJECT:txtMaxRows:TabIndex = 14.
        THIS-OBJECT:txtMaxRows:Text = "50".
        THIS-OBJECT:txtMaxRows:MaskInputRejected:Subscribe(THIS-OBJECT:txtMaxRows_MaskInputRejected).
        /*  */
        /* ViewName */
        /*  */
        THIS-OBJECT:ViewName:DropDownStyle = System.Windows.Forms.ComboBoxStyle:DropDownList.
        THIS-OBJECT:ViewName:FormattingEnabled = TRUE.
        THIS-OBJECT:ViewName:Location = NEW System.Drawing.Point(13, 19).
        THIS-OBJECT:ViewName:Name = "ViewName".
        THIS-OBJECT:ViewName:Size = NEW System.Drawing.Size(274, 21).
        THIS-OBJECT:ViewName:TabIndex = 15.
        THIS-OBJECT:ViewName:SelectedIndexChanged:Subscribe(THIS-OBJECT:ViewName_SelectedIndexChanged).
        /*  */
        /* groupBox3 */
        /*  */
        THIS-OBJECT:groupBox3:Controls:Add(THIS-OBJECT:ViewName).
        THIS-OBJECT:groupBox3:Location = NEW System.Drawing.Point(34, 70).
        THIS-OBJECT:groupBox3:Name = "groupBox3".
        THIS-OBJECT:groupBox3:Size = NEW System.Drawing.Size(304, 56).
        THIS-OBJECT:groupBox3:TabIndex = 16.
        THIS-OBJECT:groupBox3:TabStop = FALSE.
        THIS-OBJECT:groupBox3:Text = "View".
        THIS-OBJECT:groupBox3:UseCompatibleTextRendering = TRUE.
        /*  */
        /* Sports2000DemoForm */
        /*  */
        THIS-OBJECT:BackColor = System.Drawing.Color:White.
        THIS-OBJECT:ClientSize = NEW System.Drawing.Size(379, 351).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:groupBox3).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:txtMaxRows).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:useMaxRows).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:useInvariantCulture).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:useAppserver).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:groupBox2).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:btnAbout).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:btnPrint).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:groupBox1).
        THIS-OBJECT:Controls:Add(THIS-OBJECT:btnDesigner).
        THIS-OBJECT:FormBorderStyle = System.Windows.Forms.FormBorderStyle:FixedSingle.
        THIS-OBJECT:Icon = CAST(resources:GetObject("$this.Icon"), System.Drawing.Icon).
        THIS-OBJECT:MaximizeBox = FALSE.
        THIS-OBJECT:Name = "Sports2000DemoForm".
        THIS-OBJECT:SizeGripStyle = System.Windows.Forms.SizeGripStyle:Hide.
        THIS-OBJECT:Text = "Sports 2000 Reporting Playground".
        THIS-OBJECT:Load:Subscribe(THIS-OBJECT:Sports2000ReportsForm_Load).
        THIS-OBJECT:groupBox1:ResumeLayout(FALSE).
        THIS-OBJECT:groupBox2:ResumeLayout(FALSE).
        THIS-OBJECT:groupBox3:ResumeLayout(FALSE).
        THIS-OBJECT:ResumeLayout(FALSE).
        THIS-OBJECT:PerformLayout().
        CATCH e AS Progress.Lang.Error:
            UNDO, THROW e.
        END CATCH.
	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	METHOD LOGICAL ensureDirectory( pcPath AS CHARACTER ):

        DEFINE VARIABLE iErrorCode AS INTEGER NO-UNDO.
        DEFINE VARIABLE lSuccess   AS LOGICAL NO-UNDO INIT FALSE.
        RUN adecomm/_oscpath.p (pcPath, OUTPUT iErrorCode).

        IF iErrorCode = 0 THEN
           lSuccess = TRUE.
        ELSE
           MESSAGE SUBSTITUTE("Could not create directory &1. OS-ERROR: &2",pcPath,iErrorCode)
                VIEW-AS ALERT-BOX ERROR.

        RETURN lSuccess.   /* Function return value. */
	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	METHOD PRIVATE VOID enableOptions(  ):
	    
	    IF TypeList:CHECKED THEN 
	    DO:
	        MasterAsVariables:ENABLED = TRUE.
            MasterAsFields:ENABLED = TRUE.
            DataMember:ENABLED = TRUE  /*MasterAsVariables:CHECKED*/.
	    END.
	    ELSE DO:
            MasterAsVariables:ENABLED = FALSE.
            MasterAsFields:ENABLED    = FALSE.
            DataMember:ENABLED        = TRUE.
		END.
		
		RETURN.

	END METHOD.


	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID MasterAsFields_CheckedChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
        enableOptions().
        RETURN.
	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID MasterAsVariables_CheckedChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
        enableOptions().
        RETURN.
	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID Sports2000ReportsForm_Load( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
		
		RETURN.

	END METHOD.	


	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID txtMaxRows_MaskInputRejected( INPUT sender AS System.Object, INPUT e AS System.Windows.Forms.MaskInputRejectedEventArgs ):
		
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID TypeCard_CheckedChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
	    MasterAsVariables:CHECKED = TRUE.
	    enableOptions().
		RETURN.
	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID TypeLabel_CheckedChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
		MasterAsVariables:CHECKED = TRUE.
		enableOptions().
		RETURN.
	END METHOD.

	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID TypeList_CheckedChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
        IF TypeList:CHECKED THEN MasterAsFields:CHECKED = TRUE.
        enableOptions().
        RETURN.
	END METHOD.


	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID useAppserver_CheckedChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
	
	    IF VALID-OBJECT(moServiceAdapter) THEN 
	       DELETE OBJECT moServiceAdapter NO-ERROR.
		
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID useMaxRows_CheckedChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
		
		RETURN.

	END METHOD.

	/*------------------------------------------------------------------------------
	 Purpose:
	 Notes:
	------------------------------------------------------------------------------*/
	@VisualDesigner.
	METHOD PRIVATE VOID ViewName_SelectedIndexChanged( INPUT sender AS System.Object, INPUT e AS System.EventArgs ):
		
		initDataMember(ViewName:Text).
		
		RETURN.

	END METHOD.
	
	/*------------------------------------------------------------------------------
			Purpose:  																	  
			Notes:  																	  
	------------------------------------------------------------------------------*/

	DESTRUCTOR PUBLIC Sports2000DemoForm ( ):

		IF VALID-OBJECT(components) THEN DO:
			CAST(components, System.IDisposable):Dispose().
		END.

	END DESTRUCTOR.




END CLASS.
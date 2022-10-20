package prtloop;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;


/**
 * <p>Title: List & Label Sample</p>
 * <p>Description: List & Label Sample</p>
 * <p>Copyright: Copyright (C) combit GmbH</p>
 * <p>Company: combit GmbH</p>
 * @author combit GmbH
 * @version 28.0
 */


//Import combit List & Label packages
import combit.*;
import combit.callbacks.*;

//Reading the databasepath from windows registry
import java.util.prefs.*;


//Accessing datasource
import java.sql.*;


public class prtloopApplication extends JFrame
{

private
	
  //Create List & Label object
  CmbtLL28 Ll = null;
  int nLLJob_ = -1;
  long hWnd_ = 0;
  boolean isLlInitialized = false;
  
  private PreviewThread m_previewPrintThread;
  
  
  //Objects for datasource
  String databaseFile; // holds filename for MS Access database-file. Will be set in 'getConnectionString()'
  String connectionString; // holds the whole connection string for 'DriverManager.getConnection()'. Will be set in 'getConnectionString()'
  final String connectionStringPrefix = "jdbc:ucanaccess://";
  boolean isDataConnectionInitialized = false;

  Connection connection = null;
  DatabaseMetaData databaseMetaData = null;
  ResultSet tables = null;

  Statement sqlStatementCustomers = null;
  ResultSet resultSetCustomers = null;
  ResultSetMetaData metaDataCustomers = null;

  Statement sqlStatementOrders = null;
  ResultSet resultSetOrders = null;
  ResultSetMetaData metaDataOrders = null;

public // data access...

//=============================================================================
  final String getConnectionString()
//=============================================================================
  {
    //Reading database-path from windows registry. Hint: Java could only read/write under [HKEY_CURRENT_USER\Software\JavaSoft\Prefs\
    Preferences registry = Preferences.userRoot().node("/combit/cmbtll");
    databaseFile = registry.get("nwindpath", "" /*default-value*/); // key-name have to be in lowercase, because Java is casesensitive!
    
    if(databaseFile.length() <= 0)
      connectionString = "";
    else
      connectionString = connectionStringPrefix + databaseFile;

    return connectionString;
  }

//=============================================================================
  boolean initializeDataConnection()
//=============================================================================
  {
    boolean returnValue = true;

    String connectionString = getConnectionString();
    if(connectionString.length() <= 0)
      returnValue = false;
    else
    {
      try
      {
		// HINT: This sample uses the Open-Source UCanAccess-Driver 'net.ucanaccess.jdbc.UcanaccessDriver' which has to be installed before using this sample. 
    	// You will find more details for using UCanAccess on its site 'https://sourceforge.net/projects/ucanaccess/'. It is required to get access to the used 
    	// Microsoft Access Database Nwind.mdb. If the driver is not available the exception 
    	// "java.lang.ClassNotFoundException: net.ucanaccess.jdbc.UcanaccessDriver" can occur.
    	Class.forName("net.ucanaccess.jdbc.UcanaccessDriver"); // register UCanAccess for DriverManager
        connection = DriverManager.getConnection(connectionString);

        databaseMetaData = connection.getMetaData();
        tables = databaseMetaData.getTables(null, null, null, new String[]{"TABLE"}); // only tables in database are interested

        // all tables in database
        String tableName, queryString;

        // iterate all tables
        while (tables.next())
        {
          tableName = tables.getString("TABLE_NAME");
          if((tableName.compareTo("Customers") == 0) || (tableName.compareTo("Orders") == 0))
          {
            queryString = "SELECT * FROM " + tableName;
            if((tableName.compareTo("Customers") == 0)) // table: Customers
            {
              sqlStatementCustomers = connection.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
              resultSetCustomers = sqlStatementCustomers.executeQuery(queryString);
              resultSetCustomers.first();
              metaDataCustomers = resultSetCustomers.getMetaData();
            }
            if((tableName.compareTo("Orders") == 0)) // table: Orders
            {
              sqlStatementOrders = connection.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
              resultSetOrders = sqlStatementOrders.executeQuery(queryString);
              resultSetOrders.first();
              metaDataOrders = resultSetOrders.getMetaData();
            }
          }
        }
      }
      catch (SQLException exception1)
      {
        exception1.printStackTrace();
        returnValue = false;
      }
      catch (ClassNotFoundException exception2)
      {
        exception2.printStackTrace();
        returnValue = false;
      }
    }

    return returnValue;
  }

//=============================================================================
  boolean uninitializeDataConnection()
//=============================================================================
  {
    boolean returnValue = false;

    try
    {
      if(isDataConnectionInitialized)
      {
        resultSetCustomers.close();
        resultSetOrders.close();
        tables.close();
        connection.close();
        returnValue = true;
      }
    }
    catch (SQLException exception)
    {
      exception.printStackTrace();
    }

    return returnValue;
  }

public // combit List & Label...

//=============================================================================
  boolean initializeListLabel()
//=============================================================================
  {
    boolean returnValue = true;
    
    //Create List & Label object
    Ll = new CmbtLL28();
    
    //Try to get the window handle for List & Label dialogs
    if(hWnd_ == 0)
    	hWnd_ = combit.WinHelper.getWindowHandle(this);
    
    //Set combit List & Label debug mode; pending on CheckBox state
    if (jCheckBoxDebug.isSelected())
      Ll.LlSetDebug(CmbtLL28.LL_DEBUG_CMBTLL);
    else
      Ll.LlSetDebug(0);
    
    //Open combit List & Label job
    if (nLLJob_ <= 0)
    {
      nLLJob_ = Ll.LlJobOpen(CmbtLL28.CMBTLANG_DEFAULT);
      if (nLLJob_ == CmbtLL28.LL_ERR_BAD_JOBHANDLE)
      {
        JOptionPane.showMessageDialog(this, "Job can't be initialized!", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
        returnValue = false;
      }
      else if (nLLJob_ == CmbtLL28.LL_ERR_NO_LANG_DLL)
      {
        JOptionPane.showMessageDialog(this, "Language file not found!\nEnsure that *.lng files can be found in your combit List & Label DLL directory.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
        returnValue = false;
      }

      // register LL-callbacks
      MyLLCallback callback = new MyLLCallback();
      Ll.LlSetOption(nLLJob_, CmbtLL28.LL_OPTION_CALLBACKPARAMETER, nLLJob_);
      Ll.LlSetNotificationCallback(nLLJob_, callback);
      
      //Activate real data preview and export for designer
      Ll.LlSetOption(nLLJob_, CmbtLL28.LL_OPTION_DESIGNERPREVIEWPARAMETER, 1);
      Ll.LlSetOption(nLLJob_, CmbtLL28.LL_OPTION_DESIGNEREXPORTPARAMETER, 1);
      Ll.LlSetOption(nLLJob_, CmbtLL28.LL_OPTION_DESIGNERPRINT_SINGLETHREADED, 1);
    }
    else
      returnValue = false;

    return returnValue;
  }

  private class MyLLCallback implements combit.callbacks.Callback
  {
    public void notify(CallbackInfo value)
   {
		switch (value.callbackID_)
		{
		case CmbtLL28.LL_CMND_VARHELPTEXT: 
		{
			VarHelpTextCallback varHelpText = (VarHelpTextCallback) value;
			if (varHelpText.getDescription().equals("<My Var/Field to change its description>"))
				varHelpText.setDescription("New Var/Field description");
		}
		break;
		
		case CmbtLL28.LL_NTFY_DESIGNERPRINTJOB:
		{
			NtfyDesignerPrintJobCallback ntfyDesignCallBack = (NtfyDesignerPrintJobCallback)value;
			switch (ntfyDesignCallBack.function_)
			{
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_PREVIEW_START:
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_EXPORT_START:
				{
					if (m_previewPrintThread != null)
					{
						m_previewPrintThread.abort();
						m_previewPrintThread = null;
					}

					m_previewPrintThread = new PreviewThread(ntfyDesignCallBack, ntfyDesignCallBack.function_ == CmbtLL28.LL_DESIGNERPRINTCALLBACK_PREVIEW_START);
					m_previewPrintThread.start();
					ntfyDesignCallBack.setCallbackResult(0);
				}
				break;
				
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT:
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT:
				{
				  if (m_previewPrintThread != null)
				  {
					  m_previewPrintThread.abort();
				  }
				  m_previewPrintThread = null;
				}
				break;
	
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE:
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE:
				{
					if (m_previewPrintThread != null)
					{
						m_previewPrintThread.abort();
					}
					m_previewPrintThread = null;
				}
				break;
	
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE:
				case CmbtLL28.LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE:
				{
					EPrintThreadState state = EPrintThreadState.STOPPED;
					if (m_previewPrintThread != null)
					{
						state = m_previewPrintThread.getThreadState();
					}
					ntfyDesignCallBack.setCallbackResult(state.getLlStateValue());
				}
				break;
	
				case CmbtLL28.LL_DESIGNERPRINTTHREAD_STATE_STOPPED:
				{
				}
				break;
			}
		}
		break;
	
		default:
		{
			// System.out.println("unknown/unhandled LL-callback (" + value.callbackID_ + ")");
		}
		break;
	}
   }
  }

//=============================================================================
  boolean uninitializeListLabel()
//=============================================================================
  {
    boolean returnValue = true;
    
    //Release used combit List & Label job
    if (isLlInitialized && nLLJob_ > 0)
    {
      // unregister LL-callback
      Ll.LlSetNotificationCallback(nLLJob_, null);

      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;
      isLlInitialized = false;
    }
    else
      returnValue = false;

    return returnValue;
  }

//=============================================================================
  void passDataStructure(int jobId)
//=============================================================================
  {
    Ll.LlDbAddTable(jobId, "", ""); // remove "old" tables
    Ll.LlDbAddTable(jobId, "Customers", "");
    Ll.LlDbAddTable(jobId, "Orders", "");
    Ll.LlDbAddTableRelation(jobId, "Orders", "Customers", "Customers2Orders", "");
  }

//=============================================================================
  void defineData(int jobId, boolean dummyData /*LL-Designmode ?*/, ResultSet resultSet)
//=============================================================================
  {
    if(!isLlInitialized)
    {
      JOptionPane.showMessageDialog(this, "List & Label could not be initialized.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
      return;
    }

    try
    {
      int colCount = -1;
      String colName, colValue, tableName;

      if(dummyData)
      {
        resultSetCustomers.first();
        resultSetOrders.first();
        Ll.LlDefineFieldStart(jobId);

        // table: Customers
        tableName = "Customers";
        colCount = metaDataCustomers.getColumnCount();
        for (int i = 1; i <= colCount; ++i)
        {
          colName = metaDataCustomers.getColumnName(i);
          colValue = resultSetCustomers.getString(colName);
          if (colValue == null)
            colValue = "(NULL)";

          colName = tableName + "." + colName;
          Ll.LlDefineFieldExt(jobId, colName, colValue, CmbtLL28.LL_TEXT, 0);
        }

        // table: Orders
        tableName = "Orders";
        colCount = metaDataOrders.getColumnCount();
        for (int i = 1; i <= colCount; ++i)
        {
          colName = metaDataOrders.getColumnName(i);
          colValue = resultSetOrders.getString(colName);
          if (colValue == null)
            colValue = "(NULL)";

          colName = tableName + "." + colName;
          Ll.LlDefineFieldExt(jobId, colName, colValue, CmbtLL28.LL_TEXT, 0);
        }
      }
      else
      {
        StringBuffer tableNameBuffer = new StringBuffer("");
        Ll.LlPrintDbGetCurrentTable(jobId, tableNameBuffer, false);
        tableName = tableNameBuffer.toString();

        if (tableName.compareTo("Customers") == 0)
        {
          // table: Customers
          colCount = metaDataCustomers.getColumnCount();
          for (int i = 1; i <= colCount; ++i)
          {
            colName = metaDataCustomers.getColumnName(i);
            colValue = resultSet.getString(colName);
            if (colValue == null)
              colValue = "(NULL)";

            colName = tableName + "." + colName;
            Ll.LlDefineFieldExt(jobId, colName, colValue, CmbtLL28.LL_TEXT, 0);
          }
        }
        else
        {
          if (tableName.compareTo("Orders") == 0)
          {
            // table: Orders
            colCount = metaDataOrders.getColumnCount();
            for (int i = 1; i <= colCount; ++i)
            {
              colName = metaDataOrders.getColumnName(i);
              colValue = resultSet.getString(colName);
              if (colValue == null)
                colValue = "(NULL)";

              colName = tableName + "." + colName;
              Ll.LlDefineFieldExt(jobId, colName, colValue, CmbtLL28.LL_TEXT, 0);
            }
          }
        }
      }
    }
    catch (SQLException exception)
    {
      exception.printStackTrace();
    }
  }

public

  JPanel contentPane;
  JMenuBar jMenuBar1 = new JMenuBar();
  JMenu jMenuFile = new JMenu();
  JMenuItem jMenuFileExit = new JMenuItem();
  JLabel jLabelInfoGerman = new JLabel();
  JMenu jMenuDesign = new JMenu();
  JMenuItem jMenuDesignReport = new JMenuItem();
  JMenu jMenuPrint = new JMenu();
  JMenuItem jMenuPrintReport = new JMenuItem();
  JLabel jLabelInfoEnglish = new JLabel();
  JCheckBox jCheckBoxDebug = new JCheckBox();
  JLabel jLabel1 = new JLabel();
  JLabel jLabel2 = new JLabel();

  // Construct the frame
//=============================================================================
  public prtloopApplication()
//=============================================================================
  {
    enableEvents(AWTEvent.WINDOW_EVENT_MASK);
    try
    {
      jbInit();
    }
    catch(Exception e)
    {
      e.printStackTrace();
    }
  }

  // Component initialization
//=============================================================================
  private void jbInit() throws Exception
//=============================================================================
  {
    contentPane = (JPanel) this.getContentPane();
    contentPane.setLayout(null);
    this.getContentPane().setBackground(Color.white);
    this.setResizable(false);
    this.setSize(new Dimension(380, 181));
    this.setState(Frame.NORMAL);
    this.setTitle("List & Label prtloop sample");
    this.addWindowListener(new prtloopApplication_this_windowAdapter(this));
    jMenuFile.setText("File");
    jMenuFileExit.setActionCommand("Exit");
    jMenuFileExit.setText("Exit");
    jMenuFileExit.addActionListener(new prtloopApplication_jMenuFileExit_ActionAdapter(this));
    jLabelInfoGerman.setBorder(null);
    jLabelInfoGerman.setMaximumSize(new Dimension(317, 16));
    jLabelInfoGerman.setMinimumSize(new Dimension(317, 16));
    jLabelInfoGerman.setPreferredSize(new Dimension(317, 16));
    jLabelInfoGerman.setHorizontalAlignment(SwingConstants.LEFT);
    jLabelInfoGerman.setHorizontalTextPosition(SwingConstants.LEFT);
    jLabelInfoGerman.setText("Dieses Beispiel zeigt den Druck über eine eigene Druckschleife.");
    jLabelInfoGerman.setVerticalAlignment(SwingConstants.TOP);
    jLabelInfoGerman.setVerticalTextPosition(SwingConstants.TOP);
    jLabelInfoGerman.setBounds(new Rectangle(33, 10, 333, 25));
    jMenuDesign.setText("Design");
    jMenuDesignReport.setActionCommand("Report...");
    jMenuDesignReport.setText("Report...");
    jMenuDesignReport.addActionListener(new prtloopApplication_jMenuDesignReport_actionAdapter(this));
    jMenuPrint.setText("Print");
    jMenuPrintReport.setText("Report...");
    jMenuPrintReport.addActionListener(new prtloopApplication_jMenuPrintReport_actionAdapter(this));
    jLabelInfoEnglish.setBorder(null);
    jLabelInfoEnglish.setHorizontalAlignment(SwingConstants.LEFT);
    jLabelInfoEnglish.setHorizontalTextPosition(SwingConstants.LEFT);
    jLabelInfoEnglish.setIconTextGap(4);
    jLabelInfoEnglish.setLabelFor(null);
    jLabelInfoEnglish.setText("This sample shows how to print using a custom print loop.");
    jLabelInfoEnglish.setVerticalAlignment(SwingConstants.TOP);
    jLabelInfoEnglish.setVerticalTextPosition(SwingConstants.TOP);
    jLabelInfoEnglish.setBounds(new Rectangle(33, 38, 332, 25));
    jCheckBoxDebug.setBackground(SystemColor.control);
    jCheckBoxDebug.setBorder(null);
    jCheckBoxDebug.setDebugGraphicsOptions(0);
    jCheckBoxDebug.setToolTipText("");
    jCheckBoxDebug.setContentAreaFilled(false);
    jCheckBoxDebug.setSelectedIcon(null);
    jCheckBoxDebug.setText("Enable Debug Output");
    jCheckBoxDebug.setBounds(new Rectangle(204, 79, 168, 26));
    jCheckBoxDebug.addActionListener(new prtloopApplication_jCheckBoxDebug_actionAdapter(this));
    jLabel1.setFont(new java.awt.Font("Dialog", 1, 12));
    jLabel1.setText("US: ");
    jLabel1.setBounds(new Rectangle(9, 31, 25, 28));
    jLabel2.setBounds(new Rectangle(9, 3, 21, 28));
    jLabel2.setText("D: ");
    jLabel2.setFont(new java.awt.Font("Dialog", 1, 12));
    contentPane.setBackground(SystemColor.control);
    contentPane.setBorder(null);
    jMenuFile.add(jMenuFileExit);
    jMenuBar1.add(jMenuFile);
    jMenuBar1.add(jMenuDesign);
    jMenuBar1.add(jMenuPrint);
    this.setJMenuBar(jMenuBar1);
    jMenuDesign.add(jMenuDesignReport);
    jMenuPrint.add(jMenuPrintReport);
    contentPane.add(jCheckBoxDebug, null);
    contentPane.add(jLabelInfoEnglish, null);
    contentPane.add(jLabelInfoGerman, null);
    contentPane.add(jLabel2, null);
    contentPane.add(jLabel1, null);
  }

  // File | Exit action performed
//=============================================================================
  public void jMenuFileExit_actionPerformed(ActionEvent e)
//=============================================================================
  {
    //Release datasource and List & Label
    uninitializeDataConnection();
    uninitializeListLabel();
    
    //Close application
    System.exit(0);
  }

  // Design | Report action performed
//=============================================================================
  public void jMenuDesignReport_actionPerformed(ActionEvent e)
//=============================================================================
  {
    if(!isLlInitialized)
    {
      JOptionPane.showMessageDialog(this, "combit List & Label could not be successfully initialized. For further information look at method 'initializeListLabel()'.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
      return;
    }

    if(!isDataConnectionInitialized)
    {
      JOptionPane.showMessageDialog(this, "The used UCanAccess-Driver could not be successfully initialized. For further information look at method 'initializeDataConnection()'.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
      return;
    }

    passDataStructure(nLLJob_);
    defineData(nLLJob_, true /*dummyData; LL-Designmode ?*/, null);
    
    //Select project-file via file select dialog
    StringBuffer bufferFilename = new StringBuffer("*.lst");
    if (Ll.LlSelectFileDlgTitleEx(nLLJob_, hWnd_, "", CmbtLL28.LL_PROJECT_LIST | CmbtLL28.LL_FILE_ALSONEW, bufferFilename, 0) < 0)
      return; // user aborted this action
    
    //Call the desinger
    if (Ll.LlDefineLayout(nLLJob_, hWnd_, "Designer", CmbtLL28.LL_PROJECT_LIST, bufferFilename.toString()) < 0)
      JOptionPane.showMessageDialog(null, "Error by calling LlDefineLayout.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
  }

  // Print | Report action performed
//=============================================================================
  void jMenuPrintReport_actionPerformed(ActionEvent e)
//=============================================================================
  {
    if(!isLlInitialized)
    {
      JOptionPane.showMessageDialog(null, "combit List & Label could not be successfully initialized. For further information look at method 'initializeListLabel()'.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
      return;
    }

    if(!isDataConnectionInitialized)
    {
      JOptionPane.showMessageDialog(null, "The used UCanAccess-Driver could not be successfully initialized. For further information look at method 'initializeDataConnection()'.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
      return;
    }
    
    DoPrintReport(nLLJob_, "", false, -1 /* nMaxPages */, "PRV", false /* bWithoutDialog */, hWnd_);
  }

  
 //=============================================================================
  int DoPrintReport(int jobId, String projectToPrint, boolean bPreview, int nMaxPages, String exportFormat, boolean bWithoutDialog, long hWnd)
  {
	  int nResult = 0;
	  
	  if(jobId <= 0)
	  {
		  JOptionPane.showMessageDialog(this, "Job can't be initialized!", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
		  return CmbtLL28.LL_ERR_USER_ABORTED;
	  }
	  
	  if(projectToPrint.isEmpty())
	  {
		//Select project-file via file select dialog
	    StringBuffer bufferFilename = new StringBuffer("*.lst");
	    if(Ll.LlSelectFileDlgTitleEx(jobId, hWnd, "", CmbtLL28.LL_PROJECT_LIST | CmbtLL28.LL_FILE_ALSONEW, bufferFilename, 0) < 0)
	    {
	    	return CmbtLL28.LL_ERR_USER_ABORTED;
	    }
	    else
	    {
	    	projectToPrint = bufferFilename.toString();
	    }
	  }
    
	//Initialize data structure for List & Label
	passDataStructure(jobId);
	defineData(jobId, true /*dummyData; LL-Designmode ?*/, null);
	
	//Start printing
	if (Ll.LlPrintWithBoxStart(jobId, CmbtLL28.LL_PROJECT_LIST, projectToPrint, CmbtLL28.LL_PRINT_EXPORT, CmbtLL28.LL_BOXTYPE_NORMALMETER, hWnd, "Printing...") < 0)
	{
		JOptionPane.showMessageDialog(this, "Error While Printing.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
		return nResult;
	}
	
	if (nMaxPages > 0)
	{
        Ll.LlPrintSetOption(jobId, CmbtLL28.LL_PRNOPT_LASTPAGE, nMaxPages);
    }
	
	if((exportFormat != null) && (!exportFormat.isEmpty()))
		Ll.LlPrintSetOptionString(jobId, CmbtLL28.LL_PRNOPTSTR_EXPORT, exportFormat);
	
	if (
		(bWithoutDialog == false)
		&& (bPreview == false)
		&& (Ll.LlPrintOptionsDialog(jobId, hWnd, "Choose printing options") < 0)
		)
	{
	  JOptionPane.showMessageDialog(this, "Error While Printing.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
	  Ll.LlPrintEnd(jobId, 0);
	  return nResult;
	}
	
    //Initialize first page. A page wrap may occur already caused by objects which are printed before the table
    int nRet = CmbtLL28.LL_WRN_TABLECHANGE;
    while (nRet != 0)
    {
    	nRet = Ll.LlPrint(jobId);
    	while(nRet == CmbtLL28.LL_WRN_REPEAT_DATA)
		  {
			  nRet = Ll.LlPrint(jobId);
		  }
    	if(nRet == CmbtLL28.LL_ERR_USER_ABORTED)
    	{
    		Ll.LlPrintEnd(jobId, 0);
    		return nRet;
    	}
    	
    	if (nMaxPages > 0)
        {
          int printedPages = Ll.LlPrintGetCurrentPage(jobId);
          if (printedPages == nMaxPages)
          {
          	Ll.LlPrintEnd(jobId, 0);
              return CmbtLL28.LL_ERR_USER_ABORTED;
          }
        }
    }
    
    //Print loop. Repeat while there is still data to print
    nRet = CmbtLL28.LL_WRN_TABLECHANGE;
    StringBuffer tableName = new StringBuffer("");
    while (nRet == CmbtLL28.LL_WRN_TABLECHANGE)
    {
      Ll.LlPrintDbGetCurrentTable(jobId, tableName, false);
      if (tableName.toString().compareTo("Customers") == 0)
      {
		  if (nMaxPages > 0)
	      {
	        int printedPages = Ll.LlPrintGetCurrentPage(jobId);
	        if (printedPages == nMaxPages)
	        {
	        	Ll.LlPrintEnd(jobId, 0);
	            return CmbtLL28.LL_ERR_USER_ABORTED;
	        }
	      }
		  
		  nRet = PrintResultSet(jobId, resultSetCustomers);
      }
      else
      {
        if (tableName.toString().compareTo("Orders") == 0)
        {
			if (nMaxPages > 0)
			{
				int printedPages = Ll.LlPrintGetCurrentPage(jobId);
				if (printedPages == nMaxPages)
				{
					Ll.LlPrintEnd(jobId, 0);
					return CmbtLL28.LL_ERR_USER_ABORTED;
				}
			}
			
			nRet = PrintResultSet(jobId, resultSetOrders);
        }
        else
          break;
      }
    }
    
    //Finish printing
    Ll.LlPrintEnd(jobId, 0);
    
    return nResult;

  }
//=============================================================================

  
//=============================================================================
  int PrintResultSet(int jobId, ResultSet resultSet)
  {
    try
    {
      String query;
      StringBuffer tableRelationID = new StringBuffer("");

      resultSet.beforeFirst(); // jump to first record
      while(resultSet.next())
      {
        //Pass data jobId current record
        defineData(jobId, false /*dummyData; LL-Designmode ?*/, resultSet);
        
        //Print table line, check return value and abort printing or wrap pages if necessary
        int nRet = Ll.LlPrintFields(jobId);
        while (nRet == CmbtLL28.LL_WRN_REPEAT_DATA)
        {
          Ll.LlPrint(jobId);
          nRet = Ll.LlPrintFields(jobId);
        }
        
        //Print relational records
        while (nRet == CmbtLL28.LL_WRN_TABLECHANGE)
        {
          Ll.LlPrintDbGetCurrentTableRelation(jobId, tableRelationID);
          if(tableRelationID.toString().compareTo("Customers2Orders") == 0)
          {
            query = "SELECT * FROM Orders WHERE Orders.CustomerID = '" + resultSet.getString("CustomerID") + "'";
            Statement filteredStatement = connection.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_READ_ONLY);
            ResultSet filteredResultSet = filteredStatement.executeQuery(query);
            nRet = PrintResultSet(jobId, filteredResultSet);
          }
          else
            nRet = CmbtLL28.LL_WRN_REPEAT_DATA;
        }
      }
    }
    catch (SQLException exception)
    {
      exception.printStackTrace();
    }
    catch(Exception e)
    {
      e.printStackTrace();
    }
    
    //Finish printing the table, print linked objects
    int nRet = CmbtLL28.LL_WRN_REPEAT_DATA;
    while (nRet == CmbtLL28.LL_WRN_REPEAT_DATA)
      nRet = Ll.LlPrintFieldsEnd(jobId);

    return nRet;

  }
//=============================================================================

// Checkbox Debug action performed
//=============================================================================
  void jCheckBoxDebug_actionPerformed(ActionEvent e)
//=============================================================================
  {
    if(!isLlInitialized)
    {
      JOptionPane.showMessageDialog(null, "combit List & Label could not be successfully initialized. For further information look at method 'initializeListLabel()'.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
      return;
    }
    
    //Set combit List & Label debug mode; pending on CheckBox state
    if (jCheckBoxDebug.isSelected())
      Ll.LlSetDebug(CmbtLL28.LL_DEBUG_CMBTLL);
    else
      Ll.LlSetDebug(0);
  }

//=============================================================================
  void this_windowClosing(WindowEvent e)
//=============================================================================
  {
    //Release datasource and List & Label
    uninitializeDataConnection();
    uninitializeListLabel();
    
    //Close application
    System.exit(0);
  }

//=============================================================================
  void this_windowOpened(WindowEvent e)
//=============================================================================
  {
    isLlInitialized = initializeListLabel();
    if(!isLlInitialized)
      JOptionPane.showMessageDialog(null, "combit List & Label could not be successfully initialized. For further information look at method 'initializeListLabel()'.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);

    isDataConnectionInitialized = initializeDataConnection();
    if(!isDataConnectionInitialized)
      JOptionPane.showMessageDialog(this, "The used UCanAccess-Driver for the datasource could not be initialized. For further information look at method 'initializeDataConnection()'.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
  }
  
  class PreviewThread extends Thread {
    
    // Preview print values
	private NtfyDesignerPrintJobCallback m_callbackData;
	private boolean m_bPreview;
    private int m_printJobId = -1;
    private EPrintThreadState m_jobState;
    
    
  public PreviewThread(NtfyDesignerPrintJobCallback callbackData, boolean bPreview) 
  {
    super("LLDesignerPreviewPrintThread");
    m_callbackData = callbackData;
    m_bPreview = bPreview;
  }
  
  public EPrintThreadState getThreadState()
  {
    return m_jobState;
  }
  
  public void abort()
  {
	if(m_printJobId > 0)
	{
		Ll.LlPrintAbort(m_printJobId);
	}
  }

    @Override
    public void run()
    {
      try
      {
        if (m_printJobId <= 0)
        {
          m_printJobId = Ll.LlJobOpen(CmbtLL28.CMBTLANG_DEFAULT);
          if (m_printJobId == CmbtLL28.LL_ERR_BAD_JOBHANDLE)
          {
            JOptionPane.showMessageDialog(prtloopApplication.this, "Job can't be initialized!", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
            return;
          }
          else if (m_printJobId == CmbtLL28.LL_ERR_NO_LANG_DLL)
          {
            JOptionPane.showMessageDialog(prtloopApplication.this, "Language file not found!\nEnsure that *.lng files can be found in your combit List & Label DLL directory.", "List & Label Sample App", JOptionPane.ERROR_MESSAGE);
            return;
          }
        }
        
        // ThreadState to running
        m_jobState = EPrintThreadState.RUNNING;
        
        // Populate ThreadState to LL
        combit.WinHelper.setEvent(m_printJobId, m_callbackData.hEvent_);
        
        Ll.LlAssociatePreviewControl(m_printJobId, m_callbackData.hWnd_, 1);
        
        Ll.LlSetOptionString(m_printJobId, CmbtLL28.LL_OPTIONSTR_ORIGINALPROJECTFILENAME, m_callbackData.originalProjectFileName_);
        
        DoPrintReport(m_printJobId, m_callbackData.projectFileName_, m_bPreview, m_callbackData.pages_, m_callbackData.pszExportFormat_, m_callbackData.bWithoutDialog_, m_callbackData.hWnd_);
        
      }
      finally
      {
        //ThreadState to stopped
        m_jobState = EPrintThreadState.STOPPED;
        
        //Populate ThreadState to LL
        combit.WinHelper.setEvent(m_printJobId, m_callbackData.hEvent_);
        
        Ll.LlAssociatePreviewControl(m_printJobId, 0, 1);
        
        if (m_printJobId >= 0)
        {
          Ll.LlJobClose(m_printJobId);
          m_printJobId = -1;
        }
      }

    }
}

enum EPrintThreadState {
  INITIALIZING(-1),

  STOPPED(0),

  SUSPENDED(1),

  RUNNING(2);

  EPrintThreadState(int llStateValue) {
    m_llStateValue = llStateValue;
  }

  private int m_llStateValue = -1;

  public int getLlStateValue() {
    return m_llStateValue;
  }
}

  
  
}


//=============================================================================
class prtloopApplication_jMenuFileExit_ActionAdapter
    implements ActionListener
//=============================================================================
{
  prtloopApplication adaptee;

  prtloopApplication_jMenuFileExit_ActionAdapter(prtloopApplication adaptee)
  {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e)
  {
    adaptee.jMenuFileExit_actionPerformed(e);
  }
}


//=============================================================================
class prtloopApplication_jMenuDesignReport_actionAdapter
    implements java.awt.event.ActionListener
//=============================================================================
{
  prtloopApplication adaptee;

  prtloopApplication_jMenuDesignReport_actionAdapter(prtloopApplication adaptee)
  {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e)
  {
    adaptee.jMenuDesignReport_actionPerformed(e);
  }
}


//=============================================================================
class prtloopApplication_jMenuPrintReport_actionAdapter
    implements java.awt.event.ActionListener
//=============================================================================
{
  prtloopApplication adaptee;

  prtloopApplication_jMenuPrintReport_actionAdapter(prtloopApplication adaptee)
  {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e)
  {
    adaptee.jMenuPrintReport_actionPerformed(e);
  }
}


//=============================================================================
class prtloopApplication_jCheckBoxDebug_actionAdapter
    implements java.awt.event.ActionListener
//=============================================================================
{
  prtloopApplication adaptee;

  prtloopApplication_jCheckBoxDebug_actionAdapter(prtloopApplication adaptee)
  {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e)
  {
    adaptee.jCheckBoxDebug_actionPerformed(e);
  }
}


//=============================================================================
class prtloopApplication_this_windowAdapter
    extends java.awt.event.WindowAdapter
//=============================================================================
{
  prtloopApplication adaptee;

  prtloopApplication_this_windowAdapter(prtloopApplication adaptee)
  {
    this.adaptee = adaptee;
  }

  public void windowClosing(WindowEvent e)
  {
    adaptee.this_windowClosing(e);
  }

  public void windowOpened(WindowEvent e)
 {
   adaptee.this_windowOpened(e);
 }
}

package llsample;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * <p>Title: List & Label Sample</p>
 * <p>Description: List & Label Sample</p>
 * <p>Copyright: Copyright (C) combit GmbH</p>
 * <p>Company: combit GmbH</p>
 * @author combit GmbH
 * @version 27.0
 */

import combit.*;
import javax.swing.border.*;

public class CMainFrame
    extends JFrame
{

private static final long serialVersionUID = 7457913868673571688L;

  private

  //Create List & Label object
  CmbtLL27 Ll;
  int nLLJob_;
  long hWnd_;

public

  JPanel contentPane;
  Border border1;
  TitledBorder titledBorder1;
  JCheckBox JCheckBoxLLDebug = new JCheckBox();
  JPanel jPanel1 = new JPanel();
  TitledBorder titledBorder2;
  TitledBorder titledBorder3;
  TitledBorder titledBorder4;
  JButton JButtonLLDesignLabel = new JButton();
  JButton JButtonLLDesignReport = new JButton();
  JPanel jPanel2 = new JPanel();
  JButton JButtonLLPrintReport = new JButton();
  JButton JButtonLLPrintLabel = new JButton();
  Border border2;
  TitledBorder titledBorder5;
  JTextPane JTextPaneLLInfo = new JTextPane();
  JButton JButtonLLCreateDOMList = new JButton();

  //Construct the frame
  public CMainFrame()
  {
    enableEvents(AWTEvent.WINDOW_EVENT_MASK);
    try
    {
      jbInit();
    }
    catch (Exception e)
    {
      e.printStackTrace();
    }
  }

  //Component initialization
  private void jbInit() throws Exception
  {
    nLLJob_ = -1;
    hWnd_ = 0;
    
    contentPane = (JPanel)this.getContentPane();
    titledBorder4 = new TitledBorder(BorderFactory.createEtchedBorder(Color.white, new Color(148, 145, 140)), "Design...");
    border2 = BorderFactory.createLineBorder(SystemColor.controlText, 1);
    titledBorder5 = new TitledBorder(BorderFactory.createEtchedBorder(Color.white, new Color(148, 145, 140)), "Print...");
    JCheckBoxLLDebug.setText("List & Label Debug");
    JCheckBoxLLDebug.setBounds(new Rectangle(20, 266, 248, 27));
    JCheckBoxLLDebug.addItemListener(new CMainFrame_JCheckBoxLLDebug_itemAdapter(this));
    border1 = BorderFactory.createLineBorder(Color.black, 2);
    contentPane.setLayout(null);

    this.setLocale(java.util.Locale.getDefault());
    this.setResizable(false);
    this.setSize(new Dimension(545, 380));
    this.setState(Frame.ICONIFIED);
    this.setTitle("List & Label Sample");
    this.addWindowListener(new CMainFrame_this_windowAdapter(this));
    jPanel1.setBorder(titledBorder4);
    jPanel1.setDebugGraphicsOptions(0);
    jPanel1.setToolTipText("");
    jPanel1.setBounds(new Rectangle(21, 111, 504, 77));
    jPanel1.setLayout(null);
    contentPane.setEnabled(false);
    contentPane.setForeground(Color.black);
    contentPane.setAlignmentX((float) 0.5);
    contentPane.setBorder(BorderFactory.createLineBorder(Color.black));
    contentPane.setDebugGraphicsOptions(0);
    JButtonLLDesignLabel.setBounds(new Rectangle(23, 30, 144, 28));
    JButtonLLDesignLabel.setText("Design Label...");
    JButtonLLDesignLabel.addActionListener(new CMainFrame_JButtonLLDesignLabel_actionAdapter(this));
    JButtonLLDesignReport.setText("Design Report...");
    JButtonLLDesignReport.addActionListener(new CMainFrame_JButtonLLDesignReport_actionAdapter(this));
    JButtonLLDesignReport.setBounds(new Rectangle(180, 30, 144, 28));
    jPanel2.setLayout(null);
    jPanel2.setBounds(new Rectangle(21, 192, 350, 75));
    jPanel2.setToolTipText("");
    jPanel2.setBorder(titledBorder5);
    jPanel2.setDebugGraphicsOptions(0);
    JButtonLLPrintReport.setText("Print Report...");
    JButtonLLPrintReport.addActionListener(new CMainFrame_JButtonLLPrintReport_actionAdapter(this));
    JButtonLLPrintReport.setBounds(new Rectangle(180, 30, 144, 28));
    JButtonLLPrintLabel.setBounds(new Rectangle(23, 30, 144, 28));
    JButtonLLPrintLabel.setText("Print Label...");
    JButtonLLPrintLabel.addActionListener(new CMainFrame_JButtonLLPrintLabel_actionAdapter(this));

    JButtonLLCreateDOMList.setBounds(new Rectangle(342, 30, 144, 28));
    JButtonLLCreateDOMList.setToolTipText("");
    JButtonLLCreateDOMList.setActionCommand("Create DOM-List...");
    JButtonLLCreateDOMList.setSelectedIcon(null);
    JButtonLLCreateDOMList.setText("Create DOM-List...");
    JButtonLLCreateDOMList.addActionListener(new CMainFrame_JButtonLLCreateDOMList_actionAdapter(this));
        JTextPaneLLInfo.setFont(new java.awt.Font("Dialog", Font.BOLD, 11));
        jPanel1.add(JButtonLLDesignLabel, null);
    jPanel1.add(JButtonLLDesignReport, null);
    jPanel1.add(JButtonLLCreateDOMList, null);
    contentPane.add(jPanel2, null);

    jPanel2.add(JButtonLLPrintLabel, null);
    jPanel2.add(JButtonLLPrintReport, null);
    contentPane.add(JCheckBoxLLDebug, null);
    contentPane.add(JTextPaneLLInfo, null);
    contentPane.add(jPanel1, null);

    String sGermanInfo = "D: Dieses Beispiel demonstriert das Designen und Drucken \n von Etiketten und Listen";
    String sUSInfo = "US: This example demonstrates how to design and print \n labels and reports";

    JTextPaneLLInfo.setEnabled(false);
    JTextPaneLLInfo.setOpaque(false);
    JTextPaneLLInfo.setEditable(false);
    JTextPaneLLInfo.setBounds(new Rectangle(24, 25, 344, 82));
    JTextPaneLLInfo.setText(sGermanInfo + "\r\n\r\n" + sUSInfo);
  }

  //Overridden so we can exit when window is closed
  protected void processWindowEvent(WindowEvent e)
  {
    super.processWindowEvent(e);
    if (e.getID() == WindowEvent.WINDOW_CLOSING)
    {
      //Close the List & Label job
      if (nLLJob_ > 0)
      {
        Ll.LlJobClose(nLLJob_);
        nLLJob_ = -1;
      }

      System.exit(0);
    }
  }

  void this_windowClosing(WindowEvent e)
  {
    //Close the List & Label job
    if (nLLJob_ > 0)
    {
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;
    }
  }

  public boolean initializeLL()
  {
    //Create List & Label object
    Ll = new CmbtLL27();
    
    //Try to get the window handle for List & Label dialogs
    if(hWnd_ == 0)
    	hWnd_ = combit.WinHelper.getWindowHandle(this);
    
    //Set debug mode
    if (JCheckBoxLLDebug.isSelected())
    {
      Ll.LlSetDebug(CmbtLL27.LL_DEBUG_CMBTLL);
    }
    else
    {
      Ll.LlSetDebug(0);
    }
    
    //Open List & Label job
    if (nLLJob_ <= 0)
    {
      nLLJob_ = Ll.LlJobOpen(CmbtLL27.CMBTLANG_DEFAULT);
      if (nLLJob_ == CmbtLL27.LL_ERR_BAD_JOBHANDLE)
      {
        JOptionPane.showMessageDialog(this, "Job can't be initialized!",
                                      "List & Label Sample App",
                                      JOptionPane.ERROR_MESSAGE);
        return false;
      }
      else if (nLLJob_ == CmbtLL27.LL_ERR_NO_LANG_DLL)
      {
        JOptionPane.showMessageDialog(this, "Language file not found!\nEnsure that *.lng files can be found in your LuL DLL directory.",
                                      "List & Label Sample App",
                                      JOptionPane.ERROR_MESSAGE);
        return false;
      }
    }
    return true;
  }

//=============================================================================
  void JButtonLLDesignLabel_actionPerformed(ActionEvent e)
//=============================================================================
  {
    StringBuffer bufferFilename = new StringBuffer("*.lbl");
    String sTemp = "";
    
    //Initialize the List & Label job
    if (initializeLL() == false)
    {
      return;
    }
    
    //Select project file via file select dialog
    if (Ll.LlSelectFileDlgTitleEx(
        nLLJob_,
        hWnd_,
        "",
        CmbtLL27.LL_PROJECT_LABEL | CmbtLL27.LL_FILE_ALSONEW,
        bufferFilename,
        0) < 0)
    {
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }
    
    //Clear the variable buffer
    Ll.LlDefineVariableStart(nLLJob_);
    
    //For labels and cards we define the variables virtually
    //Important: Normally you use here your database functions
    for (int i = 1; i < 10; i++)
    {
      sTemp = "Field" + i;
      Ll.LlDefineVariable(nLLJob_, sTemp, sTemp);
    }
    
    //Definition of barcode variables
    //Normally you define only the barcode variables which are really needed
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13", "44|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P2", "44|44444|44444|44",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P5", "44|44444|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN128", "EAN128ean1288",
                    CmbtLL27.LL_BARCODE_EAN128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_CODE128", "Code 128",
                    CmbtLL27.LL_BARCODE_CODE128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_Codabar", "A123456A",
                    CmbtLL27.LL_BARCODE_CODABAR, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCA", "44|44444",
                    CmbtLL27.LL_BARCODE_EAN8, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCE", "4|44444|44444",
                    CmbtLL27.LL_BARCODE_UPCA, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_3OF9", "*TEST*",
                    CmbtLL27.LL_BARCODE_3OF9, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IND", "44444",
                    CmbtLL27.LL_BARCODE_25INDUSTRIAL, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IL", "444444",
                    CmbtLL27.LL_BARCODE_25INTERLEAVED, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25MAT", "44444",
                    CmbtLL27.LL_BARCODE_25MATRIX, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25DL", "44444",
                    CmbtLL27.LL_BARCODE_25DATALOGIC, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET5", "44444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET10", "44444-4444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET12", "44444-444444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_FIM", "A", CmbtLL27.LL_BARCODE_FIM, 0);
    
    //Call the desinger
    if (Ll.LlDefineLayout(nLLJob_, hWnd_, "Designer", CmbtLL27.LL_PROJECT_LABEL,
                          bufferFilename.toString()) < 0)
    {
      JOptionPane.showMessageDialog(null, "Error by calling LlDefineLayout.",
                                    "List & Label Sample App",
                                    JOptionPane.ERROR_MESSAGE);
      	
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }
    
    //Close the List & Label job
    Ll.LlJobClose(nLLJob_);
    nLLJob_ = -1;
  }

//=============================================================================
  void JButtonLLDesignReport_actionPerformed(ActionEvent e)
//=============================================================================
  {
    StringBuffer bufferFilename = new StringBuffer("*.lst");
    String sTemp = "";
    
    //Initialize the List & Label job
    if (initializeLL() == false)
    {
      System.out.println("LLInit failed!");
      return;
    }
    
    //Select project-file via file select dialog
    if (Ll.LlSelectFileDlgTitleEx(
        nLLJob_,
        hWnd_,
        "",
        CmbtLL27.LL_PROJECT_LIST | CmbtLL27.LL_FILE_ALSONEW,
        bufferFilename,
        0) < 0)
    {
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }
    
    //Clear the variable buffer
    Ll.LlDefineVariableStart(nLLJob_);
    
    //For labels and cards we define the variables virtually
    //Important: Normally you use here your database functions
    for (int i = 1; i < 10; i++)
    {
      sTemp = "FixedVariable" + i;
      Ll.LlDefineVariable(
          nLLJob_,
          sTemp,
          sTemp);
    }
    
    //Clear the field buffer
    Ll.LlDefineFieldStart(nLLJob_);
    
    //Define the fields virtually
    //Important: Normally you use here your database functions
    for (int j = 1; j < 10; j++)
    {
      sTemp = "Field" + j;
      Ll.LlDefineField(nLLJob_, sTemp, sTemp);
    }
    
    //Definition of a numerical variable
    //Important: Normally you'd use here your database functions
    Ll.LlDefineFieldExt(nLLJob_, "NumericalField", "1", CmbtLL27.LL_NUMERIC, 0);
    
    //Definition of barcode variables
    //Normally you define only the barcode variables which are really needed
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13", "44|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P2", "44|44444|44444|44",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P5", "44|44444|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN128", "EAN128ean1288",
                    CmbtLL27.LL_BARCODE_EAN128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_CODE128", "Code 128",
                    CmbtLL27.LL_BARCODE_CODE128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_Codabar", "A123456A",
                    CmbtLL27.LL_BARCODE_CODABAR, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCA", "44|44444",
                    CmbtLL27.LL_BARCODE_EAN8, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCE", "4|44444|44444",
                    CmbtLL27.LL_BARCODE_UPCA, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_3OF9", "*TEST*",
                    CmbtLL27.LL_BARCODE_3OF9, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IND", "44444",
                    CmbtLL27.LL_BARCODE_25INDUSTRIAL, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IL", "444444",
                    CmbtLL27.LL_BARCODE_25INTERLEAVED, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25MAT", "44444",
                    CmbtLL27.LL_BARCODE_25MATRIX, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25DL", "44444",
                    CmbtLL27.LL_BARCODE_25DATALOGIC, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET5", "44444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET10", "44444-4444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET12", "44444-444444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_FIM", "A", CmbtLL27.LL_BARCODE_FIM, 0);
    
    //Call the desinger
    if (Ll.LlDefineLayout(nLLJob_, hWnd_, "Designer", CmbtLL27.LL_PROJECT_LIST,
                          bufferFilename.toString()) < 0)
    {
      JOptionPane.showMessageDialog(null, "Error by calling LlDefineLayout.",
                                    "List & Label Sample App",
                                    JOptionPane.ERROR_MESSAGE);

      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }
    
    //Close the List & Label job
    Ll.LlJobClose(nLLJob_);
    nLLJob_ = -1;
  }

//=============================================================================
  void JButtonLLPrintLabel_actionPerformed(ActionEvent e)
//=============================================================================
  {
    StringBuffer bufferFilename = new StringBuffer("*.lbl");
    String sTemp = "", sTemp2 = "", sBoxText = "";
    
    //Initialize the List & Label job
    if (initializeLL() == false)
    {
      return;
    }
    
    //Select project file via file select dialog
    if (Ll.LlSelectFileDlgTitleEx(
        nLLJob_,
        hWnd_,
        "",
        CmbtLL27.LL_PROJECT_LABEL,
        bufferFilename,
        0) < 0)
    {
      JOptionPane.showMessageDialog(
          this,
          "Error While Printing.",
          "List & Label Sample App",
          JOptionPane.ERROR_MESSAGE);
      
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }
    
    //Define variables for load check
    Ll.LlDefineVariableStart(nLLJob_);

    for (int i = 1; i < 10; i++)
    {
      sTemp = "Field" + i;
      Ll.LlDefineVariable(
          nLLJob_,
          sTemp,
          sTemp);
    }
    
    //Definition of barcode variables
    //Normally you define only the barcode variables which are really needed
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13", "44|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P2", "44|44444|44444|44",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P5", " 44|44444|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN128", "EAN128ean1288",
                    CmbtLL27.LL_BARCODE_EAN128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_CODE128", "Code 128",
                    CmbtLL27.LL_BARCODE_CODE128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_Codabar", "A123456A",
                    CmbtLL27.LL_BARCODE_CODABAR, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCA", "44|44444",
                    CmbtLL27.LL_BARCODE_EAN8, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCE", "4|44444|44444",
                    CmbtLL27.LL_BARCODE_UPCA, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_3OF9", "*TEST*",
                    CmbtLL27.LL_BARCODE_3OF9, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IND", "44444",
                    CmbtLL27.LL_BARCODE_25INDUSTRIAL, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IL", "444444",
                    CmbtLL27.LL_BARCODE_25INTERLEAVED, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25MAT", "44444",
                    CmbtLL27.LL_BARCODE_25MATRIX, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25DL", "44444",
                    CmbtLL27.LL_BARCODE_25DATALOGIC, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET5", "44444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET10", "44444-4444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET12", "44444-444444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_FIM", "A", CmbtLL27.LL_BARCODE_FIM, 0);
    
    //Start printing
    if (Ll.LlPrintWithBoxStart(
        nLLJob_,
        CmbtLL27.LL_PROJECT_LABEL,
        bufferFilename.toString(),
        CmbtLL27.LL_PRINT_EXPORT,
        CmbtLL27.LL_BOXTYPE_NORMALMETER,
        hWnd_,
        "Printing...") < 0)
    {
      JOptionPane.showMessageDialog(
          this,
          "Error While Printing.",
          "List & Label Sample App",
          JOptionPane.ERROR_MESSAGE);
      
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }
    
    //Predifined selections for print options dialog
    Ll.LlPrintSetOption(
        nLLJob_,
        CmbtLL27.LL_PRNOPT_COPIES,
        CmbtLL27.LL_COPIES_HIDE);

    Ll.LlPrintSetOption(
        nLLJob_,
        CmbtLL27.LL_PRNOPT_STARTPAGE,
        1);

    Ll.LlPrintSetOption(
        nLLJob_,
        CmbtLL27.LL_PRNOPT_OFFSET,
        0);

    if (Ll.LlPrintOptionsDialog(
        nLLJob_,
        hWnd_,
        "Select printing options") < 0)
    {
      Ll.LlPrintEnd(
          nLLJob_,
          0);
      
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }

    StringBuffer bufferPrinter = new StringBuffer();
    StringBuffer bufferPort = new StringBuffer();
    int nRecCount = 30, nErrorValue = 0, nRecno;
    long nLastPage = 0;

    Ll.LlPrintGetPrinterInfo(
        nLLJob_,
        bufferPrinter,
        bufferPort);

    nLastPage = Ll.LlPrintGetOption(nLLJob_, CmbtLL27.LL_OPTION_LASTPAGE);
    nRecno = 1;
    
    //Definition of barcode variables
    //Normally you define only the barcode variables which are really needed
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13", "44|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P2", "44|44444|44444|44",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN13P5", "44|44444|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_EAN128", "EAN128ean1288",
                    CmbtLL27.LL_BARCODE_EAN128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_CODE128", "Code 128",
                    CmbtLL27.LL_BARCODE_CODE128, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_Codabar", "A123456A",
                    CmbtLL27.LL_BARCODE_CODABAR, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCA", "44|44444",
                    CmbtLL27.LL_BARCODE_EAN8, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_UPCE", "4|44444|44444",
                    CmbtLL27.LL_BARCODE_UPCA, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_3OF9", "*TEST*",
                    CmbtLL27.LL_BARCODE_3OF9, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IND", "44444",
                    CmbtLL27.LL_BARCODE_25INDUSTRIAL, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25IL", "444444",
                    CmbtLL27.LL_BARCODE_25INTERLEAVED, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25MAT", "44444",
                    CmbtLL27.LL_BARCODE_25MATRIX, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_25DL", "44444",
                    CmbtLL27.LL_BARCODE_25DATALOGIC, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET5", "44444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET10", "44444-4444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_POSTNET12", "44444-444444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineVariableExt(nLLJob_, "Barcode_FIM", "A", CmbtLL27.LL_BARCODE_FIM, 0);
    
    //Do printing loop only when there is any data to be printed and no error has occurred
    while (nRecno < nRecCount
           && (Ll.LlPrintGetCurrentPage(nLLJob_) <= nLastPage)
           && nErrorValue == 0)
    {
      for (int i = 1; i < 10; i++)
      {
        sTemp = "Field" + i;
        if (Ll.LlPrintIsVariableUsed(
            nLLJob_,
            sTemp) < 0)
        {
          sTemp2 = "contents of Field" + i + " record " + nRecno;
          Ll.LlDefineVariable(
              nLLJob_,
              sTemp,
              sTemp2);
        }
      }
      
      //Set percentage
      sBoxText = "printing on " + bufferPrinter + " " + bufferPort;
      nErrorValue = Ll.LlPrintSetBoxText(
          nLLJob_,
          sBoxText,
          (100 * nRecno / nRecCount));

      if (nErrorValue == CmbtLL27.LL_ERR_USER_ABORTED)
      {
        Ll.LlPrintEnd(
            nLLJob_,
            0);
        
        //Close the List & Label job
        Ll.LlJobClose(nLLJob_);
        nLLJob_ = -1;

        return;
      }
      
      //Print variables
      nErrorValue = Ll.LlPrint(nLLJob_);
      
      //Goto next record (virtually)
      nRecno++;
    }
    
    //Ends printjob
    Ll.LlPrintEnd(nLLJob_, 0);
    
    //Close the List & Label Job
    Ll.LlJobClose(nLLJob_);
    nLLJob_ = -1;
  }

//=============================================================================
  void JButtonLLPrintReport_actionPerformed(ActionEvent e)
//=============================================================================
  {
    StringBuffer bufferFilename = new StringBuffer("*.lst");
    String sTemp = "", sTemp2 = "", sBoxText = "";
    
    //Initialize the List & Label Job
    if (initializeLL() == false)
    {
      return;
    }
    
    //Select project file via file select dialog
    if (Ll.LlSelectFileDlgTitleEx(
        nLLJob_,
        hWnd_,
        "",
        CmbtLL27.LL_PROJECT_LIST,
        bufferFilename,
        0) < 0)
    {
      JOptionPane.showMessageDialog(
          this,
          "Error While Printing.",
          "List & Label Sample App",
          JOptionPane.ERROR_MESSAGE);
      
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }

    //Define variables for load check
    Ll.LlDefineVariableStart(nLLJob_);

    for (int i = 1; i < 10; i++)
    {
      sTemp = "FixedVariable" + i;
      Ll.LlDefineVariable(
          nLLJob_,
          sTemp,
          sTemp);
    }
    
    //Define the used database fields
    //Important: Normally you'd use here your database functions
    for (int j = 1; j < 10; j++)
    {
      sTemp = "Field" + j;
      Ll.LlDefineField(
          nLLJob_,
          sTemp,
          sTemp);
    }
    
    //Definition of a numerical variable
    //Important: Normally you'd use here your database functions
    Ll.LlDefineFieldExt(
        nLLJob_,
        "NumericalField",
        "1",
        CmbtLL27.LL_NUMERIC,
        0);
    
    //Definition of barcode variables
    //Normally you define only the barcode variables which you do need
    //in this example the barcodes are constant
    //so they will not be defined again in the print loop
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_EAN13", "44|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_EAN13P2", "44|44444|44444|44",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_EAN13P5", "44|44444|44444|44444",
                    CmbtLL27.LL_BARCODE_EAN13, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_EAN128", "EAN128ean128",
                    CmbtLL27.LL_BARCODE_EAN128, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_CODE128", "Code 128",
                    CmbtLL27.LL_BARCODE_CODE128, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_Codabar", "A123456A",
                    CmbtLL27.LL_BARCODE_CODABAR, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_UPCA", "44|44444",
                    CmbtLL27.LL_BARCODE_EAN8, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_UPCE", "4|44444|44444",
                    CmbtLL27.LL_BARCODE_UPCA, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_3OF9", "*TEST*", CmbtLL27.LL_BARCODE_3OF9,
                        0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_25IND", "44444",
                    CmbtLL27.LL_BARCODE_25INDUSTRIAL, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_25IL", "444444",
                    CmbtLL27.LL_BARCODE_25INTERLEAVED, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_25MAT", "44444",
                    CmbtLL27.LL_BARCODE_25MATRIX, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_25DL", "44444",
                    CmbtLL27.LL_BARCODE_25DATALOGIC, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_POSTNET5", "44444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_POSTNET10", "44444-4444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_POSTNET12", "44444-444444",
                    CmbtLL27.LL_BARCODE_POSTNET, 0);
    Ll.LlDefineFieldExt(nLLJob_, "Barcode_FIM", "A", CmbtLL27.LL_BARCODE_FIM, 0);
    
    //Start printing
    if (Ll.LlPrintWithBoxStart(
        nLLJob_,
        CmbtLL27.LL_PROJECT_LIST,
        bufferFilename.toString(),
        CmbtLL27.LL_PRINT_EXPORT,
        CmbtLL27.LL_BOXTYPE_NORMALMETER,
        hWnd_,
        "Printing...") < 0)
    {
      JOptionPane.showMessageDialog(
          this,
          "Error While Printing.",
          "List & Label Sample App",
          JOptionPane.ERROR_MESSAGE);
      
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }
    
    //Predifined selections for print options dialog
    Ll.LlPrintSetOption(
        nLLJob_,
        CmbtLL27.LL_PRNOPT_COPIES,
        CmbtLL27.LL_COPIES_HIDE);

    Ll.LlPrintSetOption(
        nLLJob_,
        CmbtLL27.LL_PRNOPT_STARTPAGE,
        1);

    if (Ll.LlPrintOptionsDialog(
        nLLJob_,
        hWnd_,
        "Select printing options") < 0)
    {
      Ll.LlPrintEnd(nLLJob_, 0);
      
      //Close the List & Label job
      Ll.LlJobClose(nLLJob_);
      nLLJob_ = -1;

      return;
    }

    StringBuffer bufferPrinter = new StringBuffer();
    StringBuffer bufferPort = new StringBuffer();
    int nRecCount = 34, nErrorValue = 0, nRecno;
    long nLastPage = 0;

    Ll.LlPrintGetPrinterInfo(
        nLLJob_,
        bufferPrinter,
        bufferPort);

    nLastPage = Ll.LlPrintGetOption(nLLJob_, CmbtLL27.LL_OPTION_LASTPAGE);
    nRecno = 1;
    
    //Do printing loop only when there is any data to be printed and no error has occurred
    while (nRecno < nRecCount &&
           (Ll.LlPrintGetCurrentPage(nLLJob_) <= nLastPage) &&
           (nErrorValue == 0 || nErrorValue == CmbtLL27.LL_WRN_REPEAT_DATA))
    {
      for (int i = 1; i < 10; i++)
      {
        if (i != 2)
        {
          sTemp = "FixedVariable" + i;
          sTemp2 = "FixedVariable" + i + "record " + nRecno;
          Ll.LlDefineVariable(nLLJob_, sTemp, sTemp2);
        }
      }

      nErrorValue = Ll.LlPrint(nLLJob_);
      while (nRecno < nRecCount && (nErrorValue == 0) &&
             (Ll.LlPrintGetCurrentPage(nLLJob_) <= nLastPage))
      {
        for (int i = 1; i < 10; i++)
        {
          sTemp = "Field" + i;
          if (Ll.LlPrintIsFieldUsed(nLLJob_, sTemp) < 0)
          {
            if (i == 1) {
              //Simulate a "groupable" field contents to demonstrate grouping specified at runtime in the designer
              sTemp2 = "group" + nRecno / 4;
            }
            else {
              sTemp2 = "contents of Field" + i + " record " + nRecno;
            }
            Ll.LlDefineField(nLLJob_, sTemp, sTemp2);
          }
        }
        if (Ll.LlPrintIsFieldUsed(nLLJob_, "NumericalField") < 0)
        {
          sTemp2 = String.valueOf(nRecno);
          Ll.LlDefineFieldExt(nLLJob_, "NumericalField", sTemp2,
                          CmbtLL27.LL_NUMERIC, 0);
        }
        
        //Set percentage
        sBoxText = "printing on " + bufferPrinter.toString() + " " + bufferPort.toString();
        nErrorValue = Ll.LlPrintSetBoxText(nLLJob_,
                                           sBoxText,
                                           (100 * nRecno / nRecCount));
        if (nErrorValue == CmbtLL27.LL_ERR_USER_ABORTED)
        {
          Ll.LlPrintEnd(nLLJob_, 0);
          
          //Close the List & Label job
          Ll.LlJobClose(nLLJob_);
          nLLJob_ = -1;

          return;
        }
        
        //Now print the table line
        nErrorValue = Ll.LlPrintFields(nLLJob_);

        if (nErrorValue == 0) //Everything fine, record could have been printed...
        {
          //...but probably the user defined a filter condition!
          //So before updating time dependent variables we have to check if the record really has been printed
          if (Ll.LlPrintDidMatchFilter(nLLJob_) < 0)
          {
            //Update the time dependent variable 'FixedVariable2'
            //coming after printing the list(s)
            sTemp2 = "FixedVariable2, record " + nRecno;
            Ll.LlDefineVariable(nLLJob_, "FixedVariable2", sTemp2);
          }
          
          //Now (virtually) goto next record
          nRecno++;
        }
      }
    }

    //All records have been printed, now flush the table
    //If footer doesn't fit to this page try again for the next page

    nErrorValue = Ll.LlPrintFieldsEnd(nLLJob_);
    while (nErrorValue == CmbtLL27.LL_WRN_REPEAT_DATA)
    {
      //Update the definitions of your page dependent variables here...
      for (int i = 1; i < 10; i++)
      {
        if (i != 2)
        {
          //Special: 'FixedVariable2' shall be a time dependent fixed variable in this example!
          sTemp = "FixedVariable" + i;
          sTemp2 = "FixedVariable" + i + " record " + nRecno;
          Ll.LlDefineVariable(nLLJob_, sTemp, sTemp2);
        }
      }

      //... and then try again
      nErrorValue = Ll.LlPrintFieldsEnd(nLLJob_);
    }
    
    //End print job
    Ll.LlPrintEnd(nLLJob_, 0);
    
    //Close the List & Label job
    Ll.LlJobClose(nLLJob_);
    nLLJob_ = -1;
  }

  void JCheckBoxLLDebug_itemStateChanged(ItemEvent e)
  {
    if (JCheckBoxLLDebug.isSelected())
    {
      JOptionPane.showMessageDialog(this,
                                    "Make sure that Debwin had been started before this demo application. If this doesn't happen you won't see any debug outputs now!",
                                    "List & Label Sample App",
                                    JOptionPane.INFORMATION_MESSAGE);
    }
  }

//Hint: When using List & Label DOM classes please note that the values have to be passed as strings. This is necessary to ensure a
//maximum of flexibility, as List & Label formulas are also allowed for the values.
//=============================================================================
  void JButtonLLCreateDOMList_actionPerformed(ActionEvent e)
//=============================================================================
  {
    //Initialize the List & Label Job
    if (initializeLL() == false)
    {
      return;
    }
    
    //Clear the field buffer
    Ll.LlDefineFieldStart(nLLJob_);
    
    //Define the fields virtually
    //Important: Normally you use here your database functions
    String sTemp;
    for (int j = 1; j < 6; ++j)
    {
      sTemp = "Field" + j;
      Ll.LlDefineField(nLLJob_, sTemp, sTemp);
    }
    
    //Create a new list project called 'sample_dom.lst'
    String sFileName = "sample_dom.lst";
    int nRet = Ll.LlProjectOpen(nLLJob_, CmbtLL27.LL_PROJECT_LIST, sFileName, CmbtLL27.LL_PRJOPEN_CD_CREATE_ALWAYS | CmbtLL27.LL_PRJOPEN_AM_READWRITE);
    if (nRet < 0)
    {
      JOptionPane.showMessageDialog(
          this,
          "Error while creating new dom project.\n\nHint: To be able to use DOM you will need at least the Professional Edition of List & Label.",
          "List & Label Sample App",
          JOptionPane.ERROR_MESSAGE);
      return;
    }
    
    //Get the project's DOM object
    long handleProject = -1;
    handleProject = Ll.LlDomGetProject(nLLJob_, 0 /*reserved*/);
    if(handleProject <= 0)
    {
      JOptionPane.showMessageDialog(
          this,
          "Error while getting dom project object.",
          "List & Label Sample App",
          JOptionPane.ERROR_MESSAGE);
      return;
    }
    
    //Assign new project description to the project. Due to reasons of a better overview, the return-value will be ignored
    Ll.LlDomSetProperty(handleProject, "ProjectParameters.LL.ProjectDescription.Contents", "New Project-Description");
    
    //Get the object list object
    long handleObjectList = Ll.LlDomGetObject(handleProject, "Objects", 0 /*reserved*/);
    
    //Create an empty text object
    long handleTextObject = Ll.LlDomCreateSubobject(handleObjectList, 0, "Text", 0 /*reserved*/);
    Ll.LlDomSetProperty(handleTextObject, "Name", "My new Textobject");
    
    //Get the page coordinates for the first page
    StringBuffer sHorizontalBuffer = new StringBuffer("");
    long handleRegionList = Ll.LlDomGetObject(handleProject, "Regions", 0 /*reserved*/);
    long handleRegion = Ll.LlDomCreateSubobject(handleRegionList, 0, "Region", 0 /*reserved*/);
    Ll.LlDomGetProperty(handleRegion, "Paper.Extent.Horizontal", sHorizontalBuffer);

    long nHorizontal = Long.parseLong(sHorizontalBuffer.toString().trim()) - 105000;
    String sHorizontal = String.valueOf(nHorizontal);
    
    //Set some properties for the text object
    Ll.LlDomSetProperty(handleTextObject, "Position.Left", "10000");
    Ll.LlDomSetProperty(handleTextObject, "Position.Top", "10000");
    Ll.LlDomSetProperty(handleTextObject, "Position.Width", sHorizontal);
    Ll.LlDomSetProperty(handleTextObject, "Position.Height", "27000");
    
    //Assign to "First Page" layer
    Ll.LlDomSetProperty(handleTextObject, "LayerID", "1");
    
    //Add a paragraph to the text object and set some properties
    long handleParagraphList = Ll.LlDomGetObject(handleTextObject, "Paragraphs", 0 /*reserved*/);
    long handleParagraph = Ll.LlDomCreateSubobject(handleParagraphList, 0, "Paragraph", 0 /*reserved*/);
    Ll.LlDomSetProperty(handleParagraph, "Contents", "'New Project-Description'");
    Ll.LlDomSetProperty(handleParagraph, "Font.Bold", "True");
    Ll.LlDomSetProperty(handleParagraph, "Font.Size", "16.0");
    
    //Add a drawing object
    long handleDrawingObject = Ll.LlDomCreateSubobject(handleObjectList, 0, "Drawing", 0 /*reserved*/);
    Ll.LlDomSetProperty(handleDrawingObject, "Source.FileInfo.Filename", "sunshine.gif");
    Ll.LlDomSetProperty(handleDrawingObject, "Position.Left", "120000");
    Ll.LlDomSetProperty(handleDrawingObject, "Position.Top", "9700");
    Ll.LlDomSetProperty(handleDrawingObject, "Position.Width", "73500");
    Ll.LlDomSetProperty(handleDrawingObject, "Position.Height", "36200");
    
    //Assign to "First Page" layer
    Ll.LlDomSetProperty(handleDrawingObject, "LayerID", "1");
    
    //The following object are available in a table row:
    // "Text", "RTFText", "Drawing", "Barcode", "LLX:LLHTMLObject"
    
    //Add a report container and set some properties
    long handleReportContainer = Ll.LlDomCreateSubobject(handleObjectList, 0, "ReportContainer", 0 /*reserved*/);
    Ll.LlDomSetProperty(handleReportContainer, "Position.Left", "14000");
    Ll.LlDomSetProperty(handleReportContainer, "Position.Top", "70000");
    Ll.LlDomSetProperty(handleReportContainer, "Position.Width", "177000");
    Ll.LlDomSetProperty(handleReportContainer, "Position.Height", "210000");
    
    //Link the report container to the text object
    StringBuffer sTextID = new StringBuffer("");
    Ll.LlDomGetProperty(handleTextObject, "ID", sTextID);
    Ll.LlDomSetProperty(handleReportContainer, "LinkID", sTextID.toString());
    
    //Link To - Type: Position Adaption: Vertical Relative to end.
    //Size Adaption: Vertical Proportional
    int nLinkMode = combit.CmbtLL27.LL_LINK_VPOS_END | combit.CmbtLL27.LL_LINK_VSIZE_INV;
    String sLinkMode = String.valueOf(nLinkMode);
    Ll.LlDomSetProperty(handleReportContainer, "LinkMode", sLinkMode);
    
    //Add a table to the report container
    long handleSubItems = Ll.LlDomGetObject(handleReportContainer, "SubItems", 0 /*reserved*/);
    long handleTable = Ll.LlDomCreateSubobject(handleSubItems, 0, "Table", 0 /*reserved*/);
    
    //Add a new data line
    long handleTableLines = Ll.LlDomGetObject(handleTable, "Lines", 0 /*reserved*/);
    long handleTableData = Ll.LlDomGetObject(handleTableLines, "Data", 0 /*reserved*/);

    long handleDataLine = Ll.LlDomCreateSubobject(handleTableData, 0, "Line", 0 /*reserved*/);
    Ll.LlDomSetProperty(handleDataLine, "Name", "My new table line");

    StringBuffer sContainerPositionWidth = new StringBuffer("");
    Ll.LlDomGetProperty(handleReportContainer, "Position.Width", sContainerPositionWidth);
    int nContainerPositionWidth = Integer.parseInt(sContainerPositionWidth.toString().trim());
    
    //Add header line
    long handleTableHeader = Ll.LlDomGetObject(handleTableLines, "Header", 0 /*reserved*/);
    long handleHeaderLine = Ll.LlDomCreateSubobject(handleTableHeader, 0, "Line", 0 /*reserved*/);
    
    //Add the selected fields to the header and data line
    String sVarName = "", sFieldWidth = "";
    int nItemCount = 6;

    long handleHeaderFields = Ll.LlDomGetObject(handleHeaderLine, "Fields", 0 /*reserved*/);
    long handleTableLinesFields = Ll.LlDomGetObject(handleDataLine, "Fields", 0 /*reserved*/);

    int nFieldWidth = nContainerPositionWidth / nItemCount;
    for (int i = 1; i < nItemCount; i++)
    {
      sVarName = "Field" + i;
      sFieldWidth = String.valueOf(nFieldWidth);
      
      //Define header line
      long handleTableHeaderField = Ll.LlDomCreateSubobject(handleHeaderFields, i, "Text", 0 /*reserved*/);

      Ll.LlDomSetProperty(handleTableHeaderField, "Contents", "'" + sVarName + "'");
      Ll.LlDomSetProperty(handleTableHeaderField, "Filling.Style", "1");
      Ll.LlDomSetProperty(handleTableHeaderField, "Filling.Color", "RGB(204,204,255)");
      Ll.LlDomSetProperty(handleTableHeaderField, "Font.Bold", "True");
      Ll.LlDomSetProperty(handleTableHeaderField, "Width", sFieldWidth);
      
      //Define data line
      long handleTableLine = Ll.LlDomCreateSubobject(handleTableLinesFields, 0, "Text", 0 /*reserved*/);
      Ll.LlDomSetProperty(handleTableLine, "Contents", sVarName);
      Ll.LlDomSetProperty(handleTableLine, "Width", sFieldWidth);
    }
    
    //Save project
    Ll.LlProjectSave(nLLJob_, "");
    
    //Close project
    Ll.LlProjectClose(nLLJob_);
    
    //Call the desinger
    if (Ll.LlDefineLayout(nLLJob_, hWnd_, "Designer", CmbtLL27.LL_PROJECT_LIST,
                              sFileName) < 0)
        {
          JOptionPane.showMessageDialog(null, "Error by calling LlDefineLayout.",
                                        "List & Label Sample App",
                                        JOptionPane.ERROR_MESSAGE);
          
          //Close the List & Label job
          Ll.LlJobClose(nLLJob_);
          nLLJob_ = -1;
        }
  }
}

class CMainFrame_this_windowAdapter
    extends java.awt.event.WindowAdapter {
  CMainFrame adaptee;

  CMainFrame_this_windowAdapter(CMainFrame adaptee) {
    this.adaptee = adaptee;
  }

  public void windowClosing(WindowEvent e) {
    adaptee.this_windowClosing(e);
  }
}

class CMainFrame_JButtonLLDesignLabel_actionAdapter
    implements java.awt.event.ActionListener {
  CMainFrame adaptee;

  CMainFrame_JButtonLLDesignLabel_actionAdapter(CMainFrame adaptee) {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e) {
    adaptee.JButtonLLDesignLabel_actionPerformed(e);
  }
}

class CMainFrame_JButtonLLDesignReport_actionAdapter
    implements java.awt.event.ActionListener {
  CMainFrame adaptee;

  CMainFrame_JButtonLLDesignReport_actionAdapter(CMainFrame adaptee) {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e) {
    adaptee.JButtonLLDesignReport_actionPerformed(e);
  }
}

class CMainFrame_JButtonLLPrintLabel_actionAdapter
    implements java.awt.event.ActionListener {
  CMainFrame adaptee;

  CMainFrame_JButtonLLPrintLabel_actionAdapter(CMainFrame adaptee) {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e) {
    adaptee.JButtonLLPrintLabel_actionPerformed(e);
  }
}

class CMainFrame_JButtonLLPrintReport_actionAdapter
    implements java.awt.event.ActionListener {
  CMainFrame adaptee;

  CMainFrame_JButtonLLPrintReport_actionAdapter(CMainFrame adaptee) {
    this.adaptee = adaptee;
  }

  public void actionPerformed(ActionEvent e) {
    adaptee.JButtonLLPrintReport_actionPerformed(e);
  }
}

class CMainFrame_JCheckBoxLLDebug_itemAdapter
    implements java.awt.event.ItemListener {
  CMainFrame adaptee;

  CMainFrame_JCheckBoxLLDebug_itemAdapter(CMainFrame adaptee) {
    this.adaptee = adaptee;
  }

  public void itemStateChanged(ItemEvent e) {
    adaptee.JCheckBoxLLDebug_itemStateChanged(e);
  }
}

class CMainFrame_JButtonLLCreateDOMList_actionAdapter implements java.awt.event.ActionListener
{
  CMainFrame adaptee;

  CMainFrame_JButtonLLCreateDOMList_actionAdapter(CMainFrame adaptee)
  {
    this.adaptee = adaptee;
  }
  public void actionPerformed(ActionEvent e)
  {
    adaptee.JButtonLLCreateDOMList_actionPerformed(e);
  }
}

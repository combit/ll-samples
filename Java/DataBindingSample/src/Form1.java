import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.awt.FlowLayout;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;

import java.util.EnumSet;

import Microsoft.Win32.Registry;
import Microsoft.Win32.RegistryKey;
import System.Data.OleDb.OleDbCommand;
import System.Data.OleDb.OleDbConnection;
import System.Drawing.SystemColors;
import System.Windows.Forms.DockStyle;

import combit.ListLabel24.LL_User_Aborted_Exception;
import combit.ListLabel24.ListLabelActivation;
import combit.ListLabel24.ListLabelException;
import combit.ListLabel24.LlButtonState;
import combit.ListLabel24.LlPreviewControlCloseMode;
import combit.ListLabel24.ListLabelPreviewControl.*;
import combit.ListLabel24.LlProject;
import combit.ListLabel24.DataProviders.DbCommandSetDataProvider.*;
import combit.ListLabel24.DataProviders.DbCommandSetDataProvider.ExecuteDbCommandEventArgs.DbCommand;
import combit.ListLabel24.Events.*;
/**
 * This example demonstrate the usage of the List & Label .NET component
 * (https://www.combit.net/en/reporting-tool) in Java with the third party
 * component Javonet (https://www.javonet.com):
 * 
 * - using a List & Label .NET Dataprovider to connect to an Access database with OleDB and respond to an  Dataprovider event
 * - calling/opening the List & Label Designer; including real data preview
 * - printing into the List & Label preview control on the dialog and respond to an button click event of the preview control
 * - exporting into any kind of provided formats from List & Label
 * 
 * Requirements: You need to have copy the .NET assembly combit.ListLabel24.dll
 * in the sample folder. Also you have to get the javonet-[?].jar and license key from Javonet. 
 * To get the sample working, add your licensing information for using Javonet in 
 * call to ListLabelActivation.setLicense(...) method in Form1.main(..).
 * 
 * This sample is using strongly-typed wrapper combit.ListLabel24 for Java which exposes
 * part of the List&Label API. The source code of the wrapper is included in this repository,
 * if you need to access any uncovered feature of combit List&Label, you can extend the wrapper
 * and recompile the combit.ListLabel24.jar.
 * 
 * To re-compile the Jar after changes run the ANT build script:
 * From Eclipse: Right Click "build_script.xml" > Run As Ant Build
 */

public class Form1 extends JFrame implements ButtonPressCommandDelegate, AutoDefineFieldDelegate, ExecuteDbCommandDelegate {

	private combit.ListLabel24.ListLabel LL;
	private ListLabelPreviewControl LLPreviewControl;
	private String _databasePath;
	private JButton print_Reader;
	private JButton design_Reader;
	private JLabel labelDE;
	private JLabel labelUS;

	private static final long serialVersionUID = 8903230729559541291L;

	public Form1() throws Exception {
		
		initializeComponents();
		
		// assign event for pressing the buttons in the preview control tool bar
		ButtonPressCommand buttonPressCommand = new ButtonPressCommand(this); 
		LLPreviewControl.attachButtonPressCommand(buttonPressCommand);

		RegistryKey installKey = Registry.getCurrentUser().CreateSubKey("Software\\combit\\cmbtll");
		if (installKey != null)
			_databasePath = (String) installKey.GetValue("NWINDPath", "");
	}

	class Form1_windowAdapter extends java.awt.event.WindowAdapter{
		Form1 adaptee;

		Form1_windowAdapter(Form1 adaptee) {
			this.adaptee = adaptee;
		}

		public void windowClosing(WindowEvent e) {
			adaptee.this_windowClosing(e);
		}

		public void windowOpened(WindowEvent e) {
			adaptee.this_windowOpened(e);
		}
	}

	private void initializeComponents() throws Exception {
		//
		// JFrame settings
		//
		this.setTitle("List & Label Java/.NET Databinding Sample");
		this.getContentPane().setFont(new Font("Segoe UI", Font.PLAIN, 12));
		this.setMinimumSize(new Dimension(400, 600));
		this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		this.addWindowListener(new Form1_windowAdapter(this));
		GridBagLayout gridBagLayout_1 = new GridBagLayout();
		gridBagLayout_1.rowHeights = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 50 };
		gridBagLayout_1.columnWidths = new int[] { 50 };
		getContentPane().setLayout(gridBagLayout_1);
		//
		Container frameContentPane = this.getContentPane();
		GridBagLayout gridBagLayout = new GridBagLayout();
		gridBagLayout.rowHeights = new int[] { 5 };
		gridBagLayout.columnWidths = new int[] { 5 };
		frameContentPane.setLayout(gridBagLayout);
		frameContentPane.setBackground(new Color(255, 255, 255));

		try {
			UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		} catch (InstantiationException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		} catch (UnsupportedLookAndFeelException e) {
			e.printStackTrace();
		}
		//
		// Blue pane
		//
		JPanel bluePane = new JPanel();
		FlowLayout flowLayout = (FlowLayout) bluePane.getLayout();
		flowLayout.setAlignOnBaseline(true);
		GridBagConstraints bpc = new GridBagConstraints();
		bpc.gridx = 0;
		bpc.gridy = 0;
		bluePane.setPreferredSize(new Dimension(800, 10));
		bluePane.setBackground(new Color(0, 174, 219));
		bpc.anchor = GridBagConstraints.NORTH;
		getContentPane().add(bluePane, bpc);
		//
		// tabs
		//
		UIManager.put("TabbedPane.borderHightlightColor", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.darkShadow", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.light", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.selectHighlight", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.darkShadow", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.focus", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.border", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.selectedTabPadInsets", new Insets(0, 10, 10, 10));
		UIManager.put("TabbedPane.shadow", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.unselectedTabShadow", java.awt.Color.WHITE);
		UIManager.put("TabbedPane.tabsOverlapBorder", true);
		JTabbedPane tabbedPane = new JTabbedPane();
		tabbedPane.setForeground(new Color(38, 38, 38));
		tabbedPane.setBackground(new Color(255, 255, 255));
		tabbedPane.setFont(new Font("Segoe UI", Font.BOLD, 16));
		GridBagConstraints tabbedPaneConstraint = new GridBagConstraints();
		tabbedPaneConstraint.gridx = 0;
		tabbedPaneConstraint.gridy = 1;
		tabbedPaneConstraint.fill = GridBagConstraints.HORIZONTAL;
		tabbedPaneConstraint.weightx = 0.1;
		tabbedPaneConstraint.weighty = 0.1;
		tabbedPaneConstraint.anchor = GridBagConstraints.NORTH;
		tabbedPaneConstraint.insets = new Insets(0, 0, 0, 0);
		getContentPane().add(tabbedPane, tabbedPaneConstraint);
		//
		// metroPanel6
		//
		JPanel metroPanel6 = new JPanel(false);
		metroPanel6.setBackground(new Color(255, 255, 255));
		metroPanel6.setPreferredSize(new Dimension(400, 100));
		metroPanel6.setLayout(null);
		tabbedPane.addTab("DbCommand", metroPanel6);
		//
		// labelUS
		//
		this.labelUS = new JLabel();
		this.labelUS.setBounds(409, 11, 349, 19);
		this.labelUS.setName("label11");
		this.labelUS.setText("US: Binds the component to an OleDbCommand object.");
		this.labelUS.setFont(new Font("Segeo UI", Font.PLAIN, 14));
		this.labelUS.setAlignmentX(LEFT_ALIGNMENT);
		this.labelUS.setForeground(new Color(38, 38, 38));
		metroPanel6.add(labelUS);
		//
		// label12
		//
		this.labelDE = new JLabel();
		this.labelDE.setBounds(10, 11, 375, 19);
		this.labelDE.setName("label12");
		this.labelDE.setText("DE: Bindet die Komponente an ein OleDbCommand-Objekt.");
		this.labelDE.setFont(new Font("Segeo UI", Font.PLAIN, 14));
		this.labelDE.setAlignmentX(LEFT_ALIGNMENT);
		this.labelDE.setForeground(new Color(38, 38, 38));
		metroPanel6.add(labelDE);
		//
		// design_Reader
		//
		this.design_Reader = new JButton();
		this.design_Reader.setBounds(541, 51, 100, 25);
		this.design_Reader.setFont(new Font("Segoe UI", Font.BOLD, 12));
		this.design_Reader.setForeground(new Color(38, 38, 38));
		this.design_Reader.setName("design_Reader");
		this.design_Reader.setPreferredSize(new Dimension(112, 24));
		this.design_Reader.setText("Design");
		this.design_Reader.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				ButtonDesign_Click();
			}
		});
		metroPanel6.add(design_Reader);
		//
		// print_Reader
		//
		this.print_Reader = new JButton();
		this.print_Reader.setBounds(658, 51, 100, 25);
		this.print_Reader.setFont(new Font("Segoe UI", Font.BOLD, 12));
		this.print_Reader.setForeground(new Color(38, 38, 38));
		this.print_Reader.setName("print_Reader");
		this.print_Reader.setPreferredSize(new Dimension(112, 24));
		this.print_Reader.setText("Print");
		this.print_Reader.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				ButtonPrint_Click();
			}
		});
		metroPanel6.add(print_Reader);
		//
		// LLPreviewControl
		//
		this.LLPreviewControl = new ListLabelPreviewControl();
		this.LLPreviewControl.setAllowRbuttonUsage(true);
		this.LLPreviewControl.setBackColor(SystemColors.getWindow());
		this.LLPreviewControl.setCloseMode(LlPreviewControlCloseMode.DeleteFile);
		this.LLPreviewControl.setCurrentPage(0);
		this.LLPreviewControl.setDock(DockStyle.Fill);
		this.LLPreviewControl.setForceReadOnly(false);
		this.LLPreviewControl.setName("LLPreviewControl");
		this.LLPreviewControl.setSlideshowMode(false);
		this.LLPreviewControl.setTabIndex(14);
		this.LLPreviewControl.setText("listLabelPreviewControl");
		this.LLPreviewControl.getToolbarButtons().setExit(LlButtonState.Invisible);
		this.LLPreviewControl.getToolbarButtons().setGotoFirst(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setGotoLast(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setGotoNext(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setGotoPrev(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setMouseModeMove(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setMouseModeZoom(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setNextFile(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setPageRange(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setPreviousFile(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setPrintAllPages(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setPrintCurrentPage(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setPrintToFax(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setSaveAs(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setSearchNext(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setSearchOptions(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setSearchStart(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setSearchText(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setSendTo(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setSlideshowMode(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setZoomCombo(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setZoomReset(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setZoomRevert(LlButtonState.Default);
		this.LLPreviewControl.getToolbarButtons().setZoomTimes2(LlButtonState.Default);
		//
		// LL
		//
		this.LL = new combit.ListLabel24.ListLabel();
		this.LL.setAutoPrinterSettingsStream(null);
		this.LL.setAutoProjectStream(null);
		this.LL.setDataBindingMode(combit.ListLabel24.DataBindingMode.DelayLoad);
		this.LL.setDrilldownAvailable(true);
		this.LL.setEMFResolution(100);
		this.LL.setLockNextChar(8288);
		this.LL.setMaxRTFVersion(65280);
		this.LL.setPhantomSpace(8203);
		this.LL.setUnit(combit.ListLabel24.LlUnits.Millimeter_1_100);
		this.LL.setUseHardwareCopiesForLabels(false);
		this.LL.setUseTableSchemaForDesignMode(false);
		//
		//
		//
		GridBagConstraints listPreviewConstraint = new GridBagConstraints();
		listPreviewConstraint.gridx = 0;
		listPreviewConstraint.gridy = 2;
		listPreviewConstraint.fill = GridBagConstraints.BOTH;
		listPreviewConstraint.weightx = 0.1;
		listPreviewConstraint.weighty = 10.0;
		listPreviewConstraint.anchor = GridBagConstraints.NORTH;
		listPreviewConstraint.insets = new Insets(0, 0, 0, 0);
		getContentPane().add(this.LLPreviewControl, listPreviewConstraint);
		//
		this.pack();
		this.setVisible(true);
	}

	private DbCommandSetDataProvider CreateDbCommandSetDataProvider() {
		DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
		String ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath;
		OleDbConnection conn = new OleDbConnection(ConnectionString);
		conn.Open();
		OleDbCommand cmd = new OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID)", conn);
		conn.Close();
		provider.AddCommand(cmd, "Products");
		
		ExecuteDbCommand executeDbCommand = new ExecuteDbCommand(this); 
		provider.attachExecuteDbCommand(executeDbCommand);
		
		return provider;
	}

	void this_windowClosing(WindowEvent e){
		LLPreviewControl.Dispose();
		LL.Dispose();
	}

	void this_windowOpened(WindowEvent e){
	}

	@Override
	public void ButtonPressCommand(ButtonPressCommandEventArgs arguments) {
		System.out.printf(".NET Event 'ButtonPress' occurred... %d\n", arguments.buttonID);
		switch(arguments.buttonID){
			case 115: /* Send to - more button IDs can be found in menuid.txt */{
				arguments.ignore = true;
				JOptionPane.showMessageDialog(null,
						"Information:\nThe Button for mailing was pressed but not executed, because its action was ignored by source code!",
						"Information", JOptionPane.INFORMATION_MESSAGE);
			}
			default:{
			}
		}
	}
	
	@Override
	public void AutoDefineField(AutoDefineElementEventArgs args) {
		System.out.printf(".NET Event 'AutoDefineField' occurred... %s\n", args.name);
		if (args.name.equals("Products.SupplierID")) {
			args.suppress = true;
		}
	}
	
	@Override
	public void ExecuteDbCommand(ExecuteDbCommandEventArgs args) {
		DbCommand command = args.getCommand();
		String commandText = command.getCommandText();
		System.out.printf(".NET Event 'ExecuteDbCommand' occurred... %s\n", commandText);
		
		commandText = "SELECT TOP 10 * FROM Products";
		command.setCommandText(commandText);
	}
	
	private void ButtonDesign_Click() {
		combit.ListLabel24.ListLabel workingLL = null;
		try {
			workingLL = new combit.ListLabel24.ListLabel();
			
			// attach event for firing for each assigned field with data binding
			AutoDefineField autoDefineField = new AutoDefineField(this); 
			workingLL.attachAutoDefineField(autoDefineField);
			
			// bind to the DbCommandSetDataProvider
			workingLL.SetDataBinding(CreateDbCommandSetDataProvider(), "Products");

			// set the default project name
			workingLL.setAutoProjectFile("simple.lst");

			// choose a list project, allow the user to create new ones also
			workingLL.setAutoProjectType(EnumSet.of(LlProject.List));

			// call the designer
			workingLL.Design(this);
		} catch (LL_User_Aborted_Exception ex) {
			// ignore this exception
		} catch (ListLabelException LlException) {
			JOptionPane.showMessageDialog(null,
					"Information: " + LlException.getMessage()
							+ "\n\nThis information was generated by a List & Label custom exception.",
					"Information", JOptionPane.ERROR_MESSAGE);
		}
		finally {
			if(workingLL != null) {				
				workingLL.Dispose();
			}
		}
	}

	private void ButtonPrint_Click() {
		combit.ListLabel24.ListLabel workingLL = null;
		try {
			workingLL = new combit.ListLabel24.ListLabel();
			
			// attach the preview control
			workingLL.setPreviewControl(this.LLPreviewControl);
			
			// attach event for firing for each assigned field with data binding
			AutoDefineField autoDefineField = new AutoDefineField(this); 
			workingLL.attachAutoDefineField(autoDefineField);
			
			// bind to the DbCommandSetDataProvider
			workingLL.SetDataBinding(CreateDbCommandSetDataProvider(), "Products");

			// set the default project name
			workingLL.setAutoProjectFile("simple.lst");

			// choose a list project, allow the user to create new ones also
			workingLL.setAutoProjectType(LlProject.List);

			// call the print method
			workingLL.Print(this);
		} catch (LL_User_Aborted_Exception ex) {
			// ignore this exception
		} catch (ListLabelException LlException) {
			JOptionPane.showMessageDialog(null,
					"Information: " + LlException.getMessage()
							+ "\n\nThis information was generated by a List & Label custom exception.",
					"Information", JOptionPane.ERROR_MESSAGE);
		}
		finally {		
			if(workingLL != null) {
				workingLL.Dispose();
			}
		}
	}

	public static void main(String[] args) {
		// Here you need to call ListLabelActivation.setLicense(...) and use your licensing information from Javonet
		// e.g. ListLabelActivation.setLicense("<Your eMail address>", "<Your Javonet licensing key>");
		// You can obtain your own Javonet free trial license key at: https://my.javonet.com/signup/?type=free
		
		//TODO: 1) Copy combit.ListLabel24.dll to project root folder
		//TODO: 2) Copy javonet-1.5.jar or newer to project root folder
		//TODO: 3) update your Javonet license details below
		ListLabelActivation.setLicense("your@mail.com", "your-license-key");
        
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					new Form1();
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}
}

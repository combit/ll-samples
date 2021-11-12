#ifndef __dsCLASS_INCLUDE_CH__
#define 	__dsCLASS_INCLUDE_CH__

// #define _DEBUG_CELLEDIT    wenn Celledit debuggt werden soll aktivieren

#define DSPB_CANCEL  -1

// OS Version
#define OS_OS2    0
#define OS_WIN95  1
#define OS_WINNT  2

// mode of center page
#define PAGE_CENTER    0
#define PAGE_HCENTER   1
#define PAGE_VCENTER   2

// menu definitions
#define MENUITEM_SEPARATOR    {NIL, NIL, XBPMENUBAR_MIS_SEPARATOR, 0}
#define MENUITEM_SEPARATOR_EX {NIL, NIL, XBPMENUBAR_MIS_SEPARATOR, XBPMENUBAR_MIA_OWNERDRAW}
#define ITEM_SEPARATOR        -2
#define ITEM_DISTANCE         -3
#define ITEM_TEXT             -4

// switchmode for dsPushButton and Toolbarbutton
#define BUTTON_SWITCH_NO      100
#define BUTTON_SWITCH_OFF     101
#define BUTTON_SWITCH_ON      102

// Statusbar Items
#define SB_ITEM_BUTTON        0
#define SB_ITEM_FLAT          1
#define SB_ITEM_RAISED        2
#define SB_ITEM_SUNKEN        3
#define SB_ITEM_SEPARATOR     4

// dsDataDialog Changestates
#define DLG_NORMAL_STATE								0
#define DLG_EDIT_STATE									0
#define DLG_NOTIFY_VALUECHANGED						1  // message send by control
#define DLG_EDIT_CHANGE_STATE							2
#define DLG_APPEND_STATE								3
#define DLG_APPEND_CHANGE_STATE						4
#define DLG_READONLY_STATE								5
#define DLG_PAGE_ACTIVATED								6  // if page is activated
#define DLG_EDIT_STATE_NEW								7	// neue Logik xclOPTION_CHANGESTATE#define DLG_NOTIFY_EXTENDED							20 // message send by extended controls: Browser, Treeview, etc
#define DLG_NOTIFY_BROWSECHANGED						20
#define DLG_TV_MOVE_STATE								21
#define DLG_TV_NEW_STATE								22
#define DLG_TV_DELETE_STATE							23
#define DLG_NOTIFY_BROWSECOLMOVED					24	// not in use any more => callbackslot
#define DLG_NOTIFY_BROWSECOLRESIZED					25	// not in use any more => callbackslot
#define DLG_NOTIFY_BROWSE_STATE						30
#define DLG_NOTIFY_BROWSE_EDIT_STATE				31
#define DLG_NOTIFY_BROWSE_APPEND_STATE				32
#define DLG_NOTIFY_BROWSE_EDIT_CHANGE_STATE		33
#define DLG_NOTIFY_BROWSE_APPEND_CHANGE_STATE	34

#define DLG_NOTIFY_USER				 100       // user defines start here

// defines for dsReport
#define PROP_CHARCNT  			1
#define PROP_DISTCNT  			2
#define PROP_FONT     			3
#define PROP_REFCHAR  			4
#define PROP_COLORFG  			5
#define PROP_COLORBG  			6
#define PROP_POSITION 			7
#define PROP_DECIMAL 			8
#define PROP_PICTURE 			9
#define PROP_CNT      			9

#define PRN_LEFT      			0
#define PRN_CENTER    			1
#define PRN_RIGHT     			2
#define PRN_LEFT_FIXLEN			3                                               // alt: nur wenn nicht PIXEL
#define PRN_FIXLEN	    		3
#define PRN_FIXED_LEN    		4                                               // neu: auch in Verbindung mit PIXEL
#define PRN_PIXEL		    		(2**5)                                          // binär

// defines for dsNavigateDB class
#define DS_NAVIGATEDB_GOTOP      1
#define DS_NAVIGATEDB_GOBOTTOM   2
#define DS_NAVIGATEDB_GOTO       3
#define DS_NAVIGATEDB_SKIP       4

// defines for application type
#define DS_CHILD_DLG      0
#define DS_APP_DLG        1
#define DS_APP_SDI        2
#define DS_APP_MDI        3

// for SelectBrowse internal use
#define SELECT_NONE          0
#define SELECT_SINGLE        1
#define SELECT_QSINGLE       2
#define SELECT_MULTI         3
#define SELECT_QMULTI        4
#define SELECT_MAX           4

// header colors for select browse
#define SEL_HEADCLR_ACTIVE      GRA_CLR_RED
#define SEL_HEADCLR_NOTACTIVE   GRA_CLR_BLUE

// Font setting for dsColProperty
#define HEAD_FONT   1
#define DATA_FONT   2
#define FOOT_FONT   3

// Xbase++ 1.9 adaption
#if XPPVER >= 01900314
#xtranslate   GetParentForm(<List,...>)	=> dsGetParentForm(<List>)
#endif

#if XPPVER >= 2000840
// wegen neuer EXTERN DLL Funktionsaufrufe umbenennen
// funktioniert nicht in AFX Masken !!!
#xtranslate   GetUserName()					=> dsGetUserName()
#xtranslate   GetComputerName()				=> dsGetComputerName()
#xtranslate   GetTempPath()					=> dsGetTempPath()
#endif

#define SET_AMERICAN   		1
#define SET_BRITISH    		2
#define SET_FRENCH     		3
#define SET_GERMAN     		4
#define SET_ITALIAN    		5
#define SET_JAPAN      		6
#define SET_USA        		7

// windows only
#define xbeK_PLUS       	43
#define xbeK_MINUS      	45
#define xbeK_CTRL_0     	589872
#define xbeK_CTRL_1     	589873
#define xbeK_CTRL_2     	589874
#define xbeK_CTRL_3     	589875
#define xbeK_CTRL_4     	589876
#define xbeK_CTRL_5     	589877
#define xbeK_CTRL_6     	589878
#define xbeK_CTRL_7     	589879
#define xbeK_CTRL_8     	589880
#define xbeK_CTRL_9     	589881
#ifndef xbeK_CTRL_SPACE
	#define xbeK_CTRL_SPACE 	524320
#endif
#ifndef xbeK_CTRL_SH_TAB
	#define xbeK_CTRL_SH_TAB	720905
#endif

// Resizemode
#ifdef XPP_RESIZE

   #define XBP_RELXPOS           0x10
   #define XBP_RELYPOS           0x20
   #define XBP_RELWIDTH          0x40
   #define XBP_RELHEIGHT         0x80
   #define XBP_XCENTER           0x1000
   #define XBP_YCENTER           0x2000

   #define BOTTOM_LEFT           XBP_LEFTEDGE+XBP_BOTTOMEDGE     // 1 + 8
   #define BOTTOM_RIGHT          XBP_RIGHTEDGE+XBP_BOTTOMEDGE    // 4 + 8
   #define TOP_LEFT              XBP_LEFTEDGE+XBP_TOPEDGE        // 1 + 2
   #define TOP_RIGHT             XBP_RIGHTEDGE+XBP_TOPEDGE       // 4 + 2

   #define SIZE_NONE             0
   #define SIZE_WIDTH            XBP_LEFTEDGE+XBP_RIGHTEDGE      // 1 + 4
   #define SIZE_HEIGHT           XBP_BOTTOMEDGE+XBP_TOPEDGE      // 8 + 2

   #define TOP_PIN               XBP_TOPEDGE
   #define BOTTOM_PIN            XBP_BOTTOMEDGE
   #define LEFT_PIN              XBP_LEFTEDGE
   #define RIGHT_PIN             XBP_RIGHTEDGE

#else
   #define BOTTOM_LEFT           1
   #define BOTTOM_RIGHT          2
   #define TOP_LEFT              3
   #define TOP_RIGHT             4

   #define SIZE_NONE             0
   #define SIZE_WIDTH            1
   #define SIZE_HEIGHT           2
   #define SIZE_REPOSITION       4

   #define TOP_PIN               0
   #define BOTTOM_PIN            0
   #define LEFT_PIN              0
   #define RIGHT_PIN             0
#endif

// defines für txt position
#define DSTXT_ALIGN_CENTER   1
#define DSTXT_ALIGN_LEFT     (2**1)
#define DSTXT_ALIGN_RIGHT    (2**2)
#define DSTXT_ALIGN_TOP      (2**3)
#define DSTXT_ALIGN_BOTTOM   (2**4)

// defines für image position
#define DSIMG_ALIGN_CENTER   1
#define DSIMG_ALIGN_LEFT     (2**1)
#define DSIMG_ALIGN_RIGHT    (2**2)
#define DSIMG_ALIGN_TOP      (2**3)
#define DSIMG_ALIGN_BOTTOM   (2**4)

// defines für dsDic:GetDicDef
#define DIC_NAME				1
#define DIC_INDEX				2
#define DIC_PATH				3
#define DIC_FULLNAME			4
#define DIC_NAME_EXT			5
#define DIC_INDEX_EXT		6
#define DIC_ANIMATE			7
#define DIC_DBE			   8
#define DIC_ALL_DBF			9
#define DIC_SESSION			11
#define DIC_USER_DEF			12
#define DIC_SHARED         13
#define DIC_RO					14
#define DIC_ADS_ANSI       15
#define DIC_ADS_LOCK       16
#define DIC_ADS_TYPE       17
#define DIC_ADS_RIGHTS     18
#define DIC_CHARTYPE			19
#define DIC_FILENAME			20

#define XBP_PP_INACTIVE_HILITE_BGCLR   150
#define XBP_PP_INACTIVE_HILITE_FGCLR   151

#define EDIT_ROW      1
#define EDIT_COL      2

#define COL_SET_ASCEND     1
#define COL_SET_DESCEND    2

#define CLR_COL_ACTIVE        GRA_CLR_DARKGREEN
#define CLR_COL_NOTACTIVE     GRA_CLR_RED

// dsTextItem:ShowKeyState
#define SB_NUMLOCK        1
#define SB_SCROLL         2
#define SB_CAPSLOCK       3
#define SB_INSERT         4

// ObjAlign
#define ALIGNTO_XBP_TOP     1
#define ALIGNTO_XBP_BOTTOM  2

// _dsDefaultStatusHandler
#define dsGRP_READONLY	10001                    // anzeige buttons
#define dsGRP_EDIT      10002                    // editerbuttons
#define dsGRP_CANCEL    10003                    // Abbruchbutton, Cut/Paste
#define dsGRP_CLOSE	   10004                    // close
#define dsGRP_MOVE	   10005                    // skippen
#define dsGRP_NEW			10006                    // new
#define dsGRP_DEL    	10007                    // newdel
#define dsGRP_SAVE	   10008                    // sichern / undo
#define dsGRP_PASTE	   10009                    // Copy / Paste

#define BROWSE_MARK          1
#define BROWSE_MARKALL       2
#define BROWSE_MARKINVERT    3
#define BROWSE_UNMARKALL     4

// dsRepDesign TextBreak Mode
#define _LB_NO         0
#define _LB_GATHER     1
#define _LB_SCATTER    2

#define __APP_WRAND    2

// fehlt bei Alaska
#command  TEXT INTO <varname> WRAP TRIMMED ;
      =>  text literal, <varname>, CHR(13)+CHR(10), ltrim


#endif

// Alaska Software Xbase++ header constants and function definitions for LL30.DLL
//  (c) combit GmbH
//  [build of 2024-07-11 22:07:37]

// HEADER file to be included in all modules using LL30

#ifndef _LL30_CH // include header only once
#define _LL30_CH

#ifndef CMBTLANG_DEFAULT
 #define CMBTLANG_DEFAULT    -1
 #define CMBTLANG_GERMAN      0
 #define CMBTLANG_ENGLISH     1
 #define CMBTLANG_ARABIC      2
 #define CMBTLANG_AFRIKAANS   3
 #define CMBTLANG_ALBANIAN    4
 #define CMBTLANG_BASQUE      5
 #define CMBTLANG_BULGARIAN   6
 #define CMBTLANG_BYELORUSSIAN 7
 #define CMBTLANG_CATALAN     8
 #define CMBTLANG_CHINESE     9
 #define CMBTLANG_CROATIAN    10
 #define CMBTLANG_CZECH       11
 #define CMBTLANG_DANISH      12
 #define CMBTLANG_DUTCH       13
 #define CMBTLANG_ESTONIAN    14
 #define CMBTLANG_FAEROESE    15
 #define CMBTLANG_FARSI       16
 #define CMBTLANG_FINNISH     17
 #define CMBTLANG_FRENCH      18
 #define CMBTLANG_GREEK       19
 #define CMBTLANG_HEBREW      20
 #define CMBTLANG_HUNGARIAN   21
 #define CMBTLANG_ICELANDIC   22
 #define CMBTLANG_INDONESIAN  23
 #define CMBTLANG_ITALIAN     24
 #define CMBTLANG_JAPANESE    25
 #define CMBTLANG_KOREAN      26
 #define CMBTLANG_LATVIAN     27
 #define CMBTLANG_LITHUANIAN  28
 #define CMBTLANG_NORWEGIAN   29
 #define CMBTLANG_POLISH      30
 #define CMBTLANG_PORTUGUESE  31
 #define CMBTLANG_ROMANIAN    32
 #define CMBTLANG_RUSSIAN     33
 #define CMBTLANG_SLOVAK      34
 #define CMBTLANG_SLOVENIAN   35
 #define CMBTLANG_SERBIAN     36
 #define CMBTLANG_SPANISH     37
 #define CMBTLANG_SWEDISH     38
 #define CMBTLANG_THAI        39
 #define CMBTLANG_TURKISH     40
 #define CMBTLANG_UKRAINIAN   41
 #define CMBTLANG_SERBIAN_LATIN  42
#endif

/*--- constant declarations ---*/

#define LL_LINK_HPOS_NONE              (0x0000)            
#define LL_LINK_HPOS_START             (0x0001)            
#define LL_LINK_HPOS_END               (0x0002)            
#define LL_LINK_HPOS_ABS               (0x0003)            
#define LL_LINK_HPOS_MASK              (0x0007)            
#define LL_LINK_VPOS_NONE              (0x0000)            
#define LL_LINK_VPOS_START             (0x0010)            
#define LL_LINK_VPOS_END               (0x0020)            
#define LL_LINK_VPOS_ABS               (0x0030)            
#define LL_LINK_VPOS_MASK              (0x0070)            
#define LL_LINK_HSIZE_NONE             (0x0000)            
#define LL_LINK_HSIZE_PROP             (0x0100)            
#define LL_LINK_HSIZE_INV              (0x0200)            
#define LL_LINK_HSIZE_MASK             (0x0300)            
#define LL_LINK_VSIZE_NONE             (0x0000)            
#define LL_LINK_VSIZE_PROP             (0x1000)            
#define LL_LINK_VSIZE_INV              (0x2000)            
#define LL_LINK_VSIZE_MASK             (0x3000)            
#define LL_LINK_SIZEPOS_MASK           (0x3377)            
#define LL_LINK_SIZEOFPARENT           (0x4000)            
#define LL_DESIGNERPRINTCALLBACK_PREVIEW_START (1)                 
#define LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT (2)                 
#define LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE (3)                 
#define LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE (4)                 
#define LL_DESIGNERPRINTCALLBACK_EXPORT_START (5)                 
#define LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT (6)                 
#define LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE (7)                 
#define LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE (8)                 
#define LL_DESIGNERPRINTTHREAD_STATE_STOPPED (0)                 
#define LL_DESIGNERPRINTTHREAD_STATE_SUSPENDED (1)                 
#define LL_DESIGNERPRINTTHREAD_STATE_RUNNING (2)                 
#define LL_INVOKEACTION_FLAG_SAVE_NO_PROJECTDESCRIPTIONCHECK (0x0001)             /* in HIWORD in LlDesignerInvokeAction */
#define LL_DRILLDOWN_START             (1)                 
#define LL_DRILLDOWN_FINALIZE          (2)                 
#define LL_PRINTJOB_FINALIZE           (3)                 
#define LL_JOBOPENFLAG_NOLLXPRELOAD    (0x00001000)        
#define LL_JOBOPENFLAG_ONLYEXACTLANGUAGE (0x00002000)         /* do not look for '@@' LNG file */
#define LL_JOBHANDLE_FLAG_NOTHREADCHECK (0x40000000)        
#define LL_JOBHANDLE_IDMASK            (0x00000fff)        
#define LL_DEBUG_CMBTLL                (0x0001)             /* debug CMBTLLnn.DLL */
#define LL_DEBUG_CMBTDWG               (0x0002)             /* debug CMBTDWnn.DLL */
#define LL_DEBUG_CMBTLL_NOCALLBACKS    (0x0004)            
#define LL_DEBUG_CMBTLL_NOSTORAGE      (0x0008)            
#define LL_DEBUG_CMBTLL_NOWAITDLG      (0x0010)            
#define LL_DEBUG_CMBTLL_NOSYSINFO      (0x0020)            
#define LL_DEBUG_CMBTLL_LOGTOFILE      (0x0040)            
#define LL_DEBUG_CMBTLS                (0x0080)             /* debug CMBTLSnn.DLL */
#define LL_DEBUG_PRNINFO               (0x0100)             /* issue basic printer operations */
#define LL_DEBUG_CMBTLL_OBJECTSTATES   (0x0400)             /* issue object states after drawing (realdata printing only) */
#define LL_DEBUG_NOPRIVACYDATA         (0x0800)             /* suppress field contents (useful if they might contain private data) */
#define LL_DEBUG_FORCE_SYSINFO         (0x1000)             /* issue sysinfo even though it has been issued once already */
#define LL_DEBUG_EVAL2HOSTEXPRESSION   (0x2000)             /* debug Eval2HostExpr processing */
#define LL_DEBUG_EXTENDED_DEBWINFLAGS  (0x80000000)         /* internal usage */
#define LL_VERSION_MAJOR               (1)                  /* direct return of major version (f.ex. 1) */
#define LL_VERSION_MINOR               (2)                  /* direct return of minor version (f.ex. 13) */
#define LL_CMND_DRAW_USEROBJ           (0)                  /* callback for LL_DRAWING_USEROBJ */
#define LL_CMND_EDIT_USEROBJ           (1)                  /* callback for LL_DRAWING_USEROBJ_DLG */
#define LL_CMND_GETSIZE_USEROBJ        (2)                 
#define LL_CMND_GETSIZE_USEROBJ_SCM    (3)                 
#define LL_CMND_GETSIZE_USEROBJ_PIXEL  (4)                 
#define LL_CMND_TABLELINE              (10)                 /* callback for LL_CB_TABLELINE */
#define LL_TABLE_LINE_HEADER           (0)                 
#define LL_TABLE_LINE_BODY             (1)                 
#define LL_TABLE_LINE_FOOTER           (2)                 
#define LL_TABLE_LINE_FILL             (3)                 
#define LL_TABLE_LINE_GROUP            (4)                 
#define LL_TABLE_LINE_GROUPFOOTER      (5)                 
#define LL_CMND_TABLEFIELD             (11)                 /* callback for LL_CB_TABLEFIELD */
#define LL_TABLE_FIELD_HEADER          (0)                 
#define LL_TABLE_FIELD_BODY            (1)                 
#define LL_TABLE_FIELD_FOOTER          (2)                 
#define LL_TABLE_FIELD_FILL            (3)                 
#define LL_TABLE_FIELD_GROUP           (4)                 
#define LL_TABLE_FIELD_GROUPFOOTER     (5)                 
#define LL_CMND_EVALUATE               (12)                 /* callback for "External$" function */
#define LL_CMND_OBJECT                 (20)                 /* callback of LL_CB_OBJECT */
#define LL_CMND_PAGE                   (21)                 /* callback of LL_CB_PAGE */
#define LL_CMND_PROJECT                (22)                 /* callback of LL_CB_PROJECT */
#define LL_CMND_DRAW_GROUP_BEGIN       (23)                 /* callback for LlPrintBeginGroup */
#define LL_CMND_DRAW_GROUP_END         (24)                 /* callback for LlPrintEndGroup */
#define LL_CMND_DRAW_GROUPLINE         (25)                 /* callback for LlPrintGroupLine */
#define LL_RSP_GROUP_IMT               (0)                 
#define LL_RSP_GROUP_NEXTPAGE          (1)                 
#define LL_RSP_GROUP_OK                (2)                 
#define LL_RSP_GROUP_DRAWFOOTER        (3)                 
#define LL_CMND_HELP                   (30)                 /* lParam: HIWORD=HELP_xxx, LOWORD=Context # */
#define LL_CMND_ENABLEMENU             (31)                 /* undoc: lParam/LOWORD(lParam) = HMENU */
#define LL_CMND_MODIFYMENU             (32)                 /* undoc: lParam/LOWORD(lParam) = HMENU */
#define LL_CMND_SELECTMENU             (33)                 /* undoc: lParam=ID (return TRUE if processed) */
#define LL_CMND_GETVIEWERBUTTONSTATE   (34)                 /* HIWORD(lParam)=ID, LOWORD(lParam)=state */
#define LL_CMND_VARHELPTEXT            (35)                 /* lParam=LPSTR(Name), returns LPSTR(Helptext) */
#define LL_INFO_METER                  (37)                 /* lParam = addr(scLlMeterInfo) */
#define LL_METERJOB_LOAD               (1)                 
#define LL_METERJOB_SAVE               (2)                 
#define LL_METERJOB_CONSISTENCYCHECK   (3)                 
#define LL_METERJOB_PASS2              (4)                 
#define LL_METERJOB_PASS3              (5)                 
#define LL_NTFY_FAILSFILTER            (1000)               /* data set fails filter expression */
#define LL_NTFY_VIEWERBTNCLICKED       (38)                 /* user presses a preview button (action will be done). lParam=ID. result: 0=allowed, 1=not allowed */
#define LL_CMND_DLGEXPR_VARBTN         (39)                 /* lParam: @scLlDlgExprVarExt, return: IDOK for ok */
#define LL_CMND_HOSTPRINTER            (40)                 /* lParam: scLlPrinter */
#define LL_PRN_CREATE_DC               (1)                  /* scLlPrinter._nCmd values */
#define LL_PRN_DELETE_DC               (2)                 
#define LL_PRN_SET_ORIENTATION         (3)                 
#define LL_PRN_GET_ORIENTATION         (4)                 
#define LL_PRN_EDIT                    (5)                  /* unused */
#define LL_PRN_GET_DEVICENAME          (6)                 
#define LL_PRN_GET_DRIVERNAME          (7)                 
#define LL_PRN_GET_PORTNAME            (8)                 
#define LL_PRN_RESET_DC                (9)                 
#define LL_PRN_COMPARE_PRINTER         (10)                
#define LL_PRN_GET_PHYSPAGE            (11)                
#define LL_PRN_SET_PHYSPAGE            (12)                
#define LL_PRN_GET_PAPERFORMAT         (13)                 /* fill _nPaperFormat */
#define LL_PRN_SET_PAPERFORMAT         (14)                 /* _nPaperFormat, _xPaperSize, _yPaperSize */
#define LL_OEM_TOOLBAR_START           (41)                
#define LL_OEM_TOOLBAR_END             (50)                
#define LL_NTFY_EXPRERROR              (51)                 /* lParam = LPCSTR(error text) */
#define LL_CMND_CHANGE_DCPROPERTIES_CREATE (52)                 /* lParam = addr(scLlPrinter), _hDC is valid */
#define LL_CMND_CHANGE_DCPROPERTIES_DOC (53)                 /* lParam = addr(scLlPrinter), _hDC is valid */
#define LL_CMND_CHANGE_DCPROPERTIES_PAGE (54)                 /* lParam = addr(scLlPrinter), _hDC is valid */
#define LL_CMND_CHANGE_DCPROPERTIES_PREPAGE (56)                 /* lParam = addr(scLlPrinter), _hDC and _pszBuffer( DEVMODE* ) are valid */
#define LL_CMND_MODIFY_METAFILE        (57)                 /* lParam = handle of EMF (enh. metafile) */
#define LL_INFO_PRINTJOBSUPERVISION    (58)                 /* lParam = addr(scLlPrintJobInfo) */
#define LL_CMND_DELAYEDVALUE           (59)                 /* lParam = addr(scLlDelayedValue) */
#define LL_CMND_SUPPLY_USERDATA        (60)                 /* lParam = addr(scLlProjectUserData) */
#define LL_CMND_SAVEFILENAME           (61)                 /* lParam = LPCTSTR(Filename) */
#define LL_QUERY_IS_VARIABLE_OR_FIELD  (62)                 /* lParam = addr(scLlDelayDefineFieldOrVariable), must be enabled by CB mask. If returns TRUE, the var must be defined in the callback... */
#define LL_NTFY_PROJECTLOADED          (63)                 /* lParam = 0 */
#define LL_QUERY_DESIGNERACTIONSTATE   (64)                
#define LL_NTFY_DESIGNERREADY          (65)                 /* lParam = 0 */
#define LL_NTFY_DESIGNERPRINTJOB       (66)                
#define LL_NTFY_VIEWERDRILLDOWN        (67)                
#define LL_NTFY_QUEST_DRILLDOWNDENIED  (68)                 /* see LS_VIEWERCONTROL_QUEST_DRILLDOWNDENIED */
#define LL_QUERY_DRILLDOWN_ADDITIONAL_BASETABLES_FOR_VARIABLES (69)                 /* lParam = scLlDDFilterInfo* */
#define LL_QUERY_DRILLDOWN_ADDITIONAL_TABLES (70)                 /* lParam = scLlDDFilterInfo* */
#define LL_NTFY_DRILLDOWN_DESIGNERACTION (71)                 /* lParam = scLlDDDesignerActionW* */
#define LL_NTFY_INPLACEDESIGNER_START  (72)                
#define LL_NTFY_INPLACEDESIGNER_END    (73)                
#define LL_QUERY_OWN_MENU              (74)                 /* lParam = HMENU -> return 1 if uses own menu */
#define LL_CMND_UPDATE_MENU            (75)                
#define LL_NTFY_FRAMEHANDLE            (76)                 /* lParam -> handle of layout window ("L&LFrame") */
#define LL_QUERY_DEFAULTPROJECTSTREAM  (77)                 /* lParam -> IStream**. Return NONZERO when stream contains data */
#define LL_NTFY_QUEST_RP_REALDATAJOBDENIED (78)                
#define LL_NTFY_QUEST_EXPANDABLEREGIONSJOBDENIED (79)                
#define LL_NTFY_QUEST_INTERACTIVESORTINGJOBDENIED (80)                
#define LL_QUERY_EXPR2HOSTEXPRESSION   (81)                 /* lParam = LLEXPR2HOSTEXPR*, return 0 for FAIL, 1 for OPTIMAL, 2 for INEXACT */
#define LL_NTFY_REPORTPARAMETERS_COLLECTED (82)                 /* lParam = &scNtfyReportparametersCollected, return LL_ERR_USER_ABORTED to abort, 0x01 to get RP stream, 0x02 to get RP contents, 0 to leave processing */
#define LL_NTFY_EXPORTERPAGEFINISHED   (83)                 /* lParam = &scNtfyExporterPageFinished */
#define LL_NTFY_HYPERLINK              (84)                 /* lParam = &scNtfyHyperlink */
#define LL_NTFY_SAVEREPORTSTATEITEM    (85)                 /* lParam = &scLLNtfyReportStateItem */
#define LL_NTFY_RESTOREREPORTSTATEITEM (86)                 /* lParam = &scLLNtfyReportStateItem */
#define LL_NTFY_PROGRESS               (87)                 /* lParam -> percentage of current progress */
#define LL_NTFY_TRIGGEREDJOBINUITHREAD (88)                 /* lParam -> user data */
#define LL_NTFY_PLEASE_TRANSLATE       (89)                 /* lParam=BSTR* */
#define LL_NTFY_PREVIEW_PRINT_START    (99)                 /* lParam = &scViewerControlPrintData, return 1 to abort print */
#define LL_NTFY_PREVIEW_PRINT_PAGE     (100)                /* lParam = &scViewerControlPrintData, return 1 to abort loop */
#define LL_NTFY_PREVIEW_PRINT_END      (101)                /* lParam = &scViewerControlPrintData */
#define LL_NTFY_EMF_PAGE               (102)                /* lParam = &scLLNtfyEMF */
#define LL_QUERY_FILENAME_FOR_EXPORTJOB (103)                /* lParam = VARIANT* (in: old filename, out:new filename) */
#define LL_QUERY_OBJECT_NOT_SUPPORTED  (104)                /* lParam = &scLLQueryObjectAllowed */
#define LL_QUERY_REPLACE_FILESYSTEMITEM (105)                /* lParam = &scLLQueryFilenameReplacement -> return 1 if replaced */
#define LL_QUERY_HOSTIMPORT            (106)                /* lParam = &scLlNtfyHostImport -> return 1 if LL's internal routine is superseded */
#define LL_NTFY_PREVIEW_ACTIONRESULT   (107)                /* see LS_VIEWERCONTROL_NTFY_ACTIONRESULT - for RealDataPreview */
#define LL_NTFY_DATA_LOSS              (108)                /* lParam = LL_NTFYDATALOSS_XXX */
#define LL_NTFYDATALOSS_RTFDETECTION_NOT_ENOUGH_SPACE (1)                 
#define LL_NTFY_REPORTPARAMETERS_COLLECTION_FINISHED (109)                /* lParam and result: see LL_NTFY_REPORTPARAMETERS_COLLECTED */
#define LL_NTFY_EXPRERROR_EX           (110)                /* lParam = @scLlNtfyExprErrorEx */
#define LL_NTFY_EXPORTERPAGECOUNT      (111)                /* lParam = &scLLNtfyExporterPageCount */
#define LL_NTFY_FIND_AND_REPLACE       (112)                /* lParam = &scLLNtfyFindAndReplace, returns: 0 to replace, 1 to skip, 2 to cancel search globally */
#define LL_NTFY_PROJECTLOAD_EX         (113)                /* lParam = &scLLNtfyProjectLoadEx, called before a project is loaded. SetErrortext to abort loading. */
#define LL_NTFY_JOBWILLCHANGE          (114)                /* internal */
#define LL_NTFY_COMBINATIONPRINTSTEP   (115)                /* lParam = &scLlCombinationPrintStep, return 0 on OK, 1 to reset the page number, 2 to reset the page number and total pages or error code on error */
#define LL_NTFY_LOADERROR_DATABASESTRUCTURE (116)                /* lParam = @scLlNtfyDatabaseError */
#define LL_NTFY_KEEP_FILE              (117)                /* lParam = (LPCWSTR)filename of file to be kept until the end of the (print) job */
#define LL_PROJECT_LABEL               (1)                  /* new names... */
#define LL_PROJECT_LIST                (2)                 
#define LL_PROJECT_CARD                (3)                 
#define LL_PROJECT_TOC                 (4)                 
#define LL_PROJECT_IDX                 (5)                 
#define LL_PROJECT_GTC                 (6)                 
#define LL_PROJECT_LAST                (6)                 
#define LL_PROJECT_MASK                (0x000f)            
#define LL_OBJ_MARKER                  (0)                  /* internal use only */
#define LL_OBJ_TEXT                    (1)                  /* the following are used in the object callback */
#define LL_OBJ_RECT                    (2)                 
#define LL_OBJ_LINE                    (3)                 
#define LL_OBJ_BARCODE                 (4)                 
#define LL_OBJ_DRAWING                 (5)                 
#define LL_OBJ_TABLE                   (6)                 
#define LL_OBJ_TEMPLATE                (7)                 
#define LL_OBJ_ELLIPSE                 (8)                 
#define LL_OBJ_GROUP                   (9)                  /* internal use only */
#define LL_OBJ_RTF                     (10)                
#define LL_OBJ_LLX                     (11)                
#define LL_OBJ_INPUT                   (12)                
#define LL_OBJ_LAST                    (12)                 /* last object type (for loops as upper bound) - if this is changed, change the contants in object.c too! */
#define LL_OBJ_REPORTCONTAINER         (253)                /* for exporter */
#define LL_OBJ_PROJECT                 (254)                /* for exporter */
#define LL_OBJ_PAGE                    (255)                /* for exporter */
#define LL_DELAYEDVALUE                (0x80000000)        
#define LL_TYPEMASK                    (0x7fff0000)        
#define LL_ANYTYPE                     (0x7fff0000)        
#define LL_TABLE_FIELDTYPEMASK         (0x0000f800)         /* internal use */
#define LL_SUBTYPEMASK                 (0x000000ff)        
#define LL_TYPEFLAGS                   (0x8000f800)        
#define LL_CONTENTSFLAG_SOURCE_IS_NULL (0x00000400)         /* for cRM */
#define LL_VARTYPEFLAGSMASK            (0x00000400)        
#define LL_TABLE_FOOTERFIELD           (0x00008000)         /* 'or'ed for footline-only fields // reserved also for Variables (see "$$xx$$")!!!! */
#define LL_TABLE_GROUPFIELD            (0x00004000)         /* 'or'ed for groupline-only fields */
#define LL_TABLE_HEADERFIELD           (0x00002000)         /* 'or'ed for headline-only fields */
#define LL_TABLE_BODYFIELD             (0x00001000)         /* 'or'ed for headline-only fields */
#define LL_TABLE_GROUPFOOTERFIELD      (0x00000800)         /* 'or'ed for group-footer-line-only fields */
#define LL_BARCODE                     (0x40000000)        
#define LL_BARCODE_METHODMASK          (0x000000ff)        
#define LL_BARCODE_WITHTEXT            (0x00000100)        
#define LL_BARCODE_WITHOUTTEXT         (0x00000200)        
#define LL_BARCODE_TEXTDONTCARE        (0x00000000)        
#define LL_BARCODE_EAN13               (0x40000000)        
#define LL_BARCODE_EAN8                (0x40000001)        
#define LL_BARCODE_GTIN13              (0x40000000)        
#define LL_BARCODE_GTIN8               (0x40000001)        
#define LL_BARCODE_UPCA                (0x40000002)        
#define LL_BARCODE_UPCE                (0x40000003)        
#define LL_BARCODE_3OF9                (0x40000004)        
#define LL_BARCODE_25INDUSTRIAL        (0x40000005)        
#define LL_BARCODE_25INTERLEAVED       (0x40000006)        
#define LL_BARCODE_25DATALOGIC         (0x40000007)        
#define LL_BARCODE_25MATRIX            (0x40000008)        
#define LL_BARCODE_POSTNET             (0x40000009)        
#define LL_BARCODE_FIM                 (0x4000000A)        
#define LL_BARCODE_CODABAR             (0x4000000B)        
#define LL_BARCODE_EAN128              (0x4000000C)        
#define LL_BARCODE_GS1_128             (0x4000000C)        
#define LL_BARCODE_CODE128             (0x4000000D)        
#define LL_BARCODE_DP_LEITCODE         (0x4000000E)        
#define LL_BARCODE_DP_IDENTCODE        (0x4000000F)        
#define LL_BARCODE_GERMAN_PARCEL       (0x40000010)        
#define LL_BARCODE_CODE93              (0x40000011)        
#define LL_BARCODE_MSI                 (0x40000012)        
#define LL_BARCODE_CODE11              (0x40000013)        
#define LL_BARCODE_MSI_10_CD           (0x40000014)        
#define LL_BARCODE_MSI_10_10           (0x40000015)        
#define LL_BARCODE_MSI_11_10           (0x40000016)        
#define LL_BARCODE_MSI_PLAIN           (0x40000017)        
#define LL_BARCODE_EAN14               (0x40000018)        
#define LL_BARCODE_GTIN14              (0x40000018)        
#define LL_BARCODE_UCC14               (0x40000019)        
#define LL_BARCODE_CODE39              (0x4000001A)        
#define LL_BARCODE_CODE39_CRC43        (0x4000001B)        
#define LL_BARCODE_PZN                 (0x4000001C)        
#define LL_BARCODE_CODE39_EXT          (0x4000001D)        
#define LL_BARCODE_JAPANESE_POSTAL     (0x4000001E)        
#define LL_BARCODE_RM4SCC              (0x4000001F)        
#define LL_BARCODE_RM4SCC_CRC          (0x40000020)        
#define LL_BARCODE_SSCC                (0x40000021)        
#define LL_BARCODE_ISBN                (0x40000022)        
#define LL_BARCODE_GS1                 (0x40000023)        
#define LL_BARCODE_GS1_TRUNCATED       (0x40000024)        
#define LL_BARCODE_GS1_STACKED         (0x40000025)        
#define LL_BARCODE_GS1_STACKED_OMNI    (0x40000026)        
#define LL_BARCODE_GS1_LIMITED         (0x40000027)        
#define LL_BARCODE_GS1_EXPANDED        (0x40000028)        
#define LL_BARCODE_INTELLIGENT_MAIL    (0x40000029)        
#define LL_BARCODE_PZN8                (0x4000002A)        
#define LL_BARCODE_CODE128_FULL        (0x4000002B)        
#define LL_BARCODE_EAN128_FULL         (0x4000002C)        
#define LL_BARCODE_CODABLOCK_F         (0x4000002D)        
#define LL_BARCODE_PHARMACODE          (0x4000002E)        
#define LL_BARCODE_LLXSTART            (0x40000040)        
#define LL_BARCODE_PDF417              (0x40000040)        
#define LL_BARCODE_MAXICODE            (0x40000041)        
#define LL_BARCODE_MAXICODE_UPS        (0x40000042)        
#define LL_BARCODE_DATAMATRIX          (0x40000044)        
#define LL_BARCODE_AZTEC               (0x40000045)        
#define LL_BARCODE_QRCODE              (0x40000046)        
#define LL_BARCODE_DATAMATRIX_PREMIUMADRESS (0x40000047)        
#define LL_BARCODE_MICROPDF417         (0x40000048)        
#define LL_BARCODE_QR_EPC              (0x40000049)        
#define LL_BARCODE_QR_DESIGN           (0x40000050)        
#define LL_DRAWING                     (0x20000000)        
#define LL_DRAWING_METHODMASK          (0x000000ff)        
#define LL_DRAWING_HMETA               (0x20000001)        
#define LL_DRAWING_USEROBJ             (0x20000002)        
#define LL_DRAWING_USEROBJ_DLG         (0x20000003)        
#define LL_DRAWING_HBITMAP             (0x20000004)        
#define LL_DRAWING_HICON               (0x20000005)        
#define LL_DRAWING_HEMETA              (0x20000006)        
#define LL_DRAWING_HDIB                (0x20000007)         /* global handle to BITMAPINFO and bits */
#define LL_META_MAXX                   (10000)             
#define LL_META_MAXY                   (10000)             
#define LL_TEXT                        (0x10000000)        
#define LL_TEXT_ALLOW_WORDWRAP         (0x10000000)        
#define LL_TEXT_DENY_WORDWRAP          (0x10000001)        
#define LL_TEXT_FORCE_WORDWRAP         (0x10000002)        
#define LL_NUMERIC                     (0x08000000)        
#define LL_NUMERIC_LOCALIZED           (0x08000001)        
#define LL_NUMERIC_INTEGER             (0x08000002)         /* flag */
#define LL_DATE                        (0x04000000)         /* LL's own julian */
#define LL_DATE_METHODMASK             (0x000000ff)        
#define LL_DATE_DELPHI_1               (0x04000001)        
#define LL_DATE_DELPHI                 (0x04000002)         /* DELPHI 2, 3, 4: OLE DATE */
#define LL_DATE_MS                     (0x04000002)         /* MS C/Basic: OLE DATE */
#define LL_DATE_OLE                    (0x04000002)         /* generic: OLE DATE */
#define LL_DATE_VFOXPRO                (0x04000003)         /* nearly LL's own julian, has an offset of 1! */
#define LL_DATE_DMY                    (0x04000004)         /* <d><sep><m><sep><yyyy>. Year MUST be 4 digits! */
#define LL_DATE_MDY                    (0x04000005)         /* <m><sep><d><sep><yyyy>. Year MUST be 4 digits! */
#define LL_DATE_YMD                    (0x04000006)         /* <yyyy><sep><m><sep><d>. Year MUST be 4 digits! */
#define LL_DATE_YYYYMMDD               (0x04000007)         /* <yyyymmdd> */
#define LL_DATE_LOCALIZED              (0x04000008)         /* localized (automatic VariantConversion) */
#define LL_DATE_JULIAN                 (0x04000009)         /* variant 'date' is a julian date */
#define LL_DATE_CLARION                (0x0400000a)         /* days since 1800-12-28 (what's so special about that day?) */
#define LL_DATE_YMD_AUTO               (0x04000010)         /* wither DMY, MDY or YMD, automatically detected */
#define LL_DATE_ISO8601                (0x04000011)         /* ISO 8601 date format (but without time zone *names* except 'Z') */
#define LL_BOOLEAN                     (0x02000000)        
#define LL_RTF                         (0x01000000)        
#define LL_HTML                        (0x00800000)        
#define LL_PDF                         (0x00400000)        
#define LL_INPUTOBJECT                 (0x00200000)         /* internal use only */
#define LL_LLXOBJECT                   (0x00100000)         /* internal use only */
#define LL_SUBTABLELIST                (0x00080000)         /* internal use only */
#define LL_RETURN_ERROR_IF_FILE_NOT_FOUND (0x00010000)        
#define LL_FIXEDNAME                   (0x00008000)        
#define LL_NOSAVEAS                    (0x00004000)        
#define LL_DESIGNER_OVER_CHILD         (0x00002000)        
#define LL_EXPRCONVERTQUIET            (0x00001000)         /* convert to new expressions without warning box */
#define LL_NONAMEINTITLE               (0x00000800)         /* no file name appended to title */
#define LL_PRVOPT_PRN_USEDEFAULT       (0x00000000)        
#define LL_PRVOPT_PRN_ASKPRINTERIFNEEDED (0x00000001)        
#define LL_PRVOPT_PRN_ASKPRINTERALWAYS (0x00000002)        
#define LL_PRVOPT_PRN_ALWAYSUSEDEFAULT (0x00000003)        
#define LL_PRVOPT_PRN_ASSIGNMASK       (0x00000003)         /* used by L&L */
#define LL_PRVOPT_FLAG_STANDALONEVIEWER (0x00000010)        
#define LL_OPTION_COPIES               (0)                  /* compatibility only, please use LL_PRNOPT_...   */
#define LL_OPTION_STARTPAGE            (1)                  /* compatibility only, please use LL_PRNOPT_PAGE  */
#define LL_OPTION_PAGE                 (1)                  /* compatibility only, please use LL_PRNOPT_...  */
#define LL_OPTION_OFFSET               (2)                  /* compatibility only, please use LL_PRNOPT_...  */
#define LL_OPTION_COPIES_SUPPORTED     (3)                  /* compatibility only, please use LL_PRNOPT_...  */
#define LL_OPTION_FIRSTPAGE            (5)                  /* compatibility only, please use LL_PRNOPT_...  */
#define LL_OPTION_LASTPAGE             (6)                  /* compatibility only, please use LL_PRNOPT_...  */
#define LL_OPTION_JOBPAGES             (7)                  /* compatibility only, please use LL_PRNOPT_...  */
#define LL_OPTION_PRINTORDER           (8)                  /* compatibility only, please use LL_PRNOPT_...  */
#define LL_PRNOPT_COPIES               (0)                 
#define LL_COPIES_HIDE                 (-32768)             /* anything negative... */
#define LL_PRNOPT_STARTPAGE            (1)                 
#define LL_PRNOPT_PAGE                 (1)                  /* ; please do not use STARTPAGE any more... */
#define LL_PAGE_HIDE                   (-32768)             /* must be exactly this value! */
#define LL_PRNOPT_OFFSET               (2)                 
#define LL_PRNOPT_COPIES_SUPPORTED     (3)                 
#define LL_PRNOPT_UNITS                (4)                  /* r/o */
#define LL_UNITS_MM_DIV_10             (0)                  /* for LL_PRNOPT_UNITS, LL_OPTION_UNITS and LL_OPTION_UNITS_DEFAULT */
#define LL_UNITS_INCH_DIV_100          (1)                 
#define LL_UNITS_INCH_DIV_1000         (2)                 
#define LL_UNITS_SYSDEFAULT_LORES      (3)                  /* mm/10, in/100 (depending on regional settings of the system) */
#define LL_UNITS_SYSDEFAULT            (4)                  /* mm/100, in/1000 (depending on regional settings of the system) */
#define LL_UNITS_MM_DIV_100            (5)                 
#define LL_UNITS_MM_DIV_1000           (6)                 
#define LL_UNITS_SYSDEFAULT_HIRES      (7)                  /* mm/100, in/1000 (depending on regional settings of the system) */
#define LL_PRNOPT_FIRSTPAGE            (5)                 
#define LL_PRNOPT_LASTPAGE             (6)                 
#define LL_PRNOPT_JOBPAGES             (7)                 
#define LL_PRNOPT_PRINTORDER           (8)                 
#define LL_PRINTORDER_HORZ_LTRB        (0)                 
#define LL_PRINTORDER_VERT_LTRB        (1)                 
#define LL_PRINTORDER_HORZ_RBLT        (2)                 
#define LL_PRINTORDER_VERT_RBLT        (3)                 
#define LL_PRNOPT_DEFPRINTERINSTALLED  (11)                 /* returns 0 for no default printer, 1 for default printer present */
#define LL_PRNOPT_PRINTDLG_DESTMASK    (12)                 /* any combination of the ones below... Default: all. Outdated, please use LL_OPTIONSTR_EXPORTS_ALLOWED */
#define LL_DESTINATION_PRN             (1)                 
#define LL_DESTINATION_PRV             (2)                 
#define LL_DESTINATION_FILE            (4)                 
#define LL_DESTINATION_EXTERN          (8)                 
#define LL_DESTINATION_MSFAX           (16)                 /* reserved */
#define LL_PRNOPT_PRINTDLG_DEST        (13)                 /* default destination; outdated, please use LL_PRNOPTSTR_EXPORT */
#define LL_PRNOPT_PRINTDLG_ONLYPRINTERCOPIES (14)                 /* show copies option in dialog only if they are supported by the printer. default: false */
#define LL_PRNOPT_JOBID                (17)                
#define LL_PRNOPT_PAGEINDEX            (18)                
#define LL_PRNOPT_USES2PASS            (19)                 /* r/o */
#define LL_PRNOPT_PAGERANGE_USES_ABSOLUTENUMBER (20)                 /* default: false */
#define LL_PRNOPT_USEMEMORYMETAFILE    (22)                 /* default: false */
#define LL_PRNOPT_PARTIALPREVIEW       (23)                 /* default: false */
#define LL_PRNOPT_ADDITIONALPAGES_FOR_TOTAL (24)                 /* internal */
#define LL_PRNOPT_HAS_TOTALPAGES       (25)                 /* internal */
#define LL_PRNOPT_COUNT_OF_ITEMS       (26)                 /* labels/cards */
#define LL_PRNOPT_IS_PREPROCESSING     (27)                
#define LL_PRNOPT_PRINTDLG_ALLOW_NUMBER_OF_FIRST_PAGE (28)                
#define LL_PRNOPT_NEXT_INDEX           (29)                
#define LL_PRNOPTSTR_PRINTDST_FILENAME (0)                  /* print to file: default filename (LlGet/SetPrintOptionString) */
#define LL_PRNOPTSTR_EXPORTDESCR       (1)                  /* r/o, returns the description of the export chosen */
#define LL_PRNOPTSTR_EXPORT            (2)                  /* sets default exporter to use / returns the name of the export chosen */
#define LL_PRNOPTSTR_PRINTJOBNAME      (3)                  /* set name to be given to StartDoc() (lpszMessage of LlPrintWithBoxStart() */
#define LL_PRNOPTSTR_PRESTARTDOCESCSTRING (4)                  /* sent before StartDoc() */
#define LL_PRNOPTSTR_POSTENDDOCESCSTRING (5)                  /* sent after EndDoc() */
#define LL_PRNOPTSTR_PRESTARTPAGEESCSTRING (6)                  /* sent before StartPage() */
#define LL_PRNOPTSTR_POSTENDPAGEESCSTRING (7)                  /* sent after EndPage() */
#define LL_PRNOPTSTR_PRESTARTPROJECTESCSTRING (8)                  /* sent before first StartPage() of project */
#define LL_PRNOPTSTR_POSTENDPROJECTESCSTRING (9)                  /* sent after last EndPage() of project */
#define LL_PRNOPTSTR_PAGERANGES        (10)                
#define LL_PRNOPTSTR_ISSUERANGES       (11)                
#define LL_PRNOPTSTR_PREVIEWTITLE      (12)                 /* default: language dependent */
#define LL_PRNOPTSTR_PRINTDLG_ALWAYSSHOWCOPIESFOR (13)                 /* default: empty string */
#define LL_PRNOPTSTR_NEXT_INDEX        (14)                
#define LL_PRINT_V1POINTX              (0x00000000)        
#define LL_PRINT_NORMAL                (0x00000100)        
#define LL_PRINT_PREVIEW               (0x00000200)        
#define LL_PRINT_STORAGE               (0x00000200)         /* same as LL_PRINT_PREVIEW */
#define LL_PRINT_FILE                  (0x00000400)        
#define LL_PRINT_USERSELECT            (0x00000800)        
#define LL_PRINT_EXPORT                (0x00000800)         /* same as LL_PRINT_USERSELECT */
#define LL_PRINT_MODEMASK              (0x00000f00)        
#define LL_PRINT_MULTIPLE_JOBS         (0x00001000)        
#define LL_PRINT_KEEPJOB               (0x00002000)        
#define LL_PRINT_IS_DOM_CALLER         (0x00004000)         /* internal */
#define LL_PRINT_DOM_NOCREATEDC        (0x00010000)         /* internal */
#define LL_PRINT_DOM_NOOBJECTLOAD      (0x00020000)         /* internal */
#define LL_PRINT_REMOVE_UNUSED_VARS    (0x00008000)         /* optimization flag */
#define LL_PRINT_OPTIMIZE_PRINTERS_IN_PRV_PRINT (0x00040000)         /* optimization flag */
#define LL_BOXTYPE_BOXTYPEMASK         (0x000000ff)        
#define LL_BOXTYPE_NONE                (0x000000ff)        
#define LL_BOXTYPE_FLAG_ALLOWSUSPEND   (0x40000000)        
#define LL_BOXTYPE_FLAG_USEMARQUEE     (0x80000000)        
#define LL_BOXTYPE_NORMALMETER         (0)                 
#define LL_BOXTYPE_BRIDGEMETER         (1)                 
#define LL_BOXTYPE_NORMALWAIT          (2)                 
#define LL_BOXTYPE_BRIDGEWAIT          (3)                 
#define LL_BOXTYPE_EMPTYWAIT           (4)                 
#define LL_BOXTYPE_EMPTYABORT          (5)                 
#define LL_BOXTYPE_STDWAIT             (6)                 
#define LL_BOXTYPE_STDABORT            (7)                 
#define LL_BOXTYPE_MAX                 (7)                 
#define LL_FILE_ALSONEW                (0x00008000)        
#define LL_SELECTFILEDLGTITLE_USE_OSFILENAME (0x00010000)        
#define LL_FILE_FORCE_OS_DIALOG        (0x00020000)        
#define LL_FCTPARATYPE_DOUBLE          (0x0001)            
#define LL_FCTPARATYPE_DATE            (0x0002)            
#define LL_FCTPARATYPE_STRING          (0x0004)            
#define LL_FCTPARATYPE_BOOL            (0x0008)            
#define LL_FCTPARATYPE_DRAWING         (0x0010)            
#define LL_FCTPARATYPE_BARCODE         (0x0020)            
#define LL_FCTPARATYPE_ALL             (0x003f)            
#define LL_FCTPARATYPE_PARA1           (0x8001)            
#define LL_FCTPARATYPE_PARA2           (0x8002)            
#define LL_FCTPARATYPE_PARA3           (0x8003)            
#define LL_FCTPARATYPE_PARA4           (0x8004)            
#define LL_FCTPARATYPE_SAME            (0x803f)            
#define LL_FCTPARATYPE_MASK            (0x8fff)            
#define LL_FCTPARATYPEFLAG_NONULLCHECK (0x00010000)        
#define LL_FCTPARATYPEFLAG_MULTIDIM_ALLOWED (0x00020000)         /* internal */
#define LL_FCTPARATYPEFLAG_RAW         (0x00080000)         /* parameter passed as string without evaluation */
#define LL_FCTPARATYPEFLAG_RAW_WITH_SYNTAXCHECK (0x00040000)         /* parameter passed as string without evaluation */
#define LL_FCTPARATYPEFLAG_KEEP_LINEBREAKS (0x00100000)        
#define LL_FCTPARATYPEFLAG_EXECUTE_ON_SYNTAXCHECK_AT_LOADTIME (0x00200000)        
#define LL_EXPRTYPE_DOUBLE             (1)                 
#define LL_EXPRTYPE_DATE               (2)                 
#define LL_EXPRTYPE_STRING             (3)                 
#define LL_EXPRTYPE_BOOL               (4)                 
#define LL_EXPRTYPE_DRAWING            (5)                 
#define LL_EXPRTYPE_BARCODE            (6)                 
#define LL_OPTION_NEWEXPRESSIONS       (0)                  /* default: true */
#define LL_OPTION_ONLYONETABLE         (1)                  /* default: false */
#define LL_OPTION_TABLE_COLORING       (2)                  /* default: LL_COLORING_LL */
#define LL_COLORING_LL                 (0)                 
#define LL_COLORING_PROGRAM            (1)                 
#define LL_COLORING_DONTCARE           (2)                 
#define LL_OPTION_SUPERVISOR           (3)                  /* default: false */
#define LL_OPTION_UNITS                (4)                  /* default: see LL_OPTION_METRIC */
#define LL_OPTION_TABSTOPS             (5)                  /* default: LL_TABS_DELETE  */
#define LL_TABS_DELETE                 (0)                 
#define LL_TABS_EXPAND                 (1)                 
#define LL_OPTION_CALLBACKMASK         (6)                  /* default: 0x00000000 */
#define LL_CB_PAGE                     (0x40000000)         /* callback for each page */
#define LL_CB_PROJECT                  (0x20000000)         /* callback for each label */
#define LL_CB_OBJECT                   (0x10000000)         /* callback for each object */
#define LL_CB_HELP                     (0x08000000)         /* callback for HELP (F1/Button) */
#define LL_CB_TABLELINE                (0x04000000)         /* callback for table line */
#define LL_CB_TABLEFIELD               (0x02000000)         /* callback for table field */
#define LL_CB_QUERY_IS_VARIABLE_OR_FIELD (0x01000000)         /* callback for delayload (LL_QUERY_IS_VARIABLE_OR_FIELD) */
#define LL_OPTION_CALLBACKPARAMETER    (7)                  /* default: 0 */
#define LL_OPTION_HELPAVAILABLE        (8)                  /* default: true */
#define LL_OPTION_SORTVARIABLES        (9)                  /* default: true */
#define LL_OPTION_SUPPORTPAGEBREAK     (10)                 /* default: true */
#define LL_OPTION_SHOWPREDEFVARS       (11)                 /* default: true */
#define LL_OPTION_USEHOSTPRINTER       (13)                 /* default: false // use host printer via callback */
#define LL_OPTION_EXTENDEDEVALUATION   (14)                 /* allows expressions in chevrons (amwin mode) */
#define LL_OPTION_TABREPRESENTATIONCODE (15)                 /* default: 247 (0xf7) */
#define LL_OPTION_SHOWSTATE            (16)                 /* r/o,  */
#define LL_OPTION_METRIC               (18)                 /* default: depends on Windows defaults */
#define LL_OPTION_ADDVARSTOFIELDS      (19)                 /* default: false */
#define LL_OPTION_MULTIPLETABLELINES   (20)                 /* default: true */
#define LL_OPTION_CONVERTCRLF          (21)                 /* default: true */
#define LL_OPTION_WIZ_FILENEW          (22)                 /* default: false */
#define LL_OPTION_RETREPRESENTATIONCODE (23)                 /* default: LL_CHAR_NEWLINE (182) */
#define LL_OPTION_PRVZOOM_PERC         (25)                 /* initial preview zoom */
#define LL_OPTION_PRVRECT_LEFT         (26)                 /* initial preview position */
#define LL_OPTION_PRVRECT_TOP          (27)                
#define LL_OPTION_PRVRECT_WIDTH        (28)                
#define LL_OPTION_PRVRECT_HEIGHT       (29)                
#define LL_OPTION_STORAGESYSTEM        (30)                 /* DEPRECATED. Do not change. 0=LX4-compatible, 1=STORAGE (default)  */
#define LL_STG_COMPAT4                 (0)                 
#define LL_STG_STORAGE                 (1)                 
#define LL_OPTION_COMPRESSSTORAGE      (31)                 /* 0, 1, 10..17 */
#define LL_STG_COMPRESS_THREADED       (0x00008000)        
#define LL_STG_COMPRESS_UNTHREADED     (0x00010000)        
#define LL_OPTION_NOPARAMETERCHECK     (32)                 /* you need a bit more speed? */
#define LL_OPTION_NONOTABLECHECK       (33)                 /* don't check on "NO_TABLEOBJECT" error. Default TRUE (don't check) */
#define LL_OPTION_DRAWFOOTERLINEONPRINT (34)                 /* delay footerline printing to LlPrint(). Default FALSE */
#define LL_OPTION_PRVZOOM_LEFT         (35)                 /* initial preview position in percent of screen */
#define LL_OPTION_PRVZOOM_TOP          (36)                
#define LL_OPTION_PRVZOOM_WIDTH        (37)                
#define LL_OPTION_PRVZOOM_HEIGHT       (38)                
#define LL_OPTION_SPACEOPTIMIZATION    (40)                 /* default: true */
#define LL_OPTION_REALTIME             (41)                 /* default: false */
#define LL_OPTION_AUTOMULTIPAGE        (42)                 /* default: true */
#define LL_OPTION_USEBARCODESIZES      (43)                 /* default: false */
#define LL_OPTION_MAXRTFVERSION        (44)                 /* default: 0xff00 */
#define LL_OPTION_VARSCASESENSITIVE    (46)                 /* default: false */
#define LL_OPTION_DELAYTABLEHEADER     (47)                 /* default: true */
#define LL_OPTION_OFNDIALOG_EXPLORER   (48)                 /* DEPRECATED. Do not change.  */
#define LL_OPTION_OFN_NOPLACESBAR      (0x40000000)        
#define LL_OPTION_EMFRESOLUTION        (49)                 /* DEPRECATED. Do not change.  */
#define LL_OPTION_SETCREATIONINFO      (50)                 /* default: true */
#define LL_OPTION_XLATVARNAMES         (51)                 /* default: true */
#define LL_OPTION_LANGUAGE             (52)                 /* returns current language (r/o) */
#define LL_OPTION_PHANTOMSPACEREPRESENTATIONCODE (54)                 /* default: LL_CHAR_PHANTOMSPA */
#define LL_OPTION_LOCKNEXTCHARREPRESENTATIONCODE (55)                 /* default: LL_CHAR_LOCK */
#define LL_OPTION_EXPRSEPREPRESENTATIONCODE (56)                 /* default: LL_CHAR_EXPRSEP */
#define LL_OPTION_DEFPRINTERINSTALLED  (57)                 /* r/o */
#define LL_OPTION_CALCSUMVARSONINVISIBLELINES (58)                 /* default: false - only default value if no preferences in project */
#define LL_OPTION_NOFOOTERPAGEWRAP     (59)                 /* default: false - only default value if no preferences in project */
#define LL_OPTION_IMMEDIATELASTPAGE    (64)                 /* default: true */
#define LL_OPTION_LCID                 (65)                 /* default: LOCALE_USER_DEFAULT */
#define LL_OPTION_TEXTQUOTEREPRESENTATIONCODE (66)                 /* default: 1 */
#define LL_OPTION_SCALABLEFONTSONLY    (67)                 /* default: 1, 0 = all fonts, 2 = only TRUETYPE fonts (ignoring that the device may have downloadable truetype fonts), all others: all but raster fonts */
#define LL_OPTION_NOTIFICATIONMESSAGEHWND (68)                 /* default: NULL (parent window handle) */
#define LL_OPTION_DEFDEFFONT           (69)                 /* default: GetStockObject(ANSI_VAR_FONT) */
#define LL_OPTION_CODEPAGE             (70)                 /* default: CP_ACP; set codepage to use for conversions. */
#define LL_OPTION_FORCEFONTCHARSET     (71)                 /* default: false; set font's charset to the codepage according to LL_OPTION_LCID. Default: FALSE */
#define LL_OPTION_COMPRESSRTF          (72)                 /* default: true; compress RTF text > 1024 bytes in project file */
#define LL_OPTION_ALLOW_LLX_EXPORTERS  (74)                 /* default: true; allow ILlXExport extensions */
#define LL_OPTION_SUPPORTS_PRNOPTSTR_EXPORT (75)                 /* default: false: hides "set to default" button in "export option" tab in designer */
#define LL_OPTION_DEBUGFLAG            (76)                
#define LL_OPTION_SKIPRETURNATENDOFRTF (77)                 /* default: false */
#define LL_OPTION_INTERCHARSPACING     (78)                 /* default: false: allows character interspacing in case of block justify */
#define LL_OPTION_INCLUDEFONTDESCENT   (79)                 /* default: true */
#define LL_OPTION_RESOLUTIONCOMPATIBLETO9X (80)                 /* DEPRECATED. default: false  */
#define LL_OPTION_USECHARTFIELDS       (81)                 /* default: false */
#define LL_OPTION_OFNDIALOG_NOPLACESBAR (82)                 /* default: false; do not use "Places" bar in NT2K? */
#define LL_OPTION_SKETCH_COLORDEPTH    (83)                 /* default: 24 */
#define LL_OPTION_FINAL_TRUE_ON_LASTPAGE (84)                 /* default: false: internal use */
#define LL_OPTION_INTERCHARSPACING_FORCED (86)                 /* default: false: forces character interspacing calculation in TEXT objects (possibly dangerous and slow) */
#define LL_OPTION_RTFAUTOINCREMENT     (87)                 /* default: false, to increment RTF char pointer if nothing can be printed */
#define LL_OPTION_UNITS_DEFAULT        (88)                 /* default: LL_OPTION_UNITS_SYSDEFAULT. Use for contols that query the units, where we need to return "sysdefault" also */
#define LL_OPTION_NO_MAPI              (89)                 /* default: false. Inhibit MAPI load for preview */
#define LL_OPTION_TOOLBARSTYLE         (90)                 /* default: LL_OPTION_TOOLBARSTYLE_STANDARD|LL_OPTION_TOOLBARSTYLEFLAG_DOCKABLE */
#define LL_OPTION_TOOLBARSTYLE_STANDARD (0)                  /* OFFICE97 alike style  */
#define LL_OPTION_TOOLBARSTYLE_OFFICEXP (1)                  /* DOTNET/OFFICE_XP alike style  */
#define LL_OPTION_TOOLBARSTYLE_OFFICE2003 (2)                 
#define LL_OPTION_TOOLBARSTYLEMASK     (0x0f)              
#define LL_OPTION_TOOLBARSTYLEFLAG_GRADIENT (0x80)               /* starting with XP, use gradient style  */
#define LL_OPTION_TOOLBARSTYLEFLAG_DOCKABLE (0x40)               /* dockable toolbars?  */
#define LL_OPTION_TOOLBARSTYLEFLAG_CANCLOSE (0x20)               /* internal use only  */
#define LL_OPTION_TOOLBARSTYLEFLAG_SHRINK_TO_FIT (0x10)               /* internal use only  */
#define LL_OPTION_MENUSTYLE            (91)                 /* default: LL_OPTION_MENUSTYLE_STANDARD */
#define LL_OPTION_MENUSTYLE_STANDARD_WITHOUT_BITMAPS (0)                  /* values: see CTL  */
#define LL_OPTION_MENUSTYLE_STANDARD   (1)                 
#define LL_OPTION_MENUSTYLE_OFFICEXP   (2)                 
#define LL_OPTION_MENUSTYLE_OFFICE2003 (3)                 
#define LL_OPTION_RULERSTYLE           (92)                 /* default: LL_OPTION_RULERSTYLE_FLAT */
#define LL_OPTION_RULERSTYLE_FLAT      (0x10)              
#define LL_OPTION_RULERSTYLE_GRADIENT  (0x80)              
#define LL_OPTION_STATUSBARSTYLE       (93)                
#define LL_OPTION_STATUSBARSTYLE_STANDARD (0)                 
#define LL_OPTION_STATUSBARSTYLE_OFFICEXP (1)                 
#define LL_OPTION_STATUSBARSTYLE_OFFICE2003 (2)                 
#define LL_OPTION_TABBARSTYLE          (94)                
#define LL_OPTION_TABBARSTYLE_STANDARD (0)                 
#define LL_OPTION_TABBARSTYLE_OFFICEXP (1)                 
#define LL_OPTION_TABBARSTYLE_OFFICE2003 (2)                 
#define LL_OPTION_DROPWINDOWSTYLE      (95)                
#define LL_OPTION_DROPWINDOWSTYLE_STANDARD (0)                 
#define LL_OPTION_DROPWINDOWSTYLE_OFFICEXP (1)                 
#define LL_OPTION_DROPWINDOWSTYLE_OFFICE2003 (2)                 
#define LL_OPTION_DROPWINDOWSTYLEMASK  (0x0f)              
#define LL_OPTION_DROPWINDOWSTYLEFLAG_CANCLOSE (0x20)              
#define LL_OPTION_INTERFACEWRAPPER     (96)                 /* returns IL<n>* */
#define LL_OPTION_FONTQUALITY          (97)                 /* LOGFONT.lfQuality, default: DEFAULT_QUALITY */
#define LL_OPTION_FONTPRECISION        (98)                 /* LOGFONT.lfOutPrecision, default: OUT_STRING_PRECIS */
#define LL_OPTION_UISTYLE              (99)                 /* UI collection, w/o */
#define LL_OPTION_UISTYLE_STANDARD     (0)                  /* 90=0x40, 91=1, 92=0x10, 93=0, 94=0, 95=0x20  */
#define LL_OPTION_UISTYLE_OFFICEXP     (1)                  /* 90=0x41, 91=2, 92=0x10, 93=1, 94=1, 95=0x21  */
#define LL_OPTION_UISTYLE_OFFICE2003   (2)                  /* 90=0x42, 91=3, 92=0x10, 93=2, 94=2, 95=0x22  */
#define LL_OPTION_NOFILEVERSIONUPGRADEWARNING (100)                /* default: false */
#define LL_OPTION_UPDATE_FOOTER_ON_DATALINEBREAK_AT_FIRST_LINE (101)                /* default: false */
#define LL_OPTION_ESC_CLOSES_PREVIEW   (102)                /* shall ESC close the preview window (default: false) */
#define LL_OPTION_VIEWER_ASSUMES_TEMPFILE (103)                /* shall the viewer assume that the file is a temporary file (and not store values in it)? default TRUE */
#define LL_OPTION_CALC_USED_VARS       (104)                /* default: true */
#define LL_OPTION_NOPRINTJOBSUPERVISION (106)                /* default: true */
#define LL_OPTION_CALC_SUMVARS_ON_PARTIAL_LINES (107)                /* default: false */
#define LL_OPTION_BLACKNESS_SCM        (108)                /* default: 0 */
#define LL_OPTION_PROHIBIT_USERINTERACTION (109)                /* default: false */
#define LL_OPTION_PERFMON_INSTALL      (110)                /* w/o, TRUE to install, FALSE to uninstall */
#define LL_OPTION_RESERVED111          (111)               
#define LL_OPTION_VARLISTBUCKETCOUNT   (112)                /* applied to future jobs only, default 1000 */
#define LL_OPTION_MSFAXALLOWED         (113)                /* global flag - set at start of LL! Will allow/prohibit fax detection. Default: TRUE */
#define LL_OPTION_AUTOPROFILINGTICKS   (114)                /* global flag - set at start of LL! Activates LL's thread profiling */
#define LL_OPTION_PROJECTBACKUP        (115)                /* default: true */
#define LL_OPTION_ERR_ON_FILENOTFOUND  (116)                /* default: false */
#define LL_OPTION_NOFAXVARS            (117)                /* default: false */
#define LL_OPTION_NOMAILVARS           (118)                /* default: false */
#define LL_OPTION_PATTERNRESCOMPATIBILITY (119)                /* default: false */
#define LL_OPTION_NODELAYEDVALUECACHING (120)                /* default: false */
#define LL_OPTION_FEATURE              (1000)              
#define LL_OPTION_FEATURE_CLEARALL     (0)                 
#define LL_OPTION_FEATURE_SUPPRESS_JPEG_DISPLAY (1)                 
#define LL_OPTION_FEATURE_SUPPRESS_JPEG_CREATION (2)                 
#define LL_OPTION_VARLISTDISPLAY       (121)                /* default: LL_OPTION_VARLISTDISPLAY_FOLDERPOS_TOP | LL_OPTION_VARLISTDISPLAY_VARSORT_ALPHA */
#define LL_OPTION_VARLISTDISPLAY_VARSORT_DECLARATIONORDER (0x0000)            
#define LL_OPTION_VARLISTDISPLAY_VARSORT_ALPHA (0x0001)            
#define LL_OPTION_VARLISTDISPLAY_VARSORT_MASK (0x000f)            
#define LL_OPTION_VARLISTDISPLAY_FOLDERPOS_DECLARATIONORDER (0x0000)            
#define LL_OPTION_VARLISTDISPLAY_FOLDERPOS_ALPHA (0x0010)             /* only if LL_OPTION_VARLISTDISPLAY_VARSORT_ALPHA* is set  */
#define LL_OPTION_VARLISTDISPLAY_FOLDERPOS_TOP (0x0020)            
#define LL_OPTION_VARLISTDISPLAY_FOLDERPOS_BOTTOM (0x0030)            
#define LL_OPTION_VARLISTDISPLAY_FOLDERPOS_MASK (0x00f0)            
#define LL_OPTION_VARLISTDISPLAY_LLFOLDERPOS_BOTTOM (0x0100)            
#define LL_OPTION_VARLISTDISPLAY_INITSCROLLPOS_TOP (0x0200)            
#define LL_OPTION_VARLISTDISPLAY_ALPHASORT_RESPECT_NUMBERS (0x0400)            
#define LL_OPTION_WORKAROUND_RTFBUG_EMPTYFIRSTPAGE (122)               
#define LL_OPTION_FORMULASTRINGCOMPARISONS_CASESENSITIVE (123)                /* default: true */
#define LL_OPTION_FIELDS_IN_PROJECTPARAMETERS (124)                /* default: false */
#define LL_OPTION_CHECKWINDOWTHREADEDNESS (125)                /* default: false */
#define LL_OPTION_ISUSED_WILDCARD_AT_START (126)                /* default: false */
#define LL_OPTION_ROOT_MUST_BE_MASTERTABLE (127)                /* default: false */
#define LL_OPTION_DLLTYPE              (128)                /* r/o */
#define LL_OPTION_DLLTYPE_32BIT        (0x0001)            
#define LL_OPTION_DLLTYPE_64BIT        (0x0002)            
#define LL_OPTION_DLLTYPE_BITMASK      (0x000f)            
#define LL_OPTION_DLLTYPE_SDBCS        (0x0010)            
#define LL_OPTION_DLLTYPE_UNICODE      (0x0020)            
#define LL_OPTION_DLLTYPE_CHARSET      (0x00f0)            
#define LL_OPTION_HLIBRARY             (129)                /* r/o */
#define LL_OPTION_INVERTED_PAGEORIENTATION (130)                /* default: false */
#define LL_OPTION_ENABLE_STANDALONE_DATACOLLECTING_OBJECTS (131)                /* default: false */
#define LL_OPTION_USERVARS_ARE_CODESNIPPETS (132)                /* default: false */
#define LL_OPTION_STORAGE_ADD_SUMMARYINFORMATION (133)                /* default: false */
#define LL_OPTION_INCREMENTAL_PREVIEW  (135)                /* default: true */
#define LL_OPTION_RELAX_AT_SHUTDOWN    (136)                /* default: true */
#define LL_OPTION_NOPRINTERPATHCHECK   (137)                /* default: false */
#define LL_OPTION_SUPPORT_HUGESTORAGEFS (138)                /* deprecated, always true */
#define LL_OPTION_NOAUTOPROPERTYCORRECTION (139)                /* default: false */
#define LL_OPTION_NOVARLISTRESET_ON_RESETPROJECTSTATE (140)                /* default: false; */
#define LL_OPTION_DESIGNERPREVIEWPARAMETER (141)                /* default: NULL */
#define LL_OPTION_RESERVED142          (142)               
#define LL_OPTION_DESIGNEREXPORTPARAMETER (143)                /* default: NULL */
#define LL_OPTION_DESIGNERPRINT_SINGLETHREADED (144)                /* default: false */
#define LL_OPTION_ALLOW_COMMENTS_IN_FORMULA (145)                /* default: true */
#define LL_OPTION_USE_MLANG_LINEBREAKALGORITHM (146)                /* default: false (would use MLANG to calculate the line break algorithm) */
#define LL_OPTION_USE_JPEG_OR_PNG_OPTIMIZATION (147)                /* default: true */
#define LL_OPTION_ENABLE_IMAGESMOOTHING (148)                /* default: true (uses GDIPLUS - no smoothing on Win2000/98 if not GDIPLUS installed! Right now, applies only to JPEG.) */
#define LL_OPTION_MAXRTFVERSION_AVAILABLE (159)                /* r/o */
#define LL_OPTION_CONDREPRESENTATIONCODES_LIKE_ANSI (160)                /* default: false */
#define LL_OPTION_NULL_IS_NONDESTRUCTIVE (161)                /* default: false */
#define LL_OPTION_DRILLDOWNPARAMETER   (162)                /* default: NULL */
#define LL_OPTION_ROUNDINGSTRATEGY     (163)                /* default: LL_ROUNDINGSTRATEGY_ARITHMETIC_SYMMETRIC */
#define LL_ROUNDINGSTRATEGY_BANKERSROUNDING (0)                 
#define LL_ROUNDINGSTRATEGY_ARITHMETIC_SYMMETRIC (1)                 
#define LL_OPTION_RESERVED164          (164)               
#define LL_OPTION_RESERVED165          (165)               
#define LL_OPTION_PICTURE_TRANSPARENCY_IS_WHITE (166)                /* default: false (transparent) */
#define LL_OPTION_FLOATPRECISION       (167)                /* global (not job specific!). Default: 0 (192 bit mantissa, 32 bit exponent) */
#define LL_OPTION_SUPPRESS_LRUENTRY    (168)               
#define LL_OPTION_FORCEFIRSTGROUPHEADER (169)                /* default: false (group match string is an empty string) */
#define LL_OPTION_SUPPORT_PDFINPUTFIELDS (170)                /* PDF 3.0 supports text objects and check boxes as input objects - default: true */
#define LL_OPTION_ENHANCED_SKIPRETURNATENDOFRTF (171)                /* default: false. */
#define LL_OPTION_HIERARCHICALDATASOURCE (172)                /* default: false */
#define LL_OPTION_FORCE_HEADER_EVEN_ON_LARGE_FOOTERLINES (173)                /* default: false */
#define LL_OPTION_PRINTERDEVICEOPTIMIZATION (174)                /* default: true */
#define LL_OPTION_RTFHEIGHTSCALINGPERCENTAGE (175)                /* default: 100 */
#define LL_OPTION_FORCE_DEFAULT_PRINTER_IN_PREVIEW (176)                /* default: false */
#define LL_OPTION_SAVE_PROJECT_IN_UTF8 (178)                /* INT, default 0 (meaning: project is saved as UTF16 if A API is not used), 1 (UTF-8 with BOM), 2 (UTF-8 without BOM) */
#define LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ONLY_SUBTABLES (0)                 
#define LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ALL_TABLES (1)                 
#define LL_DRILLDOWNFILTERSTRATEGY_ALLOW_SUBTABLES_AND_UNRELATED (2)                 
#define LL_DRILLDOWNFILTERSTRATEGY_ALLOW_SUBTABLES_AND_USERDEFINED (3)                 
#define LL_DRILLDOWNFILTERSTRATEGY_MASK (0x0f)              
#define LL_DRILLDOWNFILTERFLAG_OFFER_BASERECORD_AS_VARIABLES (0x10)              
#define LL_OPTION_DRILLDOWN_DATABASEFILTERING (179)                /* default: 0 (filter all except subtables of the base table: LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ONLY_SUBTABLES) */
#define LL_OPTION_SUPPRESS_TASKBARBUTTON_PROGRESSSTATE (180)                /* default: false */
#define LL_OPTION_PRINTDLG_DEVICECHANGE_KEEPS_DEVMODESETTINGS (181)                /* default: true */
#define LL_OPTION_DRILLDOWN_SUPPORTS_EMBEDDING (182)                /* default: true */
#define LL_VARLISTCLEARSTRATEGY_EMPTY_LIST (0)                 
#define LL_VARLISTCLEARSTRATEGY_SET_NULL (1)                 
#define LL_VARLISTCLEARSTRATEGY_SET_DEFAULT (2)                 
#define LL_OPTION_VARLISTCLEARSTRATEGY_ON_DEFINE_START (183)                /* default: LL_VARLISTCLEARSTRATEGY_EMPTY_LIST */
#define LL_OPTION_RESERVED184          (184)               
#define LL_OPTION_KEEP_EMPTY_SUM_VARS  (185)                /* default: false */
#define LL_OPTION_RESERVED187          (187)                /* internal test flag */
#define LL_OPTION_DEFAULTDECSFORSTR    (188)                /* default: 5. Sets the default number of decimals for Str$ */
#define LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_PRINTJOB (189)                /* default: false */
#define LL_OPTION_DEFINEXXXSTART_COMPATIBLE_TO_PRE15 (190)               
#define LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_DC (191)                /* default: true */
#define LL_OPTION_BITMAP_RESOLUTION_FOR_PREVIEW (192)                /* default: 0 (leave original size), suggestions are 300 or 600. -1 to use device default. */
#define LL_OPTION_DRAW_EMPTY_CHARTOBJECTS (193)                /* default: false */
#define LL_OPTION_PREVIOUS_DEFAULTS_TO_NULL (194)                /* default: false (for compatibility). Previous() returns NULL on first record if TRUE, otherwise some default value for the given datatype. */
#define LL_OPTION_FORCE_IMAGEEMBEDDING (195)                /* default: false. Images added via the image dialog are always embedded. */
#define LL_OPTION_VARKEY_MAP_SHARP_S_TO_SS (196)                /* default: false */
#define LL_OPTION_NO_LAYERED_WINDOWS   (197)                /* default: false */
#define LL_OPTION_SCALED_PERCENTAGEFORMATTER (198)                /* default: false (0.1="0.1%", true: 0.1="10%") */
#define LL_OPTION_USE_ANTIALIAS        (199)                /* default: true */
#define LL_OPTION_FORCETABLELINECALLBACK (200)                /* LL_CMND_TABLE_LINE is called even when COLORINGMODE_LL ist set, default: false */
#define LL_OPTION_EXPORTCONSUMER       (201)                /* internal use only */
#define LL_OPTION_TOC_IDX_ITEMID       (202)                /* internal use only */
#define LL_OPTION_FORCED2PASSMODE      (203)                /* default: false */
#define LL_OPTION_SETVAR_ONLY_SETS_IF_CONTAINER_PRINTS (204)                /* default: false */
#define LL_OPTION_SHOW_PREVIEW_AFTER_PRINT_END (206)                /* "Export-ShowResult" sets this for PRV... */
#define LL_OPTION_PROPLIST_COMBOBOX_SCROLL_WRAPS (207)                /* default: FALSE */
#define LL_OPTION_ALWAYS_CALC_GROUPCHANGE_CONDITION (208)                /* default: false */
#define LL_OPTION_NULLHANDLING_SUPPORTED_IN_ENHMODE (209)                /* default: false  */
#define LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_PREVIEWJOB (210)                /* default: true */
#define LL_OPTION_USE_LEGACY_WORDWRAPPINGALGORITHM (211)                /* default: false */
#define LL_OPTION_PREVIEW_USES_PRINTTHREAD (212)                /* default: true */
#define LL_OPTION_LL_SUPPLIES_MESSAGELOOP_WHILE_PRINTING_TO_PREVIEW (213)                /* default: true */
#define LL_OPTION_PRINTERDCCACHE_TIMEOUT_SEC (214)                /* default: 60 (0 -> no cache) */
#define LL_OPTION_DESIGNER_RIBBONBACKGROUNDCOLOR (215)                /* default: undefined (system default) */
#define LL_OPTION_INTERNAL_EMFCLEANUP  (216)                /* no comment -> internal! */
#define LL_OPTION_RIBBON_DEFAULT_ENABLEDSTATE (217)                /* default: true */
#define LL_OPTION_PRVFILEVERSION       (218)                /* default: 0 (2 would be an optimized version, supported since LL18, usually a bit faster if printing > 5000 pages) */
#define LL_OPTION_TRY_REDUCE_BMPSIZE_BY_CONVERTING_TO_PNG_OR_JPEG (219)                /* default: false */
#define LL_OPTION_NO_IMAGEFILEOPTIMIZATION (220)                /* default: false. Set this to TRUE if you know you're replacing an image file during printing that is used in a project using its file name */
#define LL_OPTION_NO_ENFORCED_GROUPFOOTERPRIORITY_FOR_LAST_GROUPFOOTER (221)                /* default: false. Compatibility to LL 16.008. */
#define LL_OPTION_ALLOW_COMBINED_COLLECTING_OF_DATA_FOR_COLLECTIONCONTROLS (222)                /* default: true */
#define LL_OPTION_SUPPRESS_LOADERRORMESSAGES (223)                /* default: false. Please take care that this is a reference counted flag, so add (true) and subtract (false) the same number of calls! [ChK] */
#define LL_OPTION_IGNOREFORMULARESULTMISMATCH_AT_LOADTIME (224)                /* default: false. Switches the r8117 (err #3535) change back to the old behavior */
#define LL_OPTION_MAX_SIZE_OF_PROJECTINFOCACHE (225)                /* default: 1000 */
#define LL_OPTION_NO_CORRECTION_OF_UNICODE_RTF (226)                /* default: false */
#define LL_OPTION_MAY_RELEASE_UNNECESSARY_PROPS_AT_PRINTTIME (227)                /* default: false */
#define LL_OPTION_DO_NOT_RESTORE_PREVSTATE_ON_FILTER_MISMATCH (228)                /* default: false (LL17: implicitly TRUE until 17.006) */
#define LL_OPTION_SUPPORT_USERDEFINED_REPORTPAGELAYOUT (229)                /* default: false */
#define LL_OPTION_DESIGNER_RIBBONTEXTCOLOR (230)                /* default: undefined (system default) */
#define LL_PARTSHARINGFLAG_VARIABLES_TOC (0x01)              
#define LL_PARTSHARINGFLAG_VARIABLES_IDX (0x02)              
#define LL_PARTSHARINGFLAG_VARIABLES_GTC (0x04)              
#define LL_OPTION_PARTSHARINGFLAGS     (231)                /* default: 0xff */
#define LL_OPTION_PIECHARTORDER_COMPATIBLE_TO_PRE19 (232)                /* default: 1 (LL18), 0 (>= LL19) */
#define LL_OPTION_DATABASESTRUCTURE_SORT_DECLARATIONORDER (233)                /* default: false (sorted alphabetically) */
#define LL_OPTION_REPORT_PARAMETERS_REALDATAJOBPARAMETER (234)                /* default: NULL */
#define LL_OPTION_EXPANDABLE_REGIONS_REALDATAJOBPARAMETER (235)                /* default: NULL */
#define LL_OPTION_IMPROVED_TABLELINEANCHORING (236)                /* default: TRUE */
#define LL_OPTION_INTERACTIVESORTING_REALDATAJOBPARAMETER (237)                /* default: NULL */
#define LL_OPTION_TEMPFILESTRATEGY     (238)                /* default: LL_TEMPFILESTRATEGY_SPEED */
#define LL_TEMPFILESTRATEGY_SPEED      (0)                 
#define LL_TEMPFILESTRATEGY_SIZE       (1)                 
#define LL_TEMPFILESTRATEGY_SECURITY   (2)                 
#define LL_OPTION_RTF_WHITE_BACKGROUND_IS_TRANSPARENT (239)                /* default: TRUE (!) */
#define LL_OPTION_NO_DOTTED_LINE_ON_SECONDARY_AXIS (240)                /* default: FALSE */
#define LL_OPTION_NO_PREVIOUS_VARLIST  (241)               
#define LL_OPTION_COMMIT_FILE_ON_SAVE  (242)                /* default: false */
#define LL_OPTION_DO_NOT_RTRIM_CELLTEXT (243)                /* default: false */
#define LL_OPTION_ALLOW_FCT_TEXTWIDTH  (244)                /* default: false */
#define LL_OPTION_PASTEOBJECTS_TO_FIRST_VISIBLE_LAYER (245)                /* default: false */
#define LL_OPTION_EMPTY_FILE_TRIGGERS_PROJECT_WIZARD (246)                /* default: false */
#define LL_OPTION_DELAY_UPDATE_REMAININGTABLESPACE (247)                /* default: false  */
#define LL_OPTION_WIZARD_ADDS_ORGNAME_TO_UI (248)                /* default: false */
#define LL_OPTION_PROHIBIT_EXTERNAL_FILES (249)                /* default: false */
#define LL_OPTION_DRAWINGS_INLINED     (250)                /* default: 0 (1 = inlined, 2 = leave as is, but no BLOBs - for GTC) */
#define LL_OPTION_SERIALIZE_PRINTAPI   (251)                /* default: false */
#define LL_OPTION_PROJECTFILELOCKTIMEOUT_IN_MS (252)                /* default: 10000 */
#define LL_OPTION_ILLDATAPROVIDER      (253)               
#define LL_OPTION_RTF_SUPPORTS_PARABREAKOPTIONS (254)                /* default: false */
#define LL_OPTION_FORCE_PDFEMBEDDING   (255)                /* default: false. PDF documents added via the pdf dialog are always embedded */
#define LL_OPTION_IGNORE_NONSCALEABLEFONTPROPERTIES (256)                /* default: false. PDF documents added via the pdf dialog are always embedded */
#define LL_DATAPROVIDERTHREADNESS_NONE (0)                 
#define LL_DATAPROVIDERTHREADNESS_ONE_INSTANCE_PER_THREAD (1)                 
#define LL_DATAPROVIDERTHREADNESS_DONTCARE (2)                  /* default  */
#define LL_OPTION_DATAPROVIDER_THREADEDNESS (257)               
#define LL_OPTION_SUBREPORT_BASE       (258)               
#define LL_OPTION_SUBREPORT_CLIENT     (259)               
#define LL_OPTION_NO_IPICTURE_SUPPORT  (260)                /* default: false */
#define LL_OPTION_FORCE_JPEG_RECOMPRESSION (261)                /* default: false */
#define LL_OPTION_TEXTWRAP_TOLERANCE_PERC (262)                /* default: 0 (no tolerance) */
#define LL_OPTION_NO_USERVARCHECK_ON_LOAD (263)                /* default: false */
#define LL_OPTION_TOC_IDX_PAGE         (264)                /* internal use only */
#define LL_OPTION_RTF_TAB_KEY_IS_TAB_FORMATTER (265)                /* default: false */
#define LL_OPTION_VARLISTDISPLAY_LL_FOLDER_AT_END (266)                /* default: false */
#define LL_OPTION_DOM_DO_NOT_KILL_EMPTY_TABLE (267)                /* default: false */
#define LL_OPTION_ENABLE_INPUTOBJECTS_IN_TABLES (268)                /* default: true */
#define LL_OPTION_MAX_ENTRIES_FOR_AUTOCOMPLETE (269)                /* default: 200 */
#define LL_OPTION_DEFAULT_FOR_SHADOWPAGEWRAP (270)                /* default: true */
#define LL_OPTION_MAX_UNDO_STEPS       (271)                /* default: 10 */
#define LL_OPTION_HTML_USE_MAILFORMAT  (272)                /* default: false */
#define LL_OPTION_CLIP_LABELS_TO_PROJECTAREA (273)                /* default: false (may paint beyond the border not to lose any data) */
#define LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_EXPORTJOB (274)               
#define LL_OPTION_SCRIPTENGINE_ENABLED (276)                /* default: false */
#define LL_OPTION_SCRIPTENGINE_TIMEOUTMS (277)                /* default: 10000 */
#define LL_OPTION_SCRIPTENGINE_AUTOEXECUTE (278)                /* default: false */
#define LL_OPTION_SHAPEFILE_TIMEOUTMS  (279)                /* default: 1000  */
#define LL_OPTION_COUNTALLPRINTEDDATA_LASTPRINT (280)                /* r/o */
#define LL_OPTION_SAVE_AS_ACTS_AS_EXPORT (281)                /* default: false */
#define LL_OPTION_RESETPROJECTSTATE_TRIGGERS_NEW_SHEET (282)                /* default: true */
#define LL_OPTION_HIDE_EXPORT_TAB_FROM_LAYOUT_CONFIG (283)                /* default: false */
#define LL_OPTION_USE_VARLIST_NAMESORTINDEXCACHE (284)                /* should be defined for job -1 */
#define LL_OPTION_NOCONTRASTOPTIMIZATION (285)                /* default: false */
#define LL_OPTION_AUTORECOVERY_DISABLED (286)                /* default: false */
#define LL_OPTION_AUTORECOVERY_SAVEOPTIONS (287)                /* default: LL_AUTORECOVERY_SAVEOPTIONS_NEWFILE (value might be combination of following) */
#define LL_AUTORECOVERY_SAVEOPTIONS_NEWFILE (1)                 
#define LL_AUTORECOVERY_SAVEOPTIONS_OVERWRITE (2)                 
#define LL_OPTION_LINK_PRINTERQUEUES   (288)                /* default: false, does not work yet */
#define LL_OPTION_FORCE_RTFMERGING     (289)                /* default: false, forces to merge RTF contents even if there is just one part to load, compatibility switch */
#define LL_OPTION_W201512300001        (290)                /* do not check on empty bodylines for "ActivateNextLine" - sort of "I know what I am doing in my print loop" */
#define LL_OPTION_CALCLINEHEIGHT_COMPATIBLE_TO_19 (291)                /* LL19 had a wrong line height calculation, force compatible mode. Default: false. */
#define LL_OPTION_FORCE_UNIQUE_PARAMETERUISTRING (292)                /* Report parameter UI strings will be forced as unique. Default: false. */
#define LL_OPTION_AUTOMATICFOOTER      (293)                /* Creates automatically footer-line in table-line wizard. Default: true. */
#define LL_OPTION_SUPPORT_PREDEFINED_COLORS (294)                /* default: for design/print job: always true. Otherwise false. */
#define LL_OPTION_FAVORITE_SETTINGS    (295)                /* default: display button and use registry settings */
#define LL_FAVORITES_ENABLE_FAVORITES_BY_DEFAULT (0x0001)            
#define LL_FAVORITES_HIDE_FAVORITES_BUTTON (0x0002)            
#define LL_OPTION_NEWMODE_EXPRSTARTREPRESENTATIONCODE (296)                /* default: 0xab */
#define LL_OPTION_NEWMODE_EXPRENDREPRESENTATIONCODE (297)                /* default: 0xbb */
#define LL_OPTION_RESERVED_298         (298)                /* outdated, not used any more */
#define LL_OPTION_ILLREPOSITORY        (299)                /* host repository */
#define LL_OPTION_VARLISTLOOKUP_ALLOWS_GLOBALNAME (300)                /* default: 0 */
#define LL_OPTION_FORCESAVEDESIGNSCHEME (301)                /* default: false */
#define LL_OPTION_REPOSITORY_SINGLEPROJECTMODE (302)                /* default: false */
#define LL_OPTION_ANIMATIONS_DISABLED  (303)                /* default: 0 */
#define LL_OPTION_ANIMATIONS_DISABLED_DISABLEALL (0x01)              
#define LL_OPTION_ANIMATIONS_DISABLED_HIDE_STD (0x02)              
#define LL_OPTION_ANIMATIONS_DISABLED_HIDE_HTML (0x04)               /*    */
#define LL_OPTION_UPDATE_INTERACTIONINFO_PER_PAGE (304)                /* default: false. "true" means some overhead per page */
#define LL_OPTION_IS_REPORTSERVERDESIGNER (305)                /* internal */
#define LL_OPTION_IMPROVED_FRAMEDRAWING (306)                /* default: false */
#define LL_OPTION_POSTPAINT_TABLESEPARATORS (307)                /* default: true */
#define LL_OPTION_CROSSTAB_USE_CELLVALUE_INSTEAD_OF_DISPLAYVALUE (308)                /* default: false; */
#define LL_OPTION_SUPPORT_DELAYEDFIELDDEFINITION (309)                /* default: false */
#define LL_OPTION_SUPPRESS_REALDATAPREVIEW_IN_DESIGNER (310)                /* default: false */
#define LL_OPTION_MAX_RTFCONTROLS_IN_CACHE (311)                /* default: 50 */
#define LL_OPTION_RDPEXPORT_CREATEMPFILEUNTILSAVEDONCE (312)                /* internal */
#define LL_OPTION_CRC32_ONLY_FOR_RTFDATA_ABOVE (313)                /* limit of RTF stream size (in KB) up to which RTF text and BLOBs are compared using MD5 - above, it's CRC32 only. Default: 100 KB */
#define LL_OPTION_PRINTER_FILE_SUPERSEDES_EXPORT_OPTIONS (314)                /* settings in printer file supersede explicit export options */
#define LL_OPTION_TRANSLATIONFLAGS     (315)                /* default: both directions. Right now, only the omittance of _SAVE works. */
#define LL_TRANSLATION_LOAD            (0x01)              
#define LL_TRANSLATION_SAVE            (0x02)              
#define LL_OPTION_PREVIEW_SCALES_RELATIVE_TO_PHYSICAL_SIZE (316)                /* needs >= Windows 8.1. Stored in preview file to modify behaviour in viewer */
#define LL_PREVIEW_SCALE_PHYSICAL_DESIGNERPREVIEW (0x01)              
#define LL_PREVIEW_SCALE_PHYSICAL_PREVIEW (0x02)              
#define LL_OPTION_NODEFAULTFONTOVERRIDE (317)                /* default: false */
#define LL_OPTION_TREEVIEWFILTER_VISIBILITYFLAGS (318)                /* default: LL_TREEVIEWFILTER_IN_ALL_TREES */
#define LL_TREEVIEWFILTER_IN_VARTREE   (0x0001)            
#define LL_TREEVIEWFILTER_IN_FCTWIZARD_VARTREE (0x0002)            
#define LL_TREEVIEWFILTER_IN_ALL_TREES (0xffff)            
#define LL_OPTION_COMPAT_ALLOW_INVALID_CHARS_IN_SINGLEFIELDFORMULA (319)                /* default: FALSE */
#define LL_OPTION_TREEVIEWFILTER_MAXIMUM_RECURSION_SEARCH_DEPTH (320)                /* default: 10 */
#define LL_OPTION_USER_ABORT_CANCELS_POSTPRINTPROCESSING (321)                /* default: false */
#define LL_OPTION_NOTOCRESET_ON_RESETPROJECTSTATE (322)                /* default: false */
#define LL_OPTION_NOIDXRESET_ON_RESETPROJECTSTATE (323)                /* default: false */
#define LL_OPTION_SUPPRESS_FORMULASUBITEMS_IN_VARTREE (324)                /* default: false */
#define LL_OPTION_TEMPLATE_OVERRIDES_USER_DESIGNSCHEME (325)                /* default: true */
#define LL_OPTION_ALLOW_ASSUMPTION_PRINTERS_CAN_PRINT_MULTIPLE_JOBS_IN_ONE_HDC (326)                /* default: true */
#define LL_OPTION_PERSISTENT_PRINTER_USE_FOR_OUTPUT (327)                /* default: false */
#define LL_OPTION_GET_CURRENT_PROJECTTYPE (328)                /* R/O */
#define LL_OPTION_DELAY_CALC_OF_USED_VARS (329)                /* default: false */
#define LL_OPTION_USE_FONT_SIZE_AS_MAXIMUM_SIZE_FOR_TEXTFITTING (330)                /* default: false */
#define LL_OPTION_CLIP_FIELDS_EXCEEDING_TABLE_WIDTH (331)                /* default: 0 */
#define LL_CLIP_FIELDS_VISUALLY        (1)                 
#define LL_CLIP_FIELDS_FIT_AT_LOAD_TIME (2)                 
#define LL_CLIP_FIELDS_FIT_AT_LOAD_TIME_PRINTING_ONLY (3)                 
#define LL_CLIP_FIELDS_FIT_COMPAT      (4)                 
#define LL_CLIP_FIELDS_METHOD_MASK     (0x0f)              
#define LL_CLIP_FIELDS_FLAG_IGNORE_APPEARANCE_CONDITION (0x10)              
#define LL_CLIP_FIELDS_FLAG_INCLUDE_NONCONST_WIDTH (0x20)              
#define LL_OPTION_COMPAT_ALLOW_FIELDS_IN_PROJECT_FILTER (332)                /* default: false */
#define LL_OPTION_SUPPRESS_CELLCLIPPING_TO_REPORTCONTAINER (333)                /* default: false */
#define LL_OPTION_RSCRIPT_MULTIJOBEXECUTION (334)                /* default: 0 */
#define LL_OPTION_RETRIES_FOR_STARTDOC (335)                /* INT, default: 1 */
#define LL_OPTION_PRN_FORCE_PROJECTSIZE_AS_PAPERSIZE (336)                /* default: 0 (1: if "ForcePaperFormat"=TRUE, do not iterate available paper formats and look up a matching one, just put the selected size in the DEVMODE structure and hope for the printer to accept it. 3: ) */
#define LL_OPTION_IS_PRINTING          (337)                /* r/o, returns if there's an active print job for the current job */
#define LL_OPTION_IDLEITERATIONCHECK_MAX_ITERATIONS (338)                /* 0 = no check. default: 0 */
#define LL_REPOSITORYTHREADNESS_NONE   (0)                 
#define LL_REPOSITORYTHREADNESS_DONTCARE (1)                  /* default  */
#define LL_REPOSITORYTHREADNESS_QUERY  (2)                 
#define LL_OPTION_REPOSITORY_THREADEDNESS (339)               
#define LL_OPTION_ALLOW_EMPTY_STRING_IN_XLAT (340)                /* default: false */
#define LL_OPTION_GTC_LASTPOSITION_CONSIDER_INDEX (341)                /* default: false */
#define LL_OPTION_DESIGNERACTIONMESSAGE (342)                /* r/o - joba handle can be any value, this is global */
#define LL_DESIGNERACTION_REFRESH_VARTREE (1)                 
#define LL_OPTION_DESIGNERFRAME_HWND   (343)                /* r/o */
#define LL_OPTION_MULTISECTIONPRINT_MERGE (344)                /* r/o */
#define LL_OPTION_COMPAT_ALLOW_FIELDS_IN_STATIC_TABLE (345)                /* default: FALSE */
#define LL_OPTION_COMPAT_GROUPHEADER_SAME_PAGE_LOCAL_ONLY (346)                /* default: false (must be set to true to behave as LL24) */
#define LL_OPTION_RESERVED_348         (348)                /* see #37979 */
#define LL_OPTION_COMPAT_PROHIBITFILTERRELATIONS (349)                /* default: FALSE */
#define LL_OPTION_ONLY_SHOW_EXISTING_PAPERSIZES_FOR_PRINTER (350)                /* default: false... do not add system defined papers to the ist of the printer's paper sizes unless the driver does not return any */
#define LL_OPTION_DEFAULT_DECIMALS     (351)                /* default: settings from registry/2. ATTENTION: global option */
#define LL_OPTION_ILLPREPRINTTEXTPROCESSOR (353)                /* ILLPrePrintTextProcessor */
#define LL_OPTION_USERVAR_TRACKTEMPLATEOVERRIDE (354)                /* default: false */
#define LL_OPTION_PROJECTVAR_IGNOREEMPTY (355)                /* default: false */
#define LL_OPTION_SUPPRESS_FUNCTION_POPUP (356)                /* default: false */
#define LL_OPTION_SUPPRESS_SYMBOLFONTMAPPING (357)                /* default: false - attn: global option! */
#define LL_OPTION_COMPAT_ENABLE_FORCEWRAP_ON_EXPORT (358)                /* default: false */
#define LL_OPTION_SORTINDEX_LCMAP_INITFLAGVALUE (359)                /* default: 0x1400 */
#define LL_OPTION_EXPANDABLE_REGIONS_FORCE_STATE (360)                /* default: 0 */
#define LL_OPTION_EXPANDABLE_REGIONS_FORCE_STATE_NEUTRAL (0)                  /* default  */
#define LL_OPTION_EXPANDABLE_REGIONS_FORCE_STATE_OPEN (1)                 
#define LL_OPTION_EXPANDABLE_REGIONS_FORCE_STATE_CLOSE (2)                 
#define LL_OPTION_COMPAT_NULL_IN_COND_ARG1_YIELDS_NULL (361)                /* default: false */
#define LL_OPTION_SUPPRESSCROSSTHREADEDWARNING (362)                /* default: 0 */
#define LL_OPTION_ALLOWSUBREPORTS      (363)                /* default: 1 */
#define LL_OPTION_INTERNALRELOADOPERATION (364)                /* default: 0 */
#define LL_INTERNALRELOADOPERATION_NEUTRAL (0)                  /* default  */
#define LL_INTERNALRELOADOPERATION_LOAD (1)                 
#define LL_INTERNALRELOADOPERATION_ERRORLIST (2)                 
#define LL_OPTION_COMPAT_BODYLINE_CELL_MAY_WRAP_EMPTY_ON_FIRST_PRINT (365)                /* default: false */
#define LL_OPTION_RTFEDITOR_SUPPRESS_KEYBOARDAUTOSWITCH (366)                /* default: false */
#define LL_OPTION_BUILDTREERECURSEOPTIONS (367)                /* default: 32 threshold for active stacksize based formula evaluation recursion detection */
#define LL_OPTION_GROUPFOOTERS_ARE_IMMUTABLE (368)                /* default: false */
#define LL_OPTION_DOM_MULTITHREADED_ACCESS (369)                /* default: false */
#define LL_OPTION_CHART_LL27_FEATURES  (370)                /* default: 0 */
#define LL_OPTION_SET_PREVIEW_ID_IN_ASSOC_FOR_SINGLETHREADED_PRINT (371)                /* w/o, internal. Important for single-threaded preview */
#define LL_OPTION_SUPPRESS_TOOLTIPHINTS (372)                /* default: false */
#define LL_OPTION_PROJECTPARAMETER_PRINTLANGUAGE_SHOW (373)                /* default: false */
#define LL_OPTION_TABLENAMETRANSLATION_NOT_DISTINCT (374)                /* default: false */
#define LL_OPTION_PRINTERLESS          (375)                /* default: false */
#define LL_OPTION_WEBDESIGNER_STATEFLAGS (376)                /* internal */
#define LL_WEBDESIGNER_STATEFLAGS_ACTIVE (0x1)               
#define LL_WEBDESIGNER_STATEFLAGS_PRINTING (0x2)               
#define LL_WEBDESIGNER_STATEFLAGS_SAVE_REBUILDDBSTRUCT (0x4)               
#define LL_WEBDESIGNER_STATEFLAGS_INTERNAL_MASK (0xffff0000)        
#define LL_WEBDESIGNER_STATEFLAGS_INTERNAL_TOCIDXATROOT (0x10000)           
#define LL_OPTION_DOM_IGNORE_EXPRESSIONERRORS (377)                /* internal */
#define LL_OPTION_SUPPRESS_EMPTY_PAGES_ON_PRINT (378)                /* default: false */
#define LL_OPTION_VIRTUALDEVICE_SCALINGOPTIONS (379)               
#define LL_VIRTUALDEVICE_SCALINGOPTION_UNSCALED (0)                  /* factor 1 (dim(DC) = dim(Project)/DPI(DC))  */
#define LL_VIRTUALDEVICE_SCALINGOPTION_OPTIMIZE_TO_SCREENRES (1)                  /* optimize DPI according to dim(DC)  */
#define LL_VIRTUALDEVICE_SCALINGOPTION_OPTIMIZE_TO_SCREENRES_AT_LEAST_ONE (2)                  /* optimize DPI according to dim(DC), but don't scale below 1 (dim(Project)/DPI(DC))  */
#define LL_VIRTUALDEVICE_SCALINGOPTION_FIXED_DPI_THRESHOLD_MIN (72)                 /* use any value above or equal (and below or equal to _MAX) as the resolution in DPI  */
#define LL_VIRTUALDEVICE_SCALINGOPTION_FIXED_DPI_THRESHOLD_MAX (2400)              
#define LL_OPTION_IGNORE_PROJECTSOURCE_FOR_DEVICEMATCHING (380)                /* default: false */
#define LL_OPTION_COMPAT_KEEPCASEDIFFONLYTABLENAMES (381)                /* default: false */
#define LL_OPTION_COMPAT_CROSSTAB_GANTT_SUPPORT_MINHEIGHTVALUE (382)                /* default: false */
#define LL_OPTION_RTF_SHARE_OBJECTS_THRESHOLD (383)                /* default: 100 */
#define LL_OPTION_COMPAT_PROHIBIT_DYNAMIC_REPORTPARAMETERCOLLECTION (384)                /* default: false */
#define LL_OPTION_COMPAT_FORCE_PRNOPT_PAGE (385)                /* internal */
#define LL_OPTION_INTENTIONAL_USER_ABORT (386)                /* internal, R/O */
#define LL_OPTION_PROHIBIT_OLE_OBJECTS_IN_RTF (387)               
#define LL_OPTION_COMPAT_ENABLE_EMF_OPTIMIZATION_IN_PDF_OBJECT (388)                /* default: true */
#define LL_OPTION_USESIMPLEWINDOWSPENSTYLE_FRAMEDRAWING (389)                /* default: false */
#define LL_OPTION_DISABLE_GDIPLUS_PATHS_IN_EMFDRAWINGS (390)                /* default: false */
#define LL_OPTION_KEEP_EXPORTER_CONTROL_FILES_IN_MEMORY (391)                /* default: false */
#define LL_OPTION_ALLOW_EMBEDDING_OF_PICTURES (392)                /* default: true */
#define LL_OPTION_COMPAT_ALLOW_NEGATIVE_DISTANCE_BEFORE (393)                /* default: false */
#define LL_OPTION_COMPAT_NULLSAFE_PRE_26_003 (394)                /* default: false */
#define LL_OPTION_DEFAULT_DATE_FORMAT_INCLUDES_TIME (395)                /* default: false */
#define LL_OPTION_SVG_TO_DIB_RESOLUTION (396)                /* default: 150 DPI. 0 to fit to printer resolution */
#define LL_OPTION_SVG_TO_DIB_MAX_SIZE  (397)                /* max area in pixel, default: x * y < 5 MB */
#define LL_OPTION_TRIM_ALSO_EXTENDEDSPACECHARS (398)                /* default: false */
#define LL_OPTION_HIDE_EXTENDED_PRINTMODES (399)                /* default: false */
#define LL_OPTION_REPOSITORY_CREATE_ITEM_RECURSIVE (400)                /* default: TRUE! */
#define LL_OPTION_GAUGE_SIZE_REDUCTION (402)                /* default: false */
#define LL_OPTION_FCT_EMPTYTABLEFILTERCORRECTION (403)                /* default: true */
#define LL_OPTION_CHARTDLG_CONTAINERUPDATE (404)                /* default: LL_OPTION_CHARTDLG_CONTAINERUPDATE_AUTO */
#define LL_OPTION_CHARTDLG_CONTAINERUPDATE_NEVER (0)                 
#define LL_OPTION_CHARTDLG_CONTAINERUPDATE_AUTO (1)                 
#define LL_OPTION_CHARTDLG_CONTAINERUPDATE_ALWAYS (-1)                
#define LL_OPTION_INTELLISENSE_MAXNESTINGDEPTH (405)                /* default: 200 */
#define LL_OPTION_INTELLISENSE_INNERTIMEOUT (406)                /* default: 200 */
#define LL_OPTION_MERGE_REPORT_PARAMETERS_WITH_THE_SAME_NAME (407)                /* default: true */
#define LL_OPTION_PERCENTAGEFORMAT_INCLUDES_NBSPACE (408)                /* default: false */
#define LL_OPTION_INCLUDE_QUERIED_VARS_IN_USED_VARIABLES (409)                /* default: false */
#define LL_OPTION_USE_SVG2BMP          (410)                /* default: true (old SVG code...) */
#define LL_OPTION_FORCE_LS_REPORTPARAM_VISIBILITYCHECK (411)                /* default: false */
#define LL_OPTION_SUPPRESS_FUNCTION_POPUP_WITHDEFAULTVALUE (412)                /* default: false */
#define LL_OPTION_SUPPRESS_REPORTPARAMETER_POPUP_WITHDEFAULTVALUE (413)                /* default: false */
#define LL_OPTION_PRINTERLESS_FORCE_FIT_LAYOUT_ORIENTATION (414)                /* default: false */
#define LL_OPTION_COMPAT_DO_NOT_REPEAT_LINKED_OBJECTS (415)                /* default: false */
#define LL_OPTION_EVALUATEISVOLATILE   (416)                /* default: false */
#define LL_OPTION_BITMAP_OUTOFMEMORY_FORCETHROW (417)                /* default: 0 */
#define LL_OPTION_REPEAT_GROUPHEADER_ONLY_IF_FORCED (418)                /* default: false */
#define LL_OPTION_COMPAT_SHOWMAILPROVIDER (419)                /* default: false */
#define LL_OPTION_BASE64TEMPFILECACHESIZE (420)                /* default: 200 */
#define LL_OPTIONSTR_LABEL_PRJEXT      (0)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_LABEL_PRVEXT      (1)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_LABEL_PRNEXT      (2)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_CARD_PRJEXT       (3)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_CARD_PRVEXT       (4)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_CARD_PRNEXT       (5)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_LIST_PRJEXT       (6)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_LIST_PRVEXT       (7)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_LIST_PRNEXT       (8)                  /* internal... (compatibility to L6) */
#define LL_OPTIONSTR_LLXPATHLIST       (12)                
#define LL_OPTIONSTR_SHORTDATEFORMAT   (13)                
#define LL_OPTIONSTR_DECIMAL           (14)                 /* decimal point, default: system */
#define LL_OPTIONSTR_THOUSAND          (15)                 /* thousands separator, default: system */
#define LL_OPTIONSTR_CURRENCY          (16)                 /* currency symbol, default: system */
#define LL_OPTIONSTR_EXPORTS_AVAILABLE (17)                 /* r/o */
#define LL_OPTIONSTR_EXPORTS_ALLOWED   (18)                
#define LL_OPTIONSTR_DEFDEFFONT        (19)                 /* in "{(r,g,b),size,<logfont>}" */
#define LL_OPTIONSTR_EXPORTFILELIST    (20)                
#define LL_OPTIONSTR_VARALIAS          (21)                 /* "<local>=<global>" */
#define LL_OPTIONSTR_MAILTO            (24)                 /* default TO: address for mailing from viewer */
#define LL_OPTIONSTR_MAILTO_CC         (25)                 /* default CC: address for mailing from viewer */
#define LL_OPTIONSTR_MAILTO_BCC        (26)                 /* default BCC: address for mailing from viewer */
#define LL_OPTIONSTR_MAILTO_SUBJECT    (27)                 /* default subject for mailing from viewer */
#define LL_OPTIONSTR_SAVEAS_PATH       (28)                 /* default filename for saving the LL file from viewer */
#define LL_OPTIONSTR_LABEL_PRJDESCR    (29)                 /* "Etikett" ... */
#define LL_OPTIONSTR_CARD_PRJDESCR     (30)                
#define LL_OPTIONSTR_LIST_PRJDESCR     (31)                
#define LL_OPTIONSTR_LLFILEDESCR       (32)                 /* "Vorschau-Datei" */
#define LL_OPTIONSTR_PROJECTPASSWORD   (33)                 /* w/o, of course :) */
#define LL_OPTIONSTR_FAX_RECIPNAME     (34)                
#define LL_OPTIONSTR_FAX_RECIPNUMBER   (35)                
#define LL_OPTIONSTR_FAX_QUEUENAME     (36)                
#define LL_OPTIONSTR_FAX_SENDERNAME    (37)                
#define LL_OPTIONSTR_FAX_SENDERCOMPANY (38)                
#define LL_OPTIONSTR_FAX_SENDERDEPT    (39)                
#define LL_OPTIONSTR_FAX_SENDERBILLINGCODE (40)                
#define LL_OPTIONSTR_FAX_AVAILABLEQUEUES (42)                 /* r/o (Tab-separated) [job can be -1 or a valid job] */
#define LL_OPTIONSTR_LOGFILEPATH       (43)                
#define LL_OPTIONSTR_LICENSINGINFO     (44)                 /* w/o, SERNO to define licensing state */
#define LL_OPTIONSTR_PRINTERALIASLIST  (45)                 /* multiple "PrnOld=PrnNew1[;PrnNew2[;...]]", erase with NULL or "" */
#define LL_OPTIONSTR_PREVIEWFILENAME   (46)                 /* path of preview file (directory will be overridden by LlPreviewSetTempPath(), if given) */
#define LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW (47)                 /* set in preview file */
#define LL_OPTIONSTR_HELPFILENAME      (48)                
#define LL_OPTIONSTR_NULLVALUE         (49)                 /* string which represents the NULL value */
#define LL_OPTIONSTR_DEFAULT_EXPORT    (50)                 /* default export medium for new projects */
#define LL_OPTIONSTR_ORIGINALPROJECTFILENAME (51)                 /* fixup project path for relative paths in realdata preview/export in designer */
#define LL_OPTIONSTR_HIERARCHICALDATASOURCE_ROOT (52)                 /* internal use only */
#define LL_OPTIONSTR_PRINTERDEFINITIONFILENAME (53)                 /* override for P file name */
#define LL_OPTIONSTR_DOCINFO_DATATYPE  (54)                 /* DOCINFO.lpszDatatype */
#define LL_OPTIONSTR_IDX_PRJEXT        (55)                
#define LL_OPTIONSTR_IDX_PRVEXT        (56)                
#define LL_OPTIONSTR_IDX_PRNEXT        (57)                
#define LL_OPTIONSTR_TOC_PRJDESCR      (58)                
#define LL_OPTIONSTR_IDX_PRJDESCR      (59)                
#define LL_OPTIONSTR_TOC_PRJEXT        (60)                
#define LL_OPTIONSTR_TOC_PRVEXT        (61)                
#define LL_OPTIONSTR_TOC_PRNEXT        (62)                
#define LL_OPTIONSTR_DEFAULTSCHEME     (63)                 /* default: empty (COMBIT) */
#define LL_OPTIONSTR_DEFAULTPROJECTNAME (64)                 /* DOCINFO.lpszDatatype */
#define LL_OPTIONSTR_GTC_PRJEXT        (65)                
#define LL_OPTIONSTR_GTC_PRVEXT        (66)                
#define LL_OPTIONSTR_GTC_PRNEXT        (67)                
#define LL_OPTIONSTR_GTC_PRJDESCR      (68)                
#define LL_OPTIONSTR_ERRORTEXT_FROM_EXPORT (69)                 /* r/o */
#define LL_OPTIONSTR_DEFAULTPRJDESCR   (70)                 /* default: empty (localized version of 'List & Label project file') */
#define LL_OPTIONSTR_DEFAULTPRINTER    (71)                 /* if set, this printer is used instead of the system's default printer (applies to ALL JOBS, so job ID must be "-1"!) */
#define LL_OPTIONSTR_QUERY_LICENSINGINFO (72)                 /* r/o, returns serial number in return value */
#define LL_OPTIONSTR_RESERVED73        (73)                
#define LL_OPTIONSTR_REPRESENTATION_BOOL_TRUE (74)                
#define LL_OPTIONSTR_REPRESENTATION_BOOL_FALSE (75)                
#define LL_OPTIONSTR_DEFAULT_FILENAME_FOR_SAVEAS (76)                 /* if set, this filename is used as a default name when "Save as" is chosen from the menu */
#define LL_OPTIONSTR_LABEL_PRJDESCR_SINGULAR (77)                
#define LL_OPTIONSTR_LIST_PRJDESCR_SINGULAR (78)                
#define LL_OPTIONSTR_CARD_PRJDESCR_SINGULAR (79)                
#define LL_OPTIONSTR_TOC_PRJDESCR_SINGULAR (80)                
#define LL_OPTIONSTR_IDX_PRJDESCR_SINGULAR (81)                
#define LL_OPTIONSTR_GTC_PRJDESCR_SINGULAR (82)                
#define LL_OPTIONSTR_DEFAULTIMAGEPATH  (83)                
#define LL_OPTIONSTR_EMBEDDED_EXPORTS  (84)                 /* ';' separated list of exports, for example "DOCX;XLSX;PDF". default: none. NOT COMPATIBLE WITH LL_QUERY_FILENAME_FOR_EXPORTJOB (!) */
#define LL_OPTIONSTR_DRILLDOWN_ROOT    (85)                 /* internal */
#define LL_OPTIONSTR_LEGACY_EXPORTERS_ALLOWED (86)                 /* ';' separated list of legacy exporters (JQM, HTML) to be allowed. Default is empty. */
#define LL_OPTIONSTR_CHART_AXISLABEL_SPACINGDELTA (87)                 /* ';' separated list of spacing deltas (coord-x;coord-y;coord-z;label-x;label-y;label-z). Default is empty, hence all zero. */
#define LL_OPTIONSTR_INTELLISENSE_CONSTANTSFILTER (88)                 /* ';' separated list e.g. "-LL.Color*;+*" (deny all entries beginning with LL.Color and allow the rest). Default is empty (hence no constants in Intellisense). */
#define LL_OPTIONSTR_WEBDESIGNER_TABLERENDERLAYER (89)                 /* internal */
#define LL_OPTIONSTR_SYSINFO           (90)                 /* '\n' read only separated list of sysinfo e.g containing loaded modules */
#define LL_OPTIONSTR_DEFAULTVARHINT    (91)                 /* hint to be displayed in the function wizard if no variable or function is selected */
#define LL_OPTIONSTR_REPORTPARAMDLGTITLE (92)                 /* title for the report parameter value dialog that is displayed on exporting */
#define LL_OPTIONSTR_DEFAULTIMAGEPATH_FOR_REPOSITORY (93)                
#define LL_OPTIONSTR_DEFAULTCHARTSCHEME (94)                 /* default: combit2 (empty equals use of project scheme) */
#define LL_OPTIONSTR_TIMEZONE_DATABASE (95)                
#define LL_OPTIONSTR_TIMEZONE_CLIENT   (96)                
#define LL_SYSCOMMAND_MINIMIZE         (-1)                
#define LL_SYSCOMMAND_MAXIMIZE         (-2)                
#define LL_PHFG_AGGREGATE              (0x01)              
#define LL_PHFG_PRINT                  (0x02)              
#define LL_PHFG_CROSSTAB               (0x04)              
#define LL_PHFG_OTHERS                 (0x08)              
#define LL_PHFG_ALL                    (0xFF)              
#define LL_DLGBOXMODE_3DBUTTONS        (0x8000)             /* 'or'ed */
#define LL_DLGBOXMODE_3DFRAME2         (0x4000)             /* 'OR'ed */
#define LL_DLGBOXMODE_3DFRAME          (0x1000)             /* 'OR'ed */
#define LL_DLGBOXMODE_NOBITMAPS        (0x2000)             /* 'or'ed */
#define LL_DLGBOXMODE_DONTCARE         (0x0000)             /* load from INI */
#define LL_DLGBOXMODE_SAA              (0x0001)            
#define LL_DLGBOXMODE_ALT1             (0x0002)            
#define LL_DLGBOXMODE_ALT2             (0x0003)            
#define LL_DLGBOXMODE_ALT3             (0x0004)            
#define LL_DLGBOXMODE_ALT4             (0x0005)            
#define LL_DLGBOXMODE_ALT5             (0x0006)            
#define LL_DLGBOXMODE_ALT6             (0x0007)            
#define LL_DLGBOXMODE_ALT7             (0x0008)            
#define LL_DLGBOXMODE_ALT8             (0x0009)             /* Win95 */
#define LL_DLGBOXMODE_ALT9             (0x000A)             /* Win98 */
#define LL_DLGBOXMODE_ALT10            (0x000B)             /* Win98 with gray/color button bitmaps like IE4 */
#define LL_DLGBOXMODE_TOOLTIPS98       (0x0800)             /* DEPRECATED. Do not change.  */
#define LL_CTL_ADDTOSYSMENU            (0x00000004)         /* from CTL */
#define LL_CTL_ALSOCHILDREN            (0x00000010)        
#define LL_CTL_CONVERTCONTROLS         (0x00010000)        
#define LL_GROUP_ALWAYSFOOTER          (0x40000000)        
#define LL_PRINTERCONFIG_SAVE          (1)                 
#define LL_PRINTERCONFIG_RESTORE       (2)                 
#define LL_PRJTYPE_OPTION_FORCEDEFAULTSETTINGS (0x8000)            
#define LL_PRJTYPE_OPTION_CREATEPARTSFROMPROJECT (0x4000)            
#define LL_PRJTYPE_OPTION_NOMERGEPRINTERSETTINGS (0x2000)            
#define LL_RTFTEXTMODE_RTF             (0x0000)            
#define LL_RTFTEXTMODE_PLAIN           (0x0001)            
#define LL_RTFTEXTMODE_EVALUATED       (0x0000)            
#define LL_RTFTEXTMODE_RAW             (0x0002)            
#define LL_RTFTEXTFLAG_ALL             (0x0000)            
#define LL_RTFTEXTFLAG_SELECTION       (0x0004)            
#define LL_ENUMFLAG_INCLUDE_INTERNAL   (1)                  /* include internal variables/fields */
#define LL_ERR_BAD_JOBHANDLE           (-1)                 /* bad jobhandle */
#define LL_ERR_TASK_ACTIVE             (-2)                 /* LlDefineLayout() only once in a job */
#define LL_ERR_BAD_OBJECTTYPE          (-3)                 /* nObjType must be one of the allowed values (obsolete constant) */
#define LL_ERR_BAD_PROJECTTYPE         (-3)                 /* nObjType must be one of the allowed values */
#define LL_ERR_PRINTING_JOB            (-4)                 /* print job not opened, no print object */
#define LL_ERR_NO_BOX                  (-5)                 /* LlPrintSetBoxText(...) called when no abort box exists! */
#define LL_ERR_ALREADY_PRINTING        (-6)                 /* the current operation cannot be performed while a print job is open */
#define LL_ERR_NOT_YET_PRINTING        (-7)                 /* LlPrintGetOptionString... */
#define LL_ERR_NO_PROJECT              (-10)                /* object with requested name does not exist (former ERR_NO_OBJECT) */
#define LL_ERR_NO_PRINTER              (-11)                /* printer couldn't be opened */
#define LL_ERR_PRINTING                (-12)                /* error while printing */
#define LL_ERR_EXPORTING               (-13)                /* error while exporting */
#define LL_ERR_NEEDS_VB                (-14)                /* '11...' needs VB.EXE */
#define LL_ERR_BAD_PRINTER             (-15)                /* PrintOptionsDialog(): no printer available */
#define LL_ERR_NO_PREVIEWMODE          (-16)                /* Preview functions: not in preview mode */
#define LL_ERR_NO_PREVIEWFILES         (-17)                /* PreviewDisplay(): no file found */
#define LL_ERR_PARAMETER               (-18)                /* bad parameter (usually NULL pointer) */
#define LL_ERR_BAD_EXPRESSION          (-19)                /* bad expression in LlExprEvaluate() and LlExprType() */
#define LL_ERR_BAD_EXPRMODE            (-20)                /* bad expression mode (LlSetExpressionMode()) */
#define LL_ERR_NO_TABLE                (-21)                /* not used */
#define LL_ERR_CFGNOTFOUND             (-22)                /* on LlPrintStart(), LlPrintWithBoxStart() [not found] */
#define LL_ERR_EXPRESSION              (-23)                /* on LlPrintStart(), LlPrintWithBoxStart() */
#define LL_ERR_CFGBADFILE              (-24)                /* on LlPrintStart(), LlPrintWithBoxStart() [read error, bad format] */
#define LL_ERR_BADOBJNAME              (-25)                /* on LlPrintEnableObject() - not a ':' at the beginning */
#define LL_ERR_NOOBJECT                (-26)                /* on LlPrintEnableObject() - "*" and no object in project */
#define LL_ERR_UNKNOWNOBJECT           (-27)                /* on LlPrintEnableObject() - object with that name not existing */
#define LL_ERR_NO_TABLEOBJECT          (-28)                /* LlPrint...Start() and no list in Project, or: */
#define LL_ERR_NO_OBJECT               (-29)                /* LlPrint...Start() and no object in project */
#define LL_ERR_NO_TEXTOBJECT           (-30)                /* LlPrintGetTextCharsPrinted() and no printable text in Project! */
#define LL_ERR_UNKNOWN                 (-31)                /* LlPrintIsVariableUsed(), LlPrintIsFieldUsed() */
#define LL_ERR_BAD_MODE                (-32)                /* LlPrintFields(), LlPrintIsFieldUsed() called on non-OBJECT_LIST */
#define LL_ERR_CFGBADMODE              (-33)                /* on LlDefineLayout(), LlPrint...Start(): file is in wrong expression mode */
#define LL_ERR_ONLYWITHONETABLE        (-34)                /* on LlDefinePageSeparation(), LlDefineGrouping() */
#define LL_ERR_UNKNOWNVARIABLE         (-35)                /* on LlGetVariableContents() */
#define LL_ERR_UNKNOWNFIELD            (-36)                /* on LlGetFieldContents() */
#define LL_ERR_UNKNOWNSORTORDER        (-37)                /* on LlGetFieldContents() */
#define LL_ERR_NOPRINTERCFG            (-38)                /* on LlPrintCopyPrinterConfiguration() - no or bad file */
#define LL_ERR_SAVEPRINTERCFG          (-39)                /* on LlPrintCopyPrinterConfiguration() - file could not be saved */
#define LL_ERR_NOVALIDPAGES            (-41)                /* could also be that 16 bit Viewer tries to open 32bit-only storage */
#define LL_ERR_NOTINHOSTPRINTERMODE    (-42)                /* cannot be done in Host Printer Mode (LlSetPrinterInPrinterFile()) */
#define LL_ERR_NOTFINISHED             (-43)                /* appears when a project reset() is done, but the table not finished */
#define LL_ERR_BUFFERTOOSMALL          (-44)                /* LlXXGetOptionStr() */
#define LL_ERR_BADCODEPAGE             (-45)                /* LL_OPTION_CODEPAGE */
#define LL_ERR_CANNOTCREATETEMPFILE    (-46)                /* cannot create temporary file */
#define LL_ERR_NODESTINATION           (-47)                /* no valid export destination */
#define LL_ERR_NOCHART                 (-48)                /* no chart control present */
#define LL_ERR_TOO_MANY_CONCURRENT_PRINTJOBS (-49)                /* WebServer: not enough print process licenses */
#define LL_ERR_BAD_WEBSERVER_LICENSE   (-50)                /* WebServer: bad license file */
#define LL_ERR_NO_WEBSERVER_LICENSE    (-51)                /* WebServer: no license file */
#define LL_ERR_INVALIDDATE             (-52)                /* LlSystemTimeFromLocaleString(): date not valid! */
#define LL_ERR_DRAWINGNOTFOUND         (-53)                /* only if LL_OPTION_ERR_ON_FILENOTFOUND set */
#define LL_ERR_NOUSERINTERACTION       (-54)                /* a call is used which would show a dialog, but LL is in Webserver mode */
#define LL_ERR_BADDATABASESTRUCTURE    (-55)                /* the project that is loading has a table that is not supported by the database */
#define LL_ERR_UNKNOWNPROPERTY         (-56)               
#define LL_ERR_INVALIDOPERATION        (-57)               
#define LL_ERR_PROPERTY_ALREADY_DEFINED (-58)               
#define LL_ERR_CFGFOUND                (-59)                /* on LlPrjOpen() with CREATE_NEW disposition, or of project file is r/o and access flag is r/w */
#define LL_ERR_SAVECFG                 (-60)                /* error while saving (LlProjectSave()) */
#define LL_ERR_WRONGTHREAD             (-61)                /* internal (.NET) */
#define LL_ERR_NO_SUCH_INFORMATION     (-62)               
#define LL_ERR_SINK_ALREADY_PRESENT    (-63)               
#define LL_ERR_SINK_NOT_PRESENT        (-64)               
#define LL_ERR_ACCESS_DENIED           (-65)               
#define LL_ERR_IDLEITERATION_DETECTED  (-66)               
#define LL_ERR_USER_ABORTED            (-99)                /* user aborted printing */
#define LL_ERR_BAD_DLLS                (-100)               /* DLLs not up to date (CTL, DWG, UTIL) */
#define LL_ERR_NO_LANG_DLL             (-101)               /* no or out-of-date language resource DLL */
#define LL_ERR_NO_MEMORY               (-102)               /* out of memory */
#define LL_ERR_EXCEPTION               (-104)               /* there was a GPF during the API execution. Any action that follows might cause problems! */
#define LL_ERR_LICENSEVIOLATION        (-105)               /* your license does not allow this call (see LL_OPTIONSTR_LICENSINGINFO) */
#define LL_ERR_NOT_SUPPORTED_IN_THIS_OS (-106)               /* the OS does not support this function */
#define LL_ERR_NO_MORE_DATA            (-107)              
#define LL_HINT_ABORT                  (-200)               /* LL aborted printing - data collection complete */
#define LL_WRN_FIRSTWARNING            (-900)              
#define LL_WRN_REPORTPARAMETERS_COLLECTION_FINISHED (-994)               /* internal use */
#define LL_WRN_ISNULL                  (-995)               /* LlExprEvaluate[Var]() */
#define LL_WRN_TABLECHANGE             (-996)              
#define LL_WRN_PRINTFINISHED           (-997)               /* LlRTFDisplay() */
#define LL_WRN_REPEAT_DATA             (-998)               /* notification: page is full, prepare for next page */
#define LL_CHAR_TEXTQUOTE              (1)                 
#define LL_CHAR_PHANTOMSPACE           (0x200b)            
#define LL_CHAR_LOCK                   (0x2060)            
#define LL_CHAR_NEWLINE                (182)                /* "¶" */
#define LL_CHAR_EXPRSEP                (164)                /* "¤" */
#define LL_CHAR_TAB                    (247)                /* "÷" */
#define LL_CHAR_EAN128NUL              (255)               
#define LL_CHAR_EAN128FNC1             (254)               
#define LL_CHAR_EAN128FNC2             (253)               
#define LL_CHAR_EAN128FNC3             (252)               
#define LL_CHAR_EAN128FNC4             (251)               
#define LL_CHAR_CODE93NUL              (255)               
#define LL_CHAR_CODE93EXDOLLAR         (254)               
#define LL_CHAR_CODE93EXPERC           (253)               
#define LL_CHAR_CODE93EXSLASH          (252)               
#define LL_CHAR_CODE93EXPLUS           (251)               
#define LL_CHAR_CODE39NUL              (255)               
#define LL_DLGEXPR_VAREXTBTN_ENABLE    (0x00000001)         /* callback for simple Wizard extension */
#define LL_DLGEXPR_VAREXTBTN_DOMODAL   (0x00000002)        
#define LL_LLX_EXTENSIONTYPE_EXPORT    (1)                 
#define LL_LLX_EXTENSIONTYPE_BARCODE   (2)                 
#define LL_LLX_EXTENSIONTYPE_OBJECT    (3)                  /* nyi */
#define LL_LLX_EXTENSIONTYPE_WIZARD    (4)                  /* nyi */
#define LL_LLX_EXTENSIONTYPEFLAG_FORCE_PUBLIC (0x00010000)        
#define LL_LLX_EXTENSIONTYPEFLAG_FORCE_PRIVATE (0x00020000)        
#define LL_LLX_EXTENSIONTYPE_TYPEMASK  (0x0000000f)        
#define LL_DECLARECHARTROW_FOR_OBJECTS (0x00000001)        
#define LL_DECLARECHARTROW_FOR_TABLECOLUMNS (0x00000002)         /* body only */
#define LL_DECLARECHARTROW_FOR_TABLECOLUMNS_FOOTERS (0x00000004)        
#define LL_GETCHARTOBJECTCOUNT_CHARTOBJECTS (1)                 
#define LL_GETCHARTOBJECTCOUNT_CHARTOBJECTS_BEFORE_TABLE (2)                 
#define LL_GETCHARTOBJECTCOUNT_CHARTCOLUMNS (3)                  /* body only */
#define LL_GETCHARTOBJECTCOUNT_CHARTCOLUMNS_FOOTERS (4)                 
#define LL_GRIPT_DIM_SCM               (1)                 
#define LL_GRIPT_DIM_PERC              (2)                 
#define LL_PARAMETERFLAG_PUBLIC        (0x00000000)        
#define LL_PARAMETERFLAG_SAVEDEFAULT   (0x00010000)        
#define LL_PARAMETERFLAG_PRIVATE       (0x40000000)        
#define LL_PARAMETERFLAG_FORMULA       (0x00000000)        
#define LL_PARAMETERFLAG_VALUE         (0x20000000)        
#define LL_PARAMETERFLAG_GLOBAL        (0x00000000)        
#define LL_PARAMETERFLAG_LOCAL         (0x10000000)        
#define LL_PARAMETERFLAG_MASK          (0xffff0000)        
#define LL_PARAMETERTYPE_USER          (0)                 
#define LL_PARAMETERTYPE_FAX           (1)                 
#define LL_PARAMETERTYPE_MAIL          (2)                 
#define LL_PARAMETERTYPE_LLINTERNAL    (4)                 
#define LL_PARAMETERTYPE_MASK          (0x0000000f)        
#define LL_PRJOPEN_AM_READWRITE        (0x40000000)        
#define LL_PRJOPEN_AM_READONLY         (0x00000000)         /* default */
#define LL_PRJOPEN_AM_MASK             (0x40000000)        
#define LL_PRJOPEN_CD_OPEN_EXISTING    (0x00000000)         /* fails if it does not exist - default */
#define LL_PRJOPEN_CD_CREATE_ALWAYS    (0x10000000)         /* open (but do not read contents) if exists, create if not */
#define LL_PRJOPEN_CD_CREATE_NEW       (0x20000000)         /* fails if already exists */
#define LL_PRJOPEN_CD_OPEN_ALWAYS      (0x30000000)         /* open (and load) if exists, create if not */
#define LL_PRJOPEN_CD_MASK             (0x30000000)         /* fails if it does not exist */
#define LL_PRJOPEN_EM_IGNORE_FORMULAERRORS (0x08000000)        
#define LL_PRJOPEN_EM_MASK             (0x08000000)        
#define LL_PRJOPEN_FLG_NOINITPRINTER   (0x04000000)        
#define LL_PRJOPEN_FLG_NOOBJECTLOAD    (0x02000000)        
#define LL_PRJOPEN_FLG_RESERVED        (0x01000000)         /* internal use */
#define LL_ASSOCIATEPREVIEWCONTROLFLAG_DELETE_ON_CLOSE (0x0001)            
#define LL_ASSOCIATEPREVIEWCONTROLFLAG_HANDLE_IS_ATTACHINFO (0x0002)            
#define LL_ASSOCIATEPREVIEWCONTROLFLAG_PRV_REPLACE (0x0000)            
#define LL_ASSOCIATEPREVIEWCONTROLFLAG_PRV_ADD_TO_CONTROL_STACK (0x0004)            
#define LL_ASSOCIATEPREVIEWCONTROLFLAG_PRV_ADD_TO_CONTROL_IN_TAB (0x0008)            
#define LL_ASSOCIATEPREVIEWCONTROLMASK_ATTACHLOCATION (0x003c)            
#define LL_DESFILEOPEN_OPEN_EXISTING   (0x00000000)         /* fails if it does not exist - default */
#define LL_DESFILEOPEN_CREATE_ALWAYS   (0x10000000)         /* open (but do not read contents) if exists, create if not */
#define LL_DESFILEOPEN_CREATE_NEW      (0x20000000)         /* fails if already exists */
#define LL_DESFILEOPEN_OPEN_ALWAYS     (0x30000000)         /* open (and load) if exists, create if not */
#define LL_DESFILEOPEN_OPEN_IMPORT     (0x40000000)         /* fails if it does not exist - only imports data */
#define LL_DESFILEOPEN_OPENMASK        (0x70000000)        
#define LL_DESFILEOPENFLAG_SUPPRESS_SAVEDIALOG (0x00000001)        
#define LL_DESFILEOPENFLAG_SUPPRESS_SAVE (0x00000002)        
#define LL_DESFILESAVE_DEFAULT         (0x00000000)         /* default */
#define LLDESADDACTIONFLAG_ADD_TO_TOOLBAR (0x20000000)        
#define LLDESADDACTION_MENUITEM_APPEND (0x00000000)        
#define LLDESADDACTION_MENUITEM_INSERT (0x10000000)        
#define LLDESADDACTION_MENUITEM_POSITIONMASK (0x10000000)        
#define LLDESADDACTION_ACCEL_CONTROL   (0x00010000)        
#define LLDESADDACTION_ACCEL_SHIFT     (0x00020000)        
#define LLDESADDACTION_ACCEL_ALT       (0x00040000)        
#define LLDESADDACTION_ACCEL_VIRTKEY   (0x00080000)        
#define LLDESADDACTION_ACCEL_KEYMODIFIERMASK (0x000f0000)        
#define LLDESADDACTION_ACCEL_KEYCODEMASK (0x0000ffff)        
#define LL_DESIGNEROPTSTR_PROJECTFILENAME (1)                 
#define LL_DESIGNEROPTSTR_WORKSPACETITLE (2)                 
#define LL_DESIGNEROPTSTR_PROJECTDESCRIPTION (3)                 
#define LL_USEDIDENTIFIERSFLAG_VARIABLES (0x0001)            
#define LL_USEDIDENTIFIERSFLAG_FIELDS  (0x0002)            
#define LL_USEDIDENTIFIERSFLAG_CHARTFIELDS (0x0004)            
#define LL_USEDIDENTIFIERSFLAG_TABLES  (0x0008)            
#define LL_USEDIDENTIFIERSFLAG_RELATIONS (0x0010)            
#define LL_USEDIDENTIFIERSFLAG_FILES   (0x0020)            
#define LL_TEMPFILENAME_DEFAULT        (0x0000)             /* see UT */
#define LL_TEMPFILENAME_ENSURELONGPATH (0x0001)             /* see UT */
#define LL_DICTIONARY_TYPE_STATIC      (1)                 
#define LL_DICTIONARY_TYPE_IDENTIFIER  (2)                 
#define LL_DICTIONARY_TYPE_TABLE       (3)                 
#define LL_DICTIONARY_TYPE_RELATION    (4)                 
#define LL_DICTIONARY_TYPE_SORTORDER   (5)                 
#define LL_DICTIONARY_TYPE_ALL         (0)                  /* only valid for NULL, NULL to clear all dictionaries in one run */
#define LL_UILANGUAGETYPE_NORMAL       (0x00000001)        
#define LL_UILANGUAGETYPE_TRIAL        (0x00000002)        
#define LL_ADDTABLEOPT_SUPPORTSSTACKEDSORTORDERS (0x00000001)        
#define LL_ADDTABLEOPT_SUPPORTSADVANCEDFILTERING (0x00000002)        
#define LL_ADDTABLEOPT_1TO1_RELATION_ONLY (0x00000004)        
#define LL_INPLACEDESIGNERINTERACTION_QUERY_CANCLOSE (1)                  /* wParam = 0, lParam = &BOOL */
#define LL_EXPRXLATRESULT_OPTIMAL      (0x00000000)        
#define LL_EXPRXLATRESULT_PARTIAL      (0x00000001)        
#define LL_EXPRXLATRESULT_FAIL         (0x00000002)        
#define LL_EXPRXLATRESULT_MASK         (0x00000007)         /* some reserve */
#define LLSRTRIGGEREXPORT_DISCARD_EXPANDABLE_REGIONS (1)                 
#define LLJOBOPENCOPYEXFLAG_NO_COPY_FIELDLIST (0x0001)            
#define LLJOBOPENCOPYEXFLAG_NO_COPY_DBSTRUCTS (0x0002)            
#define LLJOBOPENCOPYEXFLAG_NO_COPY_XLATTABLES (0x0004)            
#define LLJOBOPENCOPYEXFLAG_NO_COPY_LLXPARAMETERS (0x0008)            
#define LL_FIND_AND_REPLACE_FLAG_CASEINSENSITIVE (0)                 
#define LL_FIND_AND_REPLACE_FLAG_CASESENSITIVE (1)                 

#endif  /* #ifndef _LL30_CH */


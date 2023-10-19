#include "stdafx.h"
#define _NO_CMLL29APIDEFINES
#include "..\..\Visual C++\cmbtll29.h"
#define PHP_MAXSTRLEN 	128000

ZEND_BEGIN_ARG_INFO_EX(arginfo_void, 0, 0, 0)
ZEND_END_ARG_INFO()

// Hier werden alle Funktionen deklariert,
// die später in PHP verfügbar sein sollen
ZEND_FUNCTION(LlDbAddTable);
ZEND_FUNCTION(LlDebugOutput);
ZEND_FUNCTION(LlDefineField);
ZEND_FUNCTION(LlDefineFieldExt);
ZEND_FUNCTION(LlDefineVariable);
ZEND_FUNCTION(LlDefineVariableStart);
ZEND_FUNCTION(LlGetErrortext);
ZEND_FUNCTION(LlGetVariableContents);
ZEND_FUNCTION(LlGetVersion);
ZEND_FUNCTION(LlJobClose);
ZEND_FUNCTION(LlJobOpen);
ZEND_FUNCTION(LlPrint);
ZEND_FUNCTION(LlPrintEnd);
ZEND_FUNCTION(LlPrintFields);
ZEND_FUNCTION(LlPrintFieldsEnd);
ZEND_FUNCTION(LlPrintGetCurrentPage);
ZEND_FUNCTION(LlPrintGetOption);
ZEND_FUNCTION(LlPrintGetOptionString);
ZEND_FUNCTION(LlPrintSetOptionString);
ZEND_FUNCTION(LlPrintStart);
ZEND_FUNCTION(LlSetDebug); 
ZEND_FUNCTION(LlXSetParameter);
ZEND_FUNCTION(LlSetOptionString);
// Hier werden alle Funktionen aufgelistet
// {NULL, NULL, NULL} hat wohl keine Relevanz für uns
zend_function_entry ListLabelPHPModule_functions[] = 
{
	ZEND_FE(LlDbAddTable, arginfo_void)
	ZEND_FE(LlDebugOutput, arginfo_void)
	ZEND_FE(LlDefineField, arginfo_void)
	ZEND_FE(LlDefineFieldExt, arginfo_void)
	ZEND_FE(LlDefineVariable, arginfo_void)
	ZEND_FE(LlDefineVariableStart, arginfo_void)
	ZEND_FE(LlGetErrortext, arginfo_void)
	ZEND_FE(LlGetVariableContents, arginfo_void)
	ZEND_FE(LlGetVersion, arginfo_void)
	ZEND_FE(LlJobClose, arginfo_void)
    ZEND_FE(LlJobOpen, arginfo_void)
	ZEND_FE(LlPrint, arginfo_void)
	ZEND_FE(LlPrintEnd, arginfo_void)
	ZEND_FE(LlPrintFields, arginfo_void)
	ZEND_FE(LlPrintFieldsEnd, arginfo_void)
	ZEND_FE(LlPrintGetCurrentPage, arginfo_void)
	ZEND_FE(LlPrintGetOption, arginfo_void)
	ZEND_FE(LlPrintGetOptionString, arginfo_void)
	ZEND_FE(LlPrintSetOptionString, arginfo_void)
	ZEND_FE(LlPrintStart, arginfo_void)
	ZEND_FE(LlSetDebug, arginfo_void)
	ZEND_FE(LlXSetParameter, arginfo_void)
	ZEND_FE(LlSetOptionString, arginfo_void)
    {NULL, NULL, NULL}
};
// Konstantendeklarationen
ZEND_MINIT_FUNCTION(ListLabelPHPModule)
{
	REGISTER_LONG_CONSTANT("CMBTLANG_DEFAULT",                                       CMBTLANG_DEFAULT,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_GERMAN",                                        CMBTLANG_GERMAN,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_ENGLISH",                                       CMBTLANG_ENGLISH,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_ARABIC",                                        CMBTLANG_ARABIC,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_AFRIKAANS",                                     CMBTLANG_AFRIKAANS,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_ALBANIAN",                                      CMBTLANG_ALBANIAN,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_BASQUE",                                        CMBTLANG_BASQUE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_BULGARIAN",                                     CMBTLANG_BULGARIAN,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_BYELORUSSIAN",                                  CMBTLANG_BYELORUSSIAN,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_CATALAN",                                       CMBTLANG_CATALAN,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_CHINESE",                                       CMBTLANG_CHINESE,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_CROATIAN",                                      CMBTLANG_CROATIAN,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_CZECH",                                         CMBTLANG_CZECH,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_DANISH",                                        CMBTLANG_DANISH,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_DUTCH",                                         CMBTLANG_DUTCH,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_ESTONIAN",                                      CMBTLANG_ESTONIAN,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_FAEROESE",                                      CMBTLANG_FAEROESE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_FARSI",                                         CMBTLANG_FARSI,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_FINNISH",                                       CMBTLANG_FINNISH,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_FRENCH",                                        CMBTLANG_FRENCH,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_GREEK",                                         CMBTLANG_GREEK,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_HEBREW",                                        CMBTLANG_HEBREW,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_HUNGARIAN",                                     CMBTLANG_HUNGARIAN,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_ICELANDIC",                                     CMBTLANG_ICELANDIC,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_INDONESIAN",                                    CMBTLANG_INDONESIAN,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_ITALIAN",                                       CMBTLANG_ITALIAN,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_JAPANESE",                                      CMBTLANG_JAPANESE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_KOREAN",                                        CMBTLANG_KOREAN,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_LATVIAN",                                       CMBTLANG_LATVIAN,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_LITHUANIAN",                                    CMBTLANG_LITHUANIAN,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_NORWEGIAN",                                     CMBTLANG_NORWEGIAN,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_POLISH",                                        CMBTLANG_POLISH,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_PORTUGUESE",                                    CMBTLANG_PORTUGUESE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_ROMANIAN",                                      CMBTLANG_ROMANIAN,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_RUSSIAN",                                       CMBTLANG_RUSSIAN,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_SLOVAK",                                        CMBTLANG_SLOVAK,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_SLOVENIAN",                                     CMBTLANG_SLOVENIAN,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_SERBIAN",                                       CMBTLANG_SERBIAN,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_SPANISH",                                       CMBTLANG_SPANISH,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_SWEDISH",                                       CMBTLANG_SWEDISH,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_THAI",                                          CMBTLANG_THAI,                                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_TURKISH",                                       CMBTLANG_TURKISH,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_UKRAINIAN",                                     CMBTLANG_UKRAINIAN,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_CHINESE_TRADITIONAL",                           CMBTLANG_CHINESE_TRADITIONAL,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_PORTUGUESE_BRAZILIAN",                          CMBTLANG_PORTUGUESE_BRAZILIAN,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_SPANISH_COLOMBIA",                              CMBTLANG_SPANISH_COLOMBIA,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("CMBTLANG_UNSPECIFIED",                                   CMBTLANG_UNSPECIFIED,                                   CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_LINK_HPOS_NONE",                                      LL_LINK_HPOS_NONE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HPOS_START",                                     LL_LINK_HPOS_START,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HPOS_END",                                       LL_LINK_HPOS_END,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HPOS_ABS",                                       LL_LINK_HPOS_ABS,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HPOS_MASK",                                      LL_LINK_HPOS_MASK,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VPOS_NONE",                                      LL_LINK_VPOS_NONE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VPOS_START",                                     LL_LINK_VPOS_START,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VPOS_END",                                       LL_LINK_VPOS_END,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VPOS_ABS",                                       LL_LINK_VPOS_ABS,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VPOS_MASK",                                      LL_LINK_VPOS_MASK,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HSIZE_NONE",                                     LL_LINK_HSIZE_NONE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HSIZE_PROP",                                     LL_LINK_HSIZE_PROP,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HSIZE_INV",                                      LL_LINK_HSIZE_INV,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_HSIZE_MASK",                                     LL_LINK_HSIZE_MASK,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VSIZE_NONE",                                     LL_LINK_VSIZE_NONE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VSIZE_PROP",                                     LL_LINK_VSIZE_PROP,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VSIZE_INV",                                      LL_LINK_VSIZE_INV,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_VSIZE_MASK",                                     LL_LINK_VSIZE_MASK,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_SIZEPOS_MASK",                                   LL_LINK_SIZEPOS_MASK,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LINK_SIZEOFPARENT",                                   LL_LINK_SIZEOFPARENT,                                   CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_PREVIEW_START",                 LL_DESIGNERPRINTCALLBACK_PREVIEW_START,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT",                 LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE",              LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE,              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE",        LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE,        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_EXPORT_START",                  LL_DESIGNERPRINTCALLBACK_EXPORT_START,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT",                  LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE",               LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE,               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE",         LL_DESIGNERPRINTCALLBACK_EXPORT_QUEST_JOBSTATE,         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTTHREAD_STATE_STOPPED",                   LL_DESIGNERPRINTTHREAD_STATE_STOPPED,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTTHREAD_STATE_SUSPENDED",                 LL_DESIGNERPRINTTHREAD_STATE_SUSPENDED,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNERPRINTTHREAD_STATE_RUNNING",                   LL_DESIGNERPRINTTHREAD_STATE_RUNNING,                   CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_JOBOPENFLAG_NOLLXPRELOAD",                            LL_JOBOPENFLAG_NOLLXPRELOAD,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_JOBOPENFLAG_ONLYEXACTLANGUAGE",                       LL_JOBOPENFLAG_ONLYEXACTLANGUAGE,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTLL",                                        LL_DEBUG_CMBTLL,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTDWG",                                       LL_DEBUG_CMBTDWG,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTLL_NOCALLBACKS",                            LL_DEBUG_CMBTLL_NOCALLBACKS,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTLL_NOSTORAGE",                              LL_DEBUG_CMBTLL_NOSTORAGE,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTLL_NOWAITDLG",                              LL_DEBUG_CMBTLL_NOWAITDLG,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTLL_NOSYSINFO",                              LL_DEBUG_CMBTLL_NOSYSINFO,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTLL_LOGTOFILE",                              LL_DEBUG_CMBTLL_LOGTOFILE,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DEBUG_CMBTLS",                                        LL_DEBUG_CMBTLS,                                        CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DEBUG_PRNINFO",										 LL_DEBUG_PRNINFO,										 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_VERSION_MAJOR",                                       LL_VERSION_MAJOR,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_VERSION_MINOR",                                       LL_VERSION_MINOR,                                       CONST_CS | CONST_PERSISTENT);
  	REGISTER_LONG_CONSTANT("LL_CMND_DRAW_USEROBJ",                                   LL_CMND_DRAW_USEROBJ,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_EDIT_USEROBJ",                                   LL_CMND_EDIT_USEROBJ,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_GETSIZE_USEROBJ",                                LL_CMND_GETSIZE_USEROBJ,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_GETSIZE_USEROBJ_SCM",                            LL_CMND_GETSIZE_USEROBJ_SCM,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_GETSIZE_USEROBJ_PIXEL",							 LL_CMND_GETSIZE_USEROBJ_PIXEL,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_CMND_TABLELINE",                                      LL_CMND_TABLELINE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_LINE_HEADER",                                   LL_TABLE_LINE_HEADER,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_LINE_BODY",                                     LL_TABLE_LINE_BODY,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_LINE_FOOTER",                                   LL_TABLE_LINE_FOOTER,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_LINE_FILL",                                     LL_TABLE_LINE_FILL,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_LINE_GROUP",                                    LL_TABLE_LINE_GROUP,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_LINE_GROUPFOOTER",                              LL_TABLE_LINE_GROUPFOOTER,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_TABLEFIELD",                                     LL_CMND_TABLEFIELD,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FIELD_HEADER",                                  LL_TABLE_FIELD_HEADER,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FIELD_BODY",                                    LL_TABLE_FIELD_BODY,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FIELD_FOOTER",                                  LL_TABLE_FIELD_FOOTER,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FIELD_FILL",                                    LL_TABLE_FIELD_FILL,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FIELD_GROUP",                                   LL_TABLE_FIELD_GROUP,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FIELD_GROUPFOOTER",                             LL_TABLE_FIELD_GROUPFOOTER,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_EVALUATE",                                       LL_CMND_EVALUATE,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_OBJECT",                                         LL_CMND_OBJECT,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_PAGE",                                           LL_CMND_PAGE,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_PROJECT",                                        LL_CMND_PROJECT,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_DRAW_GROUP_BEGIN",                               LL_CMND_DRAW_GROUP_BEGIN,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_DRAW_GROUP_END",                                 LL_CMND_DRAW_GROUP_END,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_DRAW_GROUPLINE",                                 LL_CMND_DRAW_GROUPLINE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RSP_GROUP_IMT",                                       LL_RSP_GROUP_IMT,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RSP_GROUP_NEXTPAGE",                                  LL_RSP_GROUP_NEXTPAGE,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RSP_GROUP_OK",                                        LL_RSP_GROUP_OK,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RSP_GROUP_DRAWFOOTER",                                LL_RSP_GROUP_DRAWFOOTER,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_HELP",                                           LL_CMND_HELP,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_ENABLEMENU",                                     LL_CMND_ENABLEMENU,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_MODIFYMENU",                                     LL_CMND_MODIFYMENU,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_SELECTMENU",                                     LL_CMND_SELECTMENU,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_GETVIEWERBUTTONSTATE",                           LL_CMND_GETVIEWERBUTTONSTATE,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_VARHELPTEXT",                                    LL_CMND_VARHELPTEXT,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_INFO_METER",                                          LL_INFO_METER,                                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_METERJOB_LOAD",                                       LL_METERJOB_LOAD,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_METERJOB_SAVE",                                       LL_METERJOB_SAVE,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_METERJOB_CONSISTENCYCHECK",                           LL_METERJOB_CONSISTENCYCHECK,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_METERJOB_PASS2",                                      LL_METERJOB_PASS2,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_METERJOB_PASS3",										 LL_METERJOB_PASS3,										 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_NTFY_FAILSFILTER",                                    LL_NTFY_FAILSFILTER,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NTFY_VIEWERBTNCLICKED",                               LL_NTFY_VIEWERBTNCLICKED,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_DLGEXPR_VARBTN",                                 LL_CMND_DLGEXPR_VARBTN,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_HOSTPRINTER",                                    LL_CMND_HOSTPRINTER,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_CREATE_DC",                                       LL_PRN_CREATE_DC,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_DELETE_DC",                                       LL_PRN_DELETE_DC,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_SET_ORIENTATION",                                 LL_PRN_SET_ORIENTATION,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_GET_ORIENTATION",                                 LL_PRN_GET_ORIENTATION,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_EDIT",                                            LL_PRN_EDIT,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_GET_DEVICENAME",                                  LL_PRN_GET_DEVICENAME,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_GET_DRIVERNAME",                                  LL_PRN_GET_DRIVERNAME,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_GET_PORTNAME",                                    LL_PRN_GET_PORTNAME,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_RESET_DC",                                        LL_PRN_RESET_DC,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_COMPARE_PRINTER",                                 LL_PRN_COMPARE_PRINTER,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_GET_PHYSPAGE",                                    LL_PRN_GET_PHYSPAGE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_SET_PHYSPAGE",                                    LL_PRN_SET_PHYSPAGE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_GET_PAPERFORMAT",                                 LL_PRN_GET_PAPERFORMAT,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRN_SET_PAPERFORMAT",                                 LL_PRN_SET_PAPERFORMAT,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OEM_TOOLBAR_START",                                   LL_OEM_TOOLBAR_START,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OEM_TOOLBAR_END",                                     LL_OEM_TOOLBAR_END,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NTFY_EXPRERROR",                                      LL_NTFY_EXPRERROR,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_CHANGE_DCPROPERTIES_CREATE",                     LL_CMND_CHANGE_DCPROPERTIES_CREATE,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_CHANGE_DCPROPERTIES_DOC",                        LL_CMND_CHANGE_DCPROPERTIES_DOC,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_CHANGE_DCPROPERTIES_PAGE",                       LL_CMND_CHANGE_DCPROPERTIES_PAGE,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_CHANGE_DCPROPERTIES_PREPAGE",                    LL_CMND_CHANGE_DCPROPERTIES_PREPAGE,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_MODIFY_METAFILE",                                LL_CMND_MODIFY_METAFILE,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_INFO_PRINTJOBSUPERVISION",                            LL_INFO_PRINTJOBSUPERVISION,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_DELAYEDVALUE",                                   LL_CMND_DELAYEDVALUE,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_SUPPLY_USERDATA",                                LL_CMND_SUPPLY_USERDATA,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CMND_SAVEFILENAME",                                   LL_CMND_SAVEFILENAME,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_QUERY_IS_VARIABLE_OR_FIELD",                          LL_QUERY_IS_VARIABLE_OR_FIELD,                          CONST_CS | CONST_PERSISTENT);
//  REGISTER_LONG_CONSTANT("LL_INTERNAL_MAXEVENTNUMBER",                             LL_INTERNAL_MAXEVENTNUMBER,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NTFY_PROJECTLOADED",                                  LL_NTFY_PROJECTLOADED,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_QUERY_DESIGNERACTIONSTATE",                           LL_QUERY_DESIGNERACTIONSTATE,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NTFY_DESIGNERREADY",                                  LL_NTFY_DESIGNERREADY,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NTFY_DESIGNERPRINTJOB",                               LL_NTFY_DESIGNERPRINTJOB,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NTFY_VIEWERDRILLDOWN",								 LL_NTFY_VIEWERDRILLDOWN,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_NTFY_QUEST_DRILLDOWNDENIED",							 LL_NTFY_QUEST_DRILLDOWNDENIED,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_QUERY_DRILLDOWN_ADDITIONAL_BASETABLES_FOR_VARIABLES", LL_QUERY_DRILLDOWN_ADDITIONAL_BASETABLES_FOR_VARIABLES, CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_QUERY_DRILLDOWN_ADDITIONAL_TABLES",					 LL_QUERY_DRILLDOWN_ADDITIONAL_TABLES,					 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PROJECT_LABEL",                                       LL_PROJECT_LABEL,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PROJECT_LIST",                                        LL_PROJECT_LIST,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PROJECT_CARD",                                        LL_PROJECT_CARD,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PROJECT_MASK",										 LL_PROJECT_MASK,										 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OBJ_MARKER",                                          LL_OBJ_MARKER,                                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_TEXT",                                            LL_OBJ_TEXT,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_RECT",                                            LL_OBJ_RECT,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_LINE",                                            LL_OBJ_LINE,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_BARCODE",                                         LL_OBJ_BARCODE,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_DRAWING",                                         LL_OBJ_DRAWING,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_TABLE",                                           LL_OBJ_TABLE,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_TEMPLATE",                                        LL_OBJ_TEMPLATE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_ELLIPSE",                                         LL_OBJ_ELLIPSE,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_GROUP",                                           LL_OBJ_GROUP,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_RTF",                                             LL_OBJ_RTF,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_LLX",                                             LL_OBJ_LLX,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_INPUT",                                           LL_OBJ_INPUT,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_LAST",                                            LL_OBJ_LAST,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_PROJECT",                                         LL_OBJ_PROJECT,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OBJ_PAGE",                                            LL_OBJ_PAGE,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DELAYEDVALUE",                                        LL_DELAYEDVALUE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TYPEMASK",                                            LL_TYPEMASK,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FOOTERFIELD",                                   LL_TABLE_FOOTERFIELD,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_GROUPFIELD",                                    LL_TABLE_GROUPFIELD,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_HEADERFIELD",                                   LL_TABLE_HEADERFIELD,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_BODYFIELD",                                     LL_TABLE_BODYFIELD,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_GROUPFOOTERFIELD",                              LL_TABLE_GROUPFOOTERFIELD,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABLE_FIELDTYPEMASK",                                 LL_TABLE_FIELDTYPEMASK,                                 CONST_CS | CONST_PERSISTENT);
 	REGISTER_LONG_CONSTANT("LL_BARCODE",                                             LL_BARCODE,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_EAN13",                                       LL_BARCODE_EAN13,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_EAN8",                                        LL_BARCODE_EAN8,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GTIN13",										 LL_BARCODE_GTIN13,										 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_GTIN8",										 LL_BARCODE_GTIN13,										 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_UPCA",                                        LL_BARCODE_UPCA,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_UPCE",                                        LL_BARCODE_UPCE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_3OF9",                                        LL_BARCODE_3OF9,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_25INDUSTRIAL",                                LL_BARCODE_25INDUSTRIAL,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_25INTERLEAVED",                               LL_BARCODE_25INTERLEAVED,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_25DATALOGIC",                                 LL_BARCODE_25DATALOGIC,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_25MATRIX",                                    LL_BARCODE_25MATRIX,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_POSTNET",                                     LL_BARCODE_POSTNET,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_FIM",                                         LL_BARCODE_FIM,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_CODABAR",                                     LL_BARCODE_CODABAR,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_EAN128",                                      LL_BARCODE_EAN128,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GS1_128",									 LL_BARCODE_GS1_128,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_CODE128",                                     LL_BARCODE_CODE128,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_DP_LEITCODE",                                 LL_BARCODE_DP_LEITCODE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_DP_IDENTCODE",                                LL_BARCODE_DP_IDENTCODE,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GERMAN_PARCEL",                               LL_BARCODE_GERMAN_PARCEL,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_CODE93",                                      LL_BARCODE_CODE93,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_MSI",                                         LL_BARCODE_MSI,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_CODE11",                                      LL_BARCODE_CODE11,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_MSI_10_CD",                                   LL_BARCODE_MSI_10_CD,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_MSI_10_10",                                   LL_BARCODE_MSI_10_10,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_MSI_11_10",                                   LL_BARCODE_MSI_11_10,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_MSI_PLAIN",                                   LL_BARCODE_MSI_PLAIN,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_EAN14",                                       LL_BARCODE_EAN14,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GTIN14",										 LL_BARCODE_GTIN14,										 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_UCC14",                                       LL_BARCODE_UCC14,                                       CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_CODE39",                                      LL_BARCODE_CODE39,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_CODE39_CRC43",                                LL_BARCODE_CODE39_CRC43,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_PZN",                                         LL_BARCODE_PZN,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_CODE39_EXT",                                  LL_BARCODE_CODE39_EXT,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_JAPANESE_POSTAL",                             LL_BARCODE_JAPANESE_POSTAL,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_RM4SCC",                                      LL_BARCODE_RM4SCC,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_RM4SCC_CRC",                                  LL_BARCODE_RM4SCC_CRC,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_SSCC",                                        LL_BARCODE_SSCC,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_ISBN",                                        LL_BARCODE_ISBN,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GS1",										 LL_BARCODE_GS1,										 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GS1_TRUNCATED",								 LL_BARCODE_GS1_TRUNCATED,								 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GS1_STACKED",								 LL_BARCODE_GS1_STACKED,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_GS1_STACKED_OMNI",							 LL_BARCODE_GS1_STACKED_OMNI,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_GS1_LIMITED",								 LL_BARCODE_GS1_LIMITED,								 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_GS1_EXPANDED",								 LL_BARCODE_GS1_EXPANDED,								CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_INTELLIGENT_MAIL",							 LL_BARCODE_INTELLIGENT_MAIL,							 CONST_CS |	CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_BARCODE_LLXSTART",                                    LL_BARCODE_LLXSTART,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_PDF417",                                      LL_BARCODE_PDF417,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_MAXICODE",                                    LL_BARCODE_MAXICODE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_MAXICODE_UPS",                                LL_BARCODE_MAXICODE_UPS,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_DATAMATRIX",                                  LL_BARCODE_DATAMATRIX,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_AZTEC",                                       LL_BARCODE_AZTEC,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_QRCODE",                                      LL_BARCODE_QRCODE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_METHODMASK",                                  LL_BARCODE_METHODMASK,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_WITHTEXT",                                    LL_BARCODE_WITHTEXT,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_WITHOUTTEXT",                                 LL_BARCODE_WITHOUTTEXT,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BARCODE_TEXTDONTCARE",                                LL_BARCODE_TEXTDONTCARE,                                CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DRAWING",                                             LL_DRAWING,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_HMETA",                                       LL_DRAWING_HMETA,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_USEROBJ",                                     LL_DRAWING_USEROBJ,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_USEROBJ_DLG",                                 LL_DRAWING_USEROBJ_DLG,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_HBITMAP",                                     LL_DRAWING_HBITMAP,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_HICON",                                       LL_DRAWING_HICON,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_HEMETA",                                      LL_DRAWING_HEMETA,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_HDIB",                                        LL_DRAWING_HDIB,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DRAWING_METHODMASK",                                  LL_DRAWING_METHODMASK,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_META_MAXX",                                           LL_META_MAXX,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_META_MAXY",                                           LL_META_MAXY,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TEXT",                                                LL_TEXT,                                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TEXT_ALLOW_WORDWRAP",                                 LL_TEXT_ALLOW_WORDWRAP,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TEXT_DENY_WORDWRAP",                                  LL_TEXT_DENY_WORDWRAP,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TEXT_FORCE_WORDWRAP",                                 LL_TEXT_FORCE_WORDWRAP,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NUMERIC",                                             LL_NUMERIC,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NUMERIC_LOCALIZED",                                   LL_NUMERIC_LOCALIZED,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NUMERIC_INTEGER",									 LL_NUMERIC_INTEGER,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DATE",                                                LL_DATE,                                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_DELPHI_1",                                       LL_DATE_DELPHI_1,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_DELPHI",                                         LL_DATE_DELPHI,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_MS",                                             LL_DATE_MS,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_OLE",                                            LL_DATE_OLE,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_VFOXPRO",                                        LL_DATE_VFOXPRO,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_DMY",                                            LL_DATE_DMY,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_MDY",                                            LL_DATE_MDY,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_YMD",                                            LL_DATE_YMD,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_YYYYMMDD",                                       LL_DATE_YYYYMMDD,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_LOCALIZED",                                      LL_DATE_LOCALIZED,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_JULIAN",                                         LL_DATE_JULIAN,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_CLARION",                                        LL_DATE_CLARION,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_YMD_AUTO",                                       LL_DATE_YMD_AUTO,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DATE_METHODMASK",                                     LL_DATE_METHODMASK,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOOLEAN",                                             LL_BOOLEAN,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RTF",                                                 LL_RTF,                                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_HTML",                                                LL_HTML,                                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LLXOBJECT",                                           LL_LLXOBJECT,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FIXEDNAME",                                           LL_FIXEDNAME,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NOSAVEAS",                                            LL_NOSAVEAS,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_EXPRCONVERTQUIET",                                    LL_EXPRCONVERTQUIET,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_NONAMEINTITLE",                                       LL_NONAMEINTITLE,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRVOPT_PRN_USEDEFAULT",                               LL_PRVOPT_PRN_USEDEFAULT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRVOPT_PRN_ASKPRINTERIFNEEDED",                       LL_PRVOPT_PRN_ASKPRINTERIFNEEDED,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRVOPT_PRN_ASKPRINTERALWAYS",                         LL_PRVOPT_PRN_ASKPRINTERALWAYS,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRVOPT_PRN_ALWAYSUSEDEFAULT",                         LL_PRVOPT_PRN_ALWAYSUSEDEFAULT,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRVOPT_PRN_ASSIGNMASK",                               LL_PRVOPT_PRN_ASSIGNMASK,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_COPIES",                                       LL_OPTION_COPIES,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_STARTPAGE",                                    LL_OPTION_STARTPAGE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PAGE",                                         LL_OPTION_PAGE,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_OFFSET",                                       LL_OPTION_OFFSET,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_COPIES_SUPPORTED",                             LL_OPTION_COPIES_SUPPORTED,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FIRSTPAGE",                                    LL_OPTION_FIRSTPAGE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_LASTPAGE",                                     LL_OPTION_LASTPAGE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_JOBPAGES",                                     LL_OPTION_JOBPAGES,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRINTORDER",                                   LL_OPTION_PRINTORDER,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_COPIES",                                       LL_PRNOPT_COPIES,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_COPIES_HIDE",                                         LL_COPIES_HIDE,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_STARTPAGE",                                    LL_PRNOPT_STARTPAGE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PAGE",                                         LL_PRNOPT_PAGE,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PAGE_HIDE",                                           LL_PAGE_HIDE,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_OFFSET",                                       LL_PRNOPT_OFFSET,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_COPIES_SUPPORTED",                             LL_PRNOPT_COPIES_SUPPORTED,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_UNITS",                                        LL_PRNOPT_UNITS,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_MM_DIV_10",                                     LL_UNITS_MM_DIV_10,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_INCH_DIV_100",                                  LL_UNITS_INCH_DIV_100,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_INCH_DIV_1000",                                 LL_UNITS_INCH_DIV_1000,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_SYSDEFAULT_LORES",                              LL_UNITS_SYSDEFAULT_LORES,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_SYSDEFAULT",                                    LL_UNITS_SYSDEFAULT,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_MM_DIV_100",                                    LL_UNITS_MM_DIV_100,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_MM_DIV_1000",                                   LL_UNITS_MM_DIV_1000,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_UNITS_SYSDEFAULT_HIRES",                              LL_UNITS_SYSDEFAULT_HIRES,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_FIRSTPAGE",                                    LL_PRNOPT_FIRSTPAGE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_LASTPAGE",                                     LL_PRNOPT_LASTPAGE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_JOBPAGES",                                     LL_PRNOPT_JOBPAGES,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PRINTORDER",                                   LL_PRNOPT_PRINTORDER,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINTORDER_HORZ_LTRB",                                LL_PRINTORDER_HORZ_LTRB,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINTORDER_VERT_LTRB",                                LL_PRINTORDER_VERT_LTRB,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINTORDER_HORZ_RBLT",                                LL_PRINTORDER_HORZ_RBLT,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINTORDER_VERT_RBLT",                                LL_PRINTORDER_VERT_RBLT,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_DEFPRINTERINSTALLED",                          LL_PRNOPT_DEFPRINTERINSTALLED,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PRINTDLG_DESTMASK",                            LL_PRNOPT_PRINTDLG_DESTMASK,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESTINATION_PRN",                                     LL_DESTINATION_PRN,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESTINATION_PRV",                                     LL_DESTINATION_PRV,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESTINATION_FILE",                                    LL_DESTINATION_FILE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESTINATION_EXTERN",                                  LL_DESTINATION_EXTERN,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESTINATION_MSFAX",                                   LL_DESTINATION_MSFAX,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PRINTDLG_DEST",                                LL_PRNOPT_PRINTDLG_DEST,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PRINTDLG_ONLYPRINTERCOPIES",                   LL_PRNOPT_PRINTDLG_ONLYPRINTERCOPIES,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_JOBID",                                        LL_PRNOPT_JOBID,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PAGEINDEX",                                    LL_PRNOPT_PAGEINDEX,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_USES2PASS",                                    LL_PRNOPT_USES2PASS,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PAGERANGE_USES_ABSOLUTENUMBER",                LL_PRNOPT_PAGERANGE_USES_ABSOLUTENUMBER,                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_USEMEMORYMETAFILE",                            LL_PRNOPT_USEMEMORYMETAFILE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPT_PARTIALPREVIEW",                               LL_PRNOPT_PARTIALPREVIEW,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_PRINTDST_FILENAME",                         LL_PRNOPTSTR_PRINTDST_FILENAME,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_EXPORTDESCR",                               LL_PRNOPTSTR_EXPORTDESCR,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_EXPORT",                                    LL_PRNOPTSTR_EXPORT,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_PRINTJOBNAME",                              LL_PRNOPTSTR_PRINTJOBNAME,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_PRESTARTDOCESCSTRING",                      LL_PRNOPTSTR_PRESTARTDOCESCSTRING,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_POSTENDDOCESCSTRING",                       LL_PRNOPTSTR_POSTENDDOCESCSTRING,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_PRESTARTPAGEESCSTRING",                     LL_PRNOPTSTR_PRESTARTPAGEESCSTRING,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_POSTENDPAGEESCSTRING",                      LL_PRNOPTSTR_POSTENDPAGEESCSTRING,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_PRESTARTPROJECTESCSTRING",                  LL_PRNOPTSTR_PRESTARTPROJECTESCSTRING,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_POSTENDPROJECTESCSTRING",                   LL_PRNOPTSTR_POSTENDPROJECTESCSTRING,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_PAGERANGES",                                LL_PRNOPTSTR_PAGERANGES,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_ISSUERANGES",								 LL_PRNOPTSTR_ISSUERANGES,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_PRNOPTSTR_PREVIEWTITLE",								 LL_PRNOPTSTR_PREVIEWTITLE,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_PRINT_V1POINTX",                                      LL_PRINT_V1POINTX,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_NORMAL",                                        LL_PRINT_NORMAL,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_PREVIEW",                                       LL_PRINT_PREVIEW,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_STORAGE",                                       LL_PRINT_STORAGE,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_FILE",                                          LL_PRINT_FILE,                                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_USERSELECT",                                    LL_PRINT_USERSELECT,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_EXPORT",                                        LL_PRINT_EXPORT,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_MODEMASK",                                      LL_PRINT_MODEMASK,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_MULTIPLE_JOBS",                                 LL_PRINT_MULTIPLE_JOBS,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_KEEPJOB",                                       LL_PRINT_KEEPJOB,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_IS_DOM_CALLER",                                 LL_PRINT_IS_DOM_CALLER,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINT_DOM_NOCREATEDC",								 LL_PRINT_DOM_NOCREATEDC,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_PRINT_DOM_NOOBJECTLOAD",								 LL_PRINT_DOM_NOOBJECTLOAD,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_PRINT_REMOVE_UNUSED_VARS",                            LL_PRINT_REMOVE_UNUSED_VARS,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_NONE",                                        LL_BOXTYPE_NONE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_NORMALMETER",                                 LL_BOXTYPE_NORMALMETER,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_BRIDGEMETER",                                 LL_BOXTYPE_BRIDGEMETER,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_NORMALWAIT",                                  LL_BOXTYPE_NORMALWAIT,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_BRIDGEWAIT",                                  LL_BOXTYPE_BRIDGEWAIT,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_EMPTYWAIT",                                   LL_BOXTYPE_EMPTYWAIT,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_EMPTYABORT",                                  LL_BOXTYPE_EMPTYABORT,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_STDWAIT",                                     LL_BOXTYPE_STDWAIT,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_STDABORT",                                    LL_BOXTYPE_STDABORT,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_BOXTYPE_MAX",                                         LL_BOXTYPE_MAX,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FILE_ALSONEW",                                        LL_FILE_ALSONEW,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_DOUBLE",                                  LL_FCTPARATYPE_DOUBLE,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_DATE",                                    LL_FCTPARATYPE_DATE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_STRING",                                  LL_FCTPARATYPE_STRING,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_BOOL",                                    LL_FCTPARATYPE_BOOL,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_DRAWING",                                 LL_FCTPARATYPE_DRAWING,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_BARCODE",                                 LL_FCTPARATYPE_BARCODE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_ALL",                                     LL_FCTPARATYPE_ALL,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_PARA1",                                   LL_FCTPARATYPE_PARA1,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_PARA2",                                   LL_FCTPARATYPE_PARA2,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_PARA3",                                   LL_FCTPARATYPE_PARA3,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_PARA4",                                   LL_FCTPARATYPE_PARA4,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_SAME",                                    LL_FCTPARATYPE_SAME,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPE_MASK",                                    LL_FCTPARATYPE_MASK,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_FCTPARATYPEFLAG_NONULLCHECK",                         LL_FCTPARATYPEFLAG_NONULLCHECK,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_EXPRTYPE_DOUBLE",                                     LL_EXPRTYPE_DOUBLE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_EXPRTYPE_DATE",                                       LL_EXPRTYPE_DATE,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_EXPRTYPE_STRING",                                     LL_EXPRTYPE_STRING,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_EXPRTYPE_BOOL",                                       LL_EXPRTYPE_BOOL,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_EXPRTYPE_DRAWING",                                    LL_EXPRTYPE_DRAWING,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_EXPRTYPE_BARCODE",                                    LL_EXPRTYPE_BARCODE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NEWEXPRESSIONS",                               LL_OPTION_NEWEXPRESSIONS,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ONLYONETABLE",                                 LL_OPTION_ONLYONETABLE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TABLE_COLORING",                               LL_OPTION_TABLE_COLORING,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_COLORING_LL",                                         LL_COLORING_LL,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_COLORING_PROGRAM",                                    LL_COLORING_PROGRAM,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_COLORING_DONTCARE",                                   LL_COLORING_DONTCARE,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SUPERVISOR",                                   LL_OPTION_SUPERVISOR,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_UNITS",                                        LL_OPTION_UNITS,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TABSTOPS",                                     LL_OPTION_TABSTOPS,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABS_DELETE",                                         LL_TABS_DELETE,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_TABS_EXPAND",                                         LL_TABS_EXPAND,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CALLBACKMASK",                                 LL_OPTION_CALLBACKMASK,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CB_PAGE",                                             LL_CB_PAGE,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CB_PROJECT",                                          LL_CB_PROJECT,                                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CB_OBJECT",                                           LL_CB_OBJECT,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CB_HELP",                                             LL_CB_HELP,                                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CB_TABLELINE",                                        LL_CB_TABLELINE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CB_TABLEFIELD",                                       LL_CB_TABLEFIELD,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CB_QUERY_IS_VARIABLE_OR_FIELD",                       LL_CB_QUERY_IS_VARIABLE_OR_FIELD,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CALLBACKPARAMETER",                            LL_OPTION_CALLBACKPARAMETER,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_HELPAVAILABLE",                                LL_OPTION_HELPAVAILABLE,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SORTVARIABLES",                                LL_OPTION_SORTVARIABLES,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SUPPORTPAGEBREAK",                             LL_OPTION_SUPPORTPAGEBREAK,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SHOWPREDEFVARS",                               LL_OPTION_SHOWPREDEFVARS,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_USEHOSTPRINTER",                               LL_OPTION_USEHOSTPRINTER,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_EXTENDEDEVALUATION",                           LL_OPTION_EXTENDEDEVALUATION,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TABREPRESENTATIONCODE",                        LL_OPTION_TABREPRESENTATIONCODE,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SHOWSTATE",									 LL_OPTION_SHOWSTATE,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_METRIC",                                       LL_OPTION_METRIC,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ADDVARSTOFIELDS",                              LL_OPTION_ADDVARSTOFIELDS,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MULTIPLETABLELINES",                           LL_OPTION_MULTIPLETABLELINES,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CONVERTCRLF",                                  LL_OPTION_CONVERTCRLF,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_WIZ_FILENEW",                                  LL_OPTION_WIZ_FILENEW,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RETREPRESENTATIONCODE",                        LL_OPTION_RETREPRESENTATIONCODE,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVZOOM_PERC",                                 LL_OPTION_PRVZOOM_PERC,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVRECT_LEFT",                                 LL_OPTION_PRVRECT_LEFT,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVRECT_TOP",                                  LL_OPTION_PRVRECT_TOP,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVRECT_WIDTH",                                LL_OPTION_PRVRECT_WIDTH,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVRECT_HEIGHT",                               LL_OPTION_PRVRECT_HEIGHT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_STORAGESYSTEM",                                LL_OPTION_STORAGESYSTEM,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_STG_COMPAT4",                                         LL_STG_COMPAT4,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_STG_STORAGE",                                         LL_STG_STORAGE,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_COMPRESSSTORAGE",                              LL_OPTION_COMPRESSSTORAGE,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_STG_COMPRESS_THREADED",                               LL_STG_COMPRESS_THREADED,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_STG_COMPRESS_UNTHREADED",                             LL_STG_COMPRESS_UNTHREADED,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOPARAMETERCHECK",                             LL_OPTION_NOPARAMETERCHECK,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NONOTABLECHECK",                               LL_OPTION_NONOTABLECHECK,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DRAWFOOTERLINEONPRINT",                        LL_OPTION_DRAWFOOTERLINEONPRINT,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVZOOM_LEFT",                                 LL_OPTION_PRVZOOM_LEFT,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVZOOM_TOP",                                  LL_OPTION_PRVZOOM_TOP,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVZOOM_WIDTH",                                LL_OPTION_PRVZOOM_WIDTH,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PRVZOOM_HEIGHT",                               LL_OPTION_PRVZOOM_HEIGHT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SPACEOPTIMIZATION",                            LL_OPTION_SPACEOPTIMIZATION,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_REALTIME",                                     LL_OPTION_REALTIME,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_AUTOMULTIPAGE",                                LL_OPTION_AUTOMULTIPAGE,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_USEBARCODESIZES",                              LL_OPTION_USEBARCODESIZES,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MAXRTFVERSION",                                LL_OPTION_MAXRTFVERSION,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARSCASESENSITIVE",                            LL_OPTION_VARSCASESENSITIVE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DELAYTABLEHEADER",                             LL_OPTION_DELAYTABLEHEADER,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_OFNDIALOG_EXPLORER",                           LL_OPTION_OFNDIALOG_EXPLORER,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_OFN_NOPLACESBAR",                              LL_OPTION_OFN_NOPLACESBAR,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_EMFRESOLUTION",                                LL_OPTION_EMFRESOLUTION,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SETCREATIONINFO",                              LL_OPTION_SETCREATIONINFO,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_XLATVARNAMES",                                 LL_OPTION_XLATVARNAMES,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_LANGUAGE",                                     LL_OPTION_LANGUAGE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PHANTOMSPACEREPRESENTATIONCODE",               LL_OPTION_PHANTOMSPACEREPRESENTATIONCODE,               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_LOCKNEXTCHARREPRESENTATIONCODE",               LL_OPTION_LOCKNEXTCHARREPRESENTATIONCODE,               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_EXPRSEPREPRESENTATIONCODE",                    LL_OPTION_EXPRSEPREPRESENTATIONCODE,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DEFPRINTERINSTALLED",                          LL_OPTION_DEFPRINTERINSTALLED,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CALCSUMVARSONINVISIBLELINES",                  LL_OPTION_CALCSUMVARSONINVISIBLELINES,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOFOOTERPAGEWRAP",                             LL_OPTION_NOFOOTERPAGEWRAP,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_IMMEDIATELASTPAGE",                            LL_OPTION_IMMEDIATELASTPAGE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_LCID",                                         LL_OPTION_LCID,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TEXTQUOTEREPRESENTATIONCODE",                  LL_OPTION_TEXTQUOTEREPRESENTATIONCODE,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SCALABLEFONTSONLY",                            LL_OPTION_SCALABLEFONTSONLY,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOTIFICATIONMESSAGEHWND",                      LL_OPTION_NOTIFICATIONMESSAGEHWND,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DEFDEFFONT",                                   LL_OPTION_DEFDEFFONT,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CODEPAGE",                                     LL_OPTION_CODEPAGE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FORCEFONTCHARSET",                             LL_OPTION_FORCEFONTCHARSET,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_COMPRESSRTF",                                  LL_OPTION_COMPRESSRTF,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ALLOW_LLX_EXPORTERS",                          LL_OPTION_ALLOW_LLX_EXPORTERS,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SUPPORTS_PRNOPTSTR_EXPORT",                    LL_OPTION_SUPPORTS_PRNOPTSTR_EXPORT,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DEBUGFLAG",                                    LL_OPTION_DEBUGFLAG,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SKIPRETURNATENDOFRTF",                         LL_OPTION_SKIPRETURNATENDOFRTF,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_INTERCHARSPACING",                             LL_OPTION_INTERCHARSPACING,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_INCLUDEFONTDESCENT",                           LL_OPTION_INCLUDEFONTDESCENT,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RESOLUTIONCOMPATIBLETO9X",                     LL_OPTION_RESOLUTIONCOMPATIBLETO9X,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_USECHARTFIELDS",                               LL_OPTION_USECHARTFIELDS,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_OFNDIALOG_NOPLACESBAR",                        LL_OPTION_OFNDIALOG_NOPLACESBAR,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SKETCH_COLORDEPTH",                            LL_OPTION_SKETCH_COLORDEPTH,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FINAL_TRUE_ON_LASTPAGE",                       LL_OPTION_FINAL_TRUE_ON_LASTPAGE,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_INTERCHARSPACING_FORCED",                      LL_OPTION_INTERCHARSPACING_FORCED,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RTFAUTOINCREMENT",                             LL_OPTION_RTFAUTOINCREMENT,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_UNITS_DEFAULT",                                LL_OPTION_UNITS_DEFAULT,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NO_MAPI",                                      LL_OPTION_NO_MAPI,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLE",                                 LL_OPTION_TOOLBARSTYLE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLE_STANDARD",                        LL_OPTION_TOOLBARSTYLE_STANDARD,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLE_OFFICEXP",                        LL_OPTION_TOOLBARSTYLE_OFFICEXP,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLE_OFFICE2003",                      LL_OPTION_TOOLBARSTYLE_OFFICE2003,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLEMASK",                             LL_OPTION_TOOLBARSTYLEMASK,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLEFLAG_GRADIENT",                    LL_OPTION_TOOLBARSTYLEFLAG_GRADIENT,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLEFLAG_DOCKABLE",                    LL_OPTION_TOOLBARSTYLEFLAG_DOCKABLE,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLEFLAG_CANCLOSE",                    LL_OPTION_TOOLBARSTYLEFLAG_CANCLOSE,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TOOLBARSTYLEFLAG_SHRINK_TO_FIT",				 LL_OPTION_TOOLBARSTYLEFLAG_SHRINK_TO_FIT,				 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_MENUSTYLE",                                    LL_OPTION_MENUSTYLE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MENUSTYLE_STANDARD_WITHOUT_BITMAPS",           LL_OPTION_MENUSTYLE_STANDARD_WITHOUT_BITMAPS,           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MENUSTYLE_STANDARD",                           LL_OPTION_MENUSTYLE_STANDARD,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MENUSTYLE_OFFICEXP",                           LL_OPTION_MENUSTYLE_OFFICEXP,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MENUSTYLE_OFFICE2003",                         LL_OPTION_MENUSTYLE_OFFICE2003,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RULERSTYLE",                                   LL_OPTION_RULERSTYLE,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RULERSTYLE_FLAT",                              LL_OPTION_RULERSTYLE_FLAT,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RULERSTYLE_GRADIENT",                          LL_OPTION_RULERSTYLE_GRADIENT,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_STATUSBARSTYLE",                               LL_OPTION_STATUSBARSTYLE,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_STATUSBARSTYLE_STANDARD",                      LL_OPTION_STATUSBARSTYLE_STANDARD,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_STATUSBARSTYLE_OFFICEXP",                      LL_OPTION_STATUSBARSTYLE_OFFICEXP,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_STATUSBARSTYLE_OFFICE2003",                    LL_OPTION_STATUSBARSTYLE_OFFICE2003,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TABBARSTYLE",                                  LL_OPTION_TABBARSTYLE,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TABBARSTYLE_STANDARD",                         LL_OPTION_TABBARSTYLE_STANDARD,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TABBARSTYLE_OFFICEXP",                         LL_OPTION_TABBARSTYLE_OFFICEXP,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_TABBARSTYLE_OFFICE2003",                       LL_OPTION_TABBARSTYLE_OFFICE2003,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DROPWINDOWSTYLE",                              LL_OPTION_DROPWINDOWSTYLE,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DROPWINDOWSTYLE_STANDARD",                     LL_OPTION_DROPWINDOWSTYLE_STANDARD,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DROPWINDOWSTYLE_OFFICEXP",                     LL_OPTION_DROPWINDOWSTYLE_OFFICEXP,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DROPWINDOWSTYLE_OFFICE2003",                   LL_OPTION_DROPWINDOWSTYLE_OFFICE2003,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DROPWINDOWSTYLEMASK",                          LL_OPTION_DROPWINDOWSTYLEMASK,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DROPWINDOWSTYLEFLAG_CANCLOSE",                 LL_OPTION_DROPWINDOWSTYLEFLAG_CANCLOSE,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_INTERFACEWRAPPER",                             LL_OPTION_INTERFACEWRAPPER,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FONTQUALITY",                                  LL_OPTION_FONTQUALITY,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FONTPRECISION",                                LL_OPTION_FONTPRECISION,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_UISTYLE",                                      LL_OPTION_UISTYLE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_UISTYLE_STANDARD",                             LL_OPTION_UISTYLE_STANDARD,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_UISTYLE_OFFICEXP",                             LL_OPTION_UISTYLE_OFFICEXP,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_UISTYLE_OFFICE2003",                           LL_OPTION_UISTYLE_OFFICE2003,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOFILEVERSIONUPGRADEWARNING",                  LL_OPTION_NOFILEVERSIONUPGRADEWARNING,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_UPDATE_FOOTER_ON_DATALINEBREAK_AT_FIRST_LINE", LL_OPTION_UPDATE_FOOTER_ON_DATALINEBREAK_AT_FIRST_LINE, CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ESC_CLOSES_PREVIEW",                           LL_OPTION_ESC_CLOSES_PREVIEW,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VIEWER_ASSUMES_TEMPFILE",                      LL_OPTION_VIEWER_ASSUMES_TEMPFILE,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CALC_USED_VARS",                               LL_OPTION_CALC_USED_VARS,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOPRINTJOBSUPERVISION",                        LL_OPTION_NOPRINTJOBSUPERVISION,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CALC_SUMVARS_ON_PARTIAL_LINES",                LL_OPTION_CALC_SUMVARS_ON_PARTIAL_LINES,                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_BLACKNESS_SCM",                                LL_OPTION_BLACKNESS_SCM,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PROHIBIT_USERINTERACTION",                     LL_OPTION_PROHIBIT_USERINTERACTION,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PERFMON_INSTALL",                              LL_OPTION_PERFMON_INSTALL,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RESERVED111",                                  LL_OPTION_RESERVED111,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTBUCKETCOUNT",                           LL_OPTION_VARLISTBUCKETCOUNT,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MSFAXALLOWED",                                 LL_OPTION_MSFAXALLOWED,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_AUTOPROFILINGTICKS",                           LL_OPTION_AUTOPROFILINGTICKS,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PROJECTBACKUP",                                LL_OPTION_PROJECTBACKUP,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ERR_ON_FILENOTFOUND",                          LL_OPTION_ERR_ON_FILENOTFOUND,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOFAXVARS",                                    LL_OPTION_NOFAXVARS,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOMAILVARS",                                   LL_OPTION_NOMAILVARS,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_PATTERNRESCOMPATIBILITY",                      LL_OPTION_PATTERNRESCOMPATIBILITY,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NODELAYEDVALUECACHING",                        LL_OPTION_NODELAYEDVALUECACHING,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FEATURE",                                      LL_OPTION_FEATURE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FEATURE_CLEARALL",                             LL_OPTION_FEATURE_CLEARALL,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FEATURE_SUPPRESS_JPEG_DISPLAY",                LL_OPTION_FEATURE_SUPPRESS_JPEG_DISPLAY,                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FEATURE_SUPPRESS_JPEG_CREATION",               LL_OPTION_FEATURE_SUPPRESS_JPEG_CREATION,               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY",                               LL_OPTION_VARLISTDISPLAY,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_VARSORT_DECLARATIONORDER",      LL_OPTION_VARLISTDISPLAY_VARSORT_DECLARATIONORDER,      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_VARSORT_ALPHA",                 LL_OPTION_VARLISTDISPLAY_VARSORT_ALPHA,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_VARSORT_MASK",                  LL_OPTION_VARLISTDISPLAY_VARSORT_MASK,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_FOLDERPOS_DECLARATIONORDER",    LL_OPTION_VARLISTDISPLAY_FOLDERPOS_DECLARATIONORDER,    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_FOLDERPOS_ALPHA",               LL_OPTION_VARLISTDISPLAY_FOLDERPOS_ALPHA,               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_FOLDERPOS_TOP",                 LL_OPTION_VARLISTDISPLAY_FOLDERPOS_TOP,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_FOLDERPOS_BOTTOM",              LL_OPTION_VARLISTDISPLAY_FOLDERPOS_BOTTOM,              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTDISPLAY_FOLDERPOS_MASK",                LL_OPTION_VARLISTDISPLAY_FOLDERPOS_MASK,                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_WORKAROUND_RTFBUG_EMPTYFIRSTPAGE",             LL_OPTION_WORKAROUND_RTFBUG_EMPTYFIRSTPAGE,             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FORMULASTRINGCOMPARISONS_CASESENSITIVE",       LL_OPTION_FORMULASTRINGCOMPARISONS_CASESENSITIVE,       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_FIELDS_IN_PROJECTPARAMETERS",                  LL_OPTION_FIELDS_IN_PROJECTPARAMETERS,                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CHECKWINDOWTHREADEDNESS",                      LL_OPTION_CHECKWINDOWTHREADEDNESS,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ISUSED_WILDCARD_AT_START",                     LL_OPTION_ISUSED_WILDCARD_AT_START,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ROOT_MUST_BE_MASTERTABLE",                     LL_OPTION_ROOT_MUST_BE_MASTERTABLE,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DLLTYPE",                                      LL_OPTION_DLLTYPE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DLLTYPE_32BIT",                                LL_OPTION_DLLTYPE_32BIT,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DLLTYPE_64BIT",                                LL_OPTION_DLLTYPE_64BIT,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DLLTYPE_BITMASK",                              LL_OPTION_DLLTYPE_BITMASK,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DLLTYPE_SDBCS",                                LL_OPTION_DLLTYPE_SDBCS,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DLLTYPE_UNICODE",                              LL_OPTION_DLLTYPE_UNICODE,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DLLTYPE_CHARSET",                              LL_OPTION_DLLTYPE_CHARSET,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_HLIBRARY",                                     LL_OPTION_HLIBRARY,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_INVERTED_PAGEORIENTATION",                     LL_OPTION_INVERTED_PAGEORIENTATION,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ENABLE_STANDALONE_DATACOLLECTING_OBJECTS",     LL_OPTION_ENABLE_STANDALONE_DATACOLLECTING_OBJECTS,     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_USERVARS_ARE_CODESNIPPETS",                    LL_OPTION_USERVARS_ARE_CODESNIPPETS,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_STORAGE_ADD_SUMMARYINFORMATION",               LL_OPTION_STORAGE_ADD_SUMMARYINFORMATION,               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_INCREMENTAL_PREVIEW",                          LL_OPTION_INCREMENTAL_PREVIEW,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RELAX_AT_SHUTDOWN",                            LL_OPTION_RELAX_AT_SHUTDOWN,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOPRINTERPATHCHECK",                           LL_OPTION_NOPRINTERPATHCHECK,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_SUPPORT_HUGESTORAGEFS",                        LL_OPTION_SUPPORT_HUGESTORAGEFS,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOAUTOPROPERTYCORRECTION",                     LL_OPTION_NOAUTOPROPERTYCORRECTION,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_NOVARLISTRESET_ON_RESETPROJECTSTATE",          LL_OPTION_NOVARLISTRESET_ON_RESETPROJECTSTATE,          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DESIGNERPREVIEWPARAMETER",                     LL_OPTION_DESIGNERPREVIEWPARAMETER,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_RESERVED142",                                  LL_OPTION_RESERVED142,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DESIGNEREXPORTPARAMETER",                      LL_OPTION_DESIGNEREXPORTPARAMETER,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_DESIGNERPRINT_SINGLETHREADED",                 LL_OPTION_DESIGNERPRINT_SINGLETHREADED,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ALLOW_COMMENTS_IN_FORMULA",                    LL_OPTION_ALLOW_COMMENTS_IN_FORMULA,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_USE_MLANG_LINEBREAKALGORITHM",                 LL_OPTION_USE_MLANG_LINEBREAKALGORITHM,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_ENABLE_IMAGESMOOTHING",                        LL_OPTION_ENABLE_IMAGESMOOTHING,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_MAXRTFVERSION_AVAILABLE",                      LL_OPTION_MAXRTFVERSION_AVAILABLE,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTION_CONDREPRESENTATIONCODES_LIKE_ANSI",			 LL_OPTION_CONDREPRESENTATIONCODES_LIKE_ANSI,			 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_NULL_IS_NONDESTRUCTIVE",						 LL_OPTION_NULL_IS_NONDESTRUCTIVE,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_DRILLDOWNPARAMETER",							 LL_OPTION_DRILLDOWNPARAMETER,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_ROUNDINGSTRATEGY",							 LL_OPTION_ROUNDINGSTRATEGY,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_ROUNDINGSTRATEGY_BANKERSROUNDING",					 LL_ROUNDINGSTRATEGY_BANKERSROUNDING,					 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_ROUNDINGSTRATEGY_ARITHMETIC_SYMMETRIC",				 LL_ROUNDINGSTRATEGY_ARITHMETIC_SYMMETRIC,				 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_RESERVED164",									 LL_OPTION_RESERVED164,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_RESERVED165",									 LL_OPTION_RESERVED165,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_PICTURE_TRANSPARENCY_IS_WHITE",				 LL_OPTION_PICTURE_TRANSPARENCY_IS_WHITE,				 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_FLOATPRECISION",								 LL_OPTION_FLOATPRECISION,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_SUPPRESS_LRUENTRY",							 LL_OPTION_SUPPRESS_LRUENTRY,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_FORCEFIRSTGROUPHEADER",						 LL_OPTION_FORCEFIRSTGROUPHEADER,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_SUPPORT_PDFINPUTFIELDS",						 LL_OPTION_SUPPORT_PDFINPUTFIELDS,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_ENHANCED_SKIPRETURNATENDOFRTF",				 LL_OPTION_ENHANCED_SKIPRETURNATENDOFRTF,				 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_HIERARCHICALDATASOURCE",						 LL_OPTION_HIERARCHICALDATASOURCE,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_FORCE_HEADER_EVEN_ON_LARGE_FOOTERLINES",		 LL_OPTION_FORCE_HEADER_EVEN_ON_LARGE_FOOTERLINES,		 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_PRINTERDEVICEOPTIMIZATION",					 LL_OPTION_PRINTERDEVICEOPTIMIZATION,					 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_RTFHEIGHTSCALINGPERCENTAGE",					 LL_OPTION_RTFHEIGHTSCALINGPERCENTAGE,					 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_FORCE_DEFAULT_PRINTER_IN_PREVIEW",			 LL_OPTION_FORCE_DEFAULT_PRINTER_IN_PREVIEW,			 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_SAVE_PROJECT_IN_UTF8",						 LL_OPTION_SAVE_PROJECT_IN_UTF8,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ONLY_SUBTABLES",		 LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ONLY_SUBTABLES,		 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ALL_TABLES",			 LL_DRILLDOWNFILTERSTRATEGY_ALLOW_ALL_TABLES,			 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DRILLDOWNFILTERSTRATEGY_ALLOW_SUBTABLES_AND_UNRELATED",LL_DRILLDOWNFILTERSTRATEGY_ALLOW_SUBTABLES_AND_UNRELATED, CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DRILLDOWNFILTERSTRATEGY_ALLOW_SUBTABLES_AND_USERDEFINED",LL_DRILLDOWNFILTERSTRATEGY_ALLOW_SUBTABLES_AND_USERDEFINED, CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DRILLDOWNFILTERSTRATEGY_MASK",						 LL_DRILLDOWNFILTERSTRATEGY_MASK,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DRILLDOWNFILTERFLAG_OFFER_BASERECORD_AS_VARIABLES",	 LL_DRILLDOWNFILTERFLAG_OFFER_BASERECORD_AS_VARIABLES,	 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_DRILLDOWN_DATABASEFILTERING",					 LL_OPTION_DRILLDOWN_DATABASEFILTERING,					 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_SUPPRESS_TASKBARBUTTON_PROGRESSSTATE",		 LL_OPTION_SUPPRESS_TASKBARBUTTON_PROGRESSSTATE,		 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_PRINTDLG_DEVICECHANGE_KEEPS_DEVMODESETTINGS",	 LL_OPTION_PRINTDLG_DEVICECHANGE_KEEPS_DEVMODESETTINGS,	 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_DRILLDOWN_SUPPORTS_EMBEDDING",				 LL_OPTION_DRILLDOWN_SUPPORTS_EMBEDDING,				 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_VARLISTCLEARSTRATEGY_EMPTY_LIST",					 LL_VARLISTCLEARSTRATEGY_EMPTY_LIST,					 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_VARLISTCLEARSTRATEGY_SET_NULL",						 LL_VARLISTCLEARSTRATEGY_SET_NULL,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_VARLISTCLEARSTRATEGY_SET_DEFAULT",					 LL_VARLISTCLEARSTRATEGY_SET_DEFAULT,					 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_VARLISTCLEARSTRATEGY_ON_DEFINE_START",		 LL_OPTION_VARLISTCLEARSTRATEGY_ON_DEFINE_START,		 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_RESERVED184",									 LL_OPTION_RESERVED184,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_KEEP_EMPTY_SUM_VARS",							 LL_OPTION_KEEP_EMPTY_SUM_VARS,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_RESERVED187",									 LL_OPTION_RESERVED187,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_DEFAULTDECSFORSTR",							 LL_OPTION_DEFAULTDECSFORSTR,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_PRINTJOB",		 LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_PRINTJOB,		 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_DEFINEXXXSTART_COMPATIBLE_TO_PRE15",			 LL_OPTION_DEFINEXXXSTART_COMPATIBLE_TO_PRE15,			 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_DC",				 LL_OPTION_RESETPROJECTSTATE_FORCES_NEW_DC,				 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LABEL_PRJEXT",                              LL_OPTIONSTR_LABEL_PRJEXT,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LABEL_PRVEXT",                              LL_OPTIONSTR_LABEL_PRVEXT,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LABEL_PRNEXT",                              LL_OPTIONSTR_LABEL_PRNEXT,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_CARD_PRJEXT",                               LL_OPTIONSTR_CARD_PRJEXT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_CARD_PRVEXT",                               LL_OPTIONSTR_CARD_PRVEXT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_CARD_PRNEXT",                               LL_OPTIONSTR_CARD_PRNEXT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LIST_PRJEXT",                               LL_OPTIONSTR_LIST_PRJEXT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LIST_PRVEXT",                               LL_OPTIONSTR_LIST_PRVEXT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LIST_PRNEXT",                               LL_OPTIONSTR_LIST_PRNEXT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LLXPATHLIST",                               LL_OPTIONSTR_LLXPATHLIST,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_SHORTDATEFORMAT",                           LL_OPTIONSTR_SHORTDATEFORMAT,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_DECIMAL",                                   LL_OPTIONSTR_DECIMAL,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_THOUSAND",                                  LL_OPTIONSTR_THOUSAND,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_CURRENCY",                                  LL_OPTIONSTR_CURRENCY,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_EXPORTS_AVAILABLE",                         LL_OPTIONSTR_EXPORTS_AVAILABLE,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_EXPORTS_ALLOWED",                           LL_OPTIONSTR_EXPORTS_ALLOWED,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_DEFDEFFONT",                                LL_OPTIONSTR_DEFDEFFONT,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_EXPORTFILELIST",                            LL_OPTIONSTR_EXPORTFILELIST,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_VARALIAS",                                  LL_OPTIONSTR_VARALIAS,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_MAILTO",                                    LL_OPTIONSTR_MAILTO,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_MAILTO_CC",                                 LL_OPTIONSTR_MAILTO_CC,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_MAILTO_BCC",                                LL_OPTIONSTR_MAILTO_BCC,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_MAILTO_SUBJECT",                            LL_OPTIONSTR_MAILTO_SUBJECT,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_SAVEAS_PATH",                               LL_OPTIONSTR_SAVEAS_PATH,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LABEL_PRJDESCR",                            LL_OPTIONSTR_LABEL_PRJDESCR,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_CARD_PRJDESCR",                             LL_OPTIONSTR_CARD_PRJDESCR,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LIST_PRJDESCR",                             LL_OPTIONSTR_LIST_PRJDESCR,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LLFILEDESCR",                               LL_OPTIONSTR_LLFILEDESCR,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_PROJECTPASSWORD",                           LL_OPTIONSTR_PROJECTPASSWORD,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_RECIPNAME",                             LL_OPTIONSTR_FAX_RECIPNAME,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_RECIPNUMBER",                           LL_OPTIONSTR_FAX_RECIPNUMBER,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_QUEUENAME",                             LL_OPTIONSTR_FAX_QUEUENAME,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_SENDERNAME",                            LL_OPTIONSTR_FAX_SENDERNAME,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_SENDERCOMPANY",                         LL_OPTIONSTR_FAX_SENDERCOMPANY,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_SENDERDEPT",                            LL_OPTIONSTR_FAX_SENDERDEPT,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_SENDERBILLINGCODE",                     LL_OPTIONSTR_FAX_SENDERBILLINGCODE,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_FAX_AVAILABLEQUEUES",                       LL_OPTIONSTR_FAX_AVAILABLEQUEUES,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LOGFILEPATH",                               LL_OPTIONSTR_LOGFILEPATH,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_LICENSINGINFO",                             LL_OPTIONSTR_LICENSINGINFO,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_PRINTERALIASLIST",                          LL_OPTIONSTR_PRINTERALIASLIST,                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_PREVIEWFILENAME",                           LL_OPTIONSTR_PREVIEWFILENAME,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW",                LL_OPTIONSTR_EXPORTS_ALLOWED_IN_PREVIEW,                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_HELPFILENAME",                              LL_OPTIONSTR_HELPFILENAME,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_NULLVALUE",                                 LL_OPTIONSTR_NULLVALUE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_DEFAULT_EXPORT",                            LL_OPTIONSTR_DEFAULT_EXPORT,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_ORIGINALPROJECTFILENAME",                   LL_OPTIONSTR_ORIGINALPROJECTFILENAME,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_HIERARCHICALDATASOURCE_ROOT",				 LL_OPTIONSTR_HIERARCHICALDATASOURCE_ROOT,				 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_PRINTERDEFINITIONFILENAME",				 LL_OPTIONSTR_PRINTERDEFINITIONFILENAME,				 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_OPTIONSTR_DOCINFO_DATATYPE",							 LL_OPTIONSTR_DOCINFO_DATATYPE,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_SYSCOMMAND_MINIMIZE",                                 LL_SYSCOMMAND_MINIMIZE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_SYSCOMMAND_MAXIMIZE",                                 LL_SYSCOMMAND_MAXIMIZE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_3DBUTTONS",                                LL_DLGBOXMODE_3DBUTTONS,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_3DFRAME2",                                 LL_DLGBOXMODE_3DFRAME2,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_3DFRAME",                                  LL_DLGBOXMODE_3DFRAME,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_NOBITMAPS",                                LL_DLGBOXMODE_NOBITMAPS,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_DONTCARE",                                 LL_DLGBOXMODE_DONTCARE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_SAA",                                      LL_DLGBOXMODE_SAA,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT1",                                     LL_DLGBOXMODE_ALT1,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT2",                                     LL_DLGBOXMODE_ALT2,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT3",                                     LL_DLGBOXMODE_ALT3,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT4",                                     LL_DLGBOXMODE_ALT4,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT5",                                     LL_DLGBOXMODE_ALT5,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT6",                                     LL_DLGBOXMODE_ALT6,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT7",                                     LL_DLGBOXMODE_ALT7,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT8",                                     LL_DLGBOXMODE_ALT8,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT9",                                     LL_DLGBOXMODE_ALT9,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_ALT10",                                    LL_DLGBOXMODE_ALT10,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGBOXMODE_TOOLTIPS98",                               LL_DLGBOXMODE_TOOLTIPS98,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CTL_ADDTOSYSMENU",                                    LL_CTL_ADDTOSYSMENU,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CTL_ALSOCHILDREN",                                    LL_CTL_ALSOCHILDREN,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CTL_CONVERTCONTROLS",                                 LL_CTL_CONVERTCONTROLS,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_GROUP_ALWAYSFOOTER",                                  LL_GROUP_ALWAYSFOOTER,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINTERCONFIG_SAVE",                                  LL_PRINTERCONFIG_SAVE,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRINTERCONFIG_RESTORE",                               LL_PRINTERCONFIG_RESTORE,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RTFTEXTMODE_RTF",                                     LL_RTFTEXTMODE_RTF,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RTFTEXTMODE_PLAIN",                                   LL_RTFTEXTMODE_PLAIN,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RTFTEXTMODE_EVALUATED",                               LL_RTFTEXTMODE_EVALUATED,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_RTFTEXTMODE_RAW",                                     LL_RTFTEXTMODE_RAW,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_JOBHANDLE",                                   LL_ERR_BAD_JOBHANDLE,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_TASK_ACTIVE",                                     LL_ERR_TASK_ACTIVE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_OBJECTTYPE",                                  LL_ERR_BAD_OBJECTTYPE,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_PROJECTTYPE",                                 LL_ERR_BAD_PROJECTTYPE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_PRINTING_JOB",                                    LL_ERR_PRINTING_JOB,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_BOX",                                          LL_ERR_NO_BOX,                                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_ALREADY_PRINTING",                                LL_ERR_ALREADY_PRINTING,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOT_YET_PRINTING",                                LL_ERR_NOT_YET_PRINTING,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_PROJECT",                                      LL_ERR_NO_PROJECT,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_PRINTER",                                      LL_ERR_NO_PRINTER,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_PRINTING",                                        LL_ERR_PRINTING,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_EXPORTING",                                       LL_ERR_EXPORTING,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NEEDS_VB",                                        LL_ERR_NEEDS_VB,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_PRINTER",                                     LL_ERR_BAD_PRINTER,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_PREVIEWMODE",                                  LL_ERR_NO_PREVIEWMODE,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_PREVIEWFILES",                                 LL_ERR_NO_PREVIEWFILES,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_PARAMETER",                                       LL_ERR_PARAMETER,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_EXPRESSION",                                  LL_ERR_BAD_EXPRESSION,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_EXPRMODE",                                    LL_ERR_BAD_EXPRMODE,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_TABLE",                                        LL_ERR_NO_TABLE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_CFGNOTFOUND",                                     LL_ERR_CFGNOTFOUND,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_EXPRESSION",                                      LL_ERR_EXPRESSION,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_CFGBADFILE",                                      LL_ERR_CFGBADFILE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BADOBJNAME",                                      LL_ERR_BADOBJNAME,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOOBJECT",                                        LL_ERR_NOOBJECT,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_UNKNOWNOBJECT",                                   LL_ERR_UNKNOWNOBJECT,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_TABLEOBJECT",                                  LL_ERR_NO_TABLEOBJECT,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_OBJECT",                                       LL_ERR_NO_OBJECT,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_TEXTOBJECT",                                   LL_ERR_NO_TEXTOBJECT,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_UNKNOWN",                                         LL_ERR_UNKNOWN,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_MODE",                                        LL_ERR_BAD_MODE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_CFGBADMODE",                                      LL_ERR_CFGBADMODE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_ONLYWITHONETABLE",                                LL_ERR_ONLYWITHONETABLE,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_UNKNOWNVARIABLE",                                 LL_ERR_UNKNOWNVARIABLE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_UNKNOWNFIELD",                                    LL_ERR_UNKNOWNFIELD,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_UNKNOWNSORTORDER",                                LL_ERR_UNKNOWNSORTORDER,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOPRINTERCFG",                                    LL_ERR_NOPRINTERCFG,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_SAVEPRINTERCFG",                                  LL_ERR_SAVEPRINTERCFG,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOVALIDPAGES",                                    LL_ERR_NOVALIDPAGES,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOTINHOSTPRINTERMODE",                            LL_ERR_NOTINHOSTPRINTERMODE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOTFINISHED",                                     LL_ERR_NOTFINISHED,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BUFFERTOOSMALL",                                  LL_ERR_BUFFERTOOSMALL,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BADCODEPAGE",                                     LL_ERR_BADCODEPAGE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_CANNOTCREATETEMPFILE",                            LL_ERR_CANNOTCREATETEMPFILE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NODESTINATION",                                   LL_ERR_NODESTINATION,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOCHART",                                         LL_ERR_NOCHART,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_TOO_MANY_CONCURRENT_PRINTJOBS",                   LL_ERR_TOO_MANY_CONCURRENT_PRINTJOBS,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_WEBSERVER_LICENSE",                           LL_ERR_BAD_WEBSERVER_LICENSE,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_WEBSERVER_LICENSE",                            LL_ERR_NO_WEBSERVER_LICENSE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_INVALIDDATE",                                     LL_ERR_INVALIDDATE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_DRAWINGNOTFOUND",                                 LL_ERR_DRAWINGNOTFOUND,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOUSERINTERACTION",                               LL_ERR_NOUSERINTERACTION,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BADDATABASESTRUCTURE",                            LL_ERR_BADDATABASESTRUCTURE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_UNKNOWNPROPERTY",                                 LL_ERR_UNKNOWNPROPERTY,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_INVALIDOPERATION",                                LL_ERR_INVALIDOPERATION,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_PROPERTY_ALREADY_DEFINED",                        LL_ERR_PROPERTY_ALREADY_DEFINED,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_CFGFOUND",                                        LL_ERR_CFGFOUND,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_SAVECFG",                                         LL_ERR_SAVECFG,                                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_WRONGTHREAD",									 LL_ERR_WRONGTHREAD,									 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_ERR_USER_ABORTED",                                    LL_ERR_USER_ABORTED,                                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_BAD_DLLS",                                        LL_ERR_BAD_DLLS,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_LANG_DLL",                                     LL_ERR_NO_LANG_DLL,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NO_MEMORY",                                       LL_ERR_NO_MEMORY,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_EXCEPTION",                                       LL_ERR_EXCEPTION,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_LICENSEVIOLATION",                                LL_ERR_LICENSEVIOLATION,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_ERR_NOT_SUPPORTED_IN_THIS_OS",                        LL_ERR_NOT_SUPPORTED_IN_THIS_OS,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_WRN_ISNULL",                                          LL_WRN_ISNULL,                                          CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_WRN_TABLECHANGE",                                     LL_WRN_TABLECHANGE,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_WRN_PRINTFINISHED",                                   LL_WRN_PRINTFINISHED,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_WRN_REPEAT_DATA",                                     LL_WRN_REPEAT_DATA,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_TEXTQUOTE",                                      LL_CHAR_TEXTQUOTE,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_PHANTOMSPACE",                                   LL_CHAR_PHANTOMSPACE,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_LOCK",                                           LL_CHAR_LOCK,                                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_NEWLINE",                                        LL_CHAR_NEWLINE,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_EXPRSEP",                                        LL_CHAR_EXPRSEP,                                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_TAB",                                            LL_CHAR_TAB,                                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_EAN128NUL",                                      LL_CHAR_EAN128NUL,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_EAN128FNC1",                                     LL_CHAR_EAN128FNC1,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_EAN128FNC2",                                     LL_CHAR_EAN128FNC2,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_EAN128FNC3",                                     LL_CHAR_EAN128FNC3,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_EAN128FNC4",                                     LL_CHAR_EAN128FNC4,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_CODE93NUL",                                      LL_CHAR_CODE93NUL,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_CODE93EXDOLLAR",                                 LL_CHAR_CODE93EXDOLLAR,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_CODE93EXPERC",                                   LL_CHAR_CODE93EXPERC,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_CODE93EXSLASH",                                  LL_CHAR_CODE93EXSLASH,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_CODE93EXPLUS",                                   LL_CHAR_CODE93EXPLUS,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_CHAR_CODE39NUL",                                      LL_CHAR_CODE39NUL,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGEXPR_VAREXTBTN_ENABLE",                            LL_DLGEXPR_VAREXTBTN_ENABLE,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DLGEXPR_VAREXTBTN_DOMODAL",                           LL_DLGEXPR_VAREXTBTN_DOMODAL,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LLX_EXTENSIONTYPE_EXPORT",                            LL_LLX_EXTENSIONTYPE_EXPORT,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LLX_EXTENSIONTYPE_BARCODE",                           LL_LLX_EXTENSIONTYPE_BARCODE,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LLX_EXTENSIONTYPE_OBJECT",                            LL_LLX_EXTENSIONTYPE_OBJECT,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LLX_EXTENSIONTYPE_WIZARD",                            LL_LLX_EXTENSIONTYPE_WIZARD,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DECLARECHARTROW_FOR_OBJECTS",                         LL_DECLARECHARTROW_FOR_OBJECTS,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DECLARECHARTROW_FOR_TABLECOLUMNS",                    LL_DECLARECHARTROW_FOR_TABLECOLUMNS,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DECLARECHARTROW_FOR_TABLECOLUMNS_FOOTERS",            LL_DECLARECHARTROW_FOR_TABLECOLUMNS_FOOTERS,            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_GETCHARTOBJECTCOUNT_CHARTOBJECTS",                    LL_GETCHARTOBJECTCOUNT_CHARTOBJECTS,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_GETCHARTOBJECTCOUNT_CHARTOBJECTS_BEFORE_TABLE",       LL_GETCHARTOBJECTCOUNT_CHARTOBJECTS_BEFORE_TABLE,       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_GETCHARTOBJECTCOUNT_CHARTCOLUMNS",                    LL_GETCHARTOBJECTCOUNT_CHARTCOLUMNS,                    CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_GETCHARTOBJECTCOUNT_CHARTCOLUMNS_FOOTERS",            LL_GETCHARTOBJECTCOUNT_CHARTCOLUMNS_FOOTERS,            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_VARIANTFLAG_NEUTRAL",                                 LL_VARIANTFLAG_NEUTRAL,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_VARIANTFLAG_USE_JULIAN_DATE",                         LL_VARIANTFLAG_USE_JULIAN_DATE,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_GRIPT_DIM_SCM",                                       LL_GRIPT_DIM_SCM,                                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_GRIPT_DIM_PERC",                                      LL_GRIPT_DIM_PERC,                                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_PUBLIC",                                LL_PARAMETERFLAG_PUBLIC,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_SAVEDEFAULT",                           LL_PARAMETERFLAG_SAVEDEFAULT,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_PRIVATE",                               LL_PARAMETERFLAG_PRIVATE,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_FORMULA",                               LL_PARAMETERFLAG_FORMULA,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_VALUE",                                 LL_PARAMETERFLAG_VALUE,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_GLOBAL",                                LL_PARAMETERFLAG_GLOBAL,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_LOCAL",                                 LL_PARAMETERFLAG_LOCAL,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERFLAG_MASK",                                  LL_PARAMETERFLAG_MASK,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERTYPE_USER",                                  LL_PARAMETERTYPE_USER,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERTYPE_FAX",                                   LL_PARAMETERTYPE_FAX,                                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERTYPE_MAIL",                                  LL_PARAMETERTYPE_MAIL,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERTYPE_LLINTERNAL",                            LL_PARAMETERTYPE_LLINTERNAL,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PARAMETERTYPE_MASK",                                  LL_PARAMETERTYPE_MASK,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LOCCONVERSION_LCID",                                  LL_LOCCONVERSION_LCID,                                  CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LOCCONVERSION_COUNTRYPREFIX",                         LL_LOCCONVERSION_COUNTRYPREFIX,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LOCCONVERSION_COUNTRYISONAME",                        LL_LOCCONVERSION_COUNTRYISONAME,                        CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_LOCCONVERSION_DIALPREFIX",                            LL_LOCCONVERSION_DIALPREFIX,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_AM_READWRITE",                                LL_PRJOPEN_AM_READWRITE,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_AM_READONLY",                                 LL_PRJOPEN_AM_READONLY,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_AM_MASK",                                     LL_PRJOPEN_AM_MASK,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_CD_OPEN_EXISTING",                            LL_PRJOPEN_CD_OPEN_EXISTING,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_CD_CREATE_ALWAYS",                            LL_PRJOPEN_CD_CREATE_ALWAYS,                            CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_CD_CREATE_NEW",                               LL_PRJOPEN_CD_CREATE_NEW,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_CD_OPEN_ALWAYS",                              LL_PRJOPEN_CD_OPEN_ALWAYS,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_CD_MASK",                                     LL_PRJOPEN_CD_MASK,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_EM_IGNORE_FORMULAERRORS",                     LL_PRJOPEN_EM_IGNORE_FORMULAERRORS,                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_EM_MASK",                                     LL_PRJOPEN_EM_MASK,                                     CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_FLG_NOINITPRINTER",							 LL_PRJOPEN_FLG_NOINITPRINTER,							 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_FLG_NOOBJECTLOAD",							 LL_PRJOPEN_FLG_NOOBJECTLOAD,							 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_PRJOPEN_FLG_RESERVED",								 LL_PRJOPEN_FLG_RESERVED,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DESFILEOPEN_OPEN_EXISTING",                           LL_DESFILEOPEN_OPEN_EXISTING,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILEOPEN_CREATE_ALWAYS",                           LL_DESFILEOPEN_CREATE_ALWAYS,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILEOPEN_CREATE_NEW",                              LL_DESFILEOPEN_CREATE_NEW,                              CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILEOPEN_OPEN_ALWAYS",                             LL_DESFILEOPEN_OPEN_ALWAYS,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILEOPEN_OPEN_IMPORT",                             LL_DESFILEOPEN_OPEN_IMPORT,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILEOPEN_OPENMASK",                                LL_DESFILEOPEN_OPENMASK,                                CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILEOPENFLAG_SUPPRESS_SAVEDIALOG",                 LL_DESFILEOPENFLAG_SUPPRESS_SAVEDIALOG,                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILEOPENFLAG_SUPPRESS_SAVE",                       LL_DESFILEOPENFLAG_SUPPRESS_SAVE,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESFILESAVE_DEFAULT",                                 LL_DESFILESAVE_DEFAULT,                                 CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTIONFLAG_ADD_TO_TOOLBAR",                      LLDESADDACTIONFLAG_ADD_TO_TOOLBAR,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_MENUITEM_APPEND",                         LLDESADDACTION_MENUITEM_APPEND,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_MENUITEM_INSERT",                         LLDESADDACTION_MENUITEM_INSERT,                         CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_MENUITEM_POSITIONMASK",                   LLDESADDACTION_MENUITEM_POSITIONMASK,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_ACCEL_CONTROL",                           LLDESADDACTION_ACCEL_CONTROL,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_ACCEL_SHIFT",                             LLDESADDACTION_ACCEL_SHIFT,                             CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_ACCEL_ALT",                               LLDESADDACTION_ACCEL_ALT,                               CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_ACCEL_VIRTKEY",                           LLDESADDACTION_ACCEL_VIRTKEY,                           CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_ACCEL_KEYMODIFIERMASK",                   LLDESADDACTION_ACCEL_KEYMODIFIERMASK,                   CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LLDESADDACTION_ACCEL_KEYCODEMASK",                       LLDESADDACTION_ACCEL_KEYCODEMASK,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNEROPTSTR_PROJECTFILENAME",                      LL_DESIGNEROPTSTR_PROJECTFILENAME,                      CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNEROPTSTR_WORKSPACETITLE",                       LL_DESIGNEROPTSTR_WORKSPACETITLE,                       CONST_CS | CONST_PERSISTENT);
    REGISTER_LONG_CONSTANT("LL_DESIGNEROPTSTR_PROJECTDESCRIPTION",                   LL_DESIGNEROPTSTR_PROJECTDESCRIPTION,                   CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_USEDIDENTIFIERSFLAG_VARIABLES",						 LL_USEDIDENTIFIERSFLAG_VARIABLES,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_USEDIDENTIFIERSFLAG_FIELDS",							 LL_USEDIDENTIFIERSFLAG_FIELDS,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_USEDIDENTIFIERSFLAG_CHARTFIELDS",					 LL_USEDIDENTIFIERSFLAG_CHARTFIELDS,					 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_USEDIDENTIFIERSFLAG_TABLES",							 LL_USEDIDENTIFIERSFLAG_TABLES,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_USEDIDENTIFIERSFLAG_RELATIONS",						 LL_USEDIDENTIFIERSFLAG_RELATIONS,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_TEMPFILENAME_DEFAULT",								 LL_TEMPFILENAME_DEFAULT,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_TEMPFILENAME_ENSURELONGPATH",						 LL_TEMPFILENAME_ENSURELONGPATH,						 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DICTIONARY_TYPE_STATIC",								 LL_DICTIONARY_TYPE_STATIC,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DICTIONARY_TYPE_IDENTIFIER",							 LL_DICTIONARY_TYPE_IDENTIFIER,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DICTIONARY_TYPE_TABLE",								 LL_DICTIONARY_TYPE_TABLE,								 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DICTIONARY_TYPE_RELATION",							 LL_DICTIONARY_TYPE_RELATION,							 CONST_CS | CONST_PERSISTENT);
	REGISTER_LONG_CONSTANT("LL_DICTIONARY_TYPE_SORTORDER",							 LL_DICTIONARY_TYPE_SORTORDER,							 CONST_CS | CONST_PERSISTENT);
	return SUCCESS;
}
// Modulinformationen
zend_module_entry ListLabelPHPModule_module_entry = 
{
    STANDARD_MODULE_HEADER,
    "ListLabelPHP-Module",
    ListLabelPHPModule_functions,
    ZEND_MINIT(ListLabelPHPModule), 
	NULL,
	NULL,
	NULL,
	NULL,
    NO_VERSION_YET, 
	STANDARD_MODULE_PROPERTIES
};
// Modulinitialisierung
ZEND_GET_MODULE(ListLabelPHPModule)
// Error-Check
void CheckErrorCode(int nError)
{
	if (nError < 0 && nError > -106)
	{ 
		zval oBuffer;
		ZVAL_LONG(&oBuffer, 0);
		int nErrTxteLen = ::LlGetErrortextA(nError, NULL, 0);
		char* aczContents = new char[nErrTxteLen];
		::LlGetErrortextA(nError, (LPSTR)aczContents, nErrTxteLen); 
		Z_TYPE_INFO(oBuffer);
		(oBuffer).u1.type_info = IS_STRING;
		Z_STRLEN(oBuffer) = strlen(aczContents);
		oBuffer.value.str = zend_string_init(aczContents, sizeof(aczContents) - 1, 0);
		delete[] aczContents;
		char* aczBuffer;
		aczBuffer = new char[strlen((const char*)aczContents) + 10];
        sprintf_s((char*)aczBuffer, sizeof((char*)aczBuffer), (const char*)"%s (%d)", (char*)oBuffer.value.str, nError);
		zend_error(E_USER_ERROR, (const char*)aczBuffer);
	}
}
// LlDbAddTable
ZEND_FUNCTION(LlDbAddTable) 
{
    double hJob;
	LPCTSTR pszTableID;
	LPCTSTR pszDisplayName;
    double pszTableID_len;
    double pszDisplayName_len;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "dss", &hJob, &pszTableID, &pszTableID_len, &pszDisplayName, &pszDisplayName_len) != FAILURE)
	{
        int nRet = LlDbAddTableA((int)hJob, (LPCSTR)pszTableID, (LPCSTR)pszDisplayName);
		CheckErrorCode(nRet);
    }
}
// LlDebugOutput
ZEND_FUNCTION(LlDebugOutput)
{	
    double nIdent;
	LPCTSTR pszText;
    double str_len;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "ds", &nIdent, &pszText, &str_len) != FAILURE)
	{
        ::LlDebugOutputA((int)nIdent, (LPCSTR)pszText);
    }
}
// LlDefineField
ZEND_FUNCTION(LlDefineField)
{
    double hJob;
	char* lpszName;
	char* lpszCont;
    double lpszName_len;
    double lpszCont_len;
    int nRet = 0;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "dss", &hJob, &lpszName, &lpszName_len, &lpszCont, &lpszCont_len) != FAILURE)
	{
        nRet = ::LlDefineFieldA((int)hJob, lpszName, lpszCont);
		CheckErrorCode(nRet);
    }
}
// LlDefineFieldExt
ZEND_FUNCTION(LlDefineFieldExt)
{
    double hJob;
	char* lpszName;
	char* lpszCont;
    double lpszName_len;
    double lpszCont_len;
    double nRet = 0;
    double lPara;
	LPVOID lpPara = NULL;
	zval * zvPara;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "dssdz", &hJob, &lpszName, &lpszName_len, &lpszCont, &lpszCont_len, &lPara, &zvPara) != FAILURE)
	{
        nRet = ::LlDefineFieldExtA((int)hJob, lpszName, lpszCont, (int)lPara, NULL);
		CheckErrorCode((int)nRet);
    }	
}
// LlDefineVariable
ZEND_FUNCTION(LlDefineVariable)
{
    double hJob;
	char* lpszName;
	char* lpszCont;
    double lpszName_len;
    double lpszCont_len;
    double nRet = 0;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "dss", &hJob, &lpszName, &lpszName_len, &lpszCont, &lpszCont_len) != FAILURE)
	{
        nRet = ::LlDefineVariableA((int)hJob, lpszName, lpszCont);
	    CheckErrorCode((int)nRet);
    }
}
// LlDefineVariableStart
ZEND_FUNCTION(LlDefineVariableStart)
{
    double hJob;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &hJob) != FAILURE)
	{
        ::LlDefineVariableStart((int)hJob);
    }
}
// LlGetErrortext
ZEND_FUNCTION(LlGetErrortext)
{
    double nError;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &nError) != FAILURE)
	{
		zval oBuffer;
		ZVAL_LONG(&oBuffer, 0);
		TCHAR* string_contents;
		int nErrTxteLen = ::LlGetErrortextA((int)nError, NULL, 0);
		string_contents = new TCHAR[nErrTxteLen];
		int nRet = ::LlGetErrortextA((int)nError, (LPSTR)string_contents, nErrTxteLen); 
		Z_TYPE_INFO(oBuffer);
		(oBuffer).u1.type_info = IS_STRING;
		Z_STRLEN(oBuffer) = _tcslen(string_contents);
		oBuffer.value.str = zend_string_init((const char*)string_contents, sizeof(string_contents) - 1, 0);
		convert_to_string_ex(&oBuffer);
		delete[] string_contents;
		CheckErrorCode(nRet);
		RETURN_STR(oBuffer.value.str);
    }
}
// LlGetVariableContents
ZEND_FUNCTION(LlGetVariableContents)
{
    double hJob;
	char* lpszName;
    double lpszName_len;
	LPTSTR lpszBuffer = NULL;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "ds", &hJob, &lpszName, &lpszName_len) != FAILURE)
	{
        zval oBuffer;
		ZVAL_LONG(&oBuffer, 0);
		TCHAR* string_contents;
		string_contents = new TCHAR[PHP_MAXSTRLEN];
		long nRet = ::LlGetVariableContentsA((int)hJob, lpszName, (LPSTR)string_contents, PHP_MAXSTRLEN);
		Z_TYPE_INFO(oBuffer);
		(oBuffer).u1.type_info = IS_STRING;
		Z_STRLEN(oBuffer) = _tcslen(string_contents);
		oBuffer.value.str = zend_string_init((const char *)string_contents, sizeof(string_contents) - 1, 0);
		convert_to_string_ex(&oBuffer);
		delete[] string_contents;
		CheckErrorCode(nRet);
		RETURN_STR(oBuffer.value.str);
    }
}
// LlGetVersion
ZEND_FUNCTION(LlGetVersion)
{
	double nCmd;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &nCmd) != FAILURE)
	{
        RETURN_LONG(::LlGetVersion((int)nCmd));
    }
}
// LlJobClose
ZEND_FUNCTION(LlJobClose)
{
    double hJob;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &hJob) != FAILURE)
	{
        ::LlJobClose((int)hJob);
    }
}
// LlJobOpen
ZEND_FUNCTION(LlJobOpen)
{
	double language;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &language) != FAILURE)
	{
		int nRet = ::LlJobOpen((int)language);
        RETURN_LONG(nRet);
		LlSetDebug(LL_DEBUG_CMBTLL | LL_DEBUG_CMBTLL_LOGTOFILE);
   }
}
// LlPrint
ZEND_FUNCTION(LlPrint)
{
    double hJob;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &hJob) != FAILURE)
	{
        int nRet = ::LlPrint((int)hJob);
		CheckErrorCode(nRet);
		RETURN_LONG(nRet);
    }
}
// LlPrintEnd
ZEND_FUNCTION(LlPrintEnd)
{
    double hJob;
    double nPages;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "dd", &hJob, &nPages) != FAILURE)
	{
        int nRet = ::LlPrintEnd((int)hJob, (int)nPages);
		CheckErrorCode(nRet);
    }
}
// LlPrintFields
ZEND_FUNCTION(LlPrintFields)
{
    double hJob;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &hJob)!= FAILURE)
	{
        int nRet = ::LlPrintFields((int)hJob);
		RETURN_LONG(nRet);
    }
}

ZEND_FUNCTION(LlPrintFieldsEnd)
{
    double hJob;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &hJob)!= FAILURE)
	{
        int nRet = ::LlPrintFieldsEnd((int)hJob);
		RETURN_LONG(nRet);
    }
}


// LlPrintGetCurrentPage
ZEND_FUNCTION(LlPrintGetCurrentPage)
{
    double hJob;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &hJob) != FAILURE)
	{
        int nRet = ::LlPrintGetCurrentPage((int)hJob);
		RETURN_LONG(nRet);
    }
}
// LlPrintGetOption
ZEND_FUNCTION(LlPrintGetOption)
{
    double hJob;
    double nIndex;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "dd", &hJob, &nIndex) != FAILURE)
	{
        int nRet = static_cast<int>(::LlPrintGetOption((int)hJob, (int)nIndex));
		RETURN_LONG(nRet);
    }
}
// LlPrintGetOptionString
ZEND_FUNCTION(LlPrintGetOptionString)
{
    double hJob;
	double nMode;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "ddz", &hJob, &nMode) != FAILURE)
	{
        zval oBuffer;
		ZVAL_LONG(&oBuffer, 0);
		TCHAR* string_contents;
		string_contents = new TCHAR[PHP_MAXSTRLEN];
		long nRet = ::LlPrintGetOptionStringA((int)hJob, (int)nMode, (LPSTR)string_contents, PHP_MAXSTRLEN);
		Z_TYPE_INFO(oBuffer);
		(oBuffer).u1.type_info = IS_STRING;
		Z_STRLEN(oBuffer) = _tcslen(string_contents);
		oBuffer.value.str = zend_string_init((const char*)string_contents, sizeof(string_contents) - 1, 0);
		convert_to_string_ex(&oBuffer);
		delete[] string_contents;
		CheckErrorCode(nRet);
		RETURN_STR(oBuffer.value.str);
    }
}
// LlPrintSetOptionString
ZEND_FUNCTION(LlPrintSetOptionString)
{
    double hJob;
    double nMode;
	LPCTSTR pszValue;
	double pszValue_len;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "dds", &hJob, &nMode, &pszValue, &pszValue_len) != FAILURE)
	{
        int nRet = LlPrintSetOptionStringA((int)hJob, (int)nMode, (LPCSTR)pszValue);
		CheckErrorCode(nRet);
    }
}
// LlPrintStart
ZEND_FUNCTION(LlPrintStart)
{
    double hJob;
    double nObjType;
	char* lpszObjName;
    double lpszObjName_len;
    double nPrintOptions;
    double nV1Dummy;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "ddsdd", &hJob, &nObjType, &lpszObjName, &lpszObjName_len, &nPrintOptions, &nV1Dummy) != FAILURE)
	{
        int nRet = ::LlPrintStartA((int)hJob, static_cast<UINT>(nObjType), lpszObjName, (int)nPrintOptions, (int)nV1Dummy);
		CheckErrorCode(nRet);
    }
}
// LlSetDebug
PHP_FUNCTION(LlSetDebug)
{
	double nOnOff;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "d", &nOnOff) != FAILURE)
	{
        ::LlSetDebug(static_cast<UINT>(nOnOff));
    }	
}
// LlXSetParameter
ZEND_FUNCTION(LlXSetParameter)
{
    double hJob;
    double nExtensionType;
	LPCTSTR pszExtensionName;
	LPCTSTR pszKey;
	LPCTSTR pszValue;
    double pszValue_len;
    double pszKey_len;
    double pszExtensionName_len;
    if (zend_parse_parameters(ZEND_NUM_ARGS(), "ddsss", &hJob, &nExtensionType, &pszExtensionName, &pszExtensionName_len, &pszKey, &pszKey_len, &pszValue, &pszValue_len) != FAILURE){
		int nRet = LlXSetParameterA((int)hJob, (int)nExtensionType, (LPCSTR)pszExtensionName, (LPCSTR)pszKey, (LPCSTR)pszValue);
		CheckErrorCode(nRet);
    }
}

//LlSetOptionString
ZEND_FUNCTION(LlSetOptionString)
{
    double hJob;
    double nIndex;
    double str_len;
	LPCSTR pszBuffer;
	if (zend_parse_parameters(ZEND_NUM_ARGS(), "dds", &hJob, &nIndex, &pszBuffer, &str_len) != FAILURE)
	{
		int nRet = ::LlSetOptionStringA((int)hJob, (int)nIndex, pszBuffer);
		CheckErrorCode(nRet);
	}
}

/*============================================================================
 Include File:	dsACEServer.ch
 Author:      	Marcus Herz
 Description: 	only needed to generate XCLACE.DLL
 Created:     	12.10.00      09:57:27        Updated: þ12.05.2006   þ18:11:55
 Copyright:   	2000 by DS-Datasoft GmbH, Germany

 DO NOT MAKE ANY CHANGES IN HERE

============================================================================*/


#ifndef _dsACEServer_LOADED
#define _dsACEServer_LOADED

// DS-Datasoft Include Files
#include "dsServer.ch"

// Xbase++ Include Files
#include "common.ch"
#include "dll.ch"
#include "xbp.ch"
#include "Class.ch"

// Extended Systems Include Files
#include "acexbp.ch"

// c-routines in XclAceBa
#pragma map(And                              ,"_AND"                             )
#pragma map(Or                               ,"_OR"                              )
#pragma map(XOr                              ,"_XOR"                             )
#pragma map(IsBit                            ,"_ISBIT"                           )
#pragma map(SetBit                           ,"_SETBIT"                          )
#pragma map(ClearBit                         ,"_CLEARBIT"                        )
#pragma map(encrypt                          ,"_ENCRYPT"                         )
#pragma map(decrypt                          ,"_DECRYPT"                         )
#pragma map(chrcount                         ,"_CHRCOUNT"                        )
#pragma map(atnext                           ,"_ATNEXT"                          )
#pragma map(ratnext                          ,"_RATNEXT"                         )
#pragma map(stratnext                        ,"_STRATNEXT"                       )
#pragma map(wordatnext                       ,"_WORDATNEXT"                      )
#pragma map(strcount                         ,"_STRCOUNT"                        )
#pragma map(chrswap                          ,"_CHRSWAP"                         )
#pragma map(strextract                       ,"_STREXTRACT"                      )
#pragma map(strswap                          ,"_STRSWAP"                         )
#pragma map(capfirst                         ,"_CAPFIRST"                        )
#pragma map(charpos                          ,"_CHARPOS"                         )
#pragma map(getwordstart                     ,"_GETWORDSTART"                    )
#pragma map(getwordend                       ,"_GETWORDEND"                      )
#pragma map(AceGetDouble							,"_ACEGETDOUBLE"							)
#pragma map(AceSetDouble							,"_ACESETDOUBLE"							)
#pragma map(AceSetRelKeyPos						,"_ACESETRELKEYPOS"						)
#pragma map(dsADSGetAllLocks						,"_DSADSGETALLLOCKS"						)
#pragma map(dsADSMgGetOpenTables  				,"_DSADSMGGETOPENTABLES"				)
#pragma map(dsADSMgGetUserNames80   			,"_DSADSMGGETUSERNAMES80"				)
#pragma map(dsADSMgGetUserNames81   			,"_DSADSMGGETUSERNAMES81"				)
#pragma map(dsADSMgGetOpenIndexes 				,"_DSADSMGGETOPENINDEXES"				)
#pragma map(dsADSMgGetLocks       				,"_DSADSMGGETLOCKS"						)
#pragma map(dsADSMgGetLockOwner80  				,"_DSADSMGGETLOCKOWNER80"				)
#pragma map(dsADSMgGetLockOwner81  				,"_DSADSMGGETLOCKOWNER81"				)
#pragma map(dsAdsMgGetActivityInfo 				,"_DSADSMGGETACTIVITYINFO"				)
#pragma map(dsAdsMgGetConfigInfo80				,"_DSADSMGGETCONFIGINFO80"				)
#pragma map(dsAdsMgGetConfigInfo81				,"_DSADSMGGETCONFIGINFO81"				)
#pragma map(dsAdsMgGetCommStats					,"_DSADSMGGETCOMMSTATS"					)
#pragma map(dsAdsMgGetInstallInfo				,"_DSADSMGGETINSTALLINFO"				)
#pragma map(dsAdsMGGetWorkerThreadActivity	,"_DSADSMGGETWORKERTHREADACTIVITY"	)

// error handling with self
#xcommand SRVCHECK <n> [EXCEPT <a1,...>][MSG <u>][TABLE <c>][<lInt: INTERN>]=> self:SetLastErrorMsg( "" )  ;;
		if(<n>\<\>0 .and. ascan({<a1>}, <n>) == 0, AdsExtErrorCheck( <n>, self, <c>, <.lInt.>,<u>),)

// error handling with object
#xcommand OBJCHECK <n> OBJ <o> [EXCEPT <a1,...>][MSG <u>][TABLE <c>] => ;
		if(<n>\<\>0 .and. ascan({<a1>}, <n>) == 0, AdsExtErrorCheck( <n>, <o>, <c>, false ,<u>),)

// error handling without object
#xcommand CHECK <n> [EXCEPT <a1,...>][MSG <u>][TABLE <c>]			=> if(<n>\<\>0 .and. ascan({<a1>}, <n>) == 0, AdsExtErrorCheck( <n>,NIL,<c>,false,<u> ),)

#xcommand METHOD <mvar> CLASS <cvar>  			=> METHOD <cvar>:<mvar>
#xcommand CLASS_METHOD <mvar> CLASS <cvar>	=> CLASS METHOD <cvar>:<mvar>

#command ACCESS_ASSIGN <y> 						=> METHOD <y>
#command ACCESS <y>									=> METHOD <y>
#command ASSIGN <y>									=> METHOD <y>

#command ACCESS_ASSIGN <y> CLASS <x> 			=> METHOD <x>:<y>
#command ACCESS <y> CLASS <x>						=> METHOD <x>:<y>
#command ASSIGN <y> CLASS <x>						=> METHOD <x>:<y>
// end kompatibilität zu XClass++

// fieldget returns NIL-value
#define RETURN_NULL				50

// seek, Erweiterungen,
#define DS_PARTIAL_FULL_KEY_LENGTH				8
#define DS_FULL_KEY_LENGTH                   16

#define _FTS_FIELD				1
#define _FTS_DELIM            2
#define _FTS_NOISE            3
#define _FTS_DROP             4
#define _FTS_CONDITIONAL      5
#define _FTS_CONDCHAR         5
#define _FTS_MIN              6
#define _FTS_MAX              7
#define _FTS_OPTION           8
#define _FTS_MAXPROP          8


#xtranslate Date2SqlDate(<var>)              => tran(dtos(<var>), "@R 9999-99-99")
#xtranslate Date2SqlDateS(<var>)             => iif(empty(<var>), "NULL", tran(dtos(<var>), "@R '9999-99-99'"))

#xtranslate Timestamp2Sql(<var>[,<time>])    => iif(empty(<var>), "NULL", tran(dtos(<var>), "@R 9999-99-99") [+" "+ <time>])
#xtranslate Timestamp2SqlS(<var>[,<time>])   => iif(empty(<var>), "NULL", tran(dtos(<var>), "@R '9999-99-99") [+" "+ <time>] +"'")

#xtranslate AceErrorDisplayTime([<var>])		=> DisplayErrorTime(<var>)
#xtranslate AdsErrorblock([<var>])				=> AceErrorblock(<var>)
#xtranslate CreateAdtTable(<list,...>)		 	=> CreateAdsTable(<list>)
#xtranslate SetAceTableClass([<var>])			=> SetAceServerClass(<var>)
#xtranslate OpenSqlServer(<list,...>)			=> OpenSelect(<list>)
#xtranslate OpenSqlTable(<list,...>)			=> OpenSelect(<list>)
// 13.08.2020 2:27PM führt zu rekursion im compiler
//#xtranslate FormatSQL(<list,...>)				=> dsDebuglog():FormatSql(<list>)

#endif

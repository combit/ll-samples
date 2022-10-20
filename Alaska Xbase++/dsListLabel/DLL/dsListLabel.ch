/*============================================================================
 Include File: dsListLabel.ch
 Author:       Marcus Herz
 Description:
 Created:      28.07.2016     11:41:37        Updated: þ17.08.2022      þ09:19:22
 Copyright:    2016 by DS-Datasoft, 87654 Friesenried
============================================================================*/

#ifndef __DSLISTLABEL_INCLUDE__CH_
#define __DSLISTLABEL_INCLUDE__CH_

#ifndef __LL
	// default, wenn nicht in COMPILE_FLAGS gesetzt
	#define __LL	"28"
#endif

#if __LL = "28"
	#define CMBT_DLL   "CMLL28.dll"
	#include "cmbtll28.ch"
#else
	#if __LL = "27"
		#define CMBT_DLL   "CMLL27.dll"
		#include "cmbtll27.ch"
	#else
		#if __LL = "26"
			#define CMBT_DLL   "CMLL26.dll"
			#include "cmbtll26.ch"
		#else
			#if __LL = "25"
				#define CMBT_DLL   "CMLL25.dll"
				#include "cmbtll25.ch"
			#else
				#if __LL = "24"
					#define CMBT_DLL   "CMLL24.dll"
					#include "cmbtll24.ch"
				#else
					#error keine [unterstütze] List & Label Version in COMPILE_FLAGS gesetzt
				#endif
			#endif
		#endif
	#endif
#endif

// weitere Menu IDs siehe ...\combit\LL*\dokumentation\menuid.txt
// additional Menu IDs see ...\combit\LL*\documentation\menuid.txt
// LL Menue Preview ID
#define MNUID_LL_ZOOM_TIMES				100
#define MNUID_LL_ZOOM_REVERT				101
#define MNUID_LL_FIRST_PAGE				102
#define MNUID_LL_LAST_PAGE					103
#define MNUID_LL_PREVIOUS_PAGE			104
#define MNUID_LL_NEXT_PAGE					105
#define MNUID_LL_ZOOM_FIT					108
#define MNUID_LL_PREVIOUS_FILE			109
#define MNUID_LL_NEXT_FILE					110
#define MNUID_LL_PRINTPAGE					112
#define MNUID_LL_PRINT  					113
#define MNUID_LL_EXIT						114
#define MNUID_LL_SEND_TO					115
#define MNUID_LL_SAVE_AS					116
#define MNUID_LL_FAX							117
#define MNUID_LL_SEEK						118
#define MNUID_LL_SEEK_NEXT					119
#define MNUID_LL_SEEK_TEXT					121
#define MNUID_LL_SEEK_OPT					122
#define MNUID_LL_PAGECOMBO					124
#define MNUID_LL_ZOOMCOMBO					125
#define MNUID_LL_SLIDESHOW					126
#define MNUID_LL_PRINTPAGE_RM	  			16496 				// rechte maustaste, right mouse button
#define MNUID_LL_PRINT_RM	  				16497             // rechte maustaste, right mouse button

// LL Menue Designer ID
#define MNUID_LL_DESIGNER_NEW				524
#define MNUID_LL_DESIGNER_OPEN			519
#define MNUID_LL_DESIGNER_IMPORT			726
#define MNUID_LL_DESIGNER_EXPORT			509
#define MNUID_LL_DESIGNER_SAVE			514
#define MNUID_LL_DESIGNER_SAVEAS			515
#define MNUID_LL_DESIGNER_MINIMIZE		-1
#define MNUID_LL_DESIGNER_MAXIMIZE		-2

// callback direkt
#define LL_NTFY_AFTERPRINT					999

#endif

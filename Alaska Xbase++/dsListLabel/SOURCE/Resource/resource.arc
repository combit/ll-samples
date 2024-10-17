/*============================================================================
 Include File: resource.ch
 Author:       Marcus Herz
 Description:
 Created:      13.05.2020     12:47:27        Updated: þ13.05.2020      þ12:47:27
 Copyright:    2020 DS-Datasoft, 87671 Ronsberg
============================================================================*/

#include "resource.ch"
#include "xpp-cfg.ch"

#define MANIFEST_RESID 	1
#define MANIFEST 			24

CHARACTER
   XPP_CFG_MOM_MEMORYSPACE = "xpp-integer:151654"

VERSION
	"CompanyName"      = "DS-Datasoft, Germany"
   "ProductName"      = "Demo"
   "ProductVersion"   = "1.0.0.4"
   "FileVersion"      = "1.0.0.4"
   "FileDescription"  = "LLDemo"
   "InternalName"     = "LLDEMO.EXE"
   "LegalCopyright"   = "Copyright DS-Datasoft 2024, Report-/Druckmodul List & Label® Version 30: Copyright combit® GmbH"
	"OriginalFilename" = "LLDEMO.EXE"


USERDEF MANIFEST
MANIFEST_RESID = FILE "lldemo.exe.manifest"

ICON
	ICON_EXIT 			= "exit28.ico"
	ICON_INFO 			= "info28.ico"
	ICON_TIMETABLE		= "uhr28.ico"
	ICON_SUBJECT		= "subject28.ico"
	ICON_APPLICATION  = "ll-32.ico"

BITMAP
	BMP_GERMANY       = "germany.bmp"
	BMP_USA           = "usa.bmp"
	BMP_HELP          = "help.bmp"





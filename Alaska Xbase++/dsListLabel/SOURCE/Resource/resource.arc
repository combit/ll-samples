/*============================================================================
 Include File: resource.ch
 Author:       Marcus Herz
 Description:
 Created:      13.05.2020     12:47:27        Updated: þ13.05.2020      þ12:47:27
 Copyright:    2020 DS-Datasoft, 87671 Ronsberg
============================================================================*/

#include "resource.ch"

#define MANIFEST_RESID 	1
#define MANIFEST 			24

VERSION
	"CompanyName"      = "DS-Datasoft GmbH &Co.KG, Germany"
   "ProductName"      = "Demo"
   "ProductVersion"   = "1.0.0.0"
   "FileVersion"      = "1.0.0.0"
   "FileDescription"  = "LLDemo"
   "InternalName"     = "LLDEMO.EXE"
   "LegalCopyright"   = "Copyright ©XClass++ DS-Datasoft GmbH 1998-2020"
   "OriginalFilename" = "LLDEMO.EXE"


USERDEF MANIFEST
MANIFEST_RESID = FILE "lldemo.exe.manifest"


ICON
	ICON_EXIT 			= "exit28.ico"
	ICON_INFO 			= "info28.ico"
	ICON_TIMETABLE		= "uhr28.ico"
	ICON_SUBJECT		= "subject28.ico"
	ICON_APPLICATION  = "lldemo.ico"

BITMAP
	BMP_GERMANY       = "germany.bmp"
	BMP_USA           = "usa.bmp"
	BMP_HELP          = "help.bmp"





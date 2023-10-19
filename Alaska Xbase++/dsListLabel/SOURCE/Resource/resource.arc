/*============================================================================
 Include File: resource.ch
 Author:       Marcus Herz
 Description:
 Created:      13.05.2020     12:47:27        Updated: þ13.05.2020      þ12:47:27
 Copyright:    2020 DS-Datasoft, 87671 Ronsberg
============================================================================*/

#include "resource.ch"
#include "xpp-cfg.ch"

#define MANIFEST_RESID         1
#define MANIFEST                         24


VERSION
   "CompanyName"      = "DS-Datasoft GmbH &Co.KG, Germany"
   "ProductName"      = "Demo"
   "ProductVersion"   = "1.0.0.3"
   "FileVersion"      = "1.0.0.3"
   "FileDescription"  = "LLDemo"
   "InternalName"     = "LLDEMO.EXE"
   "LegalCopyright"   = "Copyright DS-Datasoft GmbH 1998-2023"
   "OriginalFilename" = "LLDEMO.EXE"


USERDEF MANIFEST
MANIFEST_RESID = FILE "lldemo.exe.manifest"

ICON
        ICON_EXIT         = "exit28.ico"
        ICON_INFO         = "info28.ico"
        ICON_TIMETABLE    = "uhr28.ico"
        ICON_SUBJECT      = "subject28.ico"
        ICON_APPLICATION  = "ll-32.ico"

BITMAP
        BMP_GERMANY       = "germany.bmp"
        BMP_USA           = "usa.bmp"
        BMP_HELP          = "help.bmp"





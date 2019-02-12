@cls
@echo off
@echo.
@echo.

@echo Batchfile to create all samples for use with XClass++
@echo.
@echo Batchdatei erstellt alle Demoprogramme für Verwendung mit XClass++
@echo.
@echo.

pause


cd "xclInvoice Example"

pbuild /A
if errorlevel 1 goto ERROR
pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\xclReport Container"

pbuild /A
if errorlevel 1 goto ERROR
pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\xclSimple1 Example"

pbuild /A
if errorlevel 1 goto ERROR
pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\xclSimple2 Example"

pbuild /A
if errorlevel 1 goto ERROR
pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\xclSimpleArray Example"

pbuild /A
if errorlevel 1 goto ERROR
pbuild project /A
pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd..

goto :SUCCESS

:ERROR
@Echo.
@Echo Error while creating
@Echo.
@Echo Fehler beim Erzeugen
cd..

goto FINAL

:SUCCESS
@Echo.
@Echo Samples created
@Echo.
@Echo Demoprogramme erzeugt


:FINAL
@Echo.
@Echo.
pause

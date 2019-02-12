@cls
@echo off
@echo.
@echo.

@echo Batchfile to create all samples with Real Data Preview
@echo.
@echo Batchdatei erstellt alle Demoprogramme mit Echtdatenvorschau
@echo.
@echo.

pause


cd "Invoice Example"

pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\Report Container"

pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\Simple1 Example"

pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\Simple2 Example"

pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\SimpleArray Example"

pbuild projectrdp /A
if errorlevel 1 goto ERROR

cd "..\SimpleDataObject Example"

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







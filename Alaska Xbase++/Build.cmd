@cls
@echo off
@echo.
@echo.

@echo Batchfile to create basic List & Label samples, without Real Data Preview
@echo.
@echo Batchdatei erstellt Demoprogramme für List & Label, ohne Echtdatenvorschau
@echo.
@echo.

pause


cd "Invoice Example"

pbuild /A
if errorlevel 1 goto ERROR

cd "..\Report Container"

pbuild /A
if errorlevel 1 goto ERROR

cd "..\Simple1 Example"

pbuild /A
if errorlevel 1 goto ERROR

cd "..\Simple2 Example"

pbuild /A
if errorlevel 1 goto ERROR


cd "..\SimpleDataObject Example"

pbuild /A
if errorlevel 1 goto ERROR
pbuild project /A
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

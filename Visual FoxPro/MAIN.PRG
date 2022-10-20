*****************************************************
* Main Program for lldemo
* List & Label Sample Application
*
* 
* Copyright (C) combit GmbH
*
******************************************************


IF !FILE('llform.scx')
	cCurrentProcedure = SYS(16,1)
	nPathStart = AT(":",cCurrentProcedure)- 1
	nLenOfPath = RAT("\", cCurrentProcedure) - (nPathStart)
 	SET DEFAULT TO (SUBSTR(cCurrentProcedure, nPathStart, nLenofPath))
ENDIF

DO api.prg
DO cmbtll28.prg
USE ARTICLE
GO TOP

DO FORM llform
CLOSE DATABASES
CANCEL



<?php
  // D:  Komplette Fehlerausgabe aktivieren
  // US: Enable full error reporting
  ERROR_REPORTING(E_ALL);
  // D:  Eigene Fehlerhandler-Funktion deklarieren
  // US: Declare an own errorhandler function
  function OwnErrorHandler($errorcode, $errormsg, $errorfile, $errorline) {
    // D:  Nur kritische Fehler, wie sie List & Label generiert werden könnten, abfangen
    // US: Catch only critical errors, which could be produced by List & Label
    if ($errorcode == E_USER_ERROR) {

	  echo '<strong>'.$errormsg.'</strong><br />File: '.$errorfile.'<br />Line: '.$errorline;
      exit(1);
      return false;
    } 
    // D:  false zurückgeben um die php-interne Fehlerbehandlung zu starten
    // US: Return false to run php intern errorhandling
    return true;
  }
  // D:  Eigene Fehlerhandler-Funktion registrieren
  // US: Register own errorhandler function
 set_error_handler("OwnErrorHandler");
  
  include('data.php');
  try {
    if (isset($_GET['report']) && !empty($_GET['report']) && isset($_GET['format']) && !empty($_GET['format']) && in_array($_GET['report'], $reports) && isset($formats[$_GET['format']]))
    {
      // D:  Artikeldaten-Datei laden
      // US: Load article file
      $ini = file('lists/demo.dat');
	    

      // D:  Debug-Modus aktivieren
      // US: Enable debug mode
      LlSetDebug(65);


      // D:  Job registrieren
      // US: Register job
      $job = LlJobOpen(0);
	  
	  
	  // D: Geben Sie hier Ihren Lizenzschlüssel ein
	  // US: Add your license key here
	  LlSetOptionString($job, LL_OPTIONSTR_LICENSINGINFO, '<your license key>');
	  
	  // D:	 Designschema wird auf COMBITBLUE gesetzt
	  // US: Set Designscheme to COMBITBLUE
	  LlSetOptionString($job, 63,'COMBITBLUE');
	  
      // D:  Tabellen und Felder registrieren
      // US: Register tables and fields
      LlDbAddTable($job,     	'Item',              	'Item');
      LlDefineField($job,    	'Item.Description1', 	'');
      LlDefineField($job,    	'Item.Description2', 	'');
      LlDefineField($job,    	'Item.No',           	'');
	  LlDefineFieldExt($job,    'Item.No_EAN128',		'', LL_BARCODE_EAN128, null);
      LlDefineFieldExt($job, 	'Item.UnitPrice',    	'', LL_NUMERIC, null);
	  LlDefineFieldExt($job, 	'Item.Picture',      	'', LL_DRAWING, null);
	  LlDefineFieldExt($job,	'Item.CustomerReview',	'', LL_NUMERIC, null);
	  
	  // D:  Alte temp Dateien löschen
	  // US: Delete old temp files
	  
	  $strDir = 'tmp/';
	  $arFiles = scandir ( $strDir );

	  foreach ( $arFiles as $strFile )
	  {
        if ( $strFile != '.' && $strFile != '..' && ! is_link ( $strDir . $strFile ) && is_file ( $strDir . $strFile ) )
        {
		  unlink ( $strDir . $strFile );
		}
	  } 

	  
      // D:  Temp-Dateiname generieren
      // US: Generate temp filename
	  if ($_GET['format'] == 'bmp' or $_GET['format'] == 'jpg' or $_GET['format'] == 'png')
      {
		$filename = md5($_GET['report']).'_%d.'.$_GET['format'];
	  }
	  else
	  {
	    $filename = md5($_GET['report']).'.'.$_GET['format'];
	  }

	  
      // D:  Dateipfad setzen
      // US: Set filepath
      $filepath = '';


      // D:  Dateipfad automatisch generieren, falls dieser leer ist
      // US: If filepath is empty, set filepath automatically
      if (empty($filepath))
      {
        $filepath = str_replace(basename($_SERVER['SCRIPT_FILENAME']), '', $_SERVER['SCRIPT_FILENAME']);
      }
	  
      // D:  Zu druckendes Projekt öffnen
      // Us: Open project to be printed
	  LlPrintStart($job, LL_PROJECT_LIST, $filepath.'lists\\'.$_GET['report'], LL_PRINT_EXPORT, 1);

	  
      // D:  Exportmodul-Name festlegen
      // US: Set exportmodule name
      switch ($_GET['format'])
      {
        case 'bmp':
          $module = 'PICTURE_BMP';
          break;
        case 'jpg':
          $module = 'PICTURE_JPEG';
          break;
		case 'png':
		  $module = 'PICTURE_PNG';
		  break;
        default:
          $module = strtoupper($_GET['format']);
          break;
      }


      // D:  Einstellungen setzen
      // US: Set options
      LlXSetParameter($job,        LL_LLX_EXTENSIONTYPE_EXPORT, $module, 'Export.File',  $filename);
      LlXSetParameter($job,        LL_LLX_EXTENSIONTYPE_EXPORT, $module, 'Export.Path',  $filepath.'tmp\\');
      LlXSetParameter($job,        LL_LLX_EXTENSIONTYPE_EXPORT, $module, 'Export.Quiet', '1');
      LlPrintSetOptionString($job, LL_PRNOPTSTR_EXPORT,         $module);


      // D:  Schleifen-Limit auf die Anzahl der in der Artikeldaten-Datei gefundenen Artikel setzen
      // US: Set loop limit to the sum of all found articles in the article file
      $nRecCount = count($ini) - 1;


      // D:  Die letzte zu druckende Seite ermitteln
      // US: Get the number of the last page in the document
      $nLastPage = LlPrintGetOption($job, LL_OPTION_LASTPAGE);


      // D:  Diese Druckschleife wird so lange wiederholt, bis sämtliche Daten abgearbeitet wurden oder ein Fehler auftritt
      // US: Do printing loop only when there is any data to be printed and no error has occurred
      
      $nRet = LlPrint($job);
      while ($nRet == LL_WRN_REPEAT_DATA)
      {
        $nRet = LlPrint($job);
      }
      

      $nTableChange = LL_WRN_TABLECHANGE;
      while ($nTableChange == LL_WRN_TABLECHANGE)
      {
        // D:  Den Pointer auf den ersten Eintrag setzen
        // US: Set the pointer to the first found article
        $nRecno = 0;


        while ($nRecno < $nRecCount && ($nRet == 0) && (LlPrintGetCurrentPage($job) <= $nLastPage))
        {
          // D:  Verarbeite und übergebe aktuelle Artikel-Zeile
          // US: Parse and assign current article row
          $inirow = explode("\\", $ini[$nRecno]);
   

          // D:  Tabellen und Felder setzen
          // US: Set tables and fields
          LlDefineField($job,    'Item.Description1', 		$inirow[1]);
          LlDefineField($job,    'Item.Description2',		$inirow[2]);
          LlDefineField($job,    'Item.No',					substr($inirow[0], strpos($inirow[0], '=') + 1));
		  LlDefineFieldExt($job, 'Item.No_EAN128',		substr($inirow[0], strpos($inirow[0], '=') + 1), LL_BARCODE_EAN128, null);
          LlDefineFieldExt($job, 'Item.Picture',			$filepath.'lists\pictures\\'.$inirow[4], LL_DRAWING, null);
          LlDefineFieldExt($job, 'Item.UnitPrice',			$inirow[3],                              LL_NUMERIC, null);
		  LlDefinefieldExt($job, 'Item.CustomerReview',		$inirow[5],                              LL_NUMERIC, null);

          // D:  Drucken der aktuellen Tabellenzeile
          // US: Print the current table line
          $nRet = LlPrintFields($job);
          while ($nRet == LL_WRN_REPEAT_DATA)
          {
            LlPrint($job);
            $nRet = LlPrintFields($job);
          }
          $nRecno++;
        }
        $nTableChange = LlPrintFieldsEnd($job);
        while ($nTableChange == LL_WRN_REPEAT_DATA)
        {
          $nTableChange = LlPrintFieldsEnd($job);
        }
      }

      LlPrintEnd($job, 0);
      LlJobClose($job);

      // D:  Eine dem Format entsprechende Ausgabe generieren
      // US: Generate a format specific output
      switch ($_GET['format'])
      {
		case 'png':
        case 'bmp':
        case 'jpg':		
			$files = scandir('tmp');
			foreach ($files as $value)
			{
				if (strpos($value,$_GET['format']) !== false)
				{
					echo '<center><img src="tmp/'.str_replace('%d', $i, $value).'" alt="" /><br /></center>';
				}
			}
          break;
        case 'pdf':
          header('Content-Type: application/pdf');
          readfile($filepath.'tmp\\'.$filename);
          break;
        case 'rtf':
          header('Content-Disposition: attachment; filename="export.rtf"');
          readfile($filepath.'tmp\\'.$filename);
          break;
        case 'xml':
          header('Content-Type: application/xhtml+xml');
          readfile($filepath.'tmp\\'.$filename);
          break;
      }
    } else {
      throw new Exception("Invalid parameter");
    }
  }
  // D:  Script-Fehler abfangen und Ausgabe
  // US: Catch and return script generated errors
  catch (Exception $e) {
    die($e->getMessage());
  }
?>
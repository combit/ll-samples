-------------------------------------------------
List & Label Sample für PHP (Version 8.5.0)
Copyright (C) combit GmbH
-------------------------------------------------

Quelldateien kopieren
- Lade die aktuellen PHP8-Quelldateien sowie das zugehörige "Development package", die mit deiner Webserver-PHP-Version übereinstimmen (PHP-Version, Non-Thread-Safe/Thread-Safe, Visual Studio-Version), von "https://www.php.net/downloads.php" herunter.
- Entpack das Quellcode-Archiv direkt in den Ordner "php_src".
- Entpacke das "Development package" und kopiere die sich darin befindliche Datei "include/main/config.w32.h" nach "php_src/main".
- Kopiere die Datei "php8ts.lib" aus deiner Webserverinstallation ("dev") in den Ordner "dev".

Nun kannst du die .dll-Datei kompilieren (Visual C++/Visual Studio 2022 und höher).

-------------------------------------------------

Sollte beim Kompilieren der Fehler "Error C3163: ‘_vsnprintf’: attributes inconsistent with previous declaration" auftreten, suche in der Datei "zend_config.w32.h" die folgenden Zeilen:

	#define snprintf _snprintf
	#define vsnprintf _vsnprintf

Ersetze diese mit den folgenden Zeilen:

	#if not defined(_MSC_VER) || defined(__MINGW32__)
	#define snprintf _snprintf
	#define vsnprintf _vsnprintf
	#endif
-------------------------------------------------

Sollte beim Kompilieren der Fehler "fatal error C1017: Ungültiger Ausdruck für Ganzzahlkonstante" auftreten, suche in der Datei "tsmr_congifg_common.h" die folgenden Zeilen:

	#if WINNT|WIN32
	#define TSRM_WIN32
	#endif

Ersetze diese mit den folgenden Zeilen:

	#if define (WINNT)| define(WIN32)
	#define TSRM_WIN32
	#endif
-------------------------------------------------

PHP-Konfiguration
- WICHTIG: Die PHP-Version deines Webservers muss mit der Version der kompilierten DLL übereinstimmen.
- Verschiebe die erstellte .dll-Datei in den Ordner "ext" in deinem PHP8-Verzeichnis.
- Suche die für deine PHP-Konfiguration verwendete Datei "php.ini".
- Füge der Datei "php.ini" den Befehl "extension=ListLabelPHP.dll" oder den Namen, den du für deine DLL gewählt hast, hinzu.

Nun musst du in der Datei "frame.php" in Zeile 45 im Ordner "websample" deinen persönlichen List & Label-Lizenzschlüssel setzen. Zu finden ist dieser in der Datei "PersonalLicense.txt" im List & Label-Installationsverzeichnis.

Um das Beispiel auszuführen, musst du lediglich den Inhalt des "websample"-Ordners auf deinen Webserver kopieren und gegebenenfalls der Datei "frame.php" sowie dem Ordner "tmp" den CHMOD 777 zuweisen. Um die Änderungen zu übernehmen, musst du deinen Webserver neu starten.

Beachte, dass du einen Zusatz zum Lizenzvertrag benötigst, um die List & Label-Funktionalität in dieser Form zu nutzen.
-------------------------------------------------

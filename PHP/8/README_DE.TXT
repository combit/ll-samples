-------------------------------------------------
List & Label Sample für PHP (Version 8.4.3)
Copyright (C) combit GmbH
-------------------------------------------------

Quelldateien kopieren
- Laden Sie sich die aktuellen PHP8-Quelldateien, sowie das zugehörige "Development package", die mit Ihrer Webserver-PHP-Version übereinstimmen (PHP-Version, Non-Thread-Safe/Thread-Safe, Visual Studio-Version), von "https://www.php.net/downloads.php" herunter.
- Entpacken Sie das Quellcode-Archiv direkt in den Ordner "php_src".
- Entpacken Sie das "Development package", und kopieren Sie sich darin befindliche Datei unter include/main/config.w32.h nach php_src/main.
- Kopieren Sie die Datei "php8ts.lib" aus Ihrer Webserverinstallation ("dev") in den Ordner "dev".

Nun können Sie die .dll-Datei kompilieren (Visual C++/Visual Studio 2019 und höher).

-------------------------------------------------

Sollte beim Kompilieren der Fehler "Error C3163: ‘_vsnprintf’: attributes inconsistent with previous declaration" auftreten, suchen Sie in der Datei "zend_config.w32.h" die folgenden Zeilen:

	#define snprintf _snprintf
	#define vsnprintf _vsnprintf

Ersetzen Sie diese mit den folgenden Zeilen:

	#if not defined(_MSC_VER) || defined(__MINGW32__)
	#define snprintf _snprintf
	#define vsnprintf _vsnprintf
	#endif
-------------------------------------------------

Sollte beim Kompilieren der Fehler "fatal error C1017: Ungültiger Ausdruck für Ganzzahlkonstante" auftreten, suchen Sie in der Datei "tsmr_congifg_common.h" die folgenden Zeilen:

	#if WINNT|WIN32
	#define TSRM_WIN32
	#endif

Ersetzen Sie diese mit den folgenden Zeilen:

	#if define (WINNT)| define(WIN32)
	#define TSRM_WIN32
	#endif
-------------------------------------------------

PHP-Konfiguration
- WICHTIG: Die PHP-Version Ihres Webservers muss mit der Version der kompilierten DLL übereinstimmen.
- Verschieben Sie die erstellte .dll-Datei in den Ordner "ext" in Ihrem PHP8-Verzeichnis.
- Suchen Sie die für Ihre PHP-Konfiguration verwendete "php.ini".
- Fügen Sie der "php.ini" folgenden Befehl hinzu: "extension=ListLabelPHP.dll" oder den Namen den Sie für Ihre DLL gewählt haben.

Nun müssen Sie in der Datei "frame.php" in Zeile 45 im Ordner "websample" Ihren persönlichen Lizenzschlüssel setzen. Zu finden ist dieser in der Datei "PersonalLicense.txt" im List & Label-Installationsverzeichnis.

Um das Beispiel auszuführen, müssen Sie lediglich den Inhalt des "websample"-Ordners auf Ihren Webserver kopieren und gegebenenfalls der Datei "frame.php" sowie dem Ordner "tmp" den CHMOD 777 zuweisen.
Um die Änderungen zu übernehmen müssen Sie Ihren Webserver neu starten.

Beachten Sie, dass Sie einen Zusatz zum Lizenzvertrag benötigen, um die List & Label-Funktionalität in dieser Form zu nutzen.
-------------------------------------------------

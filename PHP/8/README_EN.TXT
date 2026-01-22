-------------------------------------------------
List & Label Sample for PHP (Version 8.4.3)
Copyright (C) combit GmbH
-------------------------------------------------

Copy source files
- Download the current PHP8 source files and the corresponding ‘Development package’ that match your web server PHP version (PHP version, non-thread-safe/thread-safe, Visual Studio version) from ‘https://www.php.net/downloads.php’.
- Unpack the source code archive directly into the ‘php_src’ folder.
- Unzip the ‘Development package’ and copy the file under include/main/config.w32.h to php_src/main.
- Copy the file ‘php8ts.lib’ from your web server installation (‘dev’) to the ‘dev’ folder.

You're now able to compile the DLL (Visual C++/Visual Studio 2019 and newer).

-------------------------------------------------

Should you encounter the error "Error C3163:  _vsnprintf : attributes inconsistent with previous declaration" during compilation locate the following lines in "zend_config.w32.h":

	#define snprintf _snprintf
	#define vsnprintf _vsnprintf

Replace them with the following lines:

	#if not defined(_MSC_VER) || defined(__MINGW32__)
	#define snprintf _snprintf
	#define vsnprintf _vsnprintf
	#endif
-------------------------------------------------
  
Should you encounter the error "fatal error C1017: invalid integer constant expression" during compilation locate the following lines in "tsmr_congifg_common.h":

	#if WINNT|WIN32
	#define TSRM_WIN32
	#endif

Replace them with the following lines:

	#if define (WINNT)| define(WIN32)
	#define TSRM_WIN32
	#endif
-------------------------------------------------

Configure PHP
- IMPORTANT: The PHP version of your web server needs to match the version used for compiling the DLL.
- Move the generated DLL to the "ext" folder of your PHP8 directory.
- Locate the "php.ini" used by your PHP configuration.
- Add the following command: "extension=ListLabelPHP.dll;" or the name you've chosen for the DLL.

Now locate line 45 in "frame.php" in your "websample" folder and add your personal license key. You can find it in the file "PersonalLicense.txt" in the List & Label installation directory.

To run the sample, simply copy the contents of the "websample" folder to your Windows web server and assign the CHMOD 777 to the file "frame.php" and the "tmp" folder.
To apply the changes you have to restart your web server.

Please note that you need an addendum to the license agreement in order to use List & Label in this way.
-------------------------------------------------

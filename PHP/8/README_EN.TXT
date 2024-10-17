-------------------------------------------------
List & Label Sample for PHP (Version 8.3.1)
Copyright (C) combit GmbH
-------------------------------------------------

Copy sources
- Download the latest PHP8 sources that match your web server's PHP version (PHP version, Non Thread Safe/Thread Safe, Visual Studio version), from "https://www.php.net/downloads.php".
- Unpack the archive to the "php_src" folder.
- Copy the file "php8ts.lib" from your web server installation ("dev\lib") into the "dev" folder.

Then locate the following lines in "zend_build.h" in the "php_src/zend" folder:

	#if defined(ZEND_WIN32) && defined(PHP_COMPILER_ID)
	#define ZEND_BUILD_SYSTEM "," PHP_COMPILER_ID
	#else
	#define ZEND_BUILD_SYSTEM
	#endif

Replace them with the following lines:

	#if defined(ZEND_WIN32)
	#define PHP_COMPILER_ID "VS16"
	#define ZEND_BUILD_SYSTEM "," PHP_COMPILER_ID
	#endif
	
If you are using PHP Version 8.2.0 or later, please open the file "zend_alloc.h" inside the folder "php_src/zend" in your sample and located the following lines:

	#ifndef ZEND_MM_ALIGNMENT
	# error "ZEND_MM_ALIGNMENT was not defined during configure"
	#endif

Replace them with the following lines:

	#ifndef ZEND_MM_ALIGNMENT
	# define ZEND_MM_ALIGNMENT Z_UL(8)
	# define ZEND_MM_ALIGNMENT_LOG2 Z_L(3)
	#elif ZEND_MM_ALIGNMENT < 4
	# undef ZEND_MM_ALIGNMENT
	# undef ZEND_MM_ALIGNMENT_LOG2
	# define ZEND_MM_ALIGNMENT Z_UL(4)
	# define ZEND_MM_ALIGNMENT_LOG2 Z_L(2)
	#endif
	
If you are using PHP 8.3.1, there is a known error on the part of PHP and the build error "error: invalid conversion from 'const void*' to 'const char*'" could occur in "zend_operators.h". If this happens, please locate the following lines in the file "zend_operators.h" in the folder "php_src/zend":

	#if defined(HAVE_STRNLEN)
		return strnlen(s, maxlen);
	#else
		const char *p = memchr(s, '\0', maxlen);
		return p ? p-s : maxlen;
	#endif
	}

Replace them with the following lines:

	#if defined(HAVE_STRNLEN)
		return strnlen(s, maxlen);
	#else
		const char *p = (const char *)memchr(s, '\0', maxlen);
		return p ? p-s : maxlen;
	#endif
	}


You're now able to compile the DLL (Visual C++/Visual Studio 2019 and newer).
-------------------------------------------------

Should you encounter the error "fatal error C1083: Cannot open Include File "config.w32.h": No such file or directory in PHP/php_src/main/ on line 25", create a file named "config.w32.h" and paste the following code for PHP 8.0.x:

/*
	Build Configuration Template for Win32.
*/

/* Define the minimum supported version */
#undef _WIN32_WINNT
#undef NTDDI_VERSION
#define _WIN32_WINNT 0x0601
#define NTDDI_VERSION 0x06010000

/* Default PHP / PEAR directories */
#define PHP_CONFIG_FILE_PATH ""
#define CONFIGURATION_FILE_PATH "php.ini"
#define PEAR_INSTALLDIR "@PREFIX@\\pear"
#define PHP_BINDIR "@PREFIX@"
#define PHP_DATADIR "@PREFIX@"
#define PHP_EXTENSION_DIR "@PREFIX@\\ext"
#define PHP_INCLUDE_PATH	".;@PREFIX@\\pear"
#define PHP_LIBDIR "@PREFIX@"
#define PHP_LOCALSTATEDIR "@PREFIX@"
#define PHP_PREFIX "@PREFIX@"
#define PHP_SYSCONFDIR "@PREFIX@"

/* PHP Runtime Configuration */
#define PHP_URL_FOPEN 1
#define USE_CONFIG_FILE 1
#define DEFAULT_SHORT_OPEN_TAG "1"

/* Platform-Specific Configuration. Should not be changed. */
#define PHP_SIGCHILD 0
#define HAVE_GETSERVBYNAME 1
#define HAVE_GETSERVBYPORT 1
#define HAVE_GETPROTOBYNAME 1
#define HAVE_GETPROTOBYNUMBER 1
#define HAVE_GETHOSTNAME 1
#define STDIN_FILENO 0
#define STDOUT_FILENO 1
#define STDERR_FILENO 2
#define HAVE_ERRMSG_H 0
#undef HAVE_ADABAS
#undef HAVE_SOLID
#undef HAVE_SYMLINK

/* its in win32/time.c */
#define HAVE_USLEEP 1
#define HAVE_NANOSLEEP 1

#define HAVE_GETCWD 1
#define NEED_ISBLANK 1
#define DISCARD_PATH 0
#undef HAVE_SETITIMER
#undef HAVE_SIGSETJMP
#undef HAVE_IODBC
#define HAVE_LIBDL 1
#define HAVE_GETTIMEOFDAY 1
#define HAVE_PUTENV 1
#define HAVE_TZSET 1
#undef HAVE_FLOCK
#define HAVE_ALLOCA 1
#undef HAVE_SYS_TIME_H
#undef HAVE_STRUCT_STAT_ST_BLKSIZE
#undef HAVE_STRUCT_STAT_ST_BLOCKS
#define HAVE_STRUCT_STAT_ST_RDEV 1
#define REGEX 1
#define HSREGEX 1
#define HAVE_GETLOGIN 1
#define HAVE_MEMMOVE 1
#define HAVE_REGCOMP 1
#define HAVE_SHUTDOWN 1
#define HAVE_STRCASECMP 1
#define HAVE_UTIME 1
#undef HAVE_DIRENT_H
#define HAVE_FCNTL_H 1
#define HAVE_GRP_H 0
#undef HAVE_PWD_H
#undef HAVE_SYS_FILE_H
#undef HAVE_SYS_SOCKET_H
#undef HAVE_SYS_WAIT_H
#define HAVE_SYSLOG_H 1
#undef HAVE_UNISTD_H
#define HAVE_SYS_TYPES_H 1
#undef HAVE_ALLOCA_H
#undef HAVE_KILL
#define HAVE_GETPID 1
#define HAVE_LIBM 1
#undef HAVE_RINT
#define SIZEOF_SHORT 2
/* int and long are still 32bit in 64bit compiles */
#define SIZEOF_INT 4
#define SIZEOF_LONG 4
/* MSVC.6/NET don't allow 'long long' or know 'intmax_t' */
#define SIZEOF_LONG_LONG 8 /* defined as __int64 */
#define SIZEOF_INTMAX_T 0
#define ssize_t SSIZE_T
#ifdef _WIN64
# define SIZEOF_SIZE_T 8
# define SIZEOF_PTRDIFF_T 8
#else
# define SIZEOF_SIZE_T 4
# define SIZEOF_PTRDIFF_T 4
#endif
#define SIZEOF_OFF_T 4
#define HAVE_FNMATCH
#define HAVE_GLOB
#define PHP_SHLIB_SUFFIX "dll"
#define PHP_SHLIB_EXT_PREFIX "php_"
#define HAVE_SQLDATASOURCES

/* Win32 supports socketpair by the emulation in win32/sockets.c */
#define HAVE_SOCKETPAIR 1
#define HAVE_SOCKLEN_T 1

/* Win32 support proc_open */
#define PHP_CAN_SUPPORT_PROC_OPEN 1

/* inet_ntop() / inet_pton() */
#define HAVE_INET_PTON 1
#define HAVE_INET_NTOP 1

/* vs.net 2005 has a 64-bit time_t.  This will likely break
 * 3rdParty libs that were built with older compilers; switch
 * back to 32-bit */
#ifndef _WIN64
# define _USE_32BIT_TIME_T 1
#endif

#define _REENTRANT 1

#define HAVE_GETRUSAGE

#define HAVE_FTOK 1

#define HAVE_NICE

#ifdef __clang__
#define HAVE_FUNC_ATTRIBUTE_TARGET 1
#endif

#define HAVE_GETADDRINFO 1
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
- Add the following command: "extension=php_listlabel??.dll;" or the name you've chosen for the DLL.

Now locate line 45 in "frame.php in your "websample" folder and add your personal license key. You can find it in the file "PersonalLicense.txt" in the List & Label installation directory.

To run the sample, simply copy the contents of the "websample" folder to your Windows web server and assign the CHMOD 777 to the file "frame.php" and the "tmp" folder.
To apply the changes you have to restart your web server.

Please note that you need an addendum to the license agreement in order to use List & Label in this way.
-------------------------------------------------

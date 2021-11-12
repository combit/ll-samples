/*============================================================================
 Include File: dsserver.ch
 Author:       Marcus Herz
 Description:
 Created:      06.04.2016     08:18:30        Updated: þ06.04.2016      þ08:18:30
 Copyright:    2016 by DS-Datasoft, 87654 Friesenried
============================================================================*/

#ifndef __INC_SERVER_CH__
#define __INC_SERVER_CH__

#include "types.ch"

#define TOP_SCOPE       				0x01
#define BOTTOM_SCOPE    				0x02
#define FOR_SCOPE       				0x03

// erweitertes Strukturarray bei PQClass, SqlXppClass, AdsClass, dsDbServer
#define _dsDBS_TYPENAME		5
#define _dsDBS_TYPENUM		6
#define _dsDBS_NULLABLE		7
#define _dsDBS_TAB2COL		8
#define _dsDBS_SQLMAX		8

// :dbType
#define SRV_DBF							1
#define SRV_ADS      					2
#define SRV_ADSDBE						2
#define SRV_ACE      					3
#define SRV_SQL      					4
#define SRV_ACESQL   					4
#define SRV_ODBC     					5
#define SRV_ODBC_DB  					6
#define SRV_ARRAY							7
#define SRV_SQLXPP                  8           // Sqlexpress von Boris
#define SRV_PQ_NATIVE					9
#define SRV_PQ_DATASET					10
#define SRV_PGDBE							11
#define SRV_DATAOBJECT					12
#define SRV_PQCLASS						13                                              // version 2

// extending :Status
#define XBP_STAT_OPENED 				20
#define XBP_STAT_CLOSED 				21

// extending :FieldInfo
#define FLD_USER     				100
#define FLD_VALTYPE     			(FLD_USER+1)
#define FLD_NULLABLE     			(FLD_USER+2)
#define FLD_READONLY     			(FLD_USER+3)
#define FLD_PICTURE     			(FLD_USER+4)
#define FLD_EDIT_DEC     			(FLD_USER+5)
#define FLD_EDIT_LEN	     			(FLD_USER+6)
#define FLD_STRUCT					(FLD_USER+7)
#define FLD_EDITPICTURE   			(FLD_USER+8)

//#define FLD_EDIT_PICTURE     			(FLD_USER+8)// erweiterung DBOINFO
#define ACEDBO_TABLETYPE				(DBE_USER+1)
#define ACEDBO_TABLECHARTYPE     	(DBE_USER+2)
#define ACEDBO_TABLELOCKTYPE     	(DBE_USER+3)
#define ACEDBO_TABLERIGHTS       	(DBE_USER+4)

// Defines für ADSServer Datentypen, Erweiterung von XBase Datentypen
// nicht zu verwechseln mit ADS-Konstanten, welche numerisch sind !

// ALASKA changed types.ch with Build .310
#ifndef XPP_TYPE_TIME
	#define XPP_TYPE_TIME            "H"
#endif
#ifndef XPP_TYPE_TIMESTAMP
	#define XPP_TYPE_TIMESTAMP    	"T"
#endif
#ifndef XPP_TYPE_VARBINARY
	#define XPP_TYPE_VARBINARY			"Z"
#endif

// alte defines
//#define ADS_TYPE_AUTOINC				"A"                	// A 4								XPP_TYPE_ARRAY
//#define ADS_TYPE_SHORTINT			"S"                	// S 2
//#define ADS_TYPE_MODTIME				"B"         			// B 									XPP_TYPE_BLOCK
//#define ADS_TYPE_MONEY	   		"K"  						// K #typedef LONGLONG  SIGNED64 = 8
//#define ADS_TYPE_SHORTINT			"S"
//#define ADS_TYPE_ROWVERSION			"G"                  // G									XPP_TYPE_GUID
//#define ADS_TYPE_NCHAR            "1"
//#define ADS_TYPE_CISTRING			"J"
//#define ADS_TYPE_CICHAR				"J"
//#define ADS_TYPE_NVARCHAR         "2"                  //                     27    /* Unpadded Unicode Character data */
//#define ADS_TYPE_NMEMO            "3"                  //                     28    /* Variable Length Unicode Data */
//#define ADS_TYPE_VARBINARY_FOX		"Q"						// Q									XPP_TYPE_WIDEMEMO
//#define ADS_TYPE_IMAGE   			XPP_TYPE_OBJECT      // O
//#define ADS_TYPE_VARCHAR_FOX		"W"						// W									XPP_TYPE_WIDECHAR

// nur noch aus kompatibilität definiert
// KZ, Länge,..
#define ADS_TYPE_AUTOINC				XPP_TYPE_SEQUENCE   	// S 4,8
#define ADS_TYPE_BINARY    			XPP_TYPE_BLOB  		// V
#define ADS_TYPE_CHARACTER 			XPP_TYPE_CHARACTER	// C
#define ADS_TYPE_CICHAR					XPP_TYPE_CHARACTER   // andere notation
#define ADS_TYPE_CISTRING				XPP_TYPE_CHARACTER   // caseinsensitve CHAR
#define ADS_TYPE_CURDOUBLE 			XPP_TYPE_CURRENCY  	// Y 8
#define ADS_TYPE_DATE      			XPP_TYPE_DATE        // D 4
#define ADS_TYPE_DOUBLE    			XPP_TYPE_DOUBLE     	// F 8
#define ADS_TYPE_IMAGE	   			XPP_TYPE_BLOB      	// V
#define ADS_TYPE_INTEGER   			XPP_TYPE_INT       	// I 4
#define ADS_TYPE_LOGICAL   			XPP_TYPE_LOGICAL     // L 1
#define ADS_TYPE_MEMO      			XPP_TYPE_MEMO        // M
#define ADS_TYPE_MODTIME				XPP_TYPE_TIMESTAMP	// T
#define ADS_TYPE_MONEY	   			XPP_TYPE_CURRENCY		// Y
#define ADS_TYPE_NUMERIC	   		XPP_TYPE_NUMERIC  	// N
#define ADS_TYPE_RAW	      			XPP_TYPE_BINARY		// X wie C, aber mit \0 Byte , feste länge
#define ADS_TYPE_ROWVERSION			XPP_TYPE_INT         // I 8
#define ADS_TYPE_SHORTINT				XPP_TYPE_INT        	// I 2
#define ADS_TYPE_TIME      			XPP_TYPE_TIME        // H 4
#define ADS_TYPE_TIMESTAMP 			XPP_TYPE_TIMESTAMP	// T 8
#define ADS_TYPE_VARBINARY_FOX		XPP_TYPE_VARBINARY	// Z
#define ADS_TYPE_VARCHAR  				XPP_TYPE_VARCHAR		// R beliebige länge
#define ADS_TYPE_VARCHAR_FOX        XPP_TYPE_VARCHAR     // R

/* Unicode Character database */
#define ADS_TYPE_NCHAR              XPP_TYPE_WIDECHAR
#define ADS_TYPE_NMEMO              XPP_TYPE_WIDEMEMO
#define ADS_TYPE_NVARCHAR           XPP_TYPE_VARWIDECHAR

// gilt für alaska und ads
// alle numerische data types
#define DB_TYPES_NUMERIC				ADS_TYPE_AUTOINC+ADS_TYPE_DOUBLE+ADS_TYPE_ROWVERSION+ADS_TYPE_INTEGER+ADS_TYPE_MONEY+ADS_TYPE_NUMERIC+ADS_TYPE_SHORTINT+ADS_TYPE_CURDOUBLE

// alle string data types, ohne blob, image, unicode
#define DB_TYPES_STRING					ADS_TYPE_MODTIME+ADS_TYPE_CHARACTER+ADS_TYPE_TIME+ADS_TYPE_CISTRING+ADS_TYPE_MEMO+ADS_TYPE_VARCHAR+ADS_TYPE_TIMESTAMP+ADS_TYPE_VARCHAR_FOX

// _SS_ _dsDataSources constants
#define DSDSRC_ID      			1   // developer assigned unique ID (system assigns if not specified)
#define DSDSRC_NAME    			2   // database name (server name for ADSDBE)
#define DSDSRC_CSTRING 			3   // connection string
#define DSDSRC_OBJECT  			4   // DAC session (for DBE) or custom object
#define DSDSRC_THREAD  			5   // thread ID
#define DSDSRC_DBE     			6   // DBE
#define DSDSRC_CUSTOM  			7   // custom session class name
#define DSDSRC_POS	  			8   // position in List


#endif

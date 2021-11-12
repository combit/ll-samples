// Copyright (c) 2002-2003 Extended Systems, Inc.  ALL RIGHTS RESERVED.
//
// This source code can be used, modified, or copied by the licensee as long as
// the modifications (or the new binary resulting from a copy or modification of
// this source code) are used with Extended Systems' products. The source code
// is not redistributable as source code, but is redistributable as compiled
// and linked binary code. If the source code is used, modified, or copied by
// the licensee, Extended Systems Inc. reserves the right to receive from the
// licensee, upon request, at no cost to Extended Systems Inc., the modifications.
//
// Extended Systems Inc. does not warrant that the operation of this software
// will meet your requirements or that the operation of the software will be
// uninterrupted, be error free, or that defects in software will be corrected.
// This software is provided "AS IS" without warranty of any kind. The entire
// risk as to the quality and performance of this software is with the purchaser.
// If this software proves defective or inadequate, purchaser assumes the entire
// cost of servicing or repair. No oral or written information or advice given
// by an Extended Systems Inc. representative shall create a warranty or in any
// way increase the scope of this warranty.

///////////////////////////////////////////////////////////////////////////////
//
//  ace.ch
//
// This is a copy of extended systems ACE.H (ACESDK)
// adapted to Xbase++ syntax by DS-Datasoft GMBH 2006
//
///////////////////////////////////////////////////////////////////////////////



#ifndef __ACEXBP_INCLUDED__
#define __ACEXBP_INCLUDED__

// Bitmap ID in XCLACE32.DLL
#ifndef BMP_ACESERVER_INFO
#define BMP_ACESERVER_INFO			2410
#endif


********************************************************************************
* Source File  : ace.h
* Copyright    : 1996-1999 Extended Systems, Inc.
* Description  : This is the main header file for the Advantage Client
*                Engine.  It contains the type definitions, constants,
*                and prototypes for the APIs
********************************************************************************

/* Logical constants */
#define ADS_FALSE                0
#define ADS_TRUE                 1


/* This is for parameters to routines that accept a default setting */
#define ADS_DEFAULT              0

/* character set types */
#define ADS_ANSI                 		1
#define ADS_OEM                  		2
#define CZECH_VFP_CI_AS_1250           3
#define GENERAL_VFP_CI_AS_1250         4
#define HUNGARY_VFP_CI_AS_1250         5
#define MACHINE_VFP_BIN_1250           6
#define POLISH_VFP_CI_AS_1250          7
#define SLOVAK_VFP_CI_AS_1250          8
#define MACHINE_VFP_BIN_1251           9
#define RUSSIAN_VFP_CI_AS_1251         10
#define DUTCH_VFP_CI_AS_1252           11
#define GENERAL_VFP_CI_AS_1252         12
#define GERMAN_VFP_CI_AS_1252          13
#define ICELAND_VFP_CI_AS_1252         14
#define MACHINE_VFP_BIN_1252           15
#define NORDAN_VFP_CI_AS_1252          16
#define SPANISH_VFP_CI_AS_1252         17
#define SWEFIN_VFP_CI_AS_1252          18
#define UNIQWT_VFP_CS_AS_1252          19
#define GREEK_VFP_CI_AS_1253           20
#define MACHINE_VFP_BIN_1253           21
#define GENERAL_VFP_CI_AS_1254         22
#define MACHINE_VFP_BIN_1254           23
#define TURKISH_VFP_CI_AS_1254         24
#define DUTCH_VFP_CI_AS_437            25
#define GENERAL_VFP_CI_AS_437          26
#define GERMAN_VFP_CI_AS_437           27
#define ICELAND_VFP_CI_AS_437          28
#define MACHINE_VFP_BIN_437            29
#define NORDAN_VFP_CI_AS_437           30
#define SPANISH_VFP_CI_AS_437          31
#define SWEFIN_VFP_CI_AS_437           32
#define UNIQWT_VFP_CS_AS_437           33
#define GENERAL_VFP_CI_AS_620          34
#define MACHINE_VFP_BIN_620            35
#define POLISH_VFP_CI_AS_620           36
#define GREEK_VFP_CI_AS_737            37
#define MACHINE_VFP_BIN_737            38
#define DUTCH_VFP_CI_AS_850            39
#define GENERAL_VFP_CI_AS_850          40
#define ICELAND_VFP_CI_AS_850          41
#define MACHINE_VFP_BIN_850            42
#define NORDAN_VFP_CI_AS_850           43
#define SPANISH_VFP_CI_AS_850          44
#define SWEFIN_VFP_CI_AS_850           45
#define UNIQWT_VFP_CS_AS_850           46
#define CZECH_VFP_CI_AS_852            47
#define GENERAL_VFP_CI_AS_852          48
#define HUNGARY_VFP_CI_AS_852          49
#define MACHINE_VFP_BIN_852            50
#define POLISH_VFP_CI_AS_852           51
#define SLOVAK_VFP_CI_AS_852           52
#define GENERAL_VFP_CI_AS_857          53
#define MACHINE_VFP_BIN_857            54
#define TURKISH_VFP_CI_AS_857          55
#define GENERAL_VFP_CI_AS_861          56
#define ICELAND_VFP_CI_AS_861          57
#define MACHINE_VFP_BIN_861            58
#define GENERAL_VFP_CI_AS_865          59
#define MACHINE_VFP_BIN_865            60
#define NORDAN_VFP_CI_AS_865           61
#define SWEFIN_VFP_CI_AS_865           62
#define MACHINE_VFP_BIN_866            63
#define RUSSIAN_VFP_CI_AS_866          64
#define CZECH_VFP_CI_AS_895            65
#define GENERAL_VFP_CI_AS_895          66
#define MACHINE_VFP_BIN_895            67
#define SLOVAK_VFP_CI_AS_895           68
#define DANISH_ADS_CS_AS_1252          69
#define DUTCH_ADS_CS_AS_1252           70
#define ENGL_AMER_ADS_CS_AS_1252       71
#define ENGL_CAN_ADS_CS_AS_1252        72
#define ENGL_UK_ADS_CS_AS_1252         73
#define FINNISH_ADS_CS_AS_1252         74
#define FRENCH_ADS_CS_AS_1252          75
#define FRENCH_CAN_ADS_CS_AS_1252      76
#define GERMAN_ADS_CS_AS_1252          77
#define ICELANDIC_ADS_CS_AS_1252       78
#define ITALIAN_ADS_CS_AS_1252         79
#define NORWEGIAN_ADS_CS_AS_1252       80
#define PORTUGUESE_ADS_CS_AS_1252      81
#define SPANISH_ADS_CS_AS_1252         82
#define SPAN_MOD_ADS_CS_AS_1252        83
#define SWEDISH_ADS_CS_AS_1252         84
#define RUSSIAN_ADS_CS_AS_1251         85
#define ASCII_ADS_CS_AS_1252           86
#define TURKISH_ADS_CS_AS_1254         87
#define POLISH_ADS_CS_AS_1250          88
#define BALTIC_ADS_CS_AS_1257          89
#define UKRAINIAN_ADS_CS_AS_1251       90
#define DUDEN_DE_ADS_CS_AS_1252        91
#define USA_ADS_CS_AS_437              92
#define DANISH_ADS_CS_AS_865           93
#define DUTCH_ADS_CS_AS_850            94
#define FINNISH_ADS_CS_AS_865          95
#define FRENCH_ADS_CS_AS_863           96
#define GERMAN_ADS_CS_AS_850           97
#define GREEK437_ADS_CS_AS_437         98
#define GREEK851_ADS_CS_AS_851         99
#define ICELD850_ADS_CS_AS_850         100
#define ICELD861_ADS_CS_AS_861         101
#define ITALIAN_ADS_CS_AS_850          102
#define NORWEGN_ADS_CS_AS_865          103
#define PORTUGUE_ADS_CS_AS_860         104
#define SPANISH_ADS_CS_AS_852          105
#define SWEDISH_ADS_CS_AS_865          106
#define MAZOVIA_ADS_CS_AS_852          107
#define PC_LATIN_ADS_CS_AS_852         108
#define ISOLATIN_ADS_CS_AS_850         109
#define RUSSIAN_ADS_CS_AS_866          110
#define NTXCZ852_ADS_CS_AS_852         111
#define NTXCZ895_ADS_CS_AS_895         112
#define NTXSL852_ADS_CS_AS_852         113
#define NTXSL895_ADS_CS_AS_895         114
#define NTXHU852_ADS_CS_AS_852         115
#define NTXPL852_ADS_CS_AS_852         116
#define TURKISH_ADS_CS_AS_857          117
#define BOSNIAN_ADS_CS_AS_775          118

#define ADS_MAX_CHAR_SETS              118


/* rights checking options */
#define ADS_CHECKRIGHTS          1
#define ADS_IGNORERIGHTS         2

/* options for connecting to Advantage servers - can be ORed together */
#define ADS_INC_USERCOUNT        	1
#define ADS_STORED_PROC_CONN     	2
#define ADS_COMPRESS_ALWAYS      	0x00000004
#define ADS_COMPRESS_NEVER       	0x00000008
#define ADS_COMPRESS_INTERNET    	0x0000000C
#define ADS_REPLICATION_CONNECTION  0x00000010
#define ADS_UDP_IP_CONNECTION       0x00000020			// 32
#define ADS_IPX_CONNECTION          0x00000040  		// 64
#define ADS_TCP_IP_CONNECTION       0x00000080			// 128
#define ADS_TCP_IP_V6_CONNECTION    0x00000100			// 256
#define ADS_NOTIFICATION_CONNECTION 0x00000200


/* options for opening tables - can be ORed together */
#define ADS_EXCLUSIVE            			1
#define ADS_READONLY             			2
#define ADS_SHARED               			4
#define ADS_CLIPPER_MEMOS        			8
#define ADS_TABLE_PERM_READ               0x00000010
#define ADS_TABLE_PERM_UPDATE             0x00000020
#define ADS_TABLE_PERM_INSERT             0x00000040
#define ADS_TABLE_PERM_DELETE             0x00000080
#define ADS_REINDEX_ON_COLLATION_MISMATCH 0x00000100
#define ADS_IGNORE_COLLATION_MISMATCH     0x00000200
#define ADS_FREE_TABLE                    0x00001000  // Mutually exclusive with ADS_DICTIONARY_BOUND_TABLE
#define ADS_TEMP_TABLE                    0x00002000  // Mutually exclusive with ADS_DICTIONARY_BOUND_TABLE
#define ADS_DICTIONARY_BOUND_TABLE        0x00004000  // Mutually exclusive with ADS_FREE_TABLE or ADS_TEMP_TABLE
#define ADS_CACHE_READS                   0x20000000  // Enable caching of reads on the table
#define ADS_CACHE_WRITES                  0x40000000  // Enable caching of reads & writes on the table

/* Options for creating indexes - can be ORed together */
#define ADS_ASCENDING            0
#define ADS_UNIQUE               1
#define ADS_COMPOUND             2
#define ADS_CUSTOM               4
#define ADS_DESCENDING           8
#define ADS_USER_DEFINED         16
// 020 - 200 FTS index options below
#define ADS_NOT_AUTO_OPEN        0x00000400     // Don't make this an auto open index in data dictionary
#define ADS_CANDIDATE            0x00000800     // true unique CDX index (equivalent to ADS_UNIQUE for ADIs)

/* Options specifically for FTS indexes */
#define ADS_FTS_INDEX            0x00000020      // This is implied for AdsCreateFTSIndex
#define ADS_FTS_FIXED            0x00000040      // Do not maintain the index with record updates
#define ADS_FTS_CASE_SENSITIVE   0x00000080      // Make the index case sensitive
#define ADS_FTS_KEEP_SCORE       0x00000100      // Track word counts in the index for faster SCORE()
#define ADS_FTS_PROTECT_NUMBERS  0x00000200      // Don't break numbers on commas and periods

#define ADS_BINARY_INDEX              0x00001000     // logical index with a bitmap for data
/* Options concerning Unicode string in the indexes 2000 - 4000 */
#define ADS_UCHAR_KEY_SHORT           0x00002000
#define ADS_UCHAR_KEY_LONG            0x00004000
#define ADS_UCHAR_KEY_XLONG           0x00006000

/* Option to force index version */
#define ADS_ALLOW_MULTIPLE_COLLATION  0x0004000


/* Options for returning string values */
#define ADS_NONE                 0
#define ADS_LTRIM                1
#define ADS_RTRIM                2
#define ADS_TRIM                 3

//  /* this is for passing null terminated strings */
//  #define ADS_NTS    ( ( UNSIGNED16 ) -1 )

/* locking compatibility */
#define ADS_COMPATIBLE_LOCKING   0
#define ADS_PROPRIETARY_LOCKING  1

/* settings for seeks */
#define ADS_SOFTSEEK             1
#define ADS_HARDSEEK             2
#define ADS_SEEKGT               4

/* data types for seeks (and scopes) */
#define ADS_RAWKEY               1   /* no conversion performed on given data */
#define ADS_STRINGKEY            2   /* data given as a string */
#define ADS_DOUBLEKEY            4   /* data is a pointer to 8 byte double */

/* Option for AdsBuildRawKey100 */
#define  ADS_GET_DEFAULT_KEY_LENGTH       0x00000000
#define  ADS_GET_PARTIAL_FULL_KEY_LENGTH  0x00000001
#define  ADS_GET_FULL_KEY_LENGTH          0x00000002
#define  ADS_GET_PRIMARY_WEIGHT_LENGTH    0x00000004


/* For retrieving scope settings */
#define ADS_TOP                  1
#define ADS_BOTTOM               2

/* for calls that can optionally use filters
	ALASKA ADSDBE defines already
*/
#ifndef ADS_RESPECTFILTERS
#define ADS_RESPECTFILTERS       1
#define ADS_IGNOREFILTERS        2
#define ADS_RESPECTSCOPES        3
#endif

//*
//* This value is only used with GetRecordCount:  It can be ORed in with the
//* ignore filter value to force a read from the DBF header to get the most
//* current record count.
//*
#define ADS_REFRESHCOUNT         4

/* Server type constants */
#define ADS_LOCAL_SERVER         1
#define ADS_REMOTE_SERVER        2
#define ADS_AIS_SERVER           4

/* ACE Handle types */
#define ADS_CONNECTION           1
#define ADS_TABLE                2
#define ADS_INDEX_ORDER          3
#define ADS_STATEMENT            4
#define ADS_CURSOR               5
#define ADS_DATABASE_CONNECTION  6
/* #define ADS_SYS_ADMIN_CONNECTION  7   obsolete */
#define ADS_FTS_INDEX_ORDER     	8

/* ACE Cursor ReadOnly settings */
#define ADS_CURSOR_READONLY      1
#define ADS_CURSOR_READWRITE     2

/* ACE Cursor Constrain settings */
#define ADS_CONSTRAIN            1
#define ADS_NO_CONSTRAIN         2

/* Select Field Read settings */
#define ADS_READ_ALL_COLUMNS     1
#define ADS_READ_SELECT_COLUMNS  2

/* Data dictionary new contraint property validation options */
#define ADS_NO_VALIDATE           0  /* Do not validate records against the new constraint */
#define ADS_VALIDATE_NO_SAVE      1  /* Delete record not meeting the constraint from the table, no save */
#define ADS_VALIDATE_WRITE_FAIL   2  /* Validate the records against the new constraint and overwrite
                                      * the fail table with records not meeting the constraint. */
#define ADS_VALIDATE_APPEND_FAIL  3  /* Validate the records against the new constraint and append
                                      * the failed records into the fail table */
#define ADS_VALIDATE_RETURN_ERROR 4  /* Validate the records against the new constraint and return
                                      * error if there is any record not meeting the constraint */

/* Possible result values from AdsCompareBookmarks. */
#define ADS_CMP_LESS    -1
#define ADS_CMP_EQUAL    0
#define ADS_CMP_GREATER  1

/* Property values for the AdsGetConnectionProperty API */
#define ADS_CONNECTIONPROP_USERNAME    0
#define ADS_CONNECTIONPROP_PASSWORD    1
#define ADS_CONNECTIONPROP_PROTOCOL    2  // Shhh, currently unpublished...

/* Options for the AdsGetRecordCRC API */
#define ADS_CRC_LOCALLY       	1
#define ADS_CRC_IGNOREMEMOPAGES  2

/* Options for notification events */
#define ADS_EVENT_ASYNC          1
#define ADS_EVENT_WITH_DATA      2  // Allow data to be passed with this event

/* Options for the AdsCancelUpdate90 API */
#define ADS_PRESERVE_ERR      0x0001


/* property for AdsGetIntProperty API */
#define ADS_CODE_PAGE               1


/* Success return code */
#define AE_SUCCESS               0


/* Error codes */
#define AE_ALLOCATION_FAILED            5001
#define AE_COMM_MISMATCH                5002
#define AE_DATA_TOO_LONG                5003
#define AE_FILE_NOT_FOUND               5004
#define AE_INSUFFICIENT_BUFFER          5005
#define AE_INVALID_BOOKMARK             5006
#define AE_INVALID_CALLBACK             5007
#define AE_INVALID_CENTURY              5008
#define AE_INVALID_DATEFORMAT           5009
#define AE_INVALID_DECIMALS             5010
#define AE_INVALID_EXPRESSION           5011
#define AE_INVALID_FIELDDEF             5012
#define AE_INVALID_FILTER_OPTION        5013
#define AE_INVALID_INDEX_HANDLE         5014
#define AE_INVALID_INDEX_NAME           5015
#define AE_INVALID_INDEX_ORDER_NAME     5016
#define AE_INVALID_INDEX_TYPE           5017
#define AE_INVALID_HANDLE               5018
#define AE_INVALID_OPTION               5019
#define AE_INVALID_PATH                 5020
#define AE_INVALID_POINTER              5021
#define AE_INVALID_RECORD_NUMBER        5022
#define AE_INVALID_TABLE_HANDLE         5023
#define AE_INVALID_CONNECTION_HANDLE    5024
#define AE_INVALID_TABLETYPE            5025
#define AE_INVALID_WORKAREA             5026
#define AE_INVALID_CHARSETTYPE          5027
#define AE_INVALID_LOCKTYPE             5028
#define AE_INVALID_RIGHTSOPTION         5029
#define AE_INVALID_FIELDNUMBER          5030
#define AE_INVALID_KEY_LENGTH           5031
#define AE_INVALID_FIELDNAME            5032
#define AE_NO_DRIVE_CONNECTION          5033
#define AE_FILE_NOT_ON_SERVER           5034
#define AE_LOCK_FAILED                  5035
#define AE_NO_CONNECTION                5036
#define AE_NO_FILTER                    5037
#define AE_NO_SCOPE                     5038
#define AE_NO_TABLE                     5039
#define AE_NO_WORKAREA                  5040
#define AE_NOT_FOUND                    5041
#define AE_NOT_IMPLEMENTED              5042
#define AE_MAX_THREADS_EXCEEDED         5043
#define AE_START_THREAD_FAIL            5044
#define AE_TOO_MANY_INDEXES             5045
#define AE_TOO_MANY_TAGS                5046
#define AE_TRANS_OUT_OF_SEQUENCE        5047
#define AE_UNKNOWN_ERRCODE              5048
#define AE_UNSUPPORTED_LANGUAGE         5049
#define AE_NAME_TOO_LONG                5050
#define AE_DUPLICATE_ALIAS              5051
#define AE_TABLE_CLOSED_IN_TRANSACTION  5053
#define AE_PERMISSION_DENIED            5054
#define AE_STRING_NOT_FOUND             5055
#define AE_UNKNOWN_CHAR_SET             5056
#define AE_INVALID_OEM_CHAR_FILE        5057
#define AE_INVALID_MEMO_BLOCK_SIZE      5058
#define AE_NO_FILE_FOUND                5059
#define AE_NO_INF_LOCK                  5060
#define AE_INF_FILE_ERROR               5061
#define AE_RECORD_NOT_LOCKED            5062
#define AE_ILLEGAL_COMMAND_DURING_TRANS 5063
#define AE_TABLE_NOT_SHARED             5064
#define AE_INDEX_ALREADY_OPEN           5065
#define AE_INVALID_FIELD_TYPE           5066
#define AE_TABLE_NOT_EXCLUSIVE          5067
#define AE_NO_CURRENT_RECORD            5068
#define AE_PRECISION_LOST               5069
#define AE_INVALID_DATA_TYPE            5070
#define AE_DATA_TRUNCATED               5071
#define AE_TABLE_READONLY               5072
#define AE_INVALID_RECORD_LENGTH        5073
#define AE_NO_ERROR_MESSAGE             5074
#define AE_INDEX_SHARED                 5075
#define AE_INDEX_EXISTS                 5076
#define AE_CYCLIC_RELATION              5077
#define AE_INVALID_RELATION             5078
#define AE_INVALID_DAY                  5079
#define AE_INVALID_MONTH                5080
#define AE_CORRUPT_TABLE                5081
#define AE_INVALID_BINARY_OFFSET        5082
#define AE_BINARY_FILE_ERROR            5083
#define AE_INVALID_DELETED_BYTE_VALUE   5084
#define AE_NO_PENDING_UPDATE            5085
#define AE_PENDING_UPDATE               5086
#define AE_TABLE_NOT_LOCKED             5087
#define AE_CORRUPT_INDEX                5088
#define AE_AUTOOPEN_INDEX               5089
#define AE_SAME_TABLE                   5090
#define AE_INVALID_IMAGE                5091
#define AE_COLLATION_SEQUENCE_MISMATCH  5092
#define AE_INVALID_INDEX_ORDER          5093
#define AE_TABLE_CACHED                 5094
#define AE_INVALID_DATE                 5095
#define AE_ENCRYPTION_NOT_ENABLED       5096
#define AE_INVALID_PASSWORD             5097
#define AE_TABLE_ENCRYPTED              5098
#define AE_SERVER_MISMATCH              5099
#define AE_INVALID_USERNAME             5100
#define AE_INVALID_VALUE                5101
#define AE_INVALID_CONTINUE             5102
#define AE_UNRECOGNIZED_VERSION         5103
#define AE_RECORD_ENCRYPTED             5104
#define AE_UNRECOGNIZED_ENCRYPTION      5105
#define AE_INVALID_SQLSTATEMENT_HANDLE  5106
#define AE_INVALID_SQLCURSOR_HANDLE     5107
#define AE_NOT_PREPARED                 5108
#define AE_CURSOR_NOT_CLOSED            5109
#define AE_INVALID_SQL_PARAM_NUMBER     5110
#define AE_INVALID_SQL_PARAM_NAME       5111
#define AE_INVALID_COLUMN_NUMBER        5112
#define AE_INVALID_COLUMN_NAME          5113
#define AE_INVALID_READONLY_OPTION      5114
#define AE_IS_CURSOR_HANDLE             5115
#define AE_INDEX_EXPR_NOT_FOUND         5116
#define AE_NOT_DML                      5117
#define AE_INVALID_CONSTRAIN_TYPE       5118
#define AE_INVALID_CURSORHANDLE         5119
#define AE_OBSOLETE_FUNCTION            5120
#define AE_TADSDATASET_GENERAL          5121
#define AE_UDF_OVERWROTE_BUFFER         5122
#define AE_INDEX_UDF_NOT_SET            5123
#define AE_CONCURRENT_PROBLEM           5124
#define AE_INVALID_DICTIONARY_HANDLE    5125
#define AE_INVALID_PROPERTY_ID          5126
#define AE_INVALID_PROPERTY             5127
#define AE_DICTIONARY_ALREADY_EXISTS    5128
#define AE_INVALID_FIND_HANDLE          5129
#define AE_DD_REQUEST_NOT_COMPLETED     5130
#define AE_INVALID_OBJECT_ID            5131
#define AE_INVALID_OBJECT_NAME          5132
#define AE_INVALID_PROPERTY_LENGTH      5133
#define AE_INVALID_KEY_OPTIONS          5134
#define AE_CONSTRAINT_VALIDATION_ERROR  5135
#define AE_INVALID_OBJECT_TYPE          5136
#define AE_NO_OBJECT_FOUND              5137
#define AE_PROPERTY_NOT_SET             5138
#define AE_NO_PRIMARY_KEY_EXISTS        5139
#define AE_LOCAL_CONN_DISABLED          5140
#define AE_RI_RESTRICT                  5141
#define AE_RI_CASCADE                   5142
#define AE_RI_FAILED                    5143
#define AE_RI_CORRUPTED                 5144
#define AE_RI_UNDO_FAILED               5145
#define AE_RI_RULE_EXISTS               5146
#define AE_COLUMN_CANNOT_BE_NULL        5147
#define AE_MIN_CONSTRAINT_VIOLATION     5148
#define AE_MAX_CONSTRAINT_VIOLATION     5149
#define AE_RECORD_CONSTRAINT_VIOLATION  5150
#define AE_CANNOT_DELETE_TEMP_INDEX     5151
#define AE_RESTRUCTURE_FAILED           5152
#define AE_INVALID_STATEMENT            5153
#define AE_STORED_PROCEDURE_FAILED      5154
#define AE_INVALID_DICTIONARY_FILE      5155
#define AE_NOT_MEMBER_OF_GROUP          5156
#define AE_ALREADY_MEMBER_OF_GROUP      5157
#define AE_INVALID_OBJECT_RIGHT         5158
#define AE_INVALID_OBJECT_PERMISSION    5158    /* Note that this is same as above. The word
                                                 * permission is more commonly used.
                                                 */
#define AE_CANNOT_OPEN_DATABASE_TABLE   5159
#define AE_INVALID_CONSTRAINT           5160
#define AE_NOT_ADMINISTRATOR            5161
#define AE_NO_TABLE_ENCRYPTION_PASSWORD 5162
#define AE_TABLE_NOT_ENCRYPTED          5163
#define AE_INVALID_ENCRYPTION_VERSION   5164
#define AE_NO_STORED_PROC_EXEC_RIGHTS   5165
#define AE_DD_UNSUPPORTED_DEPLOYMENT    5166
#define AE_INFO_AUTO_CREATION_OCCURRED  5168
#define AE_INFO_COPY_MADE_BY_CLIENT     5169
#define AE_DATABASE_REQUIRES_NEW_SERVER 5170
#define AE_COLUMN_PERMISSION_DENIED     5171
#define AE_DATABASE_REQUIRES_NEW_CLIENT 5172
#define AE_INVALID_LINK_NUMBER          5173
#define AE_LINK_ACTIVATION_FAILED       5174
#define AE_INDEX_COLLATION_MISMATCH     5175
#define AE_ILLEGAL_USER_OPERATION       5176
#define AE_TRIGGER_FAILED               5177
#define AE_NO_ASA_FUNCTION_FOUND        5178
#define AE_VALUE_OVERFLOW               5179
#define AE_UNRECOGNIZED_FTS_VERSION     5180
#define AE_TRIG_CREATION_FAILED         5181
#define AE_MEMTABLE_SIZE_EXCEEDED       5182
#define AE_OUTDATED_CLIENT_VERSION      5183
#define AE_FREE_TABLE                   5184
#define AE_LOCAL_CONN_RESTRICTED        5185
#define AE_OLD_RECORD                   5186
#define AE_QUERY_NOT_ACTIVE             5187
#define AE_KEY_EXCEEDS_PAGE_SIZE        5188
#define AE_TABLE_FOUND                  5189
#define AE_TABLE_NOT_FOUND              5190
#define AE_LOCK_OBJECT                  5191
#define AE_INVALID_REPLICATION_IDENT    5192
#define AE_ILLEGAL_COMMAND_DURING_BACKUP 5193
#define AE_NO_MEMO_FILE                 5194
#define AE_SUBSCRIPTION_QUEUE_NOT_EMPTY 5195
#define AE_UNABLE_TO_DISABLE_TRIGGERS   5196
#define AE_UNABLE_TO_ENABLE_TRIGGERS    5197
#define AE_BACKUP                       5198
#define AE_FREETABLEFAILED              5199
#define AE_BLURRY_SNAPSHOT              5200
#define AE_INVALID_VERTICAL_FILTER      5201
#define AE_INVALID_USE_OF_HANDLE_IN_AEP 5202
#define AE_COLLATION_NOT_RECOGNIZED     5203
#define AE_INVALID_COLLATION            5204
#define AE_NOT_VFP_NULLABLE_FIELD       5205
#define AE_NOT_VFP_VARIABLE_FIELD       5206
#define AE_ILLEGAL_EVENT_COMMAND        5207
#define AE_KEY_CANNOT_BE_NULL           5208
#define AE_COLLATIONS_DO_NOT_MATCH      5209
#define AE_INVALID_APPID                5210
#define AE_UNICODE_CONVERSION           5211
#define AE_UNICODE_COLLATION            5212


// DS_Datasoft
#define AE_MAX_ERROR                    5212

/* Supported file types */
#define ADS_DATABASE_TABLE       ADS_DEFAULT
#define ADS_NTX                  1
#define ADS_CDX                  2
#define ADS_ADT                  3
#define ADS_VFP                  4

/* for retrieving file names of tables */
#define ADS_BASENAME             1
#define ADS_BASENAMEANDEXT       2
#define ADS_FULLPATHNAME         3
#define ADS_DATADICTIONARY_NAME  4
#define ADS_TABLE_OPEN_NAME      5

/* Advantage Optimized Filter (AOF) optimization levels */
#define ADS_OPTIMIZED_FULL       1
#define ADS_OPTIMIZED_PART       2
#define ADS_OPTIMIZED_NONE       3

/* Advantage Optimized Filter (AOF) resolution options */
#define ADS_DYNAMIC_AOF          0x00000000  /* default */
#define ADS_RESOLVE_IMMEDIATE    0x00000001
#define ADS_RESOLVE_DYNAMIC      0x00000002
#define ADS_KEYSET_AOF           0x00000004
#define ADS_FIXED_AOF            0x00000008
#define ADS_KEEP_AOF_PLAN        0x00000010
#define ADS_ENCODE_UTF16         0x00002000        // Used in AdsSetFilter100 options as well
#define ADS_ENCODE_UTF8          0x00004000        // Used in AdsSetFitler100 options as well

#define ADS_ENCODING_MASK        ( ADS_ENCODE_UTF8 | ADS_ENCODE_UTF16 )


/* Advantage Optimized Filter (AOF) customization options */
#define ADS_AOF_ADD_RECORD       1
#define ADS_AOF_REMOVE_RECORD    2
#define ADS_AOF_TOGGLE_RECORD    3

/* Stored procedure or trigger type */
#define ADS_STORED_PROC          0x00000001
#define ADS_COMSTORED_PROC       0x00000002  /* means we know for sure this is a com
                                              * aep. Before 7.1 we couldn't distinguish. */
#define ADS_SCRIPT_PROC          0x00000004  /* Stored procedure written in SQL script */

/* some maximum values used by the client */
/* NOTE:  constants meant for string length exclude space for null terminator */
#define ADS_MAX_DATEMASK         12
#define ADS_MAX_ERROR_LEN        600
#define ADS_MAX_INDEX_EXPR_LEN   510   /* this is only accurate for index expressions */
#define ADS_MAX_KEY_LENGTH       4082  /* maximum key value length.  This is the max key length
                                        * of ADI indexes.  Max CDX key length is 240.  Max
                                        * NTX key length is 256 */
#define ADS_MAX_FIELD_NAME       128
#define ADS_MAX_DBF_FIELD_NAME   10    /* maximum length of field name in a DBF */
#define ADS_MAX_INDEXES          15    /* physical index files, NOT index orders */
#define ADS_MAX_PATH             260
#define ADS_MAX_TABLE_NAME       255   /* long file name */
#define ADS_MAX_TAG_NAME         128
#define ADS_MAX_TAGS             256    /* maximum for CDX/ADI file */
#define ADS_MAX_OBJECT_NAME      200   /* maximum length of DD object name */
#define ADS_MAX_TABLE_AND_PATH   ADS_MAX_TABLE_NAME + ADS_MAX_PATH

/*
 * Valid range of page sizes for ADI indexes.  The default page size is 512
 * bytes.  Before using another page size, please read the section titled
 * "Index Page Size" in the Advantage Client Engine help file (ace.hlp)
 */
#define ADS_MIN_ADI_PAGESIZE     512
#define ADS_MAX_ADI_PAGESIZE     8192

/* data types */
#define ADS_TYPE_UNKNOWN         0
#define ADS_LOGICAL              1     /* 1 byte logical value */
#define ADS_NUMERIC              2     /* DBF character style numeric */
#define ADS_DATE                 3     /* Date field.  With ADS_NTX and ADS_CDX,
                                        * this is an 8 byte field of the form
                                        * CCYYMMDD.  With ADS_ADT, it is a
                                        * 4 byte Julian date. */
#define ADS_STRING               4     /* Character data */
#define ADS_MEMO                 5     /* Variable length character data */

/* the following are extended data types */
#define ADS_BINARY               6     /* BLOB - any data */
#define ADS_IMAGE                7     /* BLOB - bitmap */
#define ADS_VARCHAR              8     /* variable length character field */
#define ADS_COMPACTDATE          9     /* DBF date represented with 3 bytes */
#define ADS_DOUBLE               10    /* IEEE 8 byte floating point */
#define ADS_INTEGER              11    /* IEEE 4 byte signed long integer */

/* the following are supported with the ADT file only */
#define ADS_SHORTINT             12    /* IEEE 2 byte signed short integer */
#define ADS_TIME                 13    /* 4 byte long integer representing
                                        * milliseconds since midnight */
#define ADS_TIMESTAMP            14    /* 8 bytes.  High order 4 bytes are a
                                        * long integer representing Julian date.
                                        * Low order 4 bytes are a long integer
                                        * representing milliseconds since
                                        * midnight */
#define ADS_AUTOINC              15    /* 4 byte auto-increment value */
#define ADS_RAW                  16    /* Untranslated data */
#define ADS_CURDOUBLE            17    /* IEEE 8 byte floating point currency */
#define ADS_MONEY                18    /* 8 byte, 4 implied decimal Currency Field */
#define ADS_LONGLONG             19    /* 8 byte integer */
#define ADS_CISTRING             20    /* CaSe INSensiTIVE character data */
#define ADS_ROWVERSION           21    /* 8 byte integer, incremented for every update, unique to entire table */
#define ADS_MODTIME              22    /* 8 byte timestamp, updated when record is updated */
#define ADS_VARCHAR_FOX          23    /* Visual FoxPro varchar field */
#define ADS_VARBINARY_FOX        24    /* Visual FoxPro varbinary field */
#define ADS_SYSTEM_FIELD         25    /* For internal usage */
#define ADS_NCHAR                26    /* Unicode Character database */
#define ADS_NVARCHAR             27    /* Unpadded Unicode Character data */
#define ADS_NMEMO                28    /* Variable Length Unicode Data */


/*
 * supported User Defined Function types to be used with AdsRegisterUDF
 */
#define ADS_INDEX_UDF            1


/*
 * Constant for AdsMgGetConfigInfo
 */
#define ADS_MAX_CFG_PATH         256

/*
 * Constants for AdsMgGetServerType
 * Note ADS_MGMT_NETWARE_SERVER remains for backwards compatibility only
 */
#define ADS_MGMT_NETWARE_SERVER           1
#define ADS_MGMT_NETWARE4_OR_OLDER_SERVER 1
#define ADS_MGMT_NT_SERVER                2
#define ADS_MGMT_LOCAL_SERVER             3
#define ADS_MGMT_WIN9X_SERVER             4
#define ADS_MGMT_NETWARE5_OR_NEWER_SERVER 5
#define ADS_MGMT_LINUX_SERVER             6
#define ADS_MGMT_NT_SERVER_64_BIT         7
#define ADS_MGMT_LINUX_SERVER_64_BIT      8

/*
 * Constants for AdsMgGetLockOwner
 */
#define ADS_MGMT_NO_LOCK         1
#define ADS_MGMT_RECORD_LOCK     2
#define ADS_MGMT_FILE_LOCK       3

/*
 * Constants for MgGetInstallInfo
 */
#define ADS_REG_OWNER_LEN        36
#define ADS_REVISION_LEN         16
#define ADS_INST_DATE_LEN        16
#define ADS_OEM_CHAR_NAME_LEN    16
#define ADS_ANSI_CHAR_NAME_LEN   16
#define ADS_SERIAL_NUM_LEN       16

/*
 * Constants for MgGetOpenTables
 */
#define ADS_MGMT_MAX_PATH              260
#define ADS_MGMT_PROPRIETARY_LOCKING   1
#define ADS_MGMT_CDX_LOCKING           2
#define ADS_MGMT_NTX_LOCKING           3
#define ADS_MGMT_ADT_LOCKING           4
#define ADS_MGMT_COMIX_LOCKING         5

#define ADS_MAX_USER_NAME        50

#define ADS_MAX_ADDRESS_SIZE     30
#define ADS_MAX_MGMT_APPID_SIZE  70

// ADS DD defines 18.10.2002 13:55
#define ADS_DD_PROPERTY_NOT_AVAIL   0xFFFF
#define ADS_DD_MAX_PROPERTY_LEN     0xFFFE
#define ADS_DD_MAX_OBJECT_NAME_LEN  200

#define ADS_DD_UNKNOWN_OBJECT            0
#define ADS_DD_TABLE_OBJECT              1
#define ADS_DD_RELATION_OBJECT           2
#define ADS_DD_INDEX_FILE_OBJECT         3
#define ADS_DD_FIELD_OBJECT              4
#define ADS_DD_COLUMN_OBJECT             4
#define ADS_DD_INDEX_OBJECT              5
#define ADS_DD_VIEW_OBJECT               6
#define ADS_DD_VIEW_OR_TABLE_OBJECT      7  /* Used in AdsFindFirst/NextTable */
#define ADS_DD_USER_OBJECT               8
#define ADS_DD_USER_GROUP_OBJECT         9
#define ADS_DD_PROCEDURE_OBJECT          10
#define ADS_DD_DATABASE_OBJECT           11
#define ADS_DD_LINK_OBJECT               12
#define ADS_DD_TABLE_VIEW_OR_LINK_OBJECT 13  /* Used in v6.2 AdsFindFirst/NextTable */
#define ADS_DD_TRIGGER_OBJECT            14
#define ADS_DD_PUBLICATION_OBJECT        15
#define ADS_DD_ARTICLE_OBJECT            16  /* the things (tables) that get published */
#define ADS_DD_SUBSCRIPTION_OBJECT       17  /* indicates where a publication goes */
#define ADS_DD_FUNCTION_OBJECT           18  /* User defined function */
#define ADS_DD_PACKAGE_OBJECT            19  /* function and stored procedure packages */
#define ADS_DD_QUALIFIED_TRIGGER_OBJ     20  /* Used in AdsDDFindFirst/NextObject */


/* Common properties numbers < 100 */
#define ADS_DD_COMMENT           1
#define ADS_DD_VERSION           2
#define ADS_DD_USER_DEFINED_PROP 3
#define ADS_DD_OBJECT_NAME       4
#define ADS_DD_TRIGGERS_DISABLED 5
#define ADS_DD_OBJECT_ID         6
#define ADS_DD_OPTIONS           7


/* Database properties between 100 and 199 */
#define ADS_DD_DEFAULT_TABLE_PATH      		100
#define ADS_DD_ADMIN_PASSWORD          		101
#define ADS_DD_TEMP_TABLE_PATH         		102
#define ADS_DD_LOG_IN_REQUIRED         		103
#define ADS_DD_VERIFY_ACCESS_RIGHTS    		104
#define ADS_DD_ENCRYPT_TABLE_PASSWORD  		105
#define ADS_DD_ENCRYPT_NEW_TABLE       		106
#define ADS_DD_ENABLE_INTERNET         		107
#define ADS_DD_INTERNET_SECURITY_LEVEL 		108
#define ADS_DD_MAX_FAILED_ATTEMPTS     		109
#define ADS_DD_ALLOW_ADSSYS_NET_ACCESS 		110
#define ADS_DD_VERSION_MAJOR           		111  /* properties for customer dd version */
#define ADS_DD_VERSION_MINOR           		112
#define ADS_DD_LOGINS_DISABLED         		113
#define ADS_DD_LOGINS_DISABLED_ERRSTR  		114
#define ADS_DD_FTS_DELIMITERS          		115
#define ADS_DD_FTS_NOISE               		116
#define ADS_DD_FTS_DROP_CHARS          		117
#define ADS_DD_FTS_CONDITIONAL_CHARS   		118
#define ADS_DD_ENCRYPTED               		119
#define ADS_DD_ENCRYPT_INDEXES               120
#define ADS_DD_QUERY_LOG_TABLE               121
#define ADS_DD_ENCRYPT_COMMUNICATION         122
#define ADS_DD_DEFAULT_TABLE_RELATIVE_PATH   123
#define ADS_DD_TEMP_TABLE_RELATIVE_PATH      124
#define ADS_DD_DISABLE_DLL_CACHING           125

/* Table properties between 200 and 299 */
#define ADS_DD_TABLE_VALIDATION_EXPR   200
#define ADS_DD_TABLE_VALIDATION_MSG    201
#define ADS_DD_TABLE_PRIMARY_KEY       202
#define ADS_DD_TABLE_AUTO_CREATE       203
#define ADS_DD_TABLE_TYPE              204
#define ADS_DD_TABLE_PATH              205
#define ADS_DD_TABLE_FIELD_COUNT       206
#define ADS_DD_TABLE_RI_GRAPH          207
#define ADS_DD_TABLE_OBJ_ID            208
#define ADS_DD_TABLE_RI_XY             209
#define ADS_DD_TABLE_IS_RI_PARENT      210
#define ADS_DD_TABLE_RELATIVE_PATH     211
#define ADS_DD_TABLE_CHAR_TYPE         212
#define ADS_DD_TABLE_DEFAULT_INDEX     213
#define ADS_DD_TABLE_ENCRYPTION        214
#define ADS_DD_TABLE_MEMO_BLOCK_SIZE   215
#define ADS_DD_TABLE_PERMISSION_LEVEL  216
#define ADS_DD_TABLE_TRIGGER_TYPES     217
#define ADS_DD_TABLE_TRIGGER_OPTIONS   218
#define ADS_DD_TABLE_CACHING           219
#define ADS_DD_TABLE_TXN_FREE          220
#define ADS_DD_TABLE_VALIDATION_EXPR_W 221

/* Bit values for the ADS_DD_FIELD_OPTIONS property */
#define ADS_DD_FIELD_OPT_VFP_BINARY    0x00000001   /* field has NOCPTRANS option */
#define ADS_DD_FIELD_OPT_VFP_NULLABLE  0x00000002   /* field can be physicall set to NULL */

/* Field properties between 300 - 399 */
#define ADS_DD_FIELD_DEFAULT_VALUE     300
#define ADS_DD_FIELD_CAN_NULL          301
#define ADS_DD_FIELD_MIN_VALUE         302
#define ADS_DD_FIELD_MAX_VALUE         303
#define ADS_DD_FIELD_VALIDATION_MSG    304
#define ADS_DD_FIELD_DEFINITION        305
#define ADS_DD_FIELD_TYPE              306
#define ADS_DD_FIELD_LENGTH            307
#define ADS_DD_FIELD_DECIMAL           308
#define ADS_DD_FIELD_NUM               309
#define ADS_DD_FIELD_OPTIONS           310
#define ADS_DD_FIELD_DEFAULT_VALUE_W   311
#define ADS_DD_FIELD_MIN_VALUE_W       312
#define ADS_DD_FIELD_MAX_VALUE_W       313

/* Index tag properties between 400 - 499 */
#define ADS_DD_INDEX_FILE_NAME         400
#define ADS_DD_INDEX_EXPRESSION        401
#define ADS_DD_INDEX_CONDITION         402
#define ADS_DD_INDEX_OPTIONS           403
#define ADS_DD_INDEX_KEY_LENGTH        404
#define ADS_DD_INDEX_KEY_TYPE          405
#define ADS_DD_INDEX_FTS_MIN_LENGTH    406
#define ADS_DD_INDEX_FTS_DELIMITERS    407
#define ADS_DD_INDEX_FTS_NOISE         408
#define ADS_DD_INDEX_FTS_DROP_CHARS    409
#define ADS_DD_INDEX_FTS_CONDITIONAL_CHARS 410
#define ADS_DD_INDEX_COLLATION         411

/* RI properties between 500-599 */
#define ADS_DD_RI_PARENT_GRAPH         500
#define ADS_DD_RI_PRIMARY_TABLE        501
#define ADS_DD_RI_PRIMARY_INDEX        502
#define ADS_DD_RI_FOREIGN_TABLE        503
#define ADS_DD_RI_FOREIGN_INDEX        504
#define ADS_DD_RI_UPDATERULE           505
#define ADS_DD_RI_DELETERULE           506
#define ADS_DD_RI_NO_PKEY_ERROR        507
#define ADS_DD_RI_CASCADE_ERROR        508

/* User properties between 600-699 */
#define ADS_DD_USER_GROUP_NAME         600

/* View properties between 700-749 */
#define ADS_DD_VIEW_STMT               700
#define ADS_DD_VIEW_STMT_LEN           701
#define ADS_DD_VIEW_TRIGGER_TYPES      702
#define ADS_DD_VIEW_TRIGGER_OPTIONS    703
#define ADS_DD_VIEW_STMT_W             704

/* Stored procedure properties 800-899 */
#define ADS_DD_PROC_INPUT              800
#define ADS_DD_PROC_OUTPUT             801
#define ADS_DD_PROC_DLL_NAME           802
#define ADS_DD_PROC_DLL_FUNCTION_NAME  803
#define ADS_DD_PROC_INVOKE_OPTION      804
#define ADS_DD_PROC_SCRIPT             805
#define ADS_DD_PROC_SCRIPT_W           806

/* Index file properties 900-999 */
#define ADS_DD_INDEX_FILE_PATH          900
#define ADS_DD_INDEX_FILE_PAGESIZE      901
#define ADS_DD_INDEX_FILE_RELATIVE_PATH 902
#define ADS_DD_INDEX_FILE_TYPE          903

/*
 * Object rights properties 1001 - 1099 .  They can be used
 * with either user or user group objects.
 */
#define ADS_DD_TABLES_RIGHTS           1001
#define ADS_DD_VIEWS_RIGHTS            1002
#define ADS_DD_PROCS_RIGHTS            1003
#define ADS_DD_OBJECTS_RIGHTS          1004
#define ADS_DD_FREE_TABLES_RIGHTS      1005

/* User Properties 1101 - 1199 */
#define ADS_DD_USER_PASSWORD           1101
#define ADS_DD_USER_GROUP_MEMBERSHIP   1102
#define ADS_DD_USER_BAD_LOGINS         1103

/* User group Properties 1201 - 1299 */
/* None at this moment. */

/* Link properties 1301 - 1399 */
#define ADS_DD_LINK_PATH               1300
#define ADS_DD_LINK_OPTIONS            1301
#define ADS_DD_LINK_USERNAME           1302
#define ADS_DD_LINK_RELATIVE_PATH      1303

/* Trigger properties 1400 - 1499 */
#define ADS_DD_TRIG_TABLEID            1400
#define ADS_DD_TRIG_EVENT_TYPE         1401
#define ADS_DD_TRIG_TRIGGER_TYPE       1402
#define ADS_DD_TRIG_CONTAINER_TYPE     1403
#define ADS_DD_TRIG_CONTAINER          1404
#define ADS_DD_TRIG_FUNCTION_NAME      1405
#define ADS_DD_TRIG_PRIORITY           1406
#define ADS_DD_TRIG_OPTIONS            1407
#define ADS_DD_TRIG_TABLENAME          1408
#define ADS_DD_TRIG_CONTAINER_W        1409

/* Publication properties 1500 - 1599 */
#define ADS_DD_PUBLICATION_OPTIONS     1500

/* Publication article properties 1600 - 1699 */
#define ADS_DD_ARTICLE_FILTER             1600     // horizontal filter (optional)
#define ADS_DD_ARTICLE_ID_COLUMNS         1601     // columns that identify the target row
#define ADS_DD_ARTICLE_ID_COLUMN_NUMBERS  1602     // array of the field numbers
#define ADS_DD_ARTICLE_FILTER_SHORT       1603     // short version of the expression
#define ADS_DD_ARTICLE_INCLUDE_COLUMNS    1604     // Vertical filter (inclusion list)
#define ADS_DD_ARTICLE_EXCLUDE_COLUMNS    1605     // Vertical filter (exclusion list)
#define ADS_DD_ARTICLE_INC_COLUMN_NUMBERS 1606     // Retrieve column nums to replicate
#define ADS_DD_ARTICLE_INSERT_MERGE       1607     // Use SQL MERGE with INSERTs
#define ADS_DD_ARTICLE_UPDATE_MERGE       1608     // Use SQL MERGE with UPDATEs
#define ADS_DD_ARTICLE_FILTER_W           1609     // horizontal filter (optional)

/* Subscription article properties 1700 - 1799 */
#define ADS_DD_SUBSCR_PUBLICATION_NAME    1700    // Name of the publication (for reading)
#define ADS_DD_SUBSCR_TARGET              1701    // full path of target database
#define ADS_DD_SUBSCR_USERNAME            1702    // user name to use to connect to target
#define ADS_DD_SUBSCR_PASSWORD            1703    // password for connecting
#define ADS_DD_SUBSCR_FORWARD             1704    // boolean flag:  forward updates that came from a replication?
#define ADS_DD_SUBSCR_ENABLED             1705    // boolean flag:  Replication enabled on this subscription?
#define ADS_DD_SUBSCR_QUEUE_NAME          1706    // replication queue
#define ADS_DD_SUBSCR_OPTIONS             1707    // for future use
#define ADS_DD_SUBSCR_QUEUE_NAME_RELATIVE 1708    // replication queue relative to the DD
#define ADS_DD_SUBSCR_PAUSED              1709    // boolean flag:  Replication paused on this subscription?
#define ADS_DD_SUBSCR_COMM_TCP_IP         1710    // boolean flag:  TRUE for TCP/IP communications
#define ADS_DD_SUBSCR_COMM_TCP_IP_V6      1711    // boolean flag:  TRUE for TCP/IP V6 communications
#define ADS_DD_SUBSCR_COMM_UDP_IP         1712    // boolean flag:  TRUE for UDP/IP communications
#define ADS_DD_SUBSCR_COMM_IPX            1713    // boolean flag:  TRUE for IPX communications
#define ADS_DD_SUBSCR_OPTIONS_INTERNAL    1714    // internal ID to get ALL options incl COMM types


/* AdsMgKillUser90 Constants */
#define ADS_PROPERTY_UNSPECIFIED   0x0000
#define ADS_DONT_KILL_APPID        0x0001

#define ADS_DD_LEVEL_0  0
#define ADS_DD_LEVEL_1  1
#define ADS_DD_LEVEL_2  2

/* Referential Integrity (RI) update and delete rules */
#define ADS_DD_RI_CASCADE       1
#define ADS_DD_RI_RESTRICT      2
#define ADS_DD_RI_SETNULL       3
#define ADS_DD_RI_SETDEFAULT    4

/* Default Field Value Options */
#define ADS_DD_DFV_UNKNOWN         1
#define ADS_DD_DFV_NONE            2
#define ADS_DD_DFV_VALUES_STORED   3

/* Supported permissions in the data dictionary */
#define ADS_PERMISSION_NONE            0x00000000
#define ADS_PERMISSION_READ            0x00000001
#define ADS_PERMISSION_UPDATE          0x00000002
#define ADS_PERMISSION_EXECUTE         0x00000004
#define ADS_PERMISSION_INHERIT         0x00000008
#define ADS_PERMISSION_INSERT          0x00000010
#define ADS_PERMISSION_DELETE          0x00000020
#define ADS_PERMISSION_LINK_ACCESS     0x00000040
#define ADS_PERMISSION_CREATE          0x00000080
#define ADS_PERMISSION_ALTER           0x00000100
#define ADS_PERMISSION_DROP            0x00000200
#define ADS_PERMISSION_WITH_GRANT      0x80000000
#define ADS_PERMISSION_ALL_WITH_GRANT  0x8FFFFFFF
#define ADS_PERMISSION_ALL             0xFFFFFFFF

/*
 * special code that can be used as the input to specify
 * which special permission to retrieve.
 */
#define ADS_GET_PERMISSIONS_WITH_GRANT          0x8000FFFF
#define ADS_GET_PERMISSIONS_CREATE              0xFFFF0080
#define ADS_GET_PERMISSIONS_CREATE_WITH_GRANT   0x8FFFFF8F


/* Link DD options */
#define ADS_LINK_GLOBAL             0x00000001
#define ADS_LINK_AUTH_ACTIVE_USER   0x00000002
#define ADS_LINK_PATH_IS_STATIC     0x00000004

/* Trigger event types */
#define ADS_TRIGEVENT_INSERT             1
#define ADS_TRIGEVENT_UPDATE             2
#define ADS_TRIGEVENT_DELETE             3

/* Trigger types */
#define ADS_TRIGTYPE_BEFORE         0x00000001
#define ADS_TRIGTYPE_INSTEADOF      0x00000002
#define ADS_TRIGTYPE_AFTER          0x00000004
#define ADS_TRIGTYPE_CONFLICTON     0x00000008

/* Trigger container types */
#define ADS_TRIG_WIN32DLL           1
#define ADS_TRIG_COM                2
#define ADS_TRIG_SCRIPT             3

/*
 * Trigger options, if changed or adding more please inspect code
 * in RemoveTriggerFromDictionary
 */
#define ADS_TRIGOPTIONS_NO_VALUES             0x00000000
#define ADS_TRIGOPTIONS_WANT_VALUES           0x00000001
#define ADS_TRIGOPTIONS_WANT_MEMOS_AND_BLOBS  0x00000002
#define ADS_TRIGOPTIONS_DEFAULT               0x00000003  /* default is to include vals and memos */
#define ADS_TRIGOPTIONS_NO_TRANSACTION        0x00000004  /* don't use implicit transactions */

/*
 * Table permission verification levels.
 * level 1 is all columns searchable, even those without permission.
 * level 2 is default. Permission to the column is required to search or filter on a column.
 * level 3 is most restricted. Only static SQL cursor is allowed.
 */
#define ADS_DD_TABLE_PERMISSION_LEVEL_1   1
#define ADS_DD_TABLE_PERMISSION_LEVEL_2   2
#define ADS_DD_TABLE_PERMISSION_LEVEL_3   3

/* AdsDDRenameObject options */
#define ADS_KEEP_TABLE_FILE_NAME        0x00000001


/* AdsDDCreateArticle options */
#define ADS_IDENTIFY_BY_PRIMARY         0x00000001
#define ADS_IDENTIFY_BY_ALL             0x00000002


/* AdsDDCreateSubscription options */
#define ADS_SUBSCR_QUEUE_IS_STATIC      0x00000001
#define ADS_SUBSCR_AIS_TARGET           0x00000002   // use AIS to connect to target
#define ADS_SUBSCR_IGNORE_FAILED_REP    0x00000004   // Delete failed replication updates from the queue
#define ADS_SUBSCR_LOG_FAILED_REP_DATA  0x00000008   // if set, show data of failed replication updates in

/* AdsGetFieldLength10 options */
#define ADS_CODEUNIT_LENGTH             ADS_DEFAULT  // length in code units (characters)
#define ADS_BYTE_LENGTH                 0x00000001   // length in bytes
#define ADS_BYTE_LENGTH_IN_BUFFER       0x00000002   // physical length of data in bytes in the record buffer

/* Table caching property modes, used with AdsDDSetTableProperty etc. */
#define ADS_TABLE_CACHE_NONE               0x0000
#define ADS_TABLE_CACHE_READS              0x0001
#define ADS_TABLE_CACHE_WRITES             0x0002
																	  // the error log.
#endif  /* __ACE_INCLUDED__ */

//=============================================================================
//
//  Project: List & Label
//           Copyright (C) combit GmbH, All Rights Reserved
//
//  Authors: combit Software Team
//
//-----------------------------------------------------------------------------
//
//  List & Label Sample Application
//
//=============================================================================
// sqlitewrapper.h : 
// implementation of sqlite database wrapper template classes.
// Primary intention of these wrappers is to provide a modern c++11/14 style 
// interface to the sqlite database. 
// It is rather experimental and therefore neither feature complete nor considered stable 
// for production use yet.

#pragma once

#include "windows.h"
#include "strsafe.h"

#include <array>
#include <codecvt>
#include <crtdbg.h>
#include <functional>
#include <iostream>
#include <locale>
#include <memory>
#include <regex>
#include <type_traits>
#include <map>

#include "sqlite3.h"
#include "sqlitewrapperhandle.h"

namespace cmbtSQL
{
	// some Helpers
	struct SQLiteHelp
	{
		//----------------------------------------------------------------------------------------
		// D:   Sicherstellen, dass im Debug Mode die Übergabe von std::string/std::wstring an xsprintf einen Compilerfehler erzeugt. 
		// US:  Ensure compile time assertion when passing std::string or std::wstring to xsprintf
		template <typename ... ARGS> _cmbt_constexpr_ bool xsprintf_arg_check() const
		{
			return true;
		}
		template <typename ... ARGS> _cmbt_constexpr_ bool xsprintf_arg_check(const std::wstring& /*value*/) const
		{
			return static_assert(false, "call to xsprintf with std::wstring parameter");
			return false;
		}
		template <typename ... ARGS> _cmbt_constexpr_ bool xsprintf_arg_check(const std::string& /*value*/) const
		{
			static_assert(false, "call to xsprintf with std::string parameter");
			return false;
		}
		template <typename T> _cmbt_constexpr_ bool xsprintf_arg_check(const T& /*value*/) const { return true; }
		template <typename T, typename ... ARGS> _cmbt_constexpr_ bool xsprintf_arg_check(const T& value, ARGS&& ... args) const
		{
			return xsprintf_arg_check(value) && xsprintf_arg_check(std::forward<ARGS>(args)...);
		}
		//----------------------------------------------------------------------------------------
		// D:   Einfaches sprintf template mit einer initialen Puffergröße von 0xFFFF Zeichen 
		// US:  simple sprintf template witch an initial buffer of 0xFFFF chars
		template <typename ... ARGS> static std::string xsprintf(const char* fmt, ARGS&& ... args)
		{
			CMBTVERIFY(SQLiteHelp().xsprintf_arg_check(std::forward<ARGS>(args)...)); // compile time assert
			size_t uBuffSize = 0xFFFF;
			std::vector<char> buffer;
			buffer.assign(uBuffSize, 0);
			try
			{
				while(_snprintf_s(&buffer[0], uBuffSize, _TRUNCATE, fmt, std::forward<ARGS>(args)...) == -1)
				{
					uBuffSize *= 2;
					buffer.assign(uBuffSize, 0);
				}
			}
			catch(std::bad_alloc&){ CMBTVERIFY(false); }
			return std::string(&buffer[0]);
		}
		template <typename ... ARGS> static std::wstring xsprintf(const wchar_t* fmt, ARGS&& ... args)
		{
			CMBTVERIFY(SQLiteHelp().xsprintf_arg_check(std::forward<ARGS>(args)...)); // compile time assert
			size_t uBuffSize = 0xFFFF;
			std::vector<wchar_t> buffer;
			buffer.assign(uBuffSize, 0);
			try
			{
				while(_snwprintf_s(&buffer[0], uBuffSize, _TRUNCATE, fmt, std::forward<ARGS>(args)...) == -1)
				{
					uBuffSize *= 2;
					buffer.assign(uBuffSize, 0);
				}
			}
			catch(std::bad_alloc&){ CMBTVERIFY(false); }
			return std::wstring(&buffer[0]);
		}
		//----------------------------------------------------------------------------------------
		// D:   Konvertierungen zwischen string / wstring 
		// US:  string / wstring conversions
		using stringConvert = std::wstring_convert <std::codecvt<wchar_t, char, std::mbstate_t>>;
		static std::wstring conv2wstr(const std::string& s) { return stringConvert().from_bytes(s); }
		static std::wstring conv2wstr(const std::wstring& s) { return s; }
		static std::string conv2str(const std::wstring& s) { return stringConvert().to_bytes(s); }
		static std::string conv2str(const std::string& s) { return s; }
		//----------------------------------------------------------------------------------------
		// D/US:   string / wstring split
		template <typename StringType, typename CharType> static std::vector<StringType> strsplit(const StringType& s, const CharType delimiter, bool bKeepEmptyInputString = false)
		{
			size_t start = 0;
			size_t end = s.find_first_of(delimiter);
			std::vector<StringType> output;
			if (!s.empty() || bKeepEmptyInputString)
			{
				while (end <= StringType::npos)
				{
					output.emplace_back(s.substr(start, end - start));
					if (end == StringType::npos)
						break;
					start = end + 1;
					end = s.find_first_of(delimiter, start);
				}
			}
			return output;
		}
		//----------------------------------------------------------------------------------------
		// D:   Prüfen ob einzelne Bits gesetzt sind 
		// US:  Check for enabled bits within a value
		static bool check_enabled(const unsigned& value, const unsigned& bitmask2check, bool bCheckAll)
		{
			return bCheckAll ? ((value & bitmask2check) == bitmask2check) : ((value & bitmask2check) != 0);
		}
	};
	//----------------------------------------------------------------------------------------
	// Type and Globals
	//
	//----------------------------------------------------------------------------------------
	// D/US:   SQLite interne Datentypen  / SQLite internal datatypes
	enum class Type
	{
		Integer = SQLITE_INTEGER,
		Float   = SQLITE_FLOAT,
		Blob    = SQLITE_BLOB,
		Null    = SQLITE_NULL,
		Text    = SQLITE_TEXT
	};
	//----------------------------------------------------------------------------------------
	std::string GetTypeName(const Type& t)
	{
		std::string ret = "unknown type";
		switch (t)
		{
		case Type::Integer	: ret = "Integer"	; break;
		case Type::Float	: ret = "Float"		; break;
		case Type::Blob		: ret = "Blob"		; break;
		case Type::Null		: ret = "Null"		; break;
		case Type::Text		: ret = "Text"		; break;
		default:
			CMBTVERIFY(false);
			break;
		}
		return ret;
	}
	//----------------------------------------------------------------------------------------
	// D : Einfacher VARIANT ähnlicher Typ zur Speicherung und Konvertierung von Daten (SQLite Datentypen)
	// US: A simple VARIANT like type to store and convert data (of sqlite internal datatypes)
	class SQLiteVariant
	{
	public:
		//----------------------------------------------------------------------------------------
		void SetText(const std::string& value) _cmbt_noexcept_
		{
			SetBlob((BYTE*)value.c_str(), (value.size() + 1) * sizeof(char));
			_type = Type::Text;
			_bWide = false;
		}
		//----------------------------------------------------------------------------------------
		void SetText(const std::wstring& value) _cmbt_noexcept_
		{
			SetBlob((BYTE*)value.c_str(), (value.size() + 1) * sizeof(wchar_t));
			_type = Type::Text;
			_bWide = true;
		}
		//----------------------------------------------------------------------------------------
		template <typename T> void SetFloat(const T& value) _cmbt_noexcept_
		{
			static_assert(std::is_floating_point<T>::value, "SetFloat requires floating point value");
			double v(value);
			SetBlob((BYTE*)&v, sizeof(double));
			_type = Type::Float;
			_bWide = false;
		}
		//----------------------------------------------------------------------------------------
		template <typename T> void SetInt(const T& value) _cmbt_noexcept_
		{
			static_assert(std::is_integral<T>::value, "SetInt requires int value");
			int v(value);
			SetBlob((BYTE*)&v, sizeof(int));
			_type = Type::Integer;
			_bWide = false;
		}
		//----------------------------------------------------------------------------------------
		void SetBlob(BYTE* pBuff, int count) _cmbt_noexcept_
		{
			_bWide = false;
			_type = Type::Blob;
			_buffer.assign(pBuff, pBuff+count);
			_bWide = false;
		}
		//----------------------------------------------------------------------------------------
		void SetNull() _cmbt_noexcept_
		{
			_bWide = false;
			_type = Type::Null;
			_buffer.clear();
			_bWide = false;
		}
		//----------------------------------------------------------------------------------------
	public:
		std::string asText() const _cmbt_noexcept_
		{
			switch(_type)
			{
			case Type::Text:
				{
					if(!_bWide)
					{
						return std::string(reinterpret_cast<const char*>(&_buffer[0]));
					}
					else
					{
						auto tmp = std::wstring(reinterpret_cast<const wchar_t*>(&_buffer[0]));
						return SQLiteHelp::conv2str(tmp);
					}
				}
				break;
			case Type::Integer:
				return SQLiteHelp::xsprintf("%d", asInt());
				break;
			case Type::Float:
				return SQLiteHelp::xsprintf("%f", asFloat());
				break;
			case Type::Null:
				return std::string("<NULL>");
				break;
			case Type::Blob:
				return std::string("<BLOB>");
				break;
			default:
				break;
			}
			CMBTVERIFY(0);
			return std::string();
		}
		//----------------------------------------------------------------------------------------
		std::wstring asWideText() const _cmbt_noexcept_
		{
			switch(_type)
			{
			case Type::Text:
				{
					if(_bWide)
					{
						return std::wstring(reinterpret_cast<const wchar_t*>(&_buffer[0]));
					}
					else
					{
						auto tmp = std::string(reinterpret_cast<const char*>(&_buffer[0]));
						return SQLiteHelp::conv2wstr(tmp);
					}
				}
				break;
			case Type::Integer:
				return SQLiteHelp::xsprintf(L"%d", asInt());
				break;
			case Type::Float:
				return SQLiteHelp::xsprintf(L"%f", asFloat());
				break;
			case Type::Null:
				return std::wstring(L"<NULL>");
				break;
			case Type::Blob:
				return std::wstring(L"<BLOB>");
				break;
			default:
				break;
			}
			CMBTVERIFY(0);
			return std::wstring();
		}
		//----------------------------------------------------------------------------------------
		double asFloat() const _cmbt_noexcept_
		{ 
			switch(_type)
			{
			case Type::Text:
				return atof(asText().c_str());
				break;
			case Type::Integer:
				return double(asInt());
				break;
			case Type::Float:
				return *reinterpret_cast<const double*>(&_buffer[0]);
				break;
			default:
				break;
			}
			return double(0.0);
		}
		//----------------------------------------------------------------------------------------
		int asInt() const _cmbt_noexcept_
		{ 
			switch(_type)
			{
			case Type::Text:
				return atoi(asText().c_str());
				break;
			case Type::Integer:
				return *reinterpret_cast<const int*>(&_buffer[0]);
				break;
			case Type::Float:
				return int(asFloat());
				break;
			default:
				break;
			}
			return 0;
		}
		//----------------------------------------------------------------------------------------
		std::vector<BYTE> asBlob() const _cmbt_noexcept_ { return _buffer; }
		//----------------------------------------------------------------------------------------
		bool isNull() const _cmbt_noexcept_ { return _type == Type::Null; }
		//----------------------------------------------------------------------------------------
		bool isWide() const _cmbt_noexcept_ { return _bWide; }
		//----------------------------------------------------------------------------------------
		Type GetType() const _cmbt_noexcept_ { return _type; }
		//----------------------------------------------------------------------------------------
	private:
		bool                _bWide = false;
		Type				_type  = Type::Null;
		std::vector<BYTE>	_buffer;
	};
	//----------------------------------------------------------------------------------------
	//////////////////////////////////////////////////////////////////////////////////////////
	// D : SQLite Exceptions - Entweder freier Text oder an den Fehlercode der Connection gebunden
	// US: SQLite exeption - either free text or related to sqlite connection errorcode
	struct SQLiteException
	{
		int _result = 0;
		std::string _message;
		explicit SQLiteException(sqlite3* const connection) : _result(sqlite3_extended_errcode(connection)), _message(sqlite3_errmsg(connection)) {}
		explicit SQLiteException(const std::string& msg) : _result(SQLITE_OK), _message(msg) {}
	};
	//----------------------------------------------------------------------------------------
	// D : Das Connection Objekt. Kapselt die original sqlite3* Datenbankconnection. Automatisches Mapping für char und wchar_t basierende Aufrufe.
	// US: The connection object encapsulating the original sqlite3* database connection. Performs propper mapping for char* and wchar_t based calls. 
	class SQLiteConnection
	{
	private:
		struct SQLConnectionHandleTraits : SQLiteHandlePtrTraits<sqlite3*>
		{
			static void Close(Type value) _cmbt_noexcept_
			{
				CMBTVERIFY_(SQLITE_OK, sqlite3_close(value));
			}
		};
		using SQLiteConnectionHandle = SQLiteHandle<SQLConnectionHandleTraits>;
		SQLiteConnectionHandle _handle;
	private:
		template <typename F, typename T> void InternalOpen(F open, const T* filename, bool bCreateIfNotExists)
		{
			if(bCreateIfNotExists || (_waccess(SQLiteHelp::conv2wstr(filename).c_str(), 0) == 0))
			{
				SQLiteConnection temp;
				if(SQLITE_OK != open(filename, temp._handle.Set()))
					temp.ThrowLastError();
				swap(_handle, temp._handle);
			}
			else
				throw(SQLiteException("Database not found..."));
		}
	public:
		//----------------------------------------------------------------------------------------
		SQLiteConnection() _cmbt_noexcept_ = default;
		//----------------------------------------------------------------------------------------
		template <typename C> explicit SQLiteConnection(const C* filename, bool bCreateIfNotExists)
		{
			Open(filename, bCreateIfNotExists);
		}
		//----------------------------------------------------------------------------------------
		static SQLiteConnection Memory()
		{
			return SQLiteConnection(":memory:", true);
		}
		//----------------------------------------------------------------------------------------
		static SQLiteConnection WideMemory()
		{
			return SQLiteConnection(L":memory:", true);
		}
		//----------------------------------------------------------------------------------------
		explicit operator bool() const _cmbt_noexcept_
		{
			return static_cast<bool>(_handle);
		}
		//----------------------------------------------------------------------------------------
		sqlite3 * GetAbi() const _cmbt_noexcept_
		{
			return _handle.Get();
		}
		//----------------------------------------------------------------------------------------
		__declspec(noreturn) void ThrowLastError() const
		{
			throw SQLiteException(GetAbi());
		}
		//----------------------------------------------------------------------------------------
		void Open(const char* filename, bool bCreateIfNotExists)
		{
			InternalOpen(sqlite3_open, filename, bCreateIfNotExists);
		}
		//----------------------------------------------------------------------------------------
		void Open(const wchar_t* filename, bool bCreateIfNotExists)
		{
			InternalOpen(sqlite3_open16, filename, bCreateIfNotExists);
		}
		//----------------------------------------------------------------------------------------
	};
	//----------------------------------------------------------------------------------------
	// D : Das Backup Objekt. Kapselt die original sqlite3_backup* Backup API. 
	// US: The backup object encapsulating the original sqlite3_backup* backup API. 
	class SQLiteBackup
	{
		struct SQLiteBackupHandleTraits : SQLiteHandlePtrTraits<sqlite3_backup*>
		{
			static void Close(Type value) _cmbt_noexcept_
			{
				CMBTVERIFY_(SQLITE_OK, sqlite3_backup_finish(value));
			}
		};
		using BackupHandle = SQLiteHandle<SQLiteBackupHandleTraits>;
		BackupHandle _handle;
		const SQLiteConnection* _destination;
	public:
		//----------------------------------------------------------------------------------------
		template <typename T> static void SaveToDisk(const SQLiteConnection& source, const T* destinationName)
		{
			SQLiteConnection dest(destinationName, true);
			SQLiteBackup b(source, dest);
			b.Step();
		}
		//----------------------------------------------------------------------------------------
		SQLiteBackup(const SQLiteConnection& source,
					 const SQLiteConnection& destination,
					 const char* sourceName = "main",
					 const char* destinationName = "main") :
			_handle(sqlite3_backup_init(destination.GetAbi(), destinationName, source.GetAbi(), sourceName)),
			_destination(&destination)
		{
			if(!_handle)
				destination.ThrowLastError();
		}
		//----------------------------------------------------------------------------------------
		bool Step(const int pages = -1)
		{
			const int result = sqlite3_backup_step(GetAbi(), pages);
			if(result == SQLITE_OK) 
				return true;
			if(result == SQLITE_DONE)
				return false;
			_handle.Reset();
			_destination->ThrowLastError();
		}
		//----------------------------------------------------------------------------------------
		sqlite3_backup* GetAbi() const _cmbt_noexcept_
		{
			return _handle.Get();
		}
		//----------------------------------------------------------------------------------------
	};
	//----------------------------------------------------------------------------------------
	// D : Definition der Reader Methoden. 
	// US: Defining the reader methods. 
	template <typename T> struct Reader  // CRTP
	{
		//----------------------------------------------------------------------------------------
		int GetInt(const int column = 0) const _cmbt_noexcept_
		{
			return sqlite3_column_int(static_cast<const T*>(this)->GetAbi(), column);
		}
		//----------------------------------------------------------------------------------------
		double GetDouble(const int column = 0) const _cmbt_noexcept_
		{
			return sqlite3_column_double(static_cast<const T*>(this)->GetAbi(), column);
		}
		//----------------------------------------------------------------------------------------
		const void* GetBlob(const int column = 0) const _cmbt_noexcept_
		{
			return sqlite3_column_blob(static_cast<const T*>(this)->GetAbi(), column);
		}
		//----------------------------------------------------------------------------------------
		const char* GetString(const int column = 0) const _cmbt_noexcept_
		{
			return reinterpret_cast<const char*>(sqlite3_column_text(static_cast<const T*>(this)->GetAbi(), column));
		}
		//----------------------------------------------------------------------------------------
		const wchar_t* GetWideString(const int column = 0) const _cmbt_noexcept_
		{
			return reinterpret_cast<const wchar_t*>(sqlite3_column_text16(static_cast<const T*>(this)->GetAbi(), column));
		}
		//----------------------------------------------------------------------------------------
		int GetStringLength(const int column = 0) const _cmbt_noexcept_
		{
			return GetColumnBytes(column);
		}
		//----------------------------------------------------------------------------------------
		int GetWideStringLength(const int column = 0) const _cmbt_noexcept_
		{
			return GetColumnBytes16(column) / sizeof (wchar_t);
		}
		//----------------------------------------------------------------------------------------
		int GetColumnBytes(const int column = 0) const _cmbt_noexcept_
		{
			return sqlite3_column_bytes(static_cast<const T*>(this)->GetAbi(), column);
		}
		//----------------------------------------------------------------------------------------
		int GetColumnBytes16(const int column = 0) const _cmbt_noexcept_
		{
			return sqlite3_column_bytes16(static_cast<const T*>(this)->GetAbi(), column) / sizeof(wchar_t);
		}
		//----------------------------------------------------------------------------------------
		const char* GetColumnName(const int column = 0) const _cmbt_noexcept_
		{
			return reinterpret_cast<const char*>(sqlite3_column_name(static_cast<const T*>(this)->GetAbi(), column));
		}
		//----------------------------------------------------------------------------------------
		const wchar_t* GetColumnName16(const int column = 0) const _cmbt_noexcept_
		{
			return reinterpret_cast<const wchar_t*>(sqlite3_column_name16(static_cast<const T*>(this)->GetAbi(), column));
		}
		//----------------------------------------------------------------------------------------
		int GetColumnCount() const _cmbt_noexcept_
		{
			return sqlite3_column_count(static_cast<const T*>(this)->GetAbi());
		}
		//----------------------------------------------------------------------------------------
		Type GetType(const int column = 0) const _cmbt_noexcept_
		{
			return static_cast<Type>(sqlite3_column_type(static_cast<const T*>(this)->GetAbi(), column));
		}
		//----------------------------------------------------------------------------------------
	};
	//----------------------------------------------------------------------------------------
	// D : Das Statement Objekt. Kapselt das original sqlite3_stmt* Objekt.
	//	   Unterstützt die Reader<SQLiteStatement> Methoden und weitere char und wchar_t basierende Aufrufe.
	//	   Ermöglicht über die interne flexible Kombination der jeweiligen Aufrufe extrem kompakte Abfragen
	// US: The backup object encapsulating the original sqlite3_stmt* object. 
	//	   Supports the Reader<SQLiteStatement> methods and provides further more char und wchar_t based calls.
	//     By internal, flexible combination of methods, this provides a means of creating extremly compact queries
	// Samples:
	//	   SQLiteStatement::Execute(conn, "insert into table Test values (?1 , ?2);", val1, val2); // ad hoc insertion
	class SQLiteStatement : public Reader<SQLiteStatement>
	{
	private:
		struct SQLStatementHandleTraits : SQLiteHandlePtrTraits<sqlite3_stmt*>
		{
			static void Close(Type value) _cmbt_noexcept_
			{
				CMBTVERIFY_(SQLITE_OK, sqlite3_finalize(value));
			}
		};
		using SQLiteStatementHandle = SQLiteHandle<SQLStatementHandleTraits>;
		SQLiteStatementHandle _handle;
	private:
		//----------------------------------------------------------------------------------------
		template <typename F, typename T, typename ... Parms> void InternalPrepare(const SQLiteConnection& connection, F prepare, const T* text, Parms&& ... parms)
		{
			CMBTVERIFY(connection);
			if (SQLITE_OK != prepare(connection.GetAbi(), text, -1, _handle.Set(), nullptr))
				connection.ThrowLastError();
			BindAll(std::forward<Parms>(parms)...);
		}
		//----------------------------------------------------------------------------------------
		void InternalBind(int) const {}
		//----------------------------------------------------------------------------------------
		template <typename First, typename ... Rest> void InternalBind(const int index, First && first, Rest&& ... rest) const
		{
			Bind(index, std::forward<First>(first));
			InternalBind(index + 1, std::forward<Rest>(rest)...);
		}
		//----------------------------------------------------------------------------------------
	public:
		//----------------------------------------------------------------------------------------
		SQLiteStatement() _cmbt_noexcept_ = default;
		//----------------------------------------------------------------------------------------
		template <typename T, typename ... Parms>
		SQLiteStatement(const SQLiteConnection& connection, const T& text, Parms&& ... parms) :
			SQLiteStatement(connection, text.c_str(), std::forward<Parms>(parms)...) {}
		//----------------------------------------------------------------------------------------
		template <typename T, typename ... Parms>
		SQLiteStatement(const SQLiteConnection& connection, const T* text, Parms&& ... parms) : SQLiteStatement()
		{
			Prepare(connection, text, std::forward<Parms>(parms)...);
		}
		//----------------------------------------------------------------------------------------
		explicit operator bool() const _cmbt_noexcept_
		{
			return static_cast<bool>(_handle);
		}
		//----------------------------------------------------------------------------------------
		sqlite3_stmt * GetAbi() const _cmbt_noexcept_
		{
			return _handle.Get();
		}
		//----------------------------------------------------------------------------------------
		__declspec(noreturn) void ThrowLastError() const
		{
			throw SQLiteException(sqlite3_db_handle(GetAbi()));
		}
		//----------------------------------------------------------------------------------------
		template <typename ... Parms>
		void Prepare(const SQLiteConnection& connection, const char* text, Parms&& ... parms)
		{
			InternalPrepare(connection, sqlite3_prepare_v2, text, std::forward<Parms>(parms)...);
		}
		//----------------------------------------------------------------------------------------
		template <typename ... Parms>
		void Prepare(const SQLiteConnection& connection, const wchar_t* text, Parms&& ... parms)
		{
			InternalPrepare(connection, sqlite3_prepare16_v2, text, std::forward<Parms>(parms)...);
		}
		//----------------------------------------------------------------------------------------
		bool Step() const
		{
			int result = sqlite3_step(GetAbi());
			if (result == SQLITE_ROW)
				return true;
			if (result == SQLITE_DONE)
				return false;
			ThrowLastError();
		}
		//----------------------------------------------------------------------------------------
		void Execute() const
		{
			CMBTVERIFY(!Step());
		}
		//----------------------------------------------------------------------------------------
		template <typename T, typename ... Parms>
		static void Execute(const SQLiteConnection& connection, const T* text, Parms&& ... parms)
		{
			SQLiteStatement stmt(connection, text, std::forward<Parms>(parms)...);
			stmt.Execute();
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, const int value) const _cmbt_noexcept_
		{
			if (SQLITE_OK != sqlite3_bind_int(GetAbi(), index, value))
			{
				ThrowLastError();
			}
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, const double value) const _cmbt_noexcept_
		{
			if (SQLITE_OK != sqlite3_bind_double(GetAbi(), index, value))
			{
				ThrowLastError();
			}
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, const std::string& value) const _cmbt_noexcept_
		{
			if (SQLITE_OK != sqlite3_bind_text(GetAbi(), index, value.c_str(), value.size(), SQLITE_STATIC))
			{
				ThrowLastError();
			}
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, const std::wstring& value) const _cmbt_noexcept_
		{
			if (SQLITE_OK != sqlite3_bind_text16(GetAbi(), index, value.c_str(), value.size() * sizeof(wchar_t), SQLITE_STATIC))
			{
				ThrowLastError();
			}
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, std::string&& value) const _cmbt_noexcept_
		{
			if (SQLITE_OK != sqlite3_bind_text(GetAbi(), index, value.c_str(), value.size(), SQLITE_TRANSIENT))
			{
				ThrowLastError();
			}
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, std::wstring&& value) const _cmbt_noexcept_
		{
			if (SQLITE_OK != sqlite3_bind_text16(GetAbi(), index, value.c_str(), value.size() * sizeof(wchar_t), SQLITE_TRANSIENT))
			{
				ThrowLastError();
			}
		}
	    //----------------------------------------------------------------------------------------
		void Bind(const int index, std::vector<BYTE>& value) const _cmbt_noexcept_
		{
		  if (SQLITE_OK != sqlite3_bind_blob(GetAbi(), index, (void*)&value[0], value.size() * sizeof(BYTE), SQLITE_STATIC))
		  {
		    ThrowLastError();
		  }
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, std::vector<BYTE>&& value) const _cmbt_noexcept_
		{
		  if (SQLITE_OK != sqlite3_bind_blob(GetAbi(), index, (void*)&value[0], value.size() * sizeof(BYTE), SQLITE_TRANSIENT))
		  {
		    ThrowLastError();
		  }
		}
		//----------------------------------------------------------------------------------------
		void Bind(const int index, decltype(nullptr)) const _cmbt_noexcept_
		{
			if (SQLITE_OK != sqlite3_bind_null(GetAbi(), index))
			{
				ThrowLastError();
			}
		}
		//----------------------------------------------------------------------------------------
		template <typename ... Values> void BindAll(Values&& ... values) const
		{
			InternalBind(1, std::forward<Values>(values)...);
		}
		//----------------------------------------------------------------------------------------
		template <typename ... Values> void Reset(Values&& ... values) const
		{
			if (SQLITE_OK != sqlite3_reset(GetAbi()))
			{
				ThrowLastError();
			}
			BindAll(std::forward<Values>(values)...);
		}
		//----------------------------------------------------------------------------------------
	};
	
	//----------------------------------------------------------------------------------------
	// D : Das Row Objekt. Kapselt ein bestehendes SQLiteStatement Objekt um mittels SQLiteRowIterator 
	//	   ein einfaches C++11/14 Interface zur Verfügung zu stellen.
	// US: The row object. Encapsulating an existing instance of a SQLiteStatement object to provide
	//	   a simple C++11/14 style interface in conjunction with SQLiteRowIterator
	// Samples:
	//       for(row : stmt)
	//        for(int i= 0; i< row.GetColumnCount(); ++i)
	//		   cout << row.GetString(i) << endl;
	//	     int value = SQLiteRow(SQLiteStatement(conn, "select count(*) from Table"), 1).GetInt();
	class SQLiteRow : public Reader<SQLiteRow>
	{
		sqlite3_stmt * _statement = nullptr;
	public:
		//----------------------------------------------------------------------------------------
		sqlite3_stmt * GetAbi() const _cmbt_noexcept_
		{
			return _statement;
		}
		//----------------------------------------------------------------------------------------
		SQLiteRow(sqlite3_stmt* statement) _cmbt_noexcept_ : _statement(statement) {}
		//----------------------------------------------------------------------------------------
		SQLiteRow(const SQLiteStatement& statement, int stepsToGo) : _statement(statement.GetAbi())
		{
			// you better call this ctor only if you know what you are doing
			for(int i = 0; i < stepsToGo; ++i)
				statement.Step();
		}
	};

	//----------------------------------------------------------------------------------------
	// D : Iterator für das Row Objekt.
	// US: Iterator for the row object. 
	class SQLiteRowIterator
	{
		const SQLiteStatement * _statement = nullptr;
	public:
		//----------------------------------------------------------------------------------------
		SQLiteRowIterator() _cmbt_noexcept_ = default;
		//----------------------------------------------------------------------------------------
		SQLiteRowIterator(const SQLiteStatement& statement) _cmbt_noexcept_
		{
			if (statement.Step())
			{
				_statement = &statement;
			}
		}
		//----------------------------------------------------------------------------------------
		SQLiteRowIterator& operator++() _cmbt_noexcept_
		{
			if (!_statement->Step())
			{
				_statement = nullptr;
			}
			return *this;
		}
		//----------------------------------------------------------------------------------------
		bool operator!=(const SQLiteRowIterator& rhs) const _cmbt_noexcept_
		{
			return _statement != rhs._statement;
		}
		//----------------------------------------------------------------------------------------
		SQLiteRow operator*() const _cmbt_noexcept_
		{
			return SQLiteRow(_statement->GetAbi());
		}
		//----------------------------------------------------------------------------------------
	};
	//----------------------------------------------------------------------------------------
	inline SQLiteRowIterator begin(const SQLiteStatement& statement) _cmbt_noexcept_
	{
		return SQLiteRowIterator(statement);
	}
	//----------------------------------------------------------------------------------------
	inline SQLiteRowIterator end(const SQLiteStatement& /*statement*/) _cmbt_noexcept_
	{
		return SQLiteRowIterator();
	}

	//----------------------------------------------------------------------------------------
	// D : db_record Objekt kapselt automatisch einen ganzen Datensatz aus einer SQLiteRow 
	//	   und ordnet den Spaltennamen die SQLiteVariant Werte zu.
	//     Je nach verwendeten string typen -> db_recorda, dbrecordw, db_recordwa, dbrecordww
	// US: db_record object encapsulates a complete record from a SQLiteRow and maps 
	//	   in between column names and retrieved SQLiteVariants
	//     dependent on desired string flavours -> db_recorda, db_recordw, db_recordwa, db_recordww
	// Samples:
	//	   SQLiteStatement stmt(conn, "select * from Table;");
	//	   for(row : stmt)
	//	   {
	//       db_recorda rec(row);
	//		 cout << rec.getValue("Key")->asText() << endl;
	//     }

	template <typename KSType = std::string, typename VSType = std::string, typename VType = cmbtSQL::SQLiteVariant> class db_record
	{
		//----------------------------------------------------------------------------------------
		std::string GetColumnName(const cmbtSQL::SQLiteRow& row, int column, const std::string*)
		{
			return row.GetColumnName(column);
		}
		//----------------------------------------------------------------------------------------
		std::wstring GetColumnName(const cmbtSQL::SQLiteRow& row, int column, const std::wstring*)
		{
			return row.GetColumnName16(column);
		}
		//----------------------------------------------------------------------------------------
		KSType GetColumnName(const cmbtSQL::SQLiteRow& row, int column)
		{
			KSType* p = nullptr;
			return GetColumnName(row, column, p);
		}
		//----------------------------------------------------------------------------------------
		std::string GetString(const cmbtSQL::SQLiteRow& row, int column, const std::string*)
		{
			return row.GetString(column);
		}
		//----------------------------------------------------------------------------------------
		std::wstring GetString(const cmbtSQL::SQLiteRow& row, int column, const std::wstring*)
		{
			return row.GetWideString(column);
		}
		//----------------------------------------------------------------------------------------
		VSType GetString(const cmbtSQL::SQLiteRow& row, int column)
		{
			VSType* p = nullptr;
			return GetString(row, column, p);
		}
		//----------------------------------------------------------------------------------------
		VType GetColumnValue(const cmbtSQL::SQLiteRow& row, int column)
		{
			VType var;
			cmbtSQL::Type t = row.GetType(column);
			switch(t)
			{
			case cmbtSQL::Type::Blob:
				var.SetBlob((BYTE*)row.GetBlob(column), row.GetColumnBytes(column));
				break;
			case cmbtSQL::Type::Float:
				var.SetFloat(row.GetDouble(column));
				break;
			case cmbtSQL::Type::Integer:
				var.SetInt(row.GetInt(column));
				break;
			case cmbtSQL::Type::Null:
				var.SetNull();
				break;
			case cmbtSQL::Type::Text:
				var.SetText(GetString(row, column));
				break;
			default:
				CMBTVERIFY(0);
				break;
			}
			return var;
		}
		//----------------------------------------------------------------------------------------
	public:
		//----------------------------------------------------------------------------------------
		db_record() : _columns([](const KSType& lhs, const KSType& rhs){ return key_compare_less(lhs, rhs); }) {};
		//----------------------------------------------------------------------------------------
		db_record(const cmbtSQL::SQLiteRow& row) : _columns([](const KSType& lhs, const KSType& rhs){ return key_compare_less(lhs, rhs); })
		{
			int count = row.GetColumnCount();
			for(int i = 0; i < count; ++i)
				addOrReplace(GetColumnName(row, i), GetColumnValue(row, i));
		}
		//----------------------------------------------------------------------------------------
		template <typename ColumnsContainer> db_record(const cmbtSQL::SQLiteRow& row, const ColumnsContainer& columnNames) : _columns([](const KSType& lhs, const KSType& rhs){ return key_compare_less(lhs, rhs); })
		{
			int count = row.GetColumnCount();
			for(int i = 0; i < count; ++i)
			{
				auto key = GetColumnName(row, i);
				auto it = std::find_if(columnNames.begin(), columnNames.end(), std::function<bool(const KSType& s1, const KSType& s2)>([](const KSType& s1, const KSType& s2) { return key_compare_equal(s1,s2)}));
				if(it != columnNames.end())
					addOrReplace(GetColumnName(row, i), GetColumnValue(row, i));
			}
		}
		//----------------------------------------------------------------------------------------
		db_record& addOrReplace() { return *this; }
		template <typename T> db_record& addOrReplace(const T&) { return *this; }
		template<typename ... ARGS> db_record& addOrReplace(const KSType& key, const VType& value, ARGS&& ... args)
		{
			_columns[key] = value;
			return addOrReplace(std::forward<ARGS>(args)...);
		}
		//----------------------------------------------------------------------------------------
		VType* getValue(const KSType& key)
		{
			auto it = _columns.find(key);
			return it != _columns.end() ? &it->second : nullptr;
		}
		//----------------------------------------------------------------------------------------
		bool validateKeys() { return true; }
		template <typename ... ARGS> bool validateKeys(const KSType& key, ARGS&& ... args)
		{
			return (getValue(key) != nullptr) && validateKeys(std::forward<ARGS>(args)...);
		}
		//----------------------------------------------------------------------------------------
	public:
		int GetRecordColumnCount() const { return _columns.size(); }
		const VType& GetRecordColumn(int idx= 0) const 
		{ 
			int count = GetRecordColumnCount();
			CMBTVERIFY(idx < count);
				auto it = _columns.begin();
			for(int i = 0; i < idx; ++i)
				++it;
			return it->second;
		}
		const KSType& GetRecordColumnName(int idx = 0) const
		{
			int count = GetRecordColumnCount();
			CMBTVERIFY(idx < count);
			auto it = _columns.begin();
			for(int i = 0; i < idx; ++i)
				++it;
			return it->first;
		}
	private:
		static int key_compare_internal(const std::string& lhs, const std::string& rhs) { return _stricmp(lhs.c_str(), rhs.c_str()); }
		static int key_compare_internal(const std::wstring& lhs, const std::wstring& rhs) { return _wcsicmp(lhs.c_str(), rhs.c_str()); }
		template <typename T> static bool key_compare_less(const T& lhs, const T& rhs) { return key_compare_internal(lhs.c_str(), rhs.c_str()) < 0; }
		template <typename T> static bool key_compare_equal(const T& lhs, const T& rhs) { return key_compare_internal(lhs.c_str(), rhs.c_str()) == 0; }
		using DataMapType = std::map<KSType, VType, std::function<bool(const KSType&, const KSType&)>>;
		DataMapType _columns;
	};
	//----------------------------------------------------------------------------------------
	using db_recorda = db_record<std::string, std::string>;
	using db_recordw = db_record<std::string, std::wstring>;
	using db_recordwa = db_record<std::wstring, std::string>;
	using db_recordww = db_record<std::wstring, std::wstring>;
}

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
// prtdataprovider.h : 
// D :	Exemplarische Deklaration/Implementation von Klassen und Strukturen für den List und Label Zugriff mittels eines
//		C++ Datenproviders auf Basis von SQLite. Da es sich um ein Beispiel handelt wurde Zwecks Übersichtlichkeit weitgehend auf
//		Fehlerbehandlung oder auch Absicherungen gegen z.B. SQL Injections bewusst verzichtet.
// US:	Sample declaration / implementation of data structures and classes demonstrating usage of List and Label dataprovider interface
//		working on top of sqlite database. Since this is a sample, error handling and securing e.g against sql injections has been neglected 
//		in favour of keeping code as simple as possible.

#pragma once

// D : Ein paar Vorwärtsdeklarationen
// US: some forward declarations
class CPrintManager;
class CPrintDataProvider;
class CPrintDataProviderRoot;
class CPrintDataProviderNode;

using CDPString = std::wstring;		// since LL API basically is unicode -> we default to wchar_t here
using SQLiteRecord = db_recordww;	// also unicode for anything we retrieve from the DB

class CDPSchema
{
public:
	// D : Interne Datenstrukturen und Flags für das Datenbankschema
	// US: Internal structure and flags for database scheme
  //----------------------------------------------------------------------------------------
  enum Flags
	{
	  E_FLAG_NONE				= 0x00000000,
	  E_FLAG_GEN_MASK			= 0x000000FF,
	  E_FLAG_GEN_SORTASC		= 0x00000001,
	  E_FLAG_GEN_SORTDESC		= 0x00000002,
	  E_FLAG_COL_MASK			= 0x0000FF00,
	  E_FLAG_COL_NOTNULL		= 0x00000100,
	  E_FLAG_COL_PK				= 0x00000200,
	  E_FLAG_TAB_MASK			= 0x00FF0000,
	  E_FLAG_TAB_VARIABLE		= 0x00010000,
	  E_FLAG_TAB_MASTER			= 0x00020000
	};
  //----------------------------------------------------------------------------------------
  struct CColumnRecord
	{
	  CDPString					_column_name;			// e.g "column"
	  CDPString					_aliased_column_name;	// e.g "Table$Column" (SQLite does not like . here)
	  CDPString					_column_default;		// e.g "content string"
	  CDPString					_column_createtype_str; // e.g "UNSIGNED BIG INT" or alike, picked from reading by sqlite PRAGMA 
	  unsigned					_lltype = 0;			// the corresponding LL type returned by LLTypeFromSQLiteSchemaType
	  unsigned					_uFlags = 0;			// flags e.g E_FLAG_GEN_SORTASC|E_FLAG_COL_PK | E_FLAG_COL_NOTNULL
	  cmbtSQL::SQLiteVariant    _dbvalue;				// the value found in first row, used as sample value in LL preview
	};
  //----------------------------------------------------------------------------------------
  struct CRelationRecord
	{
	  CDPString					_relation_name;			// e.g "Invoice2Customers"
	  CDPString					_table_name;			// e.g "Customers"
	  CDPString					_column_name;			// e.g "CustomerId"
	  CDPString					_related_table_name;	// e.g "Invoice"
	  CDPString					_related_column_name;	// e.g "CustomerId"
	  bool                      _is1To1Rel;
	};
  //----------------------------------------------------------------------------------------
  struct CTableRecord
	{	
		CDPString								_table_name;			// e.g "Customers"
		CDPString								_sql;					// the original, complete sql statement to create this table
		int										_numberOfElements;		// number of elements in table
		std::vector<CColumnRecord>				_columns;				// data containers
		std::list<CRelationRecord>				_relations;				// data containers
		unsigned								_uFlags = 0;			// flags e.g E_FLAG_GEN_SORTASC|E_FLAG_COL_PK | E_FLAG_COL_NOTNULL
	};
  //----------------------------------------------------------------------------------------
  struct CSchemaFilter
	{
		// D : Interne Datenstruktur für die Anmeldung des Datenbankschemas. 
		// US: Use a list of , separated values with +/- indicating access to build schema
		using InitFunc = std::shared_ptr < std::function<void(CPrintManager* pm)> > ;
		enum EMatchType { MT_DATABASE, MT_TABLE, MT_COLUMN, MT_SORTASC, MT_SORTDESC, MT_VARTABLE, MT_MASTERTABLE };
		bool match(EMatchType type, const CDPString& sValue) const;

		CDPString   _databasepath;								// path of sqlite db to be opened
		bool        _bUseInMemoryDB = true;						// indicate that db from _databasepath will be internally copied to an in memory database
		InitFunc	_CustomDataInit;							// functor to manually modify or inject db contents on the fly prior initialization (in memory db only)
		CDPString	_databasefilt = L"+*";						// used to limit FillSchema to specific databases
		CDPString	_tablefilt = L"+*";							// used to limit FillSchema to specific tables
		CDPString	_columnfilt = L"+*";						// used to limit FillSchema to specific columns
		CDPString	_sortfiltasc = L"+*";						// used to limit FillSchema to specific sort options
		CDPString	_sortfiltdesc = L"+*";						// used to limit FillSchema to specific sort options
		CDPString	_vartables = L"";						    // used to mark table as vartable (put to variables instead fields), not used yet
		CDPString	_mastertable = L"";							// used to mark table as mastertable (there can be only one), not used yet
	};
  //----------------------------------------------------------------------------------------
  using CSchemaData = std::vector < CTableRecord > ;
public:
  //----------------------------------------------------------------------------------------
  // D : Datenbankschema auslesen. Über den Filter kann die Anmeldung der Tabellen/Spalten an dieser Stelle beeinflusst werden
	// US: Build schema information. By using the filter options, it is possible to manipulate LL table / column declaration here.
	int FillSchema(cmbtSQL::SQLiteConnection& conn, bool bFillDefaults = true);
  //----------------------------------------------------------------------------------------
  //Einträge im Schema suchen / Lookup schema entries
	CTableRecord* GetTableRecord(const CDPString& sTableName);
	CColumnRecord* GetColumnRecord(const CDPString& sTableName, const CDPString& sColumnName);
	CRelationRecord* GetRelationRecord(const CDPString& sRelationKey);
  //----------------------------------------------------------------------------------------
	// Konvertierungen zwischen SQLite und LL Typen / conversions in between SQLite and LL data types
	static int LLTypeFromSQLiteSchemaType(const CDPString& str);
	static std::wstring Convert2LLColumnWideString(const unsigned ExpectedLLType, const cmbtSQL::SQLiteVariant& RetrievedDBvalue);
	static std::string Convert2LLColumnString(const unsigned ExpectedLLType, const cmbtSQL::SQLiteVariant& RetrievedDBvalue);
	static std::wstring Convert2DBSQLWideString(const unsigned ExpectedLLType, const SQLiteVariant& RetrievedDBvalue, bool bAddQuotes);
	static std::string Convert2DBSQLString(const unsigned ExpectedLLType, const SQLiteVariant& RetrievedDBvalue, bool bAddQuotes);
public:
  //----------------------------------------------------------------------------------------
  CSchemaData& GetData();
	CSchemaFilter& GetFilter();
protected:
	CSchemaData _data;
	CSchemaFilter _filter;
};

class CPrintManager
{
public:
	struct CPM
	{
		// D : Wrapper Strukturen / Klassen für einfache Threadsynchronisation.
		// US: Wrapper structs and classes for simple thread syncronization.
		//----------------------------------------------------------------------------------------
		class CCritSect
		{
			// critical section
		public:
			CCritSect() { ::InitializeCriticalSection(&_cs); }
			~CCritSect() { ::DeleteCriticalSection(&_cs); }
			LPCRITICAL_SECTION getAbi() { return &_cs; }
		private:
			CRITICAL_SECTION _cs;
		};
		//----------------------------------------------------------------------------------------
		class CCritLock
		{
			// lock from critical section
		public:
			CCritLock(LPCRITICAL_SECTION cs) : _cs(cs) { ::EnterCriticalSection(_cs); }
			CCritLock(CCritSect& cs) : CCritLock(cs.getAbi()) {}
			~CCritLock() { ::LeaveCriticalSection(_cs); }
			LPCRITICAL_SECTION getAbi() { return _cs; }
		private:
			LPCRITICAL_SECTION _cs;
		};
		//----------------------------------------------------------------------------------------
		class CThreadEvent
		{
			// event
		public:
			CThreadEvent() : _h(NULL) {}
			virtual ~CThreadEvent() { close(); }
			BOOL create(LPSECURITY_ATTRIBUTES lpEventAttributes, BOOL bManualReset, BOOL bInitialState, LPCTSTR lpName)
			{
				close();
				_h = CreateEvent(lpEventAttributes, bManualReset, bInitialState, lpName);
				return _h != NULL;
			}
			void close() 
			{ 
				if(_h) 
					CloseHandle(_h); 
			}
			HANDLE getAbi() { return _h; }
		private:
			HANDLE _h;
		};
		//----------------------------------------------------------------------------------------
		class CThread
		{
		public:
			CThread(){};
			virtual ~CThread(){ close(); }
			template <typename T> void create(const T&& func)
			{
				close();
				_spThread = std::make_shared<std::thread>(std::move(func));
			}
			void close()
			{
				if (_spThread.get())
				{
					if (_spThread->joinable())
						_spThread->join();
					else
						_spThread->detach();
					_spThread.reset();
				}
			}
			std::shared_ptr < std::thread > GetAbi() { return _spThread; }
		private:
			std::shared_ptr < std::thread > _spThread;
		};
		//----------------------------------------------------------------------------------------
		// atomic variable read
		template <typename T> static T LockedRead(const T& value, CCritSect& s)
		{
			CCritLock lock(s);
			T ret(value);
			return ret;
		}
		//----------------------------------------------------------------------------------------
		// atomic variable write
		template <typename T> static void LockedWrite(T& value, const T& newvalue, CCritSect& s)
		{
			CCritLock lock(s);
			value = newvalue;
		}
	};
public:
	// D : Strukturen für die Jobs (Druck, Preview, Design). CJobDataRec initialisieren und RunJob aufrufen.
	// US: Structures for Print Preview and Design. Initialize CJobDataRec and call RunJob.
  //----------------------------------------------------------------------------------------
  enum class CJobType
	{
		TYPE_NONE,
		TYPE_PRINT,
		TYPE_PREVIEW,
		TYPE_DESIGN
	};
  //----------------------------------------------------------------------------------------
  struct CJobDataRec
	{
		CPrintDataProvider* _pDataProvider;				// needs to be initialized with a valid heap ptr returned by new - will be subsequently deleted by call to DoneJob or ~CPrintManager 
		CJobType _uJobType = CJobType::TYPE_PRINT;		// specify intended usage
		INT _hJob = NULL;								// the LL Job Handle
		HWND _hWnd = NULL;								// the window handle of caller
		CDPString _sFilename;							// the filename to be used
		std::set<CDPString> _usedIdentifiers;			// holds the usedIdentifiers section of the file
		static bool bUseDelayedDefinition;              // indicate if should be set LL_OPTION_SUPPORT_DELAYEDFIELDDEFINITION
	};
	using CJobData = std::vector < CJobDataRec > ;
	using CDataConnectionPtr = std::shared_ptr < SQLiteConnection >;
public:
	CPrintManager();
	virtual ~CPrintManager();
	bool Init(bool bReinit);
	INT InitJob(CJobDataRec& r);				// The main IF - call InitJob and RunJob. Not much more to do for class clients here...Returns handle
	void RunJob(INT hJob);						// The main IF - call InitJob and RunJob. Not much more to do for class clients here...Uses handle
public:
	// D : Zugriff auf Job, Connection und Schema
	// US: Access to job, connection and schema information
	INT  GetJobHandle(CJobType t);
	CJobDataRec* JobFromType(CJobType t);
	CJobDataRec* JobFromHandle(INT h);
	SQLiteConnection* GetConnection();
	CDPSchema& GetSchema();
	bool bIsPrinting(CJobDataRec* pJDR);
	bool bIsPrinting(INT hJob);
	bool bUseDelayedDefinition(CJobDataRec* pJDR);
	bool bUseDelayedDefinition(INT hJob);

	template <typename T> static void ShowMessageBox(const T& sText)
	{
		AfxMessageBox(SQLiteHelp::conv2wstr(sText).c_str());
	}
protected:
	virtual void DefineFieldsOrVariables(CJobDataRec* pJDR, bool bVariables);
	virtual void OpenDatabase();
	virtual void CloseDatabase();
	virtual void PreJob(INT hJob);
	virtual BOOL DoJob(INT hJob);
	virtual void DoneJob(INT hJob);
protected:
	CJobData _JobData;
	CDPSchema _Schema;
	CDataConnectionPtr _spDBConn;
	CPM::CCritSect _CritSect;
protected:
	// D : LL Callback und Messagedispatcher
	// US: LL callback and message dispatcher 
	friend static LRESULT CALLBACK LLCallbackProc(int wParam, LPARAM lParam, DWORD lUserParam); // the callback
	virtual LRESULT OnLLMessage(WPARAM wParam, LPARAM lParam); // the dispatcher
protected:
	// D : Designer Echtdatenvorschau mittels Message aus Callback und eigenem Thread
	// US: Designer preview by message from callback and designated thread 
	virtual INT OnNtfyRDPJob(scLlDesignerPrintJob* pscLRDDJ);
	unsigned int RDPThreadFunc();
	void RDPThreadEnd();
	struct RDP
	{
		CPrintManager*					_PM = nullptr;
		CPM::CThread					_Thread;
		CPM::CCritSect					_CritSec;
		CPM::CThreadEvent				_evThreadEvent;
		bool							_bThreadRunning= false;
		bool							_bProcessing= false;
		INT							    _hJob = 0;
		struct NtfyParms
		{
			 CDPString			_ProjectFileName;
			 CDPString			_OriginalProjectFileName;
			 UINT				_nPages = 0;
			 UINT				_nFunction = 0;
			 HWND				_hWnd = 0;
			 HANDLE				_hEvent = 0;
			 CDPString			_ExportFormat;
			 BOOL				_bWithoutDialog = FALSE;
			 BOOL				_bPreview;
		} _NtfyParms;
	}_RDP;
};

// D : Die abstrakte Basis für CPrintDataProviderRoot/CPrintDataProviderNode.
// US: Abstract base of CPrintDataProviderRoot/CPrintDataProviderNode. Refactor common used elements/methods here.
class CPrintDataProvider : public ILLDataProvider
{
public:
	// D : ctor/dtor Zugriff einschränken und Referenzzählung für COM basierte Interfaces implementieren
	// US: Limit ctor/dtor access and provide reference counting for COM Interfaces
	CPrintDataProvider(CPrintManager& PM, INT hJob);
	CPrintDataProvider(const CPrintDataProvider& cp) = delete;
	CPrintDataProvider(const CPrintDataProvider&& cp) = delete;
	CPrintDataProvider& operator= (const CPrintDataProvider& rhs) = delete;
	CPrintDataProvider& operator= (const CPrintDataProvider&& rhs) = delete;
	virtual ~CPrintDataProvider(void);
	bool SetJobHandle(INT hJob);
	virtual STDMETHODIMP 			QueryInterface(REFIID riid, VOID** ppv);
	virtual STDMETHODIMP_(ULONG) 	AddRef(void);
	virtual STDMETHODIMP_(ULONG) 	Release(void);
public:
	// D : Diese rein virtuellen Methoden müssen vollständig in CPrintDataProviderRoot/CPrintDataProviderNode implementiert werden
	// US: these inherited pure virtuals need to be implemented within the concrete CPrintDataProviderRoot/CPrintDataProviderNode
	STDMETHODIMP OpenTable(LPCWSTR pszTableName, IUnknown** ppUnkOfNewDataProvider) = 0;
	STDMETHODIMP OpenChildTable(LPCWSTR pszRelation, IUnknown** ppUnkOfNewDataProvider) = 0;
	STDMETHODIMP GetRowCount(INT* pnRows) = 0;
	STDMETHODIMP DefineDelayedInfo(enDefineDelayedInfo nInfo) = 0;
	STDMETHODIMP MoveNext() = 0;
	STDMETHODIMP DefineRow(enDefineRowMode, const VARIANT* arvRelations) = 0;
	STDMETHODIMP Dispose() = 0;
	STDMETHODIMP SetUsedIdentifiers(const VARIANT* arvFieldRestriction) = 0;
	STDMETHODIMP ApplySortOrder(LPCWSTR pszSortOrder) = 0;
	STDMETHODIMP ApplyFilter(const VARIANT* arvFields, const VARIANT* arvValues) = 0;
	STDMETHODIMP ApplyAdvancedFilter(LPCWSTR pszFilter, const VARIANT* arvValues) = 0;
	STDMETHODIMP SetOption(enOptionIndex nIndex, const VARIANT * vValue) = 0;
	STDMETHODIMP GetOption(enOptionIndex nIndex, VARIANT * vValue) = 0;
public:
	// D : Zentraler parametrisierbarer Zugriff auf den Namen des aktuellen Elements
	// US: central and customizable point of access to name auf current element 
	enum NameRecursion
	{
		E_SIMPLE,		// returns name
		E_ONELEVEL,     // return parent and name
		E_FULL,			// return full name tree
		E_DEBUG_TRACE   // full name tree and relation
	};
	CDPString name(NameRecursion uRecurseLevel = E_SIMPLE, wchar_t cSep = L'.') const;
protected:
	// D : Default für leere Methoden aus dem ILLDataProvider Interface.
	// US: Default implementation for empty methods from ILLDataProvider interface.
	#pragma warning( push )
	#pragma warning( disable: 4100 )
	template <typename ... ARGS> _cmbt_constexpr_ STDMETHODIMP CallToEmptyImplementation(const std::string& sFunc, ARGS&& ... args) const
	{
		XTRACE(_T("Empty Implementation called %hs\n"), sFunc.c_str());
		ASSERT(FALSE);
		return E_NOTIMPL;
	}
	#pragma warning( pop )
	// D : Das interne SQL statement erzeugen
	// US: Build or rebuild the internal SQL statement
	bool InitStatement(bool bReInit = false);
private:
	INT _nRef;							// refcount for COM
	CPrintDataProvider* GetSafeParent() const;
	static std::set<CPrintDataProvider*> _registeredPtrs;
protected:
	CPrintDataProvider* _pParent = nullptr;	// the parent dataprovider object, if exists
	CPrintManager& _PM;						// the associated PrintManager object
	CPrintManager::CJobType _JobType;		// the associated EJobType within the PrintManager
	INT _JobHandle= 0;						// the associated JobHandle within the PrintManager
	struct
	{
		CDPString _sql;			// the complete sql statement
		CDPString _selection;	// either * or the used fields
		CDPString _from;		// the table(s)
		CDPString _where;		// the filter
		CDPString _orderby;     // the sort order
	}_sqlparms;
	struct
	{
		bool _optHintAdvancedFilterIsCached = false;
		bool _optHintIsInfoQuery = false;
		int _optHintMaxRows = 0;
	}_opts;
	std::shared_ptr<cmbtSQL::SQLiteStatement> _statement;	// the prepared underlying SQLite statement we are working with 
	SQLiteRecord _record;									// always contains the last read record from the database
	CDPString _relation;									// the relation name
	CDPString _name;										// the table name we are working with
	int _count = 0;											// number of elements in the query
	std::set<CDPString> _usedIdentifiers;					// the used identifiers passed by LL - will be used to build a minimized select statement
};

class CPrintDataProviderRoot : public CPrintDataProvider
{
public:
	CPrintDataProviderRoot(CPrintManager& PM, INT hJob);
public:
	virtual ~CPrintDataProviderRoot(void);

	// D : Implementationen des ILLDataProvider Interfaces
	// US: The concrete ILLDataProvider interface implementations 
	// Inherited via CPrintDataProvider
	virtual STDMETHODIMP OpenTable(LPCWSTR pszTableName, IUnknown ** ppUnkOfNewDataProvider) override;
	virtual STDMETHODIMP OpenChildTable(LPCWSTR pszRelation, IUnknown ** ppUnkOfNewDataProvider) override;
	virtual STDMETHODIMP GetRowCount(INT * pnRows) override;
	virtual STDMETHODIMP DefineDelayedInfo(enDefineDelayedInfo nInfo) override;
	virtual STDMETHODIMP MoveNext() override;
	virtual STDMETHODIMP DefineRow(enDefineRowMode, const VARIANT* arvRelations) override;
	virtual STDMETHODIMP Dispose() override;
	virtual STDMETHODIMP SetUsedIdentifiers(const VARIANT * arvFieldRestriction) override;
	virtual STDMETHODIMP ApplySortOrder(LPCWSTR pszSortOrder) override;
	virtual STDMETHODIMP ApplyFilter(const VARIANT * arvFields, const VARIANT * arvValues) override;
	virtual STDMETHODIMP ApplyAdvancedFilter(LPCWSTR pszFilter, const VARIANT * arvValues) override;
	virtual STDMETHODIMP SetOption(enOptionIndex nIndex, const VARIANT * vValue) override;
	virtual STDMETHODIMP GetOption(enOptionIndex nIndex, VARIANT * vValue) override;
};

class CPrintDataProviderNode : public CPrintDataProvider
{

public:

	CPrintDataProviderNode(CPrintManager& PM, INT hJob, LPCWSTR pszTableName, int count, CPrintDataProvider* pParent = nullptr);
	virtual ~CPrintDataProviderNode(void);
	// D : Implementationen des ILLDataProvider Interfaces
	// US: The concrete ILLDataProvider interface implementations 
	// Inherited via CPrintDataProvider
	virtual STDMETHODIMP OpenTable(LPCWSTR pszTableName, IUnknown ** ppUnkOfNewDataProvider) override;
	virtual STDMETHODIMP OpenChildTable(LPCWSTR pszRelation, IUnknown ** ppUnkOfNewDataProvider) override;
	virtual STDMETHODIMP GetRowCount(INT * pnRows) override;
	virtual STDMETHODIMP DefineDelayedInfo(enDefineDelayedInfo nInfo) override;
	virtual STDMETHODIMP MoveNext() override;
	virtual STDMETHODIMP DefineRow(enDefineRowMode, const VARIANT* arvRelations) override;
	virtual STDMETHODIMP Dispose() override;
	virtual STDMETHODIMP SetUsedIdentifiers(const VARIANT * arvFieldRestriction) override;
	virtual STDMETHODIMP ApplySortOrder(LPCWSTR pszSortOrder) override;
	virtual STDMETHODIMP ApplyFilter(const VARIANT * arvFields, const VARIANT * arvValues) override;
	virtual STDMETHODIMP ApplyAdvancedFilter(LPCWSTR pszFilter, const VARIANT * arvValues) override;
	virtual STDMETHODIMP SetOption(enOptionIndex nIndex, const VARIANT * vValue) override;
	virtual STDMETHODIMP GetOption(enOptionIndex nIndex, VARIANT * vValue) override;
};

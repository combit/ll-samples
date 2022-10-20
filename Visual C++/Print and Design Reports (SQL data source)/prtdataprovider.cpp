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
// prtdataprovider.cpp : 
// D :	Exemplarische Deklaration/Implementation von Klassen und Strukturen für den List und Label Zugriff mittels eines
//		C++ Datenproviders auf Basis von SQLite. Da es sich um ein Beispiel handelt wurde Zwecks Übersichtlichkeit weitgehend auf
//		Fehlerbehandlung oder auch Absicherungen gegen z.B. SQL Injections bewusst verzichtet.
// US:	Sample declaration / implementation of data structures and classes demonstrating usage of List and Label dataprovider interface
//		working on top of sqlite database. Since this is a sample, error handling and securing e.g against sql injections has been neglected 
//		in favour of keeping code as simple as possible.

#include "StdAfx.h"
#include "prtdataprovider.h"

#include <algorithm>
///////////////////////////////////////////////////////////////////////
// CPrintDataProvider
//
///////////////////////////////////////////////////////////////////////

GUID IID_ILLDATAPROVIDER{ 0x3cbae450, 0x8880, 0x11d2, 0x96, 0xa3, 0x00, 0x60, 0x08, 0x6f, 0xef, 0xff };

using namespace cmbtSQL;

//---------------------------------------------------------------------
CDPString DebugStrHlpGetOption(ILLDataProvider::enOptionIndex nIdx);
CDPString DebugStrHlpGetDelayedInfo(ILLDataProvider::enDefineDelayedInfo nInfo);


//---------------------------------------------------------------------
static LRESULT CALLBACK LLCallbackProc(int wParam, LPARAM lParam, DWORD lUserParam)
{
	// D:  Callback Funktion
	// US: callback procedure
	CPrintManager* pThis = (CPrintManager*)lUserParam;
	ASSERT(pThis);
	return(pThis->OnLLMessage(wParam, lParam));
}
//---------------------------------------------------------------------
std::set<CPrintDataProvider*> CPrintDataProvider::_registeredPtrs;
CPrintDataProvider* CPrintDataProvider::GetSafeParent() const
{
	auto it = _registeredPtrs.find(const_cast<CPrintDataProvider*>(_pParent));
	return it != _registeredPtrs.end() ? (CPrintDataProvider*)&(*it) : nullptr;
}
//---------------------------------------------------------------------
CPrintDataProvider::CPrintDataProvider(CPrintManager& PM, INT hJob) : _PM(PM), _JobHandle(hJob), _JobType(CPrintManager::CJobType::TYPE_NONE), _nRef(1)
{
	_registeredPtrs.insert(this);
	auto pJDR = PM.JobFromHandle(hJob);
	if (pJDR)
		_JobType = pJDR->_uJobType;
}
//---------------------------------------------------------------------
CPrintDataProvider::~CPrintDataProvider()
{
	auto it = _registeredPtrs.find(this);
	if(it != _registeredPtrs.end())
		_registeredPtrs.erase(it);
}
//---------------------------------------------------------------------
bool CPrintDataProvider::SetJobHandle(INT hJob)
{
	auto pJDR = _PM.JobFromHandle(hJob);
	ASSERT(!pJDR);
	if (!pJDR)
		_JobHandle = hJob;
	return !pJDR;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProvider::QueryInterface(REFIID riid, VOID** ppvObj)
{
	*ppvObj = NULL;

	if (riid == IID_IUnknown)
	{
		*ppvObj = (IUnknown*)this;
		AddRef();
	}

	if (riid == IID_ILLDATAPROVIDER)
	{
		*ppvObj = (ILLDataProvider*)this;
		AddRef();
	}

	if (*ppvObj != NULL)
	{
		return(S_OK);
	}

	return(E_NOINTERFACE);
}
//---------------------------------------------------------------------
STDMETHODIMP_(ULONG) CPrintDataProvider::AddRef(void)
{
	//XTRACE(_T(">>%hs (%ls) (%d)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str(), _nRef);
	ASSERT(_nRef >= 0);
	return ++_nRef;
}
//---------------------------------------------------------------------
STDMETHODIMP_(ULONG) CPrintDataProvider::Release(void)
{
	//XTRACE(_T(">>%hs (%ls) (%d)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str(), _nRef);
	ASSERT(_nRef > 0);
	if (--_nRef != 0)
	{
		return(_nRef);
	}
	delete this;
	return 0;
}
//---------------------------------------------------------------------
bool CPrintDataProvider::InitStatement(bool bReInit)
{
	if (bReInit)
		_statement.reset();

	// D : Das komplette SQL Statement einmalig vollständig aufbauen.
	// US: Init the complete sql statement once.
	if (_statement.get() == nullptr)
	{
		auto pJDR = _PM.JobFromHandle(_JobHandle);
		bool bUseDelaydDefinition = pJDR->bUseDelayedDefinition;
		auto& usedIdentifiers = bUseDelaydDefinition && !_usedIdentifiers.empty() ? _usedIdentifiers : pJDR->_usedIdentifiers;

		// D : WHERE clause aufbauen, wenn es sich um eine Relation handelt
		// US: build the where clause in case of having a relation
		{
			CDPSchema::CRelationRecord* pRel = _PM.GetSchema().GetRelationRecord(_relation);
			if (pRel)
			{
				auto tableColumns = SQLiteHelp::strsplit(pRel->_column_name, L'\t');
				auto relatedColumns = SQLiteHelp::strsplit(pRel->_related_column_name, L'\t');
				ASSERT(tableColumns.size() == relatedColumns.size());
				unsigned count = 0;
				for (auto it = tableColumns.begin(), itr = relatedColumns.begin(); it != tableColumns.end(); ++it, ++itr)
				{
					unsigned llType = _PM.GetSchema().GetColumnRecord(pRel->_related_table_name, *itr)->_lltype;
					// so we lookup the hopefully already stored variable value in parent table
					SQLiteVariant * pVal = GetSafeParent() ? _pParent->_record.getValue(itr->c_str()) : nullptr;
					ASSERT(pVal);
					if (pVal)
					{
						CDPString sCommand = count == 0 ? L"WHERE" : L" AND";
						switch (llType)
						{
						case LL_NUMERIC:
							_sqlparms._where += SQLiteHelp::xsprintf(L"%s ABS(CAST(%ls.%s AS REAL) - CAST(%ls AS REAL)) < %g", sCommand.c_str(), pRel->_table_name.c_str(), it->c_str(),
																	 CDPSchema::Convert2DBSQLWideString(llType, *pVal, true).c_str(), FLT_EPSILON);
							break;
						default:
							_sqlparms._where += SQLiteHelp::xsprintf(L"%s %ls.%s = %ls", sCommand.c_str(), pRel->_table_name.c_str(), it->c_str(),
																	 CDPSchema::Convert2DBSQLWideString(llType, *pVal, true).c_str());
							break;
						}
						++count;
					}
				}
			}
		}

		// D : SELECT Klausel anhand der Used Identifiers und Relationen aus dem Projekt aufbauen
		// US: build the select clause from projects used identifiers and relations
		{
			CDPSchema::CTableRecord* pTR = _PM.GetSchema().GetTableRecord(name());
			if (pTR)
			{
				auto lIsUsedByRelation = [&](const CDPString& tableName, const CDPString& columnName)->bool
				{
					bool lFound = false;
					for (auto& tr : _PM.GetSchema().GetData())
					{
						for (auto& rr : tr._relations)
						{
							if (!lFound && _wcsicmp(rr._related_table_name.c_str(), tableName.c_str()) == 0)
							{
								auto colnames = SQLiteHelp::strsplit(rr._related_column_name, L'\t');
								lFound = std::find_if(colnames.begin(), colnames.end(), [&](CDPString& s){ return _wcsicmp(s.c_str(), columnName.c_str()) == 0; }) != colnames.end();
							}
						}
					}
					return lFound;
				};

				if (!_opts._optHintIsInfoQuery)
				{
					for (auto& elem : pTR->_columns)
					{
						CDPString ident = elem._aliased_column_name;
						std::replace_if(ident.begin(), ident.end(), [](const wchar_t& c)->bool { return c == L'$'; }, L'.');
						if ((usedIdentifiers.find(ident) != usedIdentifiers.end()) || lIsUsedByRelation(pTR->_table_name, elem._column_name))
							_sqlparms._selection += _sqlparms._selection.empty() ? ident : SQLiteHelp::xsprintf(L",%ls", ident.c_str());
					}
				}
			}
		}

		// D : und zuletzt das Statement aufbauen
		// US: finally build the statement
		{
			if (_sqlparms._from.empty())
				_sqlparms._from = _name;
			if (_sqlparms._selection.empty())
				_sqlparms._selection = L"*";
			if (!_sqlparms._orderby.empty())
				_sqlparms._orderby = SQLiteHelp::xsprintf(L"ORDER BY %ls", _sqlparms._orderby.c_str());
			_sqlparms._sql = SQLiteHelp::xsprintf(L"select %ls from %ls %ls %ls;", _sqlparms._selection.c_str(),
												  _sqlparms._from.c_str(),
												  _sqlparms._where.c_str(),
												  _sqlparms._orderby.c_str());
			_statement = std::make_shared<SQLiteStatement>(*_PM.GetConnection(), _sqlparms._sql.c_str());
		}
		XTRACE(_T("<<%hs (%ls) builds %ls\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str(), _sqlparms._sql.c_str());
	}
	return _statement.get() != nullptr;
}
//---------------------------------------------------------------------
CDPString CPrintDataProvider::name(CPrintDataProvider::NameRecursion uRecurseLevel, wchar_t cSep) const
{
	// D : Um stets zu wissen wer wir sind.
	// US: Always better to know who we are.
	CDPString ret;
	switch (uRecurseLevel)
	{
	case E_SIMPLE:
		ret = _name;
		break;
	case E_ONELEVEL:
	case E_FULL:
		if (_pParent)
		{
			CPrintDataProvider::NameRecursion nextRecurseLevel = uRecurseLevel == E_FULL ? E_FULL : E_SIMPLE;
			CDPString sParent = GetSafeParent() ? _pParent->name(nextRecurseLevel) : L"<invalid ptr>";
			ret = SQLiteHelp::xsprintf(L"%ls%c%ls", sParent.c_str(), cSep, name(E_SIMPLE).c_str());
		}
		else
			ret = name(E_SIMPLE);
		break;
	case E_DEBUG_TRACE:
		ret = SQLiteHelp::xsprintf(L"%ls [%ls]", name(E_FULL, cSep).c_str(), _relation.c_str());
		break;
	}
	return ret;
}


///////////////////////////////////////////////////////////////////////
// CPrintDataProviderRoot
//
///////////////////////////////////////////////////////////////////////

//---------------------------------------------------------------------
CPrintDataProviderRoot::CPrintDataProviderRoot(CPrintManager& PM, INT hJob) : CPrintDataProvider(PM, hJob)
{
	XTRACE(_T(">>%hs (%ls)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
}
//---------------------------------------------------------------------
CPrintDataProviderRoot::~CPrintDataProviderRoot(void)
{
	XTRACE(_T(">>%hs (%ls)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::OpenTable(LPCWSTR pszTableName, IUnknown ** ppUnkOfNewDataProvider)
{
	// D : Aufgerufen von LL. Ein CPrintDataProviderRoot Objekt identifiziert ein Root Objekt - Tatsächliche Arbeit wird jedoch an die Knoten übergeben.
	// US: Called by LL. Having a CPrintDataProviderRoot identifies a root table - Concrete work has to be directed to node though.
	XTRACE(_T(">>%hs (%d -> %ls)\n"), __FUNCTION__, this, pszTableName);
	HRESULT hRes = S_OK;
	_count = -1;
	_name = pszTableName;
	*ppUnkOfNewDataProvider = new CPrintDataProviderNode(_PM, _JobHandle, pszTableName, _count);
	return hRes;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::OpenChildTable(LPCWSTR pszRelation, IUnknown ** ppUnkOfNewDataProvider)
{
	return CallToEmptyImplementation(__FUNCTION__, pszRelation, ppUnkOfNewDataProvider);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::GetRowCount(INT * pnRows)
{
	return CallToEmptyImplementation(__FUNCTION__, pnRows);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::DefineDelayedInfo(enDefineDelayedInfo nInfo)
{
	return CallToEmptyImplementation(__FUNCTION__, nInfo);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::MoveNext()
{
	return CallToEmptyImplementation(__FUNCTION__);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::DefineRow(enDefineRowMode, const VARIANT* /*arvRelations*/)
{
	return CallToEmptyImplementation(__FUNCTION__);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::Dispose()
{
	return CallToEmptyImplementation(__FUNCTION__);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::SetUsedIdentifiers(const VARIANT * arvFieldRestriction)
{
	return CallToEmptyImplementation(__FUNCTION__, arvFieldRestriction);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::ApplySortOrder(LPCWSTR pszSortOrder)
{
	return CallToEmptyImplementation(__FUNCTION__, pszSortOrder);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::ApplyFilter(const VARIANT * arvFields, const VARIANT * arvValues)
{
	return CallToEmptyImplementation(__FUNCTION__, arvFields, arvValues);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::ApplyAdvancedFilter(LPCWSTR pszFilter, const VARIANT * arvValues)
{
	return CallToEmptyImplementation(__FUNCTION__, pszFilter, arvValues);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::SetOption(enOptionIndex nIndex, const VARIANT * vValue)
{
	return CallToEmptyImplementation(__FUNCTION__, nIndex, vValue);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderRoot::GetOption(enOptionIndex nIndex, VARIANT * vValue)
{
	return CallToEmptyImplementation(__FUNCTION__, nIndex, vValue);
}
//---------------------------------------------------------------------

///////////////////////////////////////////////////////////////////////
// CPrintDataProviderTable
//
///////////////////////////////////////////////////////////////////////

//---------------------------------------------------------------------
CPrintDataProviderNode::CPrintDataProviderNode(CPrintManager& PM, INT hJob, LPCWSTR pszTableName, int count, CPrintDataProvider* pParent) : CPrintDataProvider(PM, hJob)
{
	// D : Erzeugen eines Knotens und setzen der nötigsten Informationen
	// US: Node creation and initialization of necessary information
	_pParent = pParent;
	_count = count;
	_relation = pszTableName;
	CDPSchema::CRelationRecord* pRel = _PM.GetSchema().GetRelationRecord(_relation);
	_name = pRel ? pRel->_table_name : _relation;
	XTRACE(_T("<<%hs (%ls)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
}
//---------------------------------------------------------------------
CPrintDataProviderNode::~CPrintDataProviderNode(void)
{
	XTRACE(_T("<<%hs (%ls)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::OpenTable(LPCWSTR pszTableName, IUnknown ** ppUnkOfNewDataProvider)
{
	return CallToEmptyImplementation(__FUNCTION__, pszTableName, ppUnkOfNewDataProvider);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::OpenChildTable(LPCWSTR pszRelation, IUnknown ** ppUnkOfNewDataProvider)
{
	// D : Aufgerufen von LL. Erzeugen eines Subtable Knotens unterhalb des aktuellen Knotens.
	// US: Called by LL. Subtable node creation as child of current node.
	HRESULT hRes = S_OK;
	*ppUnkOfNewDataProvider = new CPrintDataProviderNode(_PM, _JobHandle, pszRelation, -1, this);
	XTRACE(_T("<<%hs (%d -> %ls %d)\n"), __FUNCTION__, this, pszRelation, ppUnkOfNewDataProvider);
	return hRes;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::GetRowCount(INT * pnRows)
{
	// D : Aufgerufen von LL. Anzahl der rows des SQL Statements bestimmen. Falls das Statement noch nicht initialisiert ist, erfolgt hier der entsprechende Aufruf.
	// US: Called by LL. Retrieve count of underlying statement. If not yet done, statement needs to be initialized here.
	if (InitStatement() && _count == -1)
	{
		CDPString countSQL = SQLiteHelp::xsprintf(L"select count(*) from %ls %ls;",
												  _sqlparms._from.c_str(),
												  _sqlparms._where.c_str());
		_count = SQLiteRow(SQLiteStatement(*_PM.GetConnection(), countSQL.c_str()), 1).GetInt();
	}
	*pnRows = _count;
	XTRACE(_T("<<%hs (%d -> %d)\n"), __FUNCTION__, this, _count);
	return S_OK;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::DefineDelayedInfo(enDefineDelayedInfo nInfo)
{
	// D : Aufgerufen von LL. Hier werden bei gesetztem LL_OPTION_SUPPORT_DELAYEDFIELDDEFINITION z.B. die Sortierungen angemeldet.
	// US: Called by LL. If LL_OPTION_SUPPORT_DELAYEDFIELDDEFINITION is active, e.g. the sort orders will be defined here.
	XTRACE(_T("<<%hs %ls (%ls)\n"), __FUNCTION__, DebugStrHlpGetDelayedInfo(nInfo).c_str(), name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
	
	auto lDefineSortOrder = [&](const CDPString& sTableName, const CDPString& sFieldName, bool bAscending)
	{
		CDPString sSortName = sFieldName + (bAscending ? CDPString(L" ASC") : CDPString(L" DESC"));
		CDPString sSortDisplayName = sFieldName + (bAscending ? CDPString(L" [+]") : CDPString(L" [-]"));
		::LlDbAddTableSortOrderEx(_JobHandle, sTableName.c_str(), sSortName.c_str(), sSortDisplayName.c_str(), sFieldName.c_str());
	};

	switch (nInfo)
	{
	case ILLDataProvider::DELAYEDINFO_SORTORDERS_DESIGNING: 
	case ILLDataProvider::DELAYEDINFO_SORTORDERS_PRINTING: 
		{
			auto pTableRec = _PM.GetSchema().GetTableRecord(_relation);
			if (pTableRec)
			{
				for (auto& column_rec : pTableRec->_columns)
				{
					CDPString field_name = SQLiteHelp::xsprintf(L"%ls.%ls", pTableRec->_table_name.c_str(), column_rec._column_name.c_str());
					if (SQLiteHelp::check_enabled(column_rec._uFlags, CDPSchema::E_FLAG_GEN_SORTASC, true))
						lDefineSortOrder(pTableRec->_table_name, field_name, true);
					if (SQLiteHelp::check_enabled(column_rec._uFlags, CDPSchema::E_FLAG_GEN_SORTDESC, true))
						lDefineSortOrder(pTableRec->_table_name, field_name, false);
				}
			}
		}
		break;
	default:
		ASSERT(false);
		return E_FAIL;
	}
	return S_OK;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::MoveNext()
{
	// D : Aufgerufen von LL. Den Cursor des SQL Statements weitersetzen und Datensatz lesen. Falls das Statement noch nicht initialisiert ist, erfolgt hier der entsprechende Aufruf.
	// US: Called by LL. Advance cursor of underlying sql statement and retrieve data record. If not yet done, statement needs to be initialized here.
	XTRACE(_T(">>%hs (%ls)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
	_record = SQLiteRecord();
	try
	{
		if (InitStatement() && _statement->Step())
		{
			_record = SQLiteRecord(SQLiteRow(_statement->GetAbi()));
			return S_OK;
		}
		else
			return S_FALSE;
	}
	catch (SQLiteException& e)
	{
		_PM.ShowMessageBox(e._message);
	}
	return E_FAIL;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::DefineRow(enDefineRowMode nDefineRowMode, const VARIANT* /*arvRelations*/)
{
	// D : Aufgerufen von LL. Die Daten des aktuell gelesenen Datensatzes werden hier bei LL angemeldet.
	// US: Called by LL. Define Data of current available record within LL.
	XTRACE(_T(">>%hs (%ls)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
	HRESULT hRes = E_FAIL;

	try
	{
		if (!_statement)
		{
			XTRACE(_T("%hs uninitialized statement %s, force call of MoveNext\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
			MoveNext();
		}

		CDPSchema::CTableRecord* pTabSchema = _PM.GetSchema().GetTableRecord(_name);
		if (nDefineRowMode & ROWMODE_OWN_COLUMNS)
		{
			for (int i = 0; i < _record.GetRecordColumnCount(); ++i)
			{
				CDPSchema::CColumnRecord* pColSchema = _PM.GetSchema().GetColumnRecord(_name, _record.GetRecordColumnName(i));
				ASSERT(pTabSchema && pColSchema);
				if (pColSchema)
				{
					CDPString field_name = SQLiteHelp::xsprintf(L"%ls.%ls", _name.c_str(), pColSchema->_column_name.c_str());
					auto pVal = _record.getValue(pColSchema->_aliased_column_name);
					if (!pVal)
						pVal = _record.getValue(pColSchema->_column_name);
					CDPString field_default = pVal ? CDPSchema::Convert2LLColumnWideString(pColSchema->_lltype, *pVal) : L"";
					XTRACE(_T("%hs LlDefineFieldExt %ls %ls\n"), __FUNCTION__, field_name.c_str(), field_default.c_str());
					if (SQLiteHelp::check_enabled(pTabSchema->_uFlags, CDPSchema::E_FLAG_TAB_VARIABLE, true))
						::LlDefineVariableExt(_JobHandle, field_name.c_str(), field_default.c_str(), pColSchema->_lltype, NULL);
					else
						::LlDefineFieldExt(_JobHandle, field_name.c_str(), field_default.c_str(), pColSchema->_lltype, NULL);
					hRes = S_OK;
				}
			}
		}
		if (nDefineRowMode & ROWMODE_1TO1_COLUMNS)
		{
			// currently no direct 1TO1_COLUMNS support implemented yet...
			hRes = S_OK;
		}
	}
	catch (SQLiteException& e)
	{
		_PM.ShowMessageBox(e._message);
	}

	return hRes;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::Dispose()
{
	// D : Aufgerufen von LL. Nicht benötigte Ressourcen können hier wieder freigegeben werden.
	// US: Called by LL. Cleanup if necessary.
	HRESULT hRes = S_OK;
	XTRACE(_T("<<%hs (%ls)\n"), __FUNCTION__, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
	return hRes;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::SetUsedIdentifiers(const VARIANT * arvFieldRestriction)
{
	// D : Aufgerufen von LL. Lediglich die hier empfangenen Felder werden von LL angefragt werden. Das SQL Statement kann auf diese Felder beschränkt werden.
	// US: Called by LL. Only received fields will be queried by LL later. Therefore the underlying sql statement might be restricted to those fields.
	_usedIdentifiers.clear();
	for (int i = 0; i < int(arvFieldRestriction->parray->rgsabound[0].cElements); ++i)
	{
		VARIANT vItem;
		long lIndex = i;
		SafeArrayGetElement(arvFieldRestriction->parray, &lIndex, &vItem);
		std::wstring ws(vItem.bstrVal, SysStringLen(vItem.bstrVal));
		_usedIdentifiers.insert(ws.c_str());
	}
	
	auto getUIDString = [&]() {
		std::wstring ws; 
		for (auto& e : _usedIdentifiers)
			ws += ws.empty() ? e : SQLiteHelp::xsprintf(L",%s", e.c_str());
		return ws;
	};

	XTRACE(_T("<<%hs %ls (%ls)\n"), __FUNCTION__, getUIDString().c_str(), name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
	return S_OK;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::ApplySortOrder(LPCWSTR pszSortOrder)
{
	// D : Aufgerufen von LL. Empfängt TAB getrennte Zeichenkette mit den verwendeten Sortierungen. Diese sollten im SQL Statement verwendet werden.
	// US: Called by LL. Receives tab seperated string containing the used sort definitions. These have to be used when building the sql statement.
	HRESULT hRes = S_OK;
	_sqlparms._orderby = pszSortOrder;
	std::replace(_sqlparms._orderby.begin(), _sqlparms._orderby.end(), L'\t', L',');
	XTRACE(_T("<<%hs %ls (%ls)\n"), __FUNCTION__, pszSortOrder, name(CPrintDataProvider::E_DEBUG_TRACE).c_str());
	return hRes;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::ApplyFilter(const VARIANT * arvFields, const VARIANT * arvValues)
{
	return CallToEmptyImplementation(__FUNCTION__, arvFields, arvValues);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::ApplyAdvancedFilter(LPCWSTR pszFilter, const VARIANT * arvValues)
{
	return CallToEmptyImplementation(__FUNCTION__, pszFilter, arvValues);
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::SetOption(enOptionIndex nIndex, const VARIANT * vValue)
{
	// D : Aufgerufen von LL. Wird benutzt zur Übergabe von Zusatzinformationen.
	// US: Called by LL. Used to transfer additional informations.

	CDPString sValStr;
	switch (nIndex)
	{
	case OPTION_HINT_ADVANCEDFILTER_IS_CACHED:
		_opts._optHintAdvancedFilterIsCached = vValue ? vValue->iVal != 0 ? true : false : false;
		sValStr = SQLiteHelp::xsprintf(L",%d", INT(vValue->iVal));
		break;
	case OPTION_HINT_MAXROWS:
		_opts._optHintMaxRows = vValue ? vValue->iVal : 0;
		sValStr = SQLiteHelp::xsprintf(L",%d", INT(vValue->iVal));
		break;
	case OPTION_HINT_IS_INFO_QUERY:
		_opts._optHintIsInfoQuery = vValue ? vValue->iVal != 0 ? true : false : false;
		sValStr = SQLiteHelp::xsprintf(L",%d", INT(vValue->iVal));
		break;
	default:
		ASSERT(FALSE);
	}
	XTRACE(_T("<<%hs %ls (%ls) %s\n"), __FUNCTION__, DebugStrHlpGetOption(nIndex).c_str(), name(CPrintDataProvider::E_DEBUG_TRACE).c_str(), sValStr.c_str());
	return S_OK;
}
//---------------------------------------------------------------------
STDMETHODIMP CPrintDataProviderNode::GetOption(enOptionIndex nIndex, VARIANT * vValue)
{
	HRESULT hRes = S_OK;
	switch (nIndex)
	{
	case ILLDataProvider::OPTION_SCHEME_AND_DEFAULTS:
		{
			bool bSupportSchemaRowUsageMode = false; // currently no SCHEMAROWUSAGEMODE optimizations implemented yet, so we don't use it...
			auto pJDR = _PM.JobFromHandle(_JobHandle);
			if (pJDR && vValue)
			{
				vValue->vt = VT_UI4;
				if(bSupportSchemaRowUsageMode)
					vValue->ulVal = _PM.bIsPrinting(_JobHandle) ? OPTION_SCHEMAROWUSAGEMODE_PRINT : OPTION_SCHEMAROWUSAGEMODE_DESIGN;
				else
					vValue->ullVal = OPTION_SCHEMAROWUSAGEMODE_NONE;
			}
		}
		break;
	case ILLDataProvider::OPTION_SUPPORTED_AS_1_TO_1_RELATION:
		{
			hRes = S_FALSE;
			bool bSupport1To1Columns = false; // currently no direct 1TO1_COLUMNS support implemented yet, so we don't use it...
			if (bSupport1To1Columns)
			{
				auto ws = vValue->bstrVal ? std::wstring(vValue->bstrVal, SysStringLen(vValue->bstrVal)) : std::wstring();
				auto pRel = _PM.GetSchema().GetRelationRecord(ws.c_str());
				if (pRel && pRel->_is1To1Rel)
					hRes = S_OK;
			}
		}
		break;
	default:
		ASSERT(FALSE);
	}
	XTRACE(_T("<<%hs %ls (%ls) -> %d\n"), __FUNCTION__, DebugStrHlpGetOption(nIndex).c_str(), name(CPrintDataProvider::E_DEBUG_TRACE).c_str(), hRes);
	return hRes;;
}

///////////////////////////////////////////////////////////////////////
// CPrintManager
//
///////////////////////////////////////////////////////////////////////
bool CPrintManager::CJobDataRec::bUseDelayedDefinition = true;

void CPrintManager::OpenDatabase()
{
	CDPSchema::CSchemaFilter& filter = _Schema.GetFilter();
	if (filter._bUseInMemoryDB)
	{
		// D:  Erzeuge eine SQLite Datenbank im Speicher. Anschließend umkopieren der existierenden Datenbankdatei per Backupfunktion.
		// US: Create an in memory SQLite database. Subsequently backup the data of existing file based database to the in memory db.
		_spDBConn.reset(new SQLiteConnection(SQLiteConnection::Memory()));
		if (!filter._databasepath.empty())
		{
			SQLiteConnection fileconn(_Schema.GetFilter()._databasepath.c_str(), false);
			SQLiteBackup(fileconn, *_spDBConn).Step();
			if (_Schema.GetFilter()._CustomDataInit.get())
				(*_Schema.GetFilter()._CustomDataInit)(this);
		}
	}
	else if (!filter._databasepath.empty())
	{
		// D:  Öffne existierende Datenbankdatei.
		// US: Open existing database file.
		_spDBConn.reset(new SQLiteConnection(_Schema.GetFilter()._databasepath.c_str(), false));
		ASSERT(_Schema.GetFilter()._CustomDataInit.get() == nullptr); // custom init only for in memory db, for security reasons
	}
}

void CPrintManager::CloseDatabase()
{
	_spDBConn.reset();
}

bool CPrintManager::Init(bool bReinit)
{
	if (bReinit)
		CloseDatabase();
	if (_spDBConn.get() == nullptr)
	{
		try
		{
			OpenDatabase();
			_Schema.FillSchema(*GetConnection());
		}
		catch (SQLiteException& e)
		{
			ShowMessageBox(e._message);
			CloseDatabase();
		}
	}
	return _spDBConn.get() != nullptr;
}

//---------------------------------------------------------------------
CPrintManager::CPrintManager() : _spDBConn(nullptr)
{
  _RDP._evThreadEvent.create(NULL, FALSE, FALSE, NULL);
}
//---------------------------------------------------------------------
CPrintManager::~CPrintManager()
{
  RDPThreadEnd();
  // delete unused dataproviders - should not happen, since already cleared by DoneJob
  for (auto& elem : _JobData)
  {
    elem._pDataProvider->Release();
    LlJobClose(elem._hJob);
  }
	CloseDatabase();
}
//---------------------------------------------------------------------
CPrintManager::CJobDataRec* CPrintManager::JobFromType(CJobType t)
{
	auto it = std::find_if(_JobData.begin(), _JobData.end(), [t](CJobDataRec& e) { return e._uJobType == t; });
	return it != _JobData.end() ? &(*it) : nullptr;
}
//---------------------------------------------------------------------
CPrintManager::CJobDataRec* CPrintManager::JobFromHandle(INT h)
{
	auto it = std::find_if(_JobData.begin(), _JobData.end(), [h](CJobDataRec& e) { return e._hJob == h; });
	return it != _JobData.end() ? &(*it) : nullptr;
}
//---------------------------------------------------------------------
INT CPrintManager::InitJob(CJobDataRec& r)
{
	bool bClearExistingFirst = (r._uJobType == CPrintManager::CJobType::TYPE_DESIGN) || (r._uJobType == CPrintManager::CJobType::TYPE_PREVIEW);
	if (bClearExistingFirst)
	{
		auto pJDR = JobFromType(r._uJobType);
		if (pJDR)
			DoneJob(pJDR->_hJob);
	}
	ASSERT(r._hJob == 0 && r._pDataProvider);
	{
		CPM::CCritLock lk(_CritSect);
		r._hJob = LlJobOpen(CMBTLANG_DEFAULT);
	}
	ASSERT(r._hJob > 0);
	r._pDataProvider->SetJobHandle(r._hJob);
	_JobData.push_back(r);
	return r._hJob;
}
//---------------------------------------------------------------------
void CPrintManager::RunJob(INT hJob)
{
	PreJob(hJob);
	DoJob(hJob);
	DoneJob(hJob);
}
//---------------------------------------------------------------------
void CPrintManager::PreJob(INT hJob)
{
	CJobDataRec* pJDR = JobFromHandle(hJob);
	if (!pJDR)
		return;

  if (pJDR->_uJobType == CJobType::TYPE_PREVIEW)
  {
    CPM::LockedWrite(_RDP._bProcessing, true, _RDP._CritSec);
    _RDP._hJob = pJDR->_hJob;
    pJDR->_sFilename = _RDP._NtfyParms._ProjectFileName;
    ::LlAssociatePreviewControl(pJDR->_hJob, _RDP._NtfyParms._hWnd, 1);
  }

	//D: Datenprovider in LL setzen
	//US: Set dataprovider in LL
	::LlSetOption(pJDR->_hJob, LL_OPTION_ILLDATAPROVIDER, (LPARAM)pJDR->_pDataProvider);
	
	//D: Optional Delayload in LL aktivieren
	//US: Set delayload mode in LL
	::LlSetOption(pJDR->_hJob, LL_OPTION_SUPPORT_DELAYEDFIELDDEFINITION, pJDR->bUseDelayedDefinition ? 1 : 0);
	
	if (bIsPrinting(pJDR))
	{
		//D: UsedIdentifiers aus dem Projekt lesen, String splitten und in liste einfügen -> werden später in der Query verwendet
		//US: get UsedIdentifiers from project, splitting the string an add items to list -> will be used in query later
		pJDR->_usedIdentifiers.clear();
		INT nBuffer = LlGetUsedIdentifiers(pJDR->_hJob, pJDR->_sFilename.c_str(), NULL, 0);
		if (nBuffer > 0)
		{
			std::vector<TCHAR> VarListString;
			VarListString.assign(nBuffer + 2, 0);
			LlGetUsedIdentifiers(pJDR->_hJob, pJDR->_sFilename.c_str(), &VarListString[0], nBuffer + 1);
			auto VarListTokens = SQLiteHelp::strsplit(std::wstring(&VarListString[0]), L';');
			for (auto& sItem : VarListTokens)
				pJDR->_usedIdentifiers.insert(sItem);
		}
	}

	// D:   Zurücksetzen und definieren der internen Variablen-Puffer (in diesem Beispiel nicht verwendet)
	// US:	Clear and define the variable Buffer (not used in this example)
	LlDefineVariableStart(pJDR->_hJob);
	DefineFieldsOrVariables(pJDR, true);

	// D:   Zurücksetzen und definieren der internen Feld-Puffer
	// US:	Clear and define the field Buffer
	LlDefineFieldStart(pJDR->_hJob);
	DefineFieldsOrVariables(pJDR, false);
}
//---------------------------------------------------------------------
BOOL CPrintManager::DoJob(INT hJob)
{
	CJobDataRec* pJDR = JobFromHandle(hJob);
	if (!pJDR)
		return FALSE;

  // D:  Callback einhängen
  // US: Link with the callback
  ::LlSetOption(pJDR->_hJob, LL_OPTION_CALLBACKPARAMETER, (LONG) this);
  ::LlSetNotificationCallback(pJDR->_hJob, (FARPROC)LLCallbackProc);

  if(pJDR->_uJobType == CJobType::TYPE_DESIGN)
  {
    // D:  Diese variablen werden zur Kommunikation für den Echtdatenpreview im Designer benötigt
    // US: These variables are requred for communication of designer preview
    _RDP._PM = this;
    ::LlSetOption(pJDR->_hJob, LL_OPTION_DESIGNERPREVIEWPARAMETER, (LPARAM)&_RDP);
    ::LlSetOption(pJDR->_hJob, LL_OPTION_DESIGNEREXPORTPARAMETER, (LPARAM)&_RDP);

	// D:   Variablen und Tabellen sind angemeldet, also den Designer starten
    // US:	Variables and Tables are defined, so launch designer now
    INT nRet = LlDefineLayout(pJDR->_hJob, pJDR->_hWnd, _T("Designer"), LL_PROJECT_LIST, pJDR->_sFilename.c_str());
    if (nRet < 0)
    {
      CString sErrorText;
      sErrorText.Format(_T("Error by calling LlDefineLayout. (Error: %d)"), nRet);
      MessageBox(pJDR->_hWnd, sErrorText, _T("List & Label Sample App"), MB_OK | MB_ICONEXCLAMATION);
      return FALSE;
    }

	// deactivate preview feature
	::LlSetOption(pJDR->_hJob, LL_OPTION_DESIGNERPREVIEWPARAMETER, NULL);
	::LlSetOption(pJDR->_hJob, LL_OPTION_DESIGNEREXPORTPARAMETER, NULL);

    return TRUE;
  }

  int nRet = 0;

  // D:   Druck starten
  // US: Start printing
    nRet = LlPrintWithBoxStart(pJDR->_hJob, LL_PROJECT_LIST, SQLiteHelp::conv2wstr(pJDR->_sFilename).c_str(),
                               LL_PRINT_EXPORT,
							   LL_BOXTYPE_NONE, pJDR->_hWnd, _T("Printing..."));
  if (nRet < 0)
  {
    if (pJDR->_hWnd)
    {
      CString sErrorText;
      sErrorText.Format(_T("Error While Printing. (Error: %d)"), nRet);
      MessageBox(pJDR->_hWnd, sErrorText, _T("List & Label Sample App"), MB_OK | MB_ICONEXCLAMATION);
    }
    return FALSE;
  }

  // D:  Falls der Job mit Fensterhandle initialisiert wurde, hier den Optionsdialog vorschalten
  // US: If there is a hWnd associated with the Job, launch the options dialog first
  if (pJDR->_hWnd)
  {
    LlPrintSetOptionString(pJDR->_hJob, LL_PRNOPTSTR_EXPORT, _T("PRV"));
    if (LlPrintOptionsDialog(pJDR->_hJob, pJDR->_hWnd, _T("Select printing options")) < 0)
    {
      ::LlPrintAbort(pJDR->_hJob);
      ::LlPrintEnd(pJDR->_hJob, 0);
      return FALSE;
    }
  }

  // D:  Und nun die Druckschleife
  // US: Here we go with the printloop
  nRet = ::LlPrint(pJDR->_hJob);
  while (nRet == LL_WRN_REPEAT_DATA)
  {
    nRet = ::LlPrint(pJDR->_hJob); // magic happens in CPrintDataProvider[...]

    // stop printing if the lastpage (defined by LASTPAGE) is reached
    if (::LlPrintGetOption(pJDR->_hJob, LL_PRNOPT_PAGEINDEX) > ::LlPrintGetOption(pJDR->_hJob, LL_PRNOPT_LASTPAGE))
    {
      ::LlPrintSetOption(pJDR->_hJob, LL_PRNOPT_PARTIALPREVIEW, TRUE);
      ::LlPrintEnd(pJDR->_hJob, 0);
      return TRUE;
    }
    XTRACE(_T("State: %d"), nRet);
  }

  ::LlPrintEnd(pJDR->_hJob, 0);
  // error occurred?
  if (nRet != 0)
    return FALSE;
  return TRUE;
}
//---------------------------------------------------------------------
void CPrintManager::DoneJob(INT hJob)
{
	CJobDataRec* pJDR = JobFromHandle(hJob);
	if (!pJDR)
		return;

	if (pJDR->_uJobType == CJobType::TYPE_PREVIEW)
	{
		::DeleteFile(pJDR->_sFilename.c_str());
		::LlAssociatePreviewControl(pJDR->_hJob, NULL, 1);
    CPM::LockedWrite(_RDP._bProcessing, false, _RDP._CritSec);
    _RDP._hJob = 0;
	}

	// deactivate dataprovider in LL
	auto pDP = pJDR->_pDataProvider;
	::LlSetOption(pJDR->_hJob, LL_OPTION_ILLDATAPROVIDER, 0);
	_JobData.erase(std::find_if(_JobData.begin(), _JobData.end(), [hJob](CJobDataRec& e) { return e._hJob == hJob; }));
	ULONG uRefCount = pDP->Release();
	ASSERT(uRefCount == 0);
	{
		CPM::CCritLock lk(_CritSect);
		LlJobClose(pJDR->_hJob);
	}
}
//---------------------------------------------------------------------
INT  CPrintManager::GetJobHandle(CJobType t)
{
	CJobDataRec* pJDR = JobFromType(t);
	return pJDR ? pJDR->_hJob : 0;
}
//---------------------------------------------------------------------
SQLiteConnection* CPrintManager::GetConnection()
{
	return _spDBConn.get();
}
//---------------------------------------------------------------------
void CPrintManager::DefineFieldsOrVariables(CJobDataRec* pJDR, bool bVariables)
{
	ASSERT(pJDR);
	if (!pJDR)
		return;
	
	// D:   Lambda um eine Tabelle zu definieren. 
	// US:  Lambda to define a field.
	auto lDefineTable = [&](const CDPString& sName, const CDPString& sDisplayName, UINT uOptions, bool bMaster)
	{
		::LlDbAddTableEx(pJDR->_hJob, sName.c_str(), sDisplayName.c_str(), uOptions);
		if (bMaster)
			LlDbSetMasterTable(pJDR->_hJob, sName.c_str());
	};

	// D:   Lambda um eine Sortierung zu definieren.
	// US:  Lambda to define a sort order.
	auto lDefineSortOrder = [&](const CDPString& sTableName, const CDPString& sFieldName, bool bAscending)
	{
		// attn. in delayload mode sort orders will be defined dataprovider based
		bool bDoIt = !bUseDelayedDefinition(pJDR);  
		if (bDoIt)
		{
			CDPString sSortName = sFieldName + (bAscending ? CDPString(L" ASC") : CDPString(L" DESC"));
			CDPString sSortDisplayName = sFieldName + (bAscending ? CDPString(L" [+]") : CDPString(L" [-]"));
			::LlDbAddTableSortOrderEx(pJDR->_hJob, sTableName.c_str(), sSortName.c_str(), sSortDisplayName.c_str(), sFieldName.c_str());
		}
	};

	// D:   Lambda um ein Feld zu definieren. Im Designer müssen alle verfügbaren Felder definiert werden, im Druck dann nur die tatsächlich benutzten Felder
	// US:  Lambda to define a field. In designer all available fields need to be defined, only used ones in printing mode though.
	auto lDefineFieldOrVariable = [&](const CDPString& sName, const CDPString& sContent, INT lPara, LPVOID lpPtr)
	{
		// attn. in delayload mode fields and variables will be defined dataprovider based
		bool bDoIt = !bUseDelayedDefinition(pJDR) && (!bIsPrinting(pJDR) || (bIsPrinting(pJDR) && pJDR->_usedIdentifiers.find(sName) != pJDR->_usedIdentifiers.end()));
		if (bDoIt && bVariables)
			LlDefineVariableExt(pJDR->_hJob, sName.c_str(), sContent.c_str(), lPara, lpPtr);
		else if (bDoIt && !bVariables)
			LlDefineFieldExt(pJDR->_hJob, sName.c_str(), sContent.c_str(), lPara, lpPtr);
	};

	// D:   Lambda um die Relationen einer Tabelle zu definieren. 
	// US:  Lambda to define relations of a table.
	auto lDefineRelations = [&](CDPSchema::CTableRecord& sTableRec)
	{
		for (auto& relRec : sTableRec._relations)
		{
			std::wstring _relation_name = SQLiteHelp::xsprintf(L"%ls2%ls", relRec._related_table_name.c_str(), relRec._table_name.c_str());
			std::wstring _relation_dispname = relRec._related_table_name;
			::LlDbAddTableRelationEx(pJDR->_hJob, relRec._table_name.c_str(), relRec._related_table_name.c_str(), _relation_name.c_str(), _relation_dispname.c_str(), relRec._column_name.c_str(), relRec._related_column_name.c_str());
		}
	};
	
	if (bVariables) // only once
		lDefineTable(L"LLStaticTable", L"", 0, false);

	try
	{
		CDPSchema::CSchemaData& schema_records = _Schema.GetData();
		for (auto& schema_rec : schema_records)
		{
			bool bTakeIt = bVariables == SQLiteHelp::check_enabled(schema_rec._uFlags, CDPSchema::E_FLAG_TAB_VARIABLE, true);
			bool bMaster = SQLiteHelp::check_enabled(schema_rec._uFlags, CDPSchema::E_FLAG_TAB_MASTER, true);
			if (bTakeIt && schema_rec._numberOfElements)
			{
				lDefineTable(schema_rec._table_name, L"", LL_ADDTABLEOPT_SUPPORTSADVANCEDFILTERING | LL_ADDTABLEOPT_SUPPORTSSTACKEDSORTORDERS, bMaster);
				for (auto& column_rec : schema_rec._columns)
				{
					CDPString field_name = SQLiteHelp::xsprintf(L"%ls.%ls", schema_rec._table_name.c_str(),
						column_rec._column_name.c_str());
					lDefineFieldOrVariable(field_name, column_rec._column_default, column_rec._lltype, NULL);
					if (SQLiteHelp::check_enabled(column_rec._uFlags, CDPSchema::E_FLAG_GEN_SORTASC, true))
						lDefineSortOrder(schema_rec._table_name, field_name, true);
					if (SQLiteHelp::check_enabled(column_rec._uFlags, CDPSchema::E_FLAG_GEN_SORTDESC, true))
						lDefineSortOrder(schema_rec._table_name, field_name, false);
				}
			}
		}
		for (auto& schema_rec : schema_records)
		{
			bool bTakeIt = bVariables == SQLiteHelp::check_enabled(schema_rec._uFlags, CDPSchema::E_FLAG_TAB_VARIABLE, true);
			if (bTakeIt && schema_rec._numberOfElements)
				lDefineRelations(schema_rec);
		}
	}
	catch (cmbtSQL::SQLiteException& s)
	{
		ShowMessageBox(s._message);
	}
}
//---------------------------------------------------------------------
CDPSchema& CPrintManager::GetSchema()
{
	return _Schema;
}
//---------------------------------------------------------------------
bool CPrintManager::bIsPrinting(CJobDataRec* pJDR)
{
	ASSERT(pJDR);
	return pJDR ? (pJDR->_uJobType == CJobType::TYPE_PREVIEW || pJDR->_uJobType == CJobType::TYPE_PRINT) : false;
}
//---------------------------------------------------------------------
bool CPrintManager::bIsPrinting(INT hJob)
{
	return bIsPrinting(JobFromHandle(hJob));
}
//---------------------------------------------------------------------
bool CPrintManager::bUseDelayedDefinition(CJobDataRec* pJDR)
{
	ASSERT(pJDR);
	return pJDR ? pJDR->bUseDelayedDefinition : false;
}
//---------------------------------------------------------------------
bool CPrintManager::bUseDelayedDefinition(INT hJob)
{
	return bUseDelayedDefinition(JobFromHandle(hJob));
}
//---------------------------------------------------------------------
LRESULT CPrintManager::OnLLMessage(WPARAM wParam, LPARAM lParam)
{
	// D:   Dies ist die List & Label Callback Funktion.
	//     Saemtliche Rueckmeldungen bzw. Events werden dieser Funktion
	//     gemeldet.
	// US: This is the List & Label Callback function.
	//     Is is called for requests an notifications.
	LRESULT lRes = FALSE;
	switch (wParam)
	{
		case LL_NTFY_DESIGNERPRINTJOB:
			{
				scLlDesignerPrintJob* pscLRDDJ = (scLlDesignerPrintJob*)lParam;
				ASSERT(pscLRDDJ && pscLRDDJ->_nSize == sizeof(scLlDesignerPrintJob));
				lRes = OnNtfyRDPJob(pscLRDDJ);
			}
			break;
		default:
			break;
	}
	return lRes;
}
// ------------------------------------------------------------------------------
INT CPrintManager::OnNtfyRDPJob(scLlDesignerPrintJob* pscLRDDJ)
{
	ASSERT(pscLRDDJ);

	LRESULT lRes = FALSE;

	switch (pscLRDDJ->_nFunction)
	{
		//--------------------
	case LL_DESIGNERPRINTCALLBACK_EXPORT_START:
	case LL_DESIGNERPRINTCALLBACK_PREVIEW_START:
	{
		// wait for end of thread
		RDPThreadEnd();
		// copy all parms from notification
		_RDP._NtfyParms = RDP::NtfyParms{};
		_RDP._NtfyParms._ProjectFileName = pscLRDDJ->_pszProjectFileName;
		_RDP._NtfyParms._nPages = pscLRDDJ->_nPages;
		_RDP._NtfyParms._hWnd = pscLRDDJ->_hWnd;
		_RDP._NtfyParms._hEvent = pscLRDDJ->_hEvent;
		_RDP._NtfyParms._bPreview = pscLRDDJ->_nFunction == LL_DESIGNERPRINTCALLBACK_PREVIEW_START ? TRUE : FALSE;
		_RDP._NtfyParms._OriginalProjectFileName = pscLRDDJ->_pszOriginalProjectFileName;
		_RDP._NtfyParms._ExportFormat = pscLRDDJ->_pszExportFormat ? pscLRDDJ->_pszExportFormat : L"";
		_RDP._NtfyParms._bWithoutDialog = pscLRDDJ->_bWithoutDialog;
		// start the thread
		_RDP._Thread.create([this](){RDPThreadFunc(); });
    WaitForSingleObject(_RDP._evThreadEvent.getAbi(), INFINITE);
    ASSERT(CPM::LockedRead(_RDP._bThreadRunning, _RDP._CritSec) == true);
	}
	break;
	//--------------------
	case LL_DESIGNERPRINTCALLBACK_PREVIEW_ABORT:
	case LL_DESIGNERPRINTCALLBACK_EXPORT_ABORT:
	{
    CPM::CCritLock(_RDP._CritSec);
    if (_RDP._hJob != 0)
			::LlPrintAbort(_RDP._hJob);	// D: kein Fehlercheck - es könnte LL_ERR_PRINTING_JOB legal gemeldet werden...
	}
	break;
	//--------------------
	case LL_DESIGNERPRINTCALLBACK_PREVIEW_FINALIZE:
	case LL_DESIGNERPRINTCALLBACK_EXPORT_FINALIZE:
	{
    if (CPM::LockedRead(_RDP._bThreadRunning, _RDP._CritSec) == true)
    {
      {
        CPM::CCritLock(_RDP._CritSec);
        if (_RDP._hJob != 0)
          ::LlPrintAbort(_RDP._hJob);	// D:  kein Fehlercheck - es könnte LL_ERR_PRINTING_JOB legal gemeldet werden...
      }
      WaitForSingleObject(_RDP._evThreadEvent.getAbi(), INFINITE);
      ASSERT(CPM::LockedRead(_RDP._bThreadRunning, _RDP._CritSec) == false);
    }
	}
	break;
	case LL_DESIGNERPRINTCALLBACK_PREVIEW_QUEST_JOBSTATE:
	{
    return CPM::LockedRead(_RDP._bProcessing, _RDP._CritSec) ? LL_DESIGNERPRINTTHREAD_STATE_RUNNING : LL_DESIGNERPRINTTHREAD_STATE_STOPPED;
	}
	break;


	default:
		break;

	};

	return lRes;
}
// ------------------------------------------------------------------------------
// D:  Dies ist der Thread der im Hintergrund für Designer Echtdatenvorschau zuständig ist
// US: This is the thread resposible for creating the designer realdata preview
unsigned int CPrintManager::RDPThreadFunc()
{
	CPM::LockedWrite(_RDP._bThreadRunning, true, _RDP._CritSec);
	SetEvent(_RDP._evThreadEvent.getAbi());
	CPrintManager::CJobDataRec JR;
	JR._uJobType = CPrintManager::CJobType::TYPE_PREVIEW;
	JR._pDataProvider = new CPrintDataProviderRoot(*this, 0);
	InitJob(JR);
	RunJob(JR._hJob);
	CPM::LockedWrite(_RDP._bThreadRunning, false, _RDP._CritSec);
	SetEvent(_RDP._evThreadEvent.getAbi());
	return 0;
}

//---------------------------------------------------------------------
void CPrintManager::RDPThreadEnd()
{
  if (CPM::LockedRead(_RDP._bThreadRunning, _RDP._CritSec) == true)
  {
    WaitForSingleObject(_RDP._evThreadEvent.getAbi(), INFINITE);
    ASSERT(CPM::LockedRead(_RDP._bThreadRunning, _RDP._CritSec) == false);
  }
  ResetEvent(_RDP._evThreadEvent.getAbi());
  CPM::LockedWrite(_RDP._bThreadRunning, false, _RDP._CritSec);
  CPM::LockedWrite(_RDP._bProcessing, false, _RDP._CritSec);
  _RDP._Thread.close();
}


//---------------------------------------------------------------------
bool CDPSchema::CSchemaFilter::match(EMatchType type, const CDPString& sValue) const
{
	// D : Regelbasiertes matching für Zeichenketten. Der erste gefundene passende Eintrag bestimmt das Ergebnis.
	// US: Rule based match of strings. First match will be used to determine result.
	bool ret = false;
	bool bMatch = false;
	// split the comma delimited rule set
	std::vector<CDPString> rules;
	switch (type)
	{
	case MT_DATABASE:
		ASSERT(0); // not supported yet
		break;
	case MT_TABLE:
		rules = SQLiteHelp::strsplit(_tablefilt, L',');
		break;
	case MT_COLUMN:
		rules = SQLiteHelp::strsplit(_columnfilt, L',');
		break;
	case MT_SORTASC:
		rules = SQLiteHelp::strsplit(_sortfiltasc, L',');
		break;
	case MT_SORTDESC:
		rules = SQLiteHelp::strsplit(_sortfiltdesc, L',');
		break;
	case MT_VARTABLE:
		rules = SQLiteHelp::strsplit(_vartables, L',');
		break;
	case MT_MASTERTABLE:
		rules = SQLiteHelp::strsplit(_mastertable, L',');
		break;
	}
	for (auto rule : rules)
	{
		if (bMatch)
			break;
		// ignore spaces, and pick the operator (+ or -)
		rule = std::regex_replace(rule, std::wregex(L" "), CDPString(L""));
		if (rule.length() > 0)
		{
			wchar_t op = rule[0];
			ASSERT(op == L'+' || op == L'-');
			rule = rule.substr(1);
			// transform * to .+ and pass it to regex
			rule = std::regex_replace(rule, std::wregex(L"\\*"), CDPString(L".*"));
			bMatch = regex_match(sValue, std::wregex(rule));
			// and determine result upon match
			if (bMatch)
				ret = op == L'+' ? true : false;
		}
	}
	return ret;
}
//---------------------------------------------------------------------
int CDPSchema::FillSchema(SQLiteConnection& conn, bool bFillDefaults)
{
	CSchemaData& table_records = GetData();
	CSchemaFilter& filter = GetFilter();
	// grab the tablenames and relations from schema
	table_records.clear();
	int sCount = SQLiteRow(SQLiteStatement(conn, L"select count(*) from sqlite_master where type = 'table';"), 1).GetInt();
	table_records.reserve(sCount);
	for (auto stmt_master : SQLiteStatement(conn, L"select name, sql from sqlite_master where type = 'table';"))
	{
		SQLiteRecord db_schema_record(stmt_master);
		bool bMatchingTable = filter.match(CSchemaFilter::MT_TABLE, db_schema_record.getValue(L"name")->asWideText().c_str());
		if (bMatchingTable)
		{
			table_records.emplace_back();
			CTableRecord& tr = table_records.back();
			tr._table_name = db_schema_record.getValue(L"name")->asWideText();
			tr._sql = db_schema_record.getValue(L"sql")->asWideText();
			tr._numberOfElements = SQLiteRow(SQLiteStatement(conn, SQLiteHelp::xsprintf(L"select count(*) from %ls;", tr._table_name.c_str())), 1).GetInt();
			tr._uFlags |= filter.match(CSchemaFilter::MT_VARTABLE, tr._table_name.c_str()) ? CDPSchema::E_FLAG_TAB_VARIABLE : 0;
			tr._uFlags |= filter.match(CSchemaFilter::MT_MASTERTABLE, tr._table_name.c_str()) ? CDPSchema::E_FLAG_TAB_MASTER : 0;
			// parse the sqlite foreign_key_list pragma for relations
			{
				for (auto pr : cmbtSQL::SQLiteStatement(conn, SQLiteHelp::xsprintf(L"PRAGMA foreign_key_list(%s);", tr._table_name.c_str())))
				{
					SQLiteRecord inforec(pr);
					CRelationRecord relRec{ L"", tr._table_name, inforec.getValue(L"from")->asWideText(), inforec.getValue(L"table")->asWideText(), inforec.getValue(L"to")->asWideText(), false};
					relRec._relation_name = SQLiteHelp::xsprintf(L"%ls2%ls", relRec._related_table_name.c_str(), relRec._table_name.c_str());

					bool bMatchingColumn = filter.match(CSchemaFilter::MT_COLUMN, SQLiteHelp::xsprintf(L"%ls.%ls", relRec._table_name.c_str(), relRec._column_name.c_str()));
					bool bMatchingRelatedColumn = filter.match(CSchemaFilter::MT_COLUMN, SQLiteHelp::xsprintf(L"%ls.%ls", relRec._related_table_name.c_str(), relRec._related_column_name.c_str()));
					if (bMatchingColumn && bMatchingRelatedColumn)
					{
						auto pCurrentRel = GetRelationRecord(relRec._relation_name);
						if (!pCurrentRel) // first entry
						{
							tr._relations.push_back(relRec);
							//XTRACE(_T("%hs added relation %ls %ls %ls %ls %ls\n"), __FUNCTION__, relRec._relation_name.c_str(), relRec._table_name.c_str(), relRec._column_name.c_str(), relRec._related_table_name.c_str(), relRec._related_column_name.c_str());
						}
						else // multi column
						{
							pCurrentRel->_column_name += SQLiteHelp::xsprintf(L"\t%ls", relRec._column_name.c_str());
							pCurrentRel->_related_column_name += SQLiteHelp::xsprintf(L"\t%ls", relRec._related_column_name.c_str());
							//XTRACE(_T("%hs added to relation %ls %ls %ls %ls %ls\n"), __FUNCTION__, relRec._relation_name.c_str(), relRec._table_name.c_str(), relRec._column_name.c_str(), relRec._related_table_name.c_str(), relRec._related_column_name.c_str());
						}
					}
				}
			}

			// parse the sqlite table_info pragma for columns and datatypes
			{
				for (auto pr : cmbtSQL::SQLiteStatement(conn, SQLiteHelp::xsprintf(L"PRAGMA table_info(%ls);", tr._table_name.c_str())))
				{
					SQLiteRecord inforec(pr);
					CDPString sFiltKey = SQLiteHelp::xsprintf(L"%ls.%ls", tr._table_name.c_str(), inforec.getValue(L"name")->asWideText().c_str());
					bool bMatchingColumn = filter.match(CSchemaFilter::MT_COLUMN, sFiltKey);
					if (bMatchingColumn)
					{
						CColumnRecord col;
						col._column_name = inforec.getValue(L"name")->asWideText();
						col._aliased_column_name = SQLiteHelp::xsprintf(L"%ls$%ls", tr._table_name.c_str(), col._column_name.c_str());
						col._column_createtype_str = inforec.getValue(L"type")->asWideText();
						col._lltype = CDPSchema::LLTypeFromSQLiteSchemaType(col._column_createtype_str);
						col._uFlags |= inforec.getValue(L"notnull")->asInt() != 0 ? CDPSchema::E_FLAG_COL_NOTNULL : 0;
						col._uFlags |= inforec.getValue(L"pk")->asInt() != 0 ? CDPSchema::E_FLAG_COL_PK : 0;
						col._uFlags |= filter.match(CSchemaFilter::MT_SORTASC, sFiltKey) ? CDPSchema::E_FLAG_GEN_SORTASC : 0;
						col._uFlags |= filter.match(CSchemaFilter::MT_SORTDESC, sFiltKey) ? CDPSchema::E_FLAG_GEN_SORTDESC : 0;
						tr._columns.push_back(col);
					}
				}
			}

			// grab the first entry of each table for default values
			if (bFillDefaults)
			{

				SQLiteStatement stmt_table(conn, SQLiteHelp::xsprintf(L"select * from %ls;", tr._table_name.c_str()));
				if (stmt_table.Step())
				{
					SQLiteRecord table_rec(SQLiteRow(stmt_table.GetAbi()));
					for (int i = 0; i < table_rec.GetRecordColumnCount(); i++)
					{
						auto itCol = std::find_if(tr._columns.begin(), tr._columns.end(), [&](CColumnRecord& elem)->bool{ return _wcsicmp(table_rec.GetRecordColumnName(i).c_str(), elem._column_name.c_str()) == 0; });
						if (itCol != tr._columns.end())
						{
							itCol->_dbvalue = table_rec.GetRecordColumn(i);
							itCol->_column_default = CDPSchema::Convert2LLColumnWideString(itCol->_lltype, itCol->_dbvalue);
						}
					}
				}
			}
		}
	}
	return table_records.size();
}
//---------------------------------------------------------------------
int CDPSchema::LLTypeFromSQLiteSchemaType(const CDPString& str)
{
	using elem_type = std::pair < CDPString, unsigned > ;
	static std::vector<elem_type> __LLTypeMap
	{
		std::pair<CDPString, unsigned>(L"INT", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"INTEGER", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"TINYINT", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"SMALLINT", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"MEDIUMINT", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"BIGINT", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"UNSIGNED +BIG +INT", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"INT2", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"INT8", LL_NUMERIC_INTEGER),
		std::pair<CDPString, unsigned>(L"CHARACTER", LL_TEXT),
		std::pair<CDPString, unsigned>(L"VARCHAR", LL_TEXT),
		std::pair<CDPString, unsigned>(L"VARYING +CHARACTER", LL_TEXT),
		std::pair<CDPString, unsigned>(L"NCHAR", LL_TEXT),
		std::pair<CDPString, unsigned>(L"NATIVE +CHARACTER", LL_TEXT),
		std::pair<CDPString, unsigned>(L"NVARCHAR", LL_TEXT),
		std::pair<CDPString, unsigned>(L"TEXT", LL_TEXT),
		std::pair<CDPString, unsigned>(L"CLOB", LL_TEXT),
		std::pair<CDPString, unsigned>(L"REAL", LL_NUMERIC),
		std::pair<CDPString, unsigned>(L"DOUBLE", LL_NUMERIC),
		std::pair<CDPString, unsigned>(L"DOUBLE PRECISION", LL_NUMERIC),
		std::pair<CDPString, unsigned>(L"FLOAT", LL_NUMERIC),
		std::pair<CDPString, unsigned>(L"NUMERIC", LL_NUMERIC),
		std::pair<CDPString, unsigned>(L"DECIMAL", LL_NUMERIC),
		std::pair<CDPString, unsigned>(L"BOOLEAN", LL_BOOLEAN),
		std::pair<CDPString, unsigned>(L"DATE", LL_DATE_MS),
		std::pair<CDPString, unsigned>(L"DATETIME", LL_DATE_MS),
		std::pair<CDPString, unsigned>(L"BLOB", LL_TEXT)
	};

	// sort longest first upon first call to catch INT/INTEGER problem ;-)
	static bool bFirst = true;
	if (bFirst)
	{
		bFirst = false;
		std::sort(__LLTypeMap.begin(), __LLTypeMap.end(), std::function<bool(const elem_type&, const elem_type&)>([](const elem_type& e1, const elem_type& e2){ return e1.first.length() > e2.first.length(); }));
	}
	auto it = std::find_if(__LLTypeMap.begin(), __LLTypeMap.end(), std::function<bool(const elem_type&)>([&](const elem_type& elem){ return std::regex_search(str, std::wregex(elem.first)); }));
	return it != __LLTypeMap.end() ? it->second : LL_TEXT;
}
//---------------------------------------------------------------------
std::wstring CDPSchema::Convert2LLColumnWideString(const unsigned ExpectedLLType, const SQLiteVariant& RetrievedDBvalue)
{
	std::wstring result;
	switch (ExpectedLLType)
	{
	case LL_DATE_MS:
	{
		COleDateTime dtm;
		auto txt = RetrievedDBvalue.asWideText();
		dtm.ParseDateTime(txt.c_str());
		result = SQLiteHelp::xsprintf(L"%f", (DATE)dtm).c_str();
	}
	break;
	case LL_BOOLEAN:
		result = RetrievedDBvalue.asInt() != 0 ? L".T." : L".F.";
		break;
	default:
		result = RetrievedDBvalue.asWideText();
		break;
	}
	return result;
}
//---------------------------------------------------------------------
std::string CDPSchema::Convert2LLColumnString(const unsigned ExpectedLLType, const SQLiteVariant& RetrievedDBvalue)
{
	return SQLiteHelp::conv2str(Convert2LLColumnWideString(ExpectedLLType, RetrievedDBvalue));
}
//---------------------------------------------------------------------
std::wstring CDPSchema::Convert2DBSQLWideString(const unsigned ExpectedLLType, const SQLiteVariant& RetrievedDBvalue, bool bAddQuotes)
{
	std::wstring sQuote = bAddQuotes && (ExpectedLLType == LL_NUMERIC_INTEGER || ExpectedLLType == LL_NUMERIC) ? L"\'" : L"";
	std::wstring result = SQLiteHelp::xsprintf(L"%s%s%s", sQuote.c_str(), RetrievedDBvalue.asWideText().c_str(), sQuote.c_str());
	return result;
}
//---------------------------------------------------------------------
std::string CDPSchema::Convert2DBSQLString(const unsigned ExpectedLLType, const SQLiteVariant& RetrievedDBvalue, bool bAddQuotes)
{
	return SQLiteHelp::conv2str(Convert2DBSQLWideString(ExpectedLLType, RetrievedDBvalue, bAddQuotes));
}
//---------------------------------------------------------------------
CDPSchema::CTableRecord* CDPSchema::GetTableRecord(const CDPString& sTableName)
{
	CSchemaData& table_records = GetData();
	CTableRecord* ret = nullptr;
	auto pred = std::function<bool(CTableRecord&)>([&](CTableRecord& elem){ return _wcsicmp(elem._table_name.c_str(), sTableName.c_str()) == 0; });
	auto it = std::find_if(table_records.begin(), table_records.end(), pred);
	if (it != table_records.end())
		ret = &(*it);
	return ret;
}
//---------------------------------------------------------------------
CDPSchema::CColumnRecord* CDPSchema::GetColumnRecord(const CDPString& sTableName, const CDPString& sColumnName)
{
	CColumnRecord* ret = nullptr;
	CTableRecord* pTR = GetTableRecord(sTableName);
	if (pTR)
	{
		auto pred = std::function<bool(CColumnRecord&)>([&](CColumnRecord& elem){ return (_wcsicmp(elem._column_name.c_str(), sColumnName.c_str()) == 0) ||
														(_wcsicmp(elem._aliased_column_name.c_str(), sColumnName.c_str()) == 0); });
		auto it = std::find_if(pTR->_columns.begin(), pTR->_columns.end(), pred);
		if (it != pTR->_columns.end())
			ret = &(*it);
	}
	return ret;
}
//---------------------------------------------------------------------
CDPSchema::CRelationRecord* CDPSchema::GetRelationRecord(const CDPString& sRelationKey)
{
	CSchemaData& table_records = GetData();
	CRelationRecord* ret = nullptr;
	for (auto it = table_records.begin(); ret == nullptr && it != table_records.end(); ++it)
	{
		auto rit = std::find_if(it->_relations.begin(), it->_relations.end(), [&](CRelationRecord& elem)->bool { return _wcsicmp(elem._relation_name.c_str(), sRelationKey.c_str()) == 0; });
		if (rit != it->_relations.end())
			ret = &*rit;
	}
	return ret;
}
//---------------------------------------------------------------------
CDPSchema::CSchemaData& CDPSchema::GetData()
{
	return _data;
}
//---------------------------------------------------------------------
CDPSchema::CSchemaFilter& CDPSchema::GetFilter()
{
	return _filter;
}

//---------------------------------------------------------------------
CDPString DebugStrHlpGetOption(ILLDataProvider::enOptionIndex nIdx)
{
	switch (nIdx)
	{
	case ILLDataProvider::OPTION_LAST_ERROR: return L"OPTION_LAST_ERROR";
	case ILLDataProvider::OPTION_SCHEME_AND_DEFAULTS: return L"OPTION_SCHEME_AND_DEFAULTS";
	case ILLDataProvider::OPTION_QUERY_THREADED_ACCESS: return L"OPTION_QUERY_THREADED_ACCESS";
	case ILLDataProvider::OPTION_HINT_ADVANCEDFILTER_IS_CACHED: return L"OPTION_HINT_ADVANCEDFILTER_IS_CACHED";
	case ILLDataProvider::OPTION_HINT_DISTINCT: return L"OPTION_HINT_DISTINCT";
	case ILLDataProvider::OPTION_SUPPORTED_AS_1_TO_1_RELATION: return L"OPTION_SUPPORTED_AS_1_TO_1_RELATION";
	case ILLDataProvider::OPTION_HINT_IS_INFO_QUERY: return L"OPTION_HINT_IS_INFO_QUERY";
	case ILLDataProvider::OPTION_HINT_MAXROWS: return L"OPTION_HINT_MAXROWS";

	}
	ASSERT(FALSE);
	return SQLiteHelp::xsprintf(L"%d", int(nIdx));
}
//---------------------------------------------------------------------
CDPString DebugStrHlpGetDelayedInfo(ILLDataProvider::enDefineDelayedInfo nInfo)
{
	switch (nInfo)
	{
		case ILLDataProvider::DELAYEDINFO_SORTORDERS_DESIGNING: return L"DELAYEDINFO_SORTORDERS_DESIGNING";
		case ILLDataProvider::DELAYEDINFO_SORTORDERS_PRINTING: return L"DELAYEDINFO_SORTORDERS_PRINTING";
	}
	ASSERT(FALSE);
	return SQLiteHelp::xsprintf(L"%d", nInfo);
}
//---------------------------------------------------------------------

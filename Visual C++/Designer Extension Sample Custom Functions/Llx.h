#pragma once

// combit module Headers
#ifndef CTRLRESVER
 #define CTRLRESVER 28
#endif

#include <list>
#include <comdef.h>
#include "..\cmbtLL28.h"
#include "LL28interf_designer_extension.h"

class LlXFct;

class LlFctList
	: public std::list<LlXFct*>
	{
	public:
		virtual ~LlFctList();
		LlFctList& operator = (const LlFctList&);
		
		void					Clear();
	};

class LlXBase
	: public ILlXInterface
	{
	private:
		INT						_nRef;
		LlFctList				_FctList;
	public:
								LlXBase(LlFctList&);
		virtual					~LlXBase(void);

		STDMETHODIMP 			QueryInterface(REFIID riid, VOID** ppv);
		STDMETHODIMP_(ULONG) 	AddRef(void);
		STDMETHODIMP_(ULONG) 	Release(void);
	};

class LlXEnumFunctions
	: public ILlXEnumFunctions
	{
	private:
		INT								_nRef;
		LlFctList::const_iterator		_iter;
		LlFctList						_FctList;

	public:
								LlXEnumFunctions(LlFctList&);
		virtual					~LlXEnumFunctions(void);

		STDMETHODIMP 			QueryInterface(REFIID riid, VOID** ppv);
		STDMETHODIMP_(ULONG) 	AddRef(void);
		STDMETHODIMP_(ULONG) 	Release(void);

        STDMETHODIMP			Next(ULONG, ILlXFunction**, ULONG *); // reminder: objects returned have a ref count of 1
        STDMETHODIMP			Skip(ULONG);
        STDMETHODIMP			Reset(void);
        STDMETHODIMP			Clone(ILlXEnumFunctions **);
	};


class LlXFct
	: public ILlXFunction
	{
	private:
		INT						_nRef;
		HLLJOB					_hLLJob;
		ILlBase* 				_pLLBase;
		INT						_nLanguage;
	protected:
		BOOL					_bDesigntime;
	public:
								LlXFct(void);
		virtual					~LlXFct(void);

		STDMETHODIMP 			QueryInterface(REFIID riid, VOID** ppv);
		STDMETHODIMP_(ULONG) 	AddRef(void);
		STDMETHODIMP_(ULONG) 	Release(void);

		STDMETHODIMP			SetLLJob(HLLJOB hLLJob, ILlBase* pLLBase);

        STDMETHOD(SetOption)(INT nOption, INT_PTR nValue);
        STDMETHOD(GetOption)(INT nOption, INT_PTR* pnValue);
        STDMETHOD(GetName)(BSTR* pbsName);
        STDMETHOD(GetDescr)(BSTR* pbsDescr);
        STDMETHOD(GetGroups)(BSTR* pbsGroups);
        STDMETHOD(GetGroupDescr)(BSTR bsGroup, BSTR* pbsDescr);
        STDMETHOD(GetParaCount)(INT* pnMinParas, INT* pnMaxParas);
        STDMETHOD(GetParaTypes)(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4);  // -1 if result type!
								// store result type in *pResType, -1 if error
        STDMETHOD(CheckSyntax)(BSTR* pbsError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
								// store result in *pVarRes
        STDMETHOD(Execute)(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
        STDMETHOD(GetVisibleFlag)(BOOL*	pbVis)
									{
									*pbVis = 1;
                                    return(S_OK);
                                    }
        STDMETHOD(GetParaValueHint)(INT nPara, BSTR* pbsHint, BSTR* pbsTabbedList);

				INT				Language(void) { return(_nLanguage); }
				BOOL			IsDesigntime(void) { return(_bDesigntime); }

		virtual	CString			FctName(void) = 0;
		virtual	CString			FctDescr(void) = 0;
		virtual	CString			FctGroups(void) = 0;
		virtual	CString			FctGroupDescr(const CString& sGroup) = 0;
		virtual	void			FctGetParaCount(INT* pnMinParas, INT* pnMaxParas) = 0;
		virtual	void			FctGetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4) = 0;
        virtual	INT				FctCheckSyntax(CString& sError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4) = 0;
        virtual	INT				FctExecute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4) = 0;
        virtual	void			FctGetParaValueHint(INT nPara, CString& sHint, CString& TabbedList) = 0;

	};

class LlXFunctionProvider
{
	private:
		LlFctList				m_FctList;
	public:
								LlXFunctionProvider();
		virtual					~LlXFunctionProvider();
		
		LlXFunctionProvider& operator=(const LlXFunctionProvider& rhs)
								{
									if (&rhs != this)
									{
										m_FctList = rhs.m_FctList;
									}
									return(*this);
								}

		void					Clear()
								{
									m_FctList.Clear();
								}

		//@cmember Add a function to the provider
		void					AddFunction(LlXFct* pFunction);
		//@cmember Retrieve the List & Label Base Interface for the function provider
		ILlXInterface*			GetBaseInterface();
		int						size() { return((int)(m_FctList.size())); }
};

class LlXFctConvertToRoman
	: public LlXFct
{
	public:
							LlXFctConvertToRoman()
							{
							}
		virtual				~LlXFctConvertToRoman()
							{
							}
		
		virtual CString		FctName();
		virtual CString		FctDescr();
		virtual CString		FctGroups();
		virtual CString		FctGroupDescr(const CString& sGroup);
		virtual	void		FctGetParaCount(INT* pnMinParas, INT* pnMaxParas);
		virtual	void		FctGetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4);
        virtual	INT			FctCheckSyntax(CString& sError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
        virtual	INT			FctExecute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
        virtual	void		FctGetParaValueHint(INT nPara, CString& sHint, CString& TabbedList);
};

class LlXFctReverseString
	: public LlXFct
{
	public:
							LlXFctReverseString()
							{
							}
		virtual				~LlXFctReverseString()
							{
							}
		
		virtual CString		FctName();
		virtual CString		FctDescr();
		virtual CString		FctGroups();
		virtual CString		FctGroupDescr(const CString& sGroup);
		virtual	void		FctGetParaCount(INT* pnMinParas, INT* pnMaxParas);
		virtual	void		FctGetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4);
        virtual	INT			FctCheckSyntax(CString& sError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
        virtual	INT			FctExecute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
        virtual	void		FctGetParaValueHint(INT nPara, CString& sHint, CString& TabbedList);
};

class LlXFctEncodeURL
	: public LlXFct
{
	public:
							LlXFctEncodeURL()
							{
							}
		virtual				~LlXFctEncodeURL()
							{
							}
		
		virtual CString		FctName();
		virtual CString		FctDescr();
		virtual CString		FctGroups();
		virtual CString		FctGroupDescr(const CString& sGroup);
		virtual	void		FctGetParaCount(INT* pnMinParas, INT* pnMaxParas);
		virtual	void		FctGetParaTypes(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4);
        virtual	INT			FctCheckSyntax(CString& sError, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
        virtual	INT			FctExecute(VARIANT* pVarRes, INT* pnResType, UINT32* pnLLType, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4);
        virtual	void		FctGetParaValueHint(INT nPara, CString& sHint, CString& TabbedList);
};

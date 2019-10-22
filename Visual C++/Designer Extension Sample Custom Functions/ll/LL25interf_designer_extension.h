#if !defined(LXINTERF_H) // include only once!
#define LXINTERF_H

#if !defined(SOURCE_FROM_CTRLRESVER)

	#define __GLUE3(x,y,z) 	x ## y ## z
	#define __GLUE(x,y) 	x ## y
	#define ___STRINGIZE(parm) # parm
	#define __STRINGIZE(parm) ___STRINGIZE(parm)

	#define __CHK_MAKE_HEADERNAME_INTFDEF_X(d,t)	< __GLUE(d,t) >
	#define _CHK_MAKE_HEADERNAME_INTFDEF_X(d,v,t)	__CHK_MAKE_HEADERNAME_INTFDEF_X(__GLUE(d,v),t)
	#define CHK_MAKE_HEADERNAME_INTFDEF_X(d,v,t)	_CHK_MAKE_HEADERNAME_INTFDEF_X(d,v,t)
	#define HEADER_FROM_CTRLRESVER(base) 			CHK_MAKE_HEADERNAME_INTFDEF_X(base,CTRLRESVER,.h)
	#define HEADER_FROM_CTRLRESVER_DYN(base) 		CHK_MAKE_HEADERNAME_INTFDEF_X(base,CTRLRESVER,.hx)
	#define HEADER_FROM_CTRLRESVER_INTF(base) 		CHK_MAKE_HEADERNAME_INTFDEF_X(base,CTRLRESVER,.hi)
	#define HEADER_FROM_CTRLRESVER_DECL(base) 		CHK_MAKE_HEADERNAME_INTFDEF_X(base,CTRLRESVER,.hd)
#endif

// BASE ============================================================================

#ifndef _LLX_BASE_H_
#define _LLX_BASE_H_

#include HEADER_FROM_CTRLRESVER_DECL(cmbtut)

#ifdef CMBT_GUID
    #undef CMBT_GUID
#endif
#if defined(CMBTGUID_IMPLEMENTATION)
    #define CMBT_GUID(v,d,w1,w2,b0,b1,b2,b3,b4,b5,b6,b7)    EXTERN_C const GUID CDECL v = {d,w1,w2,b0,b1,b2,b3,b4,b5,b6,b7}
  #else
    #define CMBT_GUID(v,d,w1,w2,b0,b1,b2,b3,b4,b5,b6,b7)    EXTERN_C const GUID CDECL   FAR v
#endif

CMBT_GUID(CLSID_LLX,                    				0x3cbae4e0,0x8880,0x11d2,0x96,0xa3,0x00,0x60,0x08,0x6f,0xef,0xd5);
CMBT_GUID(IID_LLX_IBASE,                				0x3cbae4e1,0x8880,0x11d2,0x96,0xa3,0x00,0x60,0x08,0x6f,0xef,0xd5);

#if !defined(CMBTGUID_IMPLEMENTATION)


interface ILlXInterface
    : public IUnknown
    {
    public:
        STDMETHOD(QueryInterface)(REFIID riid, VOID** ppv) PURE;
        STDMETHOD_(ULONG,AddRef)(void) PURE;
        STDMETHOD_(ULONG,Release)(void) PURE;
    };

//////////////////////////////////////////////////////////////////////////////
// this interface is given by LL to the LLX Object
// supports:
//  IID_LLX_ILLBASE                     -> self
//  IID_LLX_ILLCOORDINATEPACKAGE        -> ILlCoordinatePackage
//  IID_LLX_ILLFONT                     -> ILlFont

interface ILlBase
    : public IUnknown
    {
    public:
        STDMETHOD(QueryInterface)(REFIID riid, VOID** ppv) PURE;
        STDMETHOD_(ULONG,AddRef)(void) PURE;
        STDMETHOD_(ULONG,Release)(void) PURE;
    };

	
#endif // defined(CMBTGUID_IMPLEMENTATION)
#endif // _LLX_BASE_H_
	
// ================================================================================= 

// FCT =============================================================================

#ifndef _LLX_FCT_H_
#define _LLX_FCT_H_

//////////////////////////////////////////////////////////////////////////////

CMBT_GUID(IID_LLX_IENUMFUNCTIONS,       0x3cbae4e6,0x8880,0x11d2,0x96,0xa3,0x00,0x60,0x08,0x6f,0xef,0xd5);
CMBT_GUID(IID_LLX_IFUNCTION,            0x3cbae4e7,0x8880,0x11d2,0x96,0xa3,0x00,0x60,0x08,0x6f,0xef,0xd5);

#if !defined(CMBTGUID_IMPLEMENTATION)

interface ILlXFunction
    : public IUnknown
    {
    public:
        STDMETHOD(QueryInterface)(REFIID riid, VOID** ppv) PURE;
        STDMETHOD_(ULONG,AddRef)(void) PURE;
        STDMETHOD_(ULONG,Release)(void) PURE;

        STDMETHOD(SetLLJob)(HLLJOB hLLJob, ILlBase* pLLBase) PURE;

        STDMETHOD(SetOption)(INT nOption, INT_PTR nValue) PURE;
        STDMETHOD(GetOption)(INT nOption, INT_PTR* pnValue) PURE;
            #define LLXFUNCTION_OPTION_LANGUAGE         1 // w/o, if call fails with E_FAIL, LL does not load this object
            #define LLXFUNCTION_OPTION_DESIGNTIME       2 // w/o, if called in designer, i.e. non-"real"-data environment
            #define LLXFUNCTION_OPTION_HLIBRARY         3 // w/o
			#define LLXFUNCTION_OPTION_Q_IS_CONSTANT	4 // r/o, parent asks function whether it always returns the same value for the same arguments
			//#define LLXFUNCTION_OPTION_NTFY_OBJECT_WILL_BE_RELEASED 32767
        STDMETHOD(GetName)(BSTR* pbsName) PURE;
        STDMETHOD(GetDescr)(BSTR* pbsDescr) PURE;
        STDMETHOD(GetGroups)(BSTR* pbsGroups) PURE;
        STDMETHOD(GetGroupDescr)(BSTR bsGroup, BSTR* pbsDescr) PURE;
        STDMETHOD(GetParaCount)(INT* pnMinParas, INT* pnMaxParas) PURE;
        STDMETHOD(GetParaTypes)(INT* pnTypeRes, INT* pnTypeArg1, INT* pnTypeArg2, INT* pnTypeArg3, INT* pnTypeArg4) PURE;
        STDMETHOD(CheckSyntax)(BSTR* pbsError, INT* pnTypeRes, UINT32* pnTypeResLL, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4) PURE;
        STDMETHOD(Execute)(VARIANT* pVarRes, INT* pnTypeRes, UINT32* pnTypeResLL, UINT* pnDecs, UINT nArgs, VARIANT VarArg1, VARIANT VarArg2, VARIANT VarArg3, VARIANT VarArg4) PURE;
        STDMETHOD(GetVisibleFlag)(BOOL* pbVisible) PURE;
        STDMETHOD(GetParaValueHint)(INT nPara, BSTR* pbsHint, BSTR* pbsTabbedList) PURE; // nPara = 0..3
    };

interface ILlXEnumFunctions
    : public IUnknown
    {
    public:
        STDMETHOD(QueryInterface)(REFIID riid, VOID** ppv) PURE;
        STDMETHOD_(ULONG,AddRef)(void) PURE;
        STDMETHOD_(ULONG,Release)(void) PURE;

        // IEnumXXX standard members
        STDMETHOD(Next)(ULONG, ILlXFunction**, ULONG *) PURE;
        STDMETHOD(Skip)(ULONG) PURE;
        STDMETHOD(Reset)(void) PURE;
        STDMETHOD(Clone)(ILlXEnumFunctions **) PURE;
    };

#endif // defined(CMBTGUID_IMPLEMENTATION)
#endif // _LLX_FCT_H_

// =================================================================================

#if defined(__CTRLRESVER__)
	#if __CTRLRESVER__ != 25
		#error(INCLUDE_FILE_AND_LINE("Attention: adapt interface ID!!!"))
	#endif
#endif

#endif // LXINTERF_H
// stdafx.h : include file for standard system include files,
//  or project specific include files that are used frequently, but
//      are changed infrequently
//

#if !defined(AFX_STDAFX_H__BE04CFC6_E31A_4F56_8BD1_A02B94B8BF6C__INCLUDED_)
#define AFX_STDAFX_H__BE04CFC6_E31A_4F56_8BD1_A02B94B8BF6C__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define VC_EXTRALEAN		// Exclude rarely-used stuff from Windows headers

#include <afxwin.h>         // MFC core and standard components
#include <afxext.h>         // MFC extensions
#include <afxdtctl.h>		// MFC support for Internet Explorer 4 Common Controls
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>			// MFC support for Windows Common Controls
#endif // _AFX_NO_AFXCMN_SUPPORT

#include "..\cmbtll29.h"
#define DATABASENAME L"Chinook.db"

// D:   XTRACE Makro einfach wahlweise auf TRACE oder Debwin4 umbiegen
// US:  simple redirection of XTRACE macro to either TRACE or Debwin4
#ifndef XTRACE
 //#define XTRACE TRACE
 #define XTRACE CDebwin::Output
#endif

class CDebwin
{
public:
	#ifdef _DEBUG
	template <typename ... ARGS> static void Output(LPCWSTR fmt, ARGS&& ... args) {
		::LlDebugOutput(0,SQLiteHelp::xsprintf(fmt, std::forward<ARGS>(args)...).c_str());
	}
	#else
	template <typename ... ARGS> static void Output(LPCWSTR /*fmt*/, ARGS&& ... /*args*/) {}
	#endif
};

#include <vector>
#include <list>
#include <map>
#include <set>
#include <string>
#include <locale>
#include <functional>
#include <memory>
#include <codecvt>
#include <thread>
#include <mutex>
#include <atomic>
#include <condition_variable>

#pragma component(browser, off, references)
#include "sqlitewrapper.h"
using namespace cmbtSQL;
#pragma component(browser, on, references)

#include <OleAuto.h>

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__BE04CFC6_E31A_4F56_8BD1_A02B94B8BF6C__INCLUDED_)

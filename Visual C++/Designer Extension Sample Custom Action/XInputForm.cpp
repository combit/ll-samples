// XInputForm.cpp : implementation file
//

#include "stdafx.h"
#include "desext.h"
#include "XInputForm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CXInputForm dialog


CXInputForm::CXInputForm(CWnd* pParent /*=NULL*/)
	: CDialog(CXInputForm::IDD, pParent)
{
	//{{AFX_DATA_INIT(CXInputForm)
	m_sObjectName = _T("");
	//}}AFX_DATA_INIT
}


void CXInputForm::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CXInputForm)
	DDX_Control(pDX, IDC_EDIT_OBJECT_NAME, m_oObjectName);
	DDX_Text(pDX, IDC_EDIT_OBJECT_NAME, m_sObjectName);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CXInputForm, CDialog)
	//{{AFX_MSG_MAP(CXInputForm)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CXInputForm message handlers

BOOL CXInputForm::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

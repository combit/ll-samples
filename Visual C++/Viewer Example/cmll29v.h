// Machine generated IDispatch wrapper class(es) created with ClassWizard
/////////////////////////////////////////////////////////////////////////////
// IToolbarButtons wrapper class

class IToolbarButtons : public COleDispatchDriver
{
public:
	IToolbarButtons() {}		// Calls COleDispatchDriver default constructor
	IToolbarButtons(LPDISPATCH pDispatch) : COleDispatchDriver(pDispatch) {}
	IToolbarButtons(const IToolbarButtons& dispatchSrc) : COleDispatchDriver(dispatchSrc) {}

// Attributes
public:

// Operations
public:
	long GetButtonState(long nButtonID);
	void SetButtonState(long nButtonID, long nButtonState);
};

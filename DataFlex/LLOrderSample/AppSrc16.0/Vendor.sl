Use DFClient.pkg
Use DFSelLst.pkg
Use Windows.pkg
Use cDbCJGridPromptList.pkg

Use Vendor.DD

CD_Popup_Object Vendor_sl is a dbModalPanel
    Set Label to "Vendor List"
    Set Size to 132 238
    Set Location to 4 5
    Set piMinSize to 132 238

    Object Vendor_DD is a Vendor_DataDictionary
    End_Object    // Vendor_DD

    Set Main_DD to Vendor_DD
    Set Server to Vendor_DD

    Object oSelList is a cDbCJGridPromptList
        Set Size to 95 229
        Set Location to 12 4
        Set pbAllowColumnRemove to False
        Set peAnchors to anAll

        Object oVendor_ID is a cDbCJGridColumn
            Entry_Item Vendor.ID
            Set piWidth to 63
            Set psCaption to "ID"
        End_Object

        Object oVendor_Name is a cDbCJGridColumn
            Entry_Item Vendor.Name
            Set piWidth to 280
            Set psCaption to "Vendor Name"
        End_Object
    End_Object

    Object oOK_bn is a Button
        Set Label to "&Ok"
        Set Location to 114 77
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send OK of oSelList
        End_Procedure

    End_Object    // oOK_bn

    Object oCancel_bn is a Button
        Set Label to "&Cancel"
        Set Location to 114 130
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send Cancel of oSelList
        End_Procedure

    End_Object    // oCancel_bn

    Object oSearch_bn is a Button
        Set Label to "&Search..."
        Set Location to 114 183
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send Search of oSelList
        End_Procedure

    End_Object    // oSearch_bn

    On_Key Key_Alt+Key_O Send KeyAction of oOk_bn
    On_Key Key_Alt+Key_C Send KeyAction of oCancel_bn
    On_Key Key_Alt+Key_S Send KeyAction of oSearch_bn

CD_End_Object    // Vendor_sl

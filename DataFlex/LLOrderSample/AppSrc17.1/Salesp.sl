Use DFClient.pkg
Use DFSelLst.pkg
Use Windows.pkg
Use cDbCJGridPromptList.pkg

Use SalesP.DD

CD_Popup_Object SalesP_sl is a dbModalPanel

    Set Minimize_Icon to False
    Set Label to "Sales Person List"
    Set Size to 99 260
    Set Location to 4 5
    Set piMinSize to 99 180

    Object SalesP_DD is a SalesP_DataDictionary
    End_Object    // Salesp_DD

    Set Main_DD to SalesP_DD
    Set Server to SalesP_DD

    Object oSelList is a cDbCJGridPromptList
        Set Size to 70 249
        Set Location to 6 5
        Set pbAllowColumnRemove to False
        Set peAnchors to anAll

        Object oSalesP_ID is a cDbCJGridColumn
            Entry_Item SalesP.ID
            Set piWidth to 60
            Set psCaption to "ID"
        End_Object

        Object oSalesP_Name is a cDbCJGridColumn
            Entry_Item SalesP.Name
            Set piWidth to 313
            Set psCaption to "Sales Person Name"
        End_Object
    End_Object

    Object oOK_bn is a Button
        Set Label to "&Ok"
        Set Location to 81 99
        Set peAnchors to anBottomRight
        Set Default_State to True

        Procedure OnClick
            Send OK of oSelList
        End_Procedure

    End_Object    // oOK_bn

    Object oCancel_bn is a Button
        Set Label to "&Cancel"
        Set Location to 81 152
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send Cancel of oSelList
        End_Procedure

    End_Object    // oCancel_bn

    Object oSearch_bn is a Button
        Set Label to "&Search..."
        Set Location to 81 205
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send Search of oSelList
        End_Procedure

    End_Object    // oSearch_bn

    On_Key Key_Alt+Key_O Send KeyAction of oOk_bn
    On_Key Key_Alt+Key_C Send KeyAction of oCancel_bn
    On_Key Key_Alt+Key_S Send KeyAction of oSearch_bn

CD_End_Object    // SalesP_sl

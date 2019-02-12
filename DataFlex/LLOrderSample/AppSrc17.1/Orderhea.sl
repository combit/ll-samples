Use DFClient.pkg
Use DFSelLst.pkg
Use Windows.pkg
Use cDbCJGridPromptList.pkg

Use Customer.DD
Use OrderHea.DD


CD_Popup_Object OrderHea_sl is a dbModalPanel

    Set Minimize_Icon to False
    Set Label to "Order List"
    Set Size to 134 392
    Set Location to 4 5
    Set piMinSize to 134 392

    Object Customer_DD is a Customer_DataDictionary
    End_Object    // Customer_DD

    Object OrderHea_DD is a OrderHea_DataDictionary
        Set DDO_Server to Customer_DD
    End_Object    // OrderHea_DD

    Set Main_DD to OrderHea_DD
    Set Server to OrderHea_DD

    Object oSelList is a cDbCJGridPromptList
        Set Size to 100 377
        Set Location to 9 7
        Set pbAllowColumnRemove to False
        Set peAnchors to anAll

        Object oOrderHea_Order_Number is a cDbCJGridColumn
            Entry_Item OrderHea.Order_Number
            Set piWidth to 87
            Set psCaption to "Order Number"
        End_Object

        Object oCustomer_Customer_Number is a cDbCJGridColumn
            Entry_Item Customer.Customer_Number
            Set piWidth to 84
            Set psCaption to "Cust. Number"
        End_Object

        Object oCustomer_Name is a cDbCJGridColumn
            Entry_Item Customer.Name
            Set piWidth to 231
            Set psCaption to "Customer Name"
        End_Object

        Object oOrderHea_Order_Date is a cDbCJGridColumn
            Entry_Item OrderHea.Order_Date
            Set piWidth to 75
            Set psCaption to "Order Date"
            Set peTextAlignment to xtpAlignmentRight
        End_Object

        Object oOrderHea_Order_Total is a cDbCJGridColumn
            Entry_Item OrderHea.Order_Total
            Set piWidth to 88
            Set psCaption to "Order Total"
        End_Object
    End_Object

    Object oOK_bn is a Button
        Set Label to "&Ok"
        Set Location to 116 231
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send OK of oSelList
        End_Procedure

    End_Object    // oOK_bn

    Object oCancel_bn is a Button
        Set Label to "&Cancel"
        Set Location to 116 284
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send Cancel of oSelList
        End_Procedure

    End_Object    // oCancel_bn

    Object oSearch_bn is a Button
        Set Label to "&Search..."
        Set Location to 116 337
        Set peAnchors to anBottomRight

        Procedure OnClick
            Send Search of oSelList
        End_Procedure

    End_Object    // oSearch_bn

    On_Key Key_Alt+Key_O Send KeyAction of oOk_bn
    On_Key Key_Alt+Key_C Send KeyAction of oCancel_bn
    On_Key Key_Alt+Key_S Send KeyAction of oSearch_bn

CD_End_Object    // OrderHea_sl

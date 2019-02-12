Use dfClient.pkg
Use DataDict.pkg
Use dfEntry.pkg
Use dfTabDlg.pkg
Use dfCEntry.pkg
Use cDbTextEdit.Pkg
Use Customer.DD

DEFERRED_VIEW Activate_oCustomerView FOR ;
;
Object oCustomerView is a dbView
    Set Border_Style to Border_Thick
    Set Label to "Customer Entry View"
    Set Location to 7 23
    Set Size to 146 277
    Set piMaxSize to 300 350
    Set piMinSize to 146 277

    Object Customer_DD is a Customer_DataDictionary
    End_Object    // Customer_DD

    Set Main_DD to Customer_DD
    Set Server to Customer_DD

    Object oCustomer_Number is a dbForm
        Entry_Item Customer.Customer_Number
        Set Label to "Customer Number:"
        Set Size to 13 42
        Set Location to 5 72
        Set peAnchors to anTopLeft
        Set Label_Col_Offset to 2
        Set Label_Justification_Mode to jMode_Right
    End_Object    // oCustomer_Number

    Object oCustomer_Name is a dbForm
        Entry_Item Customer.Name
        Set Label to "Name:"
        Set Size to 13 186
        Set Location to 20 72
        Set peAnchors to anTopLeftRight
        Set Label_Col_Offset to 2
        Set Label_Justification_Mode to jMode_Right
    End_Object    // oCustomer_Name

    Object oCustTD is a dbTabDialog
        Set Size to 105 265
        Set Location to 36 7
        Set Rotate_Mode to RM_Rotate
        Set peAnchors to anAll
        Object oAddress_TP is a dbTabPage
            Set Label to "Address"
            Set Tab_ToolTip_Value to "Customer contact information"
            Object oCustomer_Address is a dbForm
                Entry_Item Customer.Address
                Set Label to "Street Address:"
                Set Size to 13 180
                Set Location to 8 62
                Set peAnchors to anTopLeftRight
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_Address

            Object oCustomer_City is a dbForm
                Entry_Item Customer.City
                Set Label to "City/State/Zip:"
                Set Size to 13 84
                Set Location to 24 62
                Set peAnchors to anTopLeftRight
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_City

            Object oCustomer_State is a dbComboForm
                Entry_Item Customer.State
                Set Size to 13 32
                Set Location to 24 152
                Set peAnchors to anTopRight
                Set Form_Border to 0
                Set Code_Display_Mode to cb_code_display_code
            End_Object    // oCustomer_State

            Object oCustomer_Zip is a dbForm
                Entry_Item Customer.Zip
                Set Size to 13 51
                Set Location to 24 191
                Set peAnchors to anTopRight
            End_Object    // oCustomer_Zip

            Object oCustomer_Phone_number is a dbForm
                Entry_Item Customer.Phone_Number
                Set Label to "Phone Number:"
                Set Size to 13 120
                Set Location to 39 62
                Set peAnchors to anTopLeft
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_Phone_number

            Object oCustomer_Fax_number is a dbForm
                Entry_Item Customer.Fax_Number
                Set Label to "Fax Number:"
                Set Size to 13 120
                Set Location to 54 62
                Set peAnchors to anTopLeft
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_Fax_number

            Object oCustomer_Email_address is a dbForm
                Entry_Item Customer.EMail_Address
                Set Label to "E-Mail Address:"
                Set Size to 13 180
                Set Location to 69 62
                Set peAnchors to anTopLeftRight
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_Email_address

        End_Object    // oAddress_TP

        Object oBalances_TP is a dbTabPage
            Set Label to "Balances"
            Set Tab_ToolTip_Value to "Current account balances"
            Object oCustomer_Credit_Limit is a dbForm
                Entry_Item Customer.Credit_limit
                Set Label to "Credit Limit:"
                Set Size to 13 48
                Set Location to 9 72
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_Credit_Limit

            Object oCustomer_Purchases is a dbForm
                Entry_Item Customer.Purchases
                Set Label to "Total Purchases:"
                Set Size to 13 48
                Set Location to 24 72
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_Purchases

            Object oCustomer_Balance is a dbForm
                Entry_Item Customer.Balance
                Set Label to "Balance Due:"
                Set Size to 13 48
                Set Location to 39 72
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oCustomer_Balance

        End_Object    // oBalances_TP

        Object oComments_TP is a dbTabPage
            Set Label to "Comments"
            Set Tab_ToolTip_Value to "Notes about this customer"
            Object oCustomer_Comments is a cDbTextEdit
                Entry_Item Customer.Comments
                Set Size to 71 242
                Set Location to 9 9
                Set peAnchors to anAll
            End_Object    // oCustomer_Comments

        End_Object    // oComments_TP

    End_Object    // oCustTD

CD_End_Object    // oCustomerView

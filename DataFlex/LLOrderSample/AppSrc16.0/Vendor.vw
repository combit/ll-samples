Use dfClient.pkg
Use DataDict.pkg
Use dfEntry.pkg
Use dfCEntry.pkg
Use Vendor.DD

DEFERRED_VIEW Activate_oVendorView FOR ;
;
Object oVendorView is a dbView
    Set Border_Style to Border_Thick
    Set Label to "Vendor Entry View"
    Set Location to 6 6
    Set Size to 137 281
    Set piMaxSize to 137 350
    Set piMinSize to 137 215

    Object Vendor_DD is a Vendor_DataDictionary
    End_Object    // Vendor_DD

    Set Main_DD to Vendor_DD
    Set Server to Vendor_DD

    Object oContainer1 is a dbContainer3d
        Set Size to 129 273
        Set Location to 4 4
        Set peAnchors to anAll
        Object oVendor_Id is a dbForm
            Entry_Item Vendor.ID
            Set Label to "Vendor ID:"
            Set Size to 13 42
            Set Location to 4 67
            Set peAnchors to anTopLeft
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oVendor_ID

        Object oVendor_Name is a dbForm
            Entry_Item Vendor.Name
            Set Label to "Vendor Name:"
            Set Size to 13 186
            Set Location to 18 67
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oVendor_Name

        Object oVendor_Address is a dbForm
            Entry_Item Vendor.Address
            Set Label to "Street Address:"
            Set Size to 13 186
            Set Location to 34 67
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oVendor_Address

        Object oVendor_City is a dbForm
            Entry_Item Vendor.City
            Set Label to "City:"
            Set Size to 13 90
            Set Location to 49 67
            Set peAnchors to anTopLeft
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oVendor_City

        Object oVendor_State is a dbComboForm
            Entry_Item Vendor.State
            Set Label to "State:"
            Set Size to 13 32
            Set Location to 64 67
            Set peAnchors to anTopLeft
            Set Form_Border to 0
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
            Set Entry_State to False
            Set Code_Display_Mode to cb_code_display_code
        End_Object    // oVendor_State

        Object oVendor_Zip is a dbForm
            Entry_Item Vendor.Zip
            Set Label to "Zip/Postal Code:"
            Set Size to 13 66
            Set Location to 79 67
            Set peAnchors to anTopLeft
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oVendor_Zip

        Object oVendor_Phone_Number is a dbForm
            Entry_Item Vendor.Phone_Number
            Set Label to "Phone Number:"
            Set Size to 13 126
            Set Location to 94 67
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oVendor_Phone_Number

        Object oVendor_Fax_Number is a dbForm
            Entry_Item Vendor.Fax_Number
            Set Label to "Fax Number:"
            Set Size to 13 126
            Set Location to 108 67
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oVendor_Fax_Number

    End_Object    // oContainer1

CD_End_Object    // oVendorView

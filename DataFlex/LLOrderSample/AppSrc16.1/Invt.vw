Use dfClient.pkg
Use DataDict.pkg
Use dfEntry.pkg
Use Vendor.DD
Use Invt.DD

DEFERRED_VIEW Activate_oInventoryView FOR ;
;
Object oInventoryView is a dbView
    Set Border_Style to Border_Thick
    Set Label to "Inventory Item View"
    Set Location to 5 8
    Set Size to 151 305
    Set piMaxSize to 115 350
    Set piMinSize to 151 270

    Object Vendor_DD is a Vendor_DataDictionary
    End_Object    // Vendor_DD

    Object Invt_DD is a Invt_DataDictionary
        Set DDO_Server to Vendor_DD
    End_Object    // Invt_DD

    Set Main_DD to Invt_DD
    Set Server to Invt_DD

    Object oDbCont is a dbContainer3d
        Set Size to 140 295
        Set Location to 5 4
        Set peAnchors to anAll
        Object oInvt_Item_ID is a dbForm
            Entry_Item Invt.Item_ID
            Set Label to "Invt. Item ID:"
            Set Size to 13 60
            Set Location to 10 70
            Set peAnchors to anTopLeft
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oInvt_Item_Id

        Object oInvt_Description is a dbForm
            Entry_Item Invt.Description
            Set Label to "Invt. Description:"
            Set Size to 13 210
            Set Location to 25 70
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oInvt_Description

        Object oVendorGroup is a dbGroup
            Set Size to 58 271
            Set Location to 41 9
            Set peAnchors to anAll
            Set Label to "Vendor"
            Object oInvt_Vendor_ID is a dbForm
                Entry_Item Vendor.ID
                Set Label to "Vendor ID:"
                Set Size to 13 42
                Set Location to 9 61
                Set peAnchors to anTopLeft
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oInvt_Vendor_Id

            Object oVendor_Name is a dbForm
                Entry_Item Vendor.Name
                Set Label to "Vendor Name:"
                Set Size to 13 180
                Set Location to 24 61
                Set peAnchors to anTopLeftRight
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oVendor_Name

            Object oInvt_Vendor_Part_ID is a dbForm
                Entry_Item Invt.Vendor_Part_ID
                Set Label to "Vendor Part ID:"
                Set Size to 13 90
                Set Location to 39 61
                Set peAnchors to anTopLeft
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oInvt_Vendor_Part_ID

        End_Object    // oVendorGroup

        Object oUnitGroup is a dbGroup
            Set Size to 28 271
            Set Location to 101 9
            Set peAnchors to anAll
            Object oInvt_Unit_Price is a dbForm
                Entry_Item Invt.Unit_Price
                Set Label to "Unit Price:"
                Set Size to 13 48
                Set Location to 10 61
                Set peAnchors to anTopLeft
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oInvt_Unit_Price

            Object oInvt_On_Hand is a dbForm
                Entry_Item Invt.On_Hand
                Set Label to "On Hand:"
                Set Size to 13 36
                Set Location to 10 205
                Set peAnchors to anTopRight
                Set Label_Col_Offset to 2
                Set Label_Justification_Mode to jMode_Right
            End_Object    // oInvt_On_Hand

        End_Object    // oUnitGroup

    End_Object    // oDbCont

CD_End_Object    // oInventoryView

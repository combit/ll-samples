Use dfClient.pkg
Use DataDict.pkg
Use dfEntry.pkg
Use dfSpnEnt.pkg
Use dfCEntry.pkg
Use dfTable.pkg
Use Windows.pkg
Use Vendor.DD
Use Invt.DD
Use Customer.DD
Use SalesP.DD
Use OrderHea.DD
Use OrderDtl.DD
Use cDbCJGrid.pkg
Use cCJGridColumnRowIndicator.pkg
Register_Object oLLInvoice

Activate_View Activate_oOrderEntryView for oOrderEntryView
Object oOrderEntryView is a dbView
    Set Border_Style to Border_Thick
    Set Maximize_Icon to True
    Set Label to "Order Entry"
    Set Location to 2 3
    Set Size to 174 383
    Set piMinSize to 174 383
    Set pbAutoActivate to True

    Object Vendor_DD is a Vendor_DataDictionary
    End_Object    // Vendor_DD

    Object Invt_DD is a Invt_DataDictionary
        Set DDO_Server to Vendor_DD
    End_Object    // Invt_DD

    Object Customer_DD is a Customer_DataDictionary
    End_Object    // Customer_DD

    Object SalesP_DD is a Salesp_DataDictionary
    End_Object    // SalesP_DD

    Object OrderHea_DD is a OrderHea_DataDictionary
        Set DDO_Server to Customer_DD
        Set DDO_Server to SalesP_DD
    End_Object    // OrderHea_DD

    Object OrderDtl_DD is a OrderDtl_DataDictionary
        Set DDO_Server to OrderHea_DD
        Set DDO_Server to Invt_DD
        Set Constrain_File to OrderHea.File_Number
    End_Object    // OrderDtl_DD

    Set Main_DD to OrderHea_DD
    Set Server to OrderHea_DD

    Object oDbContainer3d1 is a dbContainer3d
        Set Size to 85 377
        Set Location to 2 3
        Set peAnchors to anTopLeftRight
        Object oOrderHea_Order_Number is a dbForm
            Entry_Item OrderHea.Order_Number
            Set Label to "Order Number:"
            Set Size to 13 42
            Set Location to 4 63
            Set peAnchors to anTopLeft
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right

        End_Object    // oOrderHea_Order_Number

        Object oOrderHea_Customer_Number is a dbForm
            Entry_Item Customer.Customer_Number
            Set Label to "Customer Number:"
            Set Size to 13 42
            Set Location to 4 201
            Set peAnchors to anTopRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right

            // If order record exists, disallow entry in customer window.
            Procedure Refresh Integer iMode
                Handle  hoSrvr
                Boolean bCrnt
                Get Server to hoSrvr                 // get the data_set
                Get HasRecord of hoSrvr to bCrnt // has record in data_set
                // Set displayonly to true if iCrnt is non-zero
                Set Enabled_State to (not(bCrnt))
                Forward Send Refresh iMode          // do normal refrsh
                // don't leave us sitting on a displayonly window
                If (bCrnt and Focus(Self)=Self) Send Next
            End_Procedure  // Refresh
            
        End_Object    // oOrderHea_Customer_Number

        Object oOrderHea_Order_Date is a dbSpinForm
            Entry_Item OrderHea.Order_Date
            Set Label to "Order Date:"
            Set Size to 13 67
            Set Location to 4 299
            Set peAnchors to anTopRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oOrderHea_Order_Date

        Object oCustomer_Name is a dbForm
            Entry_Item Customer.Name
            Set Label to "Customer Name:"
            Set Size to 13 180
            Set Location to 18 63
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
            Set Prompt_Button_Mode to pb_PromptOff

            // We want this to be a displayonly field
            Set Enabled_State to False
            
        End_Object    // oCustomer_Name

        Object oCustomer_Address is a dbForm
            Entry_Item Customer.Address
            Set Label to "Street Address:"
            Set Size to 13 180
            Set Location to 34 63
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oCustomer_Address

        Object oCustomer_City is a dbForm
            Entry_Item Customer.City
            Set Label to "City/State/Zip:"
            Set Size to 13 84
            Set Location to 49 63
            Set peAnchors to anTopLeftRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oCustomer_City

        Object oCustomer_State is a dbForm
            Entry_Item Customer.State
            Set Size to 13 20
            Set Location to 49 155
            Set peAnchors to anTopRight
        End_Object    // oCustomer_State

        Object oCustomer_Zip is a dbForm
            Entry_Item Customer.Zip
            Set Size to 13 60
            Set Location to 49 183
            Set peAnchors to anTopRight
        End_Object    // oCustomer_Zip

        Object oOrderHea_Ordered_By is a dbForm
            Entry_Item OrderHea.Ordered_By
            Set Label to "Ordered By:"
            Set Size to 13 67
            Set Location to 34 299
            Set peAnchors to anTopRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oOrderHea_Ordered_By

        Object oOrderHea_Salesperson_ID is a dbForm
            Entry_Item Salesp.Id
            Set Label to "Salesperson ID:"
            Set Size to 13 40
            Set Location to 49 299
            Set peAnchors to anTopRight
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oOrderHea_Salesperson_ID

        Object oOrderHea_Terms is a dbComboForm
            Entry_Item OrderHea.Terms
            Set Label to "Terms:"
            Set Size to 13 85
            Set Location to 64 63
            Set peAnchors to anTopLeft
            Set Form_Border to 0
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right

        End_Object    // oOrderHea_Terms

        Object oOrderHea_Ship_Via is a dbComboForm
            Entry_Item OrderHea.Ship_Via
            Set Label to "Ship Via:"
            Set Size to 13 103
            Set Location to 64 183
            Set peAnchors to anTopRight
            Set Form_Border to 0
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right

            Procedure Switch
               Boolean bEnabled
               // the normal switch behavior is to attempt to keep
               // keep looking for additional objects to switch to. If
               // we can't switch to the dtl table, we want to stop!
               Send Request_Save
               Send EnableObjects // make sure grid is properly enabled and save button is disabled
               Get Enabled_State of oOrderDtl_Grid to bEnabled                
               If bEnabled Begin
                   Forward Send Switch //  of oOrderDtl_Grid
               End
            End_Procedure  // Switch

        End_Object    // oOrderHea_Ship_Via

//        Object oSaveHdrButton is a Button
//            Set Size to 14 67
//            Set Location to 64 297
//            Set Label to 'Save Header'
//            Set peAnchors to anTopRight
//        
//            // fires when the button is clicked
//            Procedure OnClick
//                Boolean bCancel
//                Get Save_Header to bCancel
//            End_Procedure
//            
//        End_Object

    End_Object    // oDbContainer3d1

    Object oOrderDtl_Grid is a cDbCJGrid
        Set Server to OrderDtl_DD
        Set Ordering to 1
        Set Size to 63 377
        Set Location to 90 3
        Set peAnchors to anAll
        Set pbAllowInsertRow to False
        Set pbRestoreLayout to False
        Set psLayoutSection to "OrderView_oOrderDtl_Grid2"
        Set piLayoutBuild to 6
        Set pbHeaderPrompts to True

        On_Key Key_F11 Send Request_InsertRow

        Object oMark is a cCJGridColumnRowIndicator
        End_Object
        
        Object oInvt_Item_ID is a cDbCJGridColumn
            Entry_Item Invt.Item_ID
            Set piWidth to 91
            Set psCaption to "Item ID"
            Set psImage to "ActionPrompt.ico"
        End_Object

        Object oInvt_Description is a cDbCJGridColumn
            Entry_Item Invt.Description
            Set piWidth to 213
            Set psCaption to "Description"
        End_Object

        Object oInvt_Unit_Price is a cDbCJGridColumn
            Entry_Item Invt.Unit_Price
            Set piWidth to 53
            Set psCaption to "Unit Price"
        End_Object

        Object oOrderDtl_Qty_Ordered is a cDbCJGridColumn
            Entry_Item OrderDtl.Qty_Ordered
            Set piWidth to 50
            Set psCaption to "Quantity"
        End_Object

        Object oOrderDtl_Price is a cDbCJGridColumn
            Entry_Item OrderDtl.Price
            Set piWidth to 62
            Set psCaption to "Price"
        End_Object

        Object oOrderDtl_Extended_Price is a cDbCJGridColumn
            Entry_Item OrderDtl.Extended_Price
            Set piWidth to 81
            Set psCaption to "Total"
        End_Object
        
    End_Object    // oOrderDtl_Grid

    Object oOrderHea_Order_Total is a dbForm
        Entry_Item OrderHea.Order_Total
        Set Label to "Order Total:"
        Set Size to 13 60
        Set Location to 156 307
        Set peAnchors to anBottomRight
        Set Label_Col_Offset to 3
        Set Label_Justification_Mode to jMode_Right
    End_Object    // oOrderHea_Order_Total

    Object oPrintBtn is a Button
        Set Label to "Print Order"
        Set Location to 156 3
        Set peAnchors to anBottomLeft
        Set psToolTip to "Print preview of current order"

        Procedure OnClick
            Delegate Send PrintCurrentOrder // defined in view object
        End_Procedure  // OnClick

    End_Object    // oPrintBtn

    // Change:   Create custom confirmation messages for save and delete
    //           We must create the new functions and assign verify messages
    //           to them.
    Function Confirm_Delete_Order Returns Integer
        Integer iRetVal
        Get Confirm "Delete Entire Order?" to iRetVal
        Function_Return iRetVal
    End_Function
    
    // Only confirm on the saving of new records
    Function Confirm_Save_Order Returns Integer
        Integer iNoSave iSrvr
        Boolean bOld
        Get Server to iSrvr
        Get HasRecord of iSrvr to bOld
        If not bOld Begin
            Get Confirm "Save this NEW order header?" to iNoSave
        End
        Function_Return iNoSave
    End_Function
    
    // Define alternate confirmation Messages
    Set Verify_Save_MSG       to (RefFunc(Confirm_Save_Order))
    Set Verify_Delete_MSG     to (RefFunc(Confirm_Delete_Order))
    Set Auto_Clear_DEO_State  to False // don't clear Header on save
    
//    // Change: Table entry checking - attempt to save header record
//    //         before entering a table (this is called by table. Return
//    //         a non-zero if the save failed (i.e., don't enter table)
//    Function Save_Header Returns Integer
//        Boolean bHasRec bChanged
//        Handle hoSrvr
//    
//        Get Server to hoSrvr                 // The Header DDO.
//        Get HasRecord of hoSrvr to bHasRec   // Do we have a record?
//        Get Should_Save to bChanged          // Are there any current changes?
//    
//        // If there is no record and no changes we have an error.
//        If ( not(bHasRec) and not(bChanged) ) Begin  // no rec
//            Send UserError "You must First Create & Save Main Order Header" ""
//            Function_Return 1
//        End
//    
//        // Attempt to Save the current Record
//        // request_save_no_clear does a save without clearing.
//        Send Request_Save_No_Clear
//    
//        // The save succeeded if there are now no changes, and we
//        // have a saved record. Should_save tells us if we've got changes.
//        // We must check the data-sets hasRecord property to see if
//        // we have a record. If it is not, we had no save.
//        Get Should_Save to bChanged  // is a save still needed
//        Get HasRecord of hoSrvr to bHasRec // current record of the DD
//        // if no record or changes still exist, return an error code of 1
//        If ( not(bHasRec) or (bChanged)) ;
//            Function_Return 1
//    End_Function  // Save_Header
    
    // print the current order. This message will be sent
    // by the print button
    Procedure PrintCurrentOrder
        Integer hDD iNum
        Get Server to hDD // this will be the OrderHea DD
        If (HasRecord(hDD)) Begin // only do this if record exists
            Get Field_Current_Value of hDD Field OrderHea.Order_Number to iNum
            Send PrintOrder of oLLInvoice iNum
        End
    End_Procedure
    
    Object oIdle is a cIdleHandler
        Procedure OnIdle
            Delegate Send OnIdle
        End_Procedure
    End_Object
    
    Procedure OnIdle
        Send EnableObjects
    End_Procedure

    Procedure EnableObjects
        Boolean bChanged bRec
        Handle hoServer
        Get Server to hoServer
        Get Should_Save of hoServer to bChanged
        Get HasRecord of hoServer to bRec
//        Set Enabled_State of oSaveHdrButton to bChanged
        Set Enabled_State of oOrderDtl_Grid to (not(bChanged) and bRec)
        Set Enabled_State of oPrintBtn to bRec
    End_Procedure
    
    Procedure Activating
        Forward Send Activating
        Set pbEnabled of oIdle to True
    End_Procedure

    Procedure DeActivating
        Set pbEnabled of oIdle to False
        Forward Send Deactivating
    End_Procedure
    
End_Object

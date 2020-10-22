Use dfClient.pkg
Use DataDict.pkg
Use dfEntry.pkg
Use SalesP.DD

DEFERRED_VIEW Activate_oSalesPersonView FOR ;
;
Object oSalesPersonView is a dbView
    Set Border_Style to Border_None
    Set Label to "Sales Person Entry View"
    Set Location to 6 6
    Set Size to 51 245

    Object SalesP_DD is a Salesp_DataDictionary
    End_Object    // Salesp_DD

    Set Main_DD to SalesP_DD
    Set Server to SalesP_DD

    Object oContainer1 is a dbContainer3d
        Set Size to 40 233
        Set Location to 5 6
        Object oSalesP_ID is a dbForm
            Entry_Item SalesP.ID
            Set Label to "Sales Person ID:"
            Set Size to 13 46
            Set Location to 4 70
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oSalesP_ID

        Object oSalesP_Name is a dbForm
            Entry_Item SalesP.Name
            Set Label to "Sales Person Name:"
            Set Size to 13 156
            Set Location to 20 70
            Set Label_Col_Offset to 2
            Set Label_Justification_Mode to jMode_Right
        End_Object    // oSalesP_Name

    End_Object    // oContainer1

CD_End_Object    // oSalesPersonView

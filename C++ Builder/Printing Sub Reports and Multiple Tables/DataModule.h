//---------------------------------------------------------------------------

#ifndef DataModuleH
#define DataModuleH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ADODB.hpp>
#include <Db.hpp>
//---------------------------------------------------------------------------
class TDataModule1 : public TDataModule
{
__published:	// IDE-managed Components
        TDataSource *dsProducts;
        TADOConnection *ADOConnection1;
        TADOTable *Products;
        TADOTable *OrderDetails;
        TADOTable *Orders;
        TADOTable *Customers;
        TDataSource *dsOrderDetails;
        TDataSource *dsOrders;
        TDataSource *dsCustomers;
        TIntegerField *OrderDetailsOrderID;
        TIntegerField *OrderDetailsProductID;
        TBCDField *OrderDetailsUnitPrice;
        TSmallintField *OrderDetailsQuantity;
        TFloatField *OrderDetailsDiscount;
        TStringField *OrderDetailsOrderDetailsProductIDProductsProductIDProductName;
        void __fastcall DataModuleCreate(TObject *Sender);
        void __fastcall DataModuleDestroy(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TDataModule1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDataModule1 *DataModule1;
//---------------------------------------------------------------------------
#endif

unit uMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Registry, Dialogs, L26, DB, ADODB, StdCtrls, cmbtll26, Grids, DBGrids, 
  L26db;

type
  TfrmMain = class(TForm)
    btnDesign: TButton;
    dsOrders: TDataSource;
    ADOConnection1: TADOConnection;
    LL: TDBL26_;
    btnPrint: TButton;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    Orders: TADODataSet;
    Order_Details: TADODataSet;
    procedure btnDesignClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnPrintClick(Sender: TObject);
  private
    procedure FillDictionary();
    procedure FillStaticTextDictionary();
   public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;

implementation

{$R *.dfm}

procedure TfrmMain.btnDesignClick(Sender: TObject);
begin
        FillDictionary();
        FillStaticTextDictionary();
               LL.AutoDesign('Localization Sample...');
end;

procedure TfrmMain.FillDictionary;
begin
  with LL.Dictionary do
  begin
      // D: Dictionary l�schen
		  // US: Clear dictionary
      LL.Dictionary.Clear;
      LL.DesignerWorkspace.DesignerLanguages.Clear;

              // D: Zur Verf�gung stehende Sprachen im Designer hinzuf�gen. Die zuerst angemeldete Sprache wird als Basissprache verwendet!
              // US: Add available languages for the designer. The first language is the basic language
              LL.DesignerWorkspace.DesignerLanguages.Add(9);
              LL.DesignerWorkspace.DesignerLanguages.Add(7) ;
              LL.DesignerWorkspace.DesignerLanguages.Add(12);

              // D: Deutsch
              // US: German

              // D: Tabellennamen lokalisieren
              // US: Localize table names
              LL.Dictionary.Tables.Add('Orders','Bestellungen',7);
              LL.Dictionary.Tables.Add('Order_Details', 'Bestellposten',7);

              // D: Relationsnamen lokalisieren
              // US: Localize relation name
              LL.Dictionary.Relations.Add('Orders2Order_Details', 'Bestellungen/Bestellposten',7);

              // D: Feldnamen lokalisieren
              // US: Localize field names
              LL.Dictionary.Fields.Add('ProductID','ProduktID',7);
              LL.Dictionary.Fields.Add('Quantity', 'Anzahl',7);
              LL.Dictionary.Fields.Add('UnitPrice', 'Einzelpreis',7);
              LL.Dictionary.Fields.Add('Discount', 'Rabatt',7);

              LL.Dictionary.Fields.Add('OrderID', 'BestellID',7);
              LL.Dictionary.Fields.Add('CustomerID', 'KundenID',7);
              LL.Dictionary.Fields.Add('EmployeeID', 'MitarbeiterID',7);
              LL.Dictionary.Fields.Add('OrderDate', 'Bestelldatum',7);
              LL.Dictionary.Fields.Add('RequiredDate', 'Bedarfstermin',7);
              LL.Dictionary.Fields.Add('ShippedDate', 'Versanddatum',7);
              LL.Dictionary.Fields.Add('ShipVia', 'VersandDurch',7);
              LL.Dictionary.Fields.Add('Freight', 'Frachtkosten',7);
              LL.Dictionary.Fields.Add('ShipName', 'Empf�ngerName',7);
              LL.Dictionary.Fields.Add('ShipAddress', 'Empf�ngerAdresse',7);
              LL.Dictionary.Fields.Add('ShipCity', 'Empf�ngerStadt',7);
              LL.Dictionary.Fields.Add('ShipRegion', 'Bundesland',7);
              LL.Dictionary.Fields.Add('ShipPostalCode', 'PLZ',7);
              LL.Dictionary.Fields.Add('ShipCountry', 'Empf�ngerLand',7);

              // D: Zus�tzliche Variable lokalisieren
              // US: Localize additional variable
              LL.Dictionary.Fields.Add('Language', 'Sprache',7);


              // D: Franz�sisch
              // US: French

              // D: Tabellennamen lokalisieren
              // US: Localize table names
              LL.Dictionary.Tables.Add('Orders', 'Commandes',12);
              LL.Dictionary.Tables.Add('Order_Details', 'D�tailsDesCommandes',12);

              // D: Relationsnamen lokalisieren
              // US: Localize relation name
              LL.Dictionary.Relations.Add('Orders2Order_Details', 'Commandes2D�tailsDesCommandes',12);

              // D: Feldnamen lokalisieren
              // US: Localize field names
              LL.Dictionary.Fields.Add('ProductID', 'ProduitID',12);
              LL.Dictionary.Fields.Add('Quantity', 'Quantit�',12);
              LL.Dictionary.Fields.Add('UnitPrice', 'PrixUnitaire',12);
              LL.Dictionary.Fields.Add('Discount', 'Ristourne',12);

              LL.Dictionary.Fields.Add('OrderID', 'CommandeID',12);
              LL.Dictionary.Fields.Add('CustomerID', 'ClientID',12);
              LL.Dictionary.Fields.Add('EmployeeID', 'Coop�rateurID',12);
              LL.Dictionary.Fields.Add('OrderDate', 'DateDeLaCommande',12);
              LL.Dictionary.Fields.Add('RequiredDate', 'BesionDate',12);
              LL.Dictionary.Fields.Add('ShippedDate', 'EnvoiDate',12);
              LL.Dictionary.Fields.Add('ShipVia', 'EnvoirPar',12);
              LL.Dictionary.Fields.Add('Freight', 'Fret',12);
              LL.Dictionary.Fields.Add('ShipName', 'DestinataireNom',12);
              LL.Dictionary.Fields.Add('ShipAddress', 'DestinataireAdresse',12);
              LL.Dictionary.Fields.Add('ShipCity', 'DestinataireVille',12);
              LL.Dictionary.Fields.Add('ShipRegion', 'R�gion',12);
              LL.Dictionary.Fields.Add('ShipPostalCode', 'CodePostal',12);
              LL.Dictionary.Fields.Add('ShipCountry', 'DestinatairePays',12);

              // D: Zus�tzliche Variable lokalisieren
              // US: Localize additional variable
              LL.Dictionary.Fields.Add('Language', 'Langue',12);

              // D:   Spezieller Fall f�r statische Texte, da diese sp�ter auch f�r den Druck ben�tigt werden
		      // US: Handling for static texts, because static texts will be neccessary for later printing
              FillStaticTextDictionary();
  end;
end;

procedure TfrmMain.FillStaticTextDictionary;
begin
                LL.Dictionary.StaticTexts.Add('Language', 'Deutsch',7)   ;
		LL.Dictionary.StaticTexts.Add('Summary of Sales by Year', 'Verk�ufe nach Jahren', 7);
		LL.Dictionary.StaticTexts.Add('Quarter', 'Quartal', 7);
		LL.Dictionary.StaticTexts.Add('Shipped', 'Bestellungen', 7);
		LL.Dictionary.StaticTexts.Add('Sales', 'Umsatz', 7);
		LL.Dictionary.StaticTexts.Add('Totals for', 'Summen f�r', 7);
		LL.Dictionary.StaticTexts.Add('Sales by Year', 'Umsatz nach Jahr', 7);
		LL.Dictionary.StaticTexts.Add('Lot by Year', 'St�ckzahlen nach Jahr', 7);

		LL.Dictionary.StaticTexts.Add('designed & printed with combit� List & Label�', 'gestaltet & gedruckt mit combit� List & Label�', 7);
		LL.Dictionary.StaticTexts.Add('Page {0} of {1}', 'Seite {0} von {1}',7);
		LL.Dictionary.StaticTexts.Add('Printed {0} at {1} on {2}', 'Gedruckt {0} am {1} auf {2}',7);

		// D: Zus�tzliche statische Texte lokalisieren
		//US: Localize additional static values
		LL.Dictionary.StaticTexts.Add('Language', 'Fran�ais', 12);
		LL.Dictionary.StaticTexts.Add('Summary of Sales by Year', 'Chiffre d�affaires � ann�e', 12);
		LL.Dictionary.StaticTexts.Add('Quarter', 'Trimestre', 12);
		LL.Dictionary.StaticTexts.Add('Shipped', 'Commandes', 12);
		LL.Dictionary.StaticTexts.Add('Sales', 'Volume d''affaires', 12);
		LL.Dictionary.StaticTexts.Add('Totals for', 'Bourdonnement pour', 12);
		LL.Dictionary.StaticTexts.Add('Sales by Year', 'Volume d�affaires � ann�e', 12);
		LL.Dictionary.StaticTexts.Add('Lot by Year', 'Nombre de pi�ces � ann�e', 12);

		LL.Dictionary.StaticTexts.Add('designed & printed with combit� List & Label�', 'modeler & imprim�e avec combit� List & Label�', 12);
	        LL.Dictionary.StaticTexts.Add('Page {0} of {1}', 'Page {0} de {1}',12);
                LL.Dictionary.StaticTexts.Add('Printed {0} at {1} on {2}', 'Imprim�e la {0} � {1} sur {2}',12);

end;

procedure TfrmMain.FormCreate(Sender: TObject);
var
  reg: TRegistry;
  dbPath: string;
begin


  //D: Pfad setzen und Datenbankpfad auslesen
  //US: Set path and read database path
  SetCurrentDir(ExtractFilePath(Application.ExeName));

  reg := TRegistry.Create();
  try
    reg.RootKey := HKEY_CURRENT_USER;
    if reg.OpenKey('Software\combit\cmbtll',false) then
    begin
      dbPath := reg.ReadString('NWINDPath');
      reg.CloseKey();
    end else ShowMessage('Unable to find sample database. Make sure List & Label is installed correctly.');
  finally
    reg.Free;
  end;

 if dbPath = '' then
    ShowMessage('Unable to find sample database. Make sure List & Label is installed correctly.')
 else
 begin
     if not  ADOConnection1.Connected then
    begin
      ADOConnection1.ConnectionString := 'Provider=Microsoft.Jet.OLEDB.4.0;' +
                                         'User ID=Admin;' +
                                         'Data Source=' + dbPath + ';' +
                                         'Mode=Share Deny None;' +
                                         'Extended Properties="";' +
                                         'Jet OLEDB:Engine Type=4;';
      ADOConnection1.Connected := true;
      Orders.Active := true;
      Order_Details.Active := true;
    end;
 end;
end;

procedure TfrmMain.btnPrintClick(Sender: TObject);
begin
        LL.Dictionary.Clear();
		
		// D:   Spezieller Fall f�r statische Texte, da diese sp�ter auch f�r den Druck ben�tigt werden
		// US: Handling for static texts, because static texts will be neccessary for later printing
        FillStaticTextDictionary();
		
        LL.AutoPrint('Localization Sample...','');
end;

end.

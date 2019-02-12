using combit.ListLabel24.DataProviders;
using System.Data.OleDb;

namespace AdhocDesignerSample
{
    public static class ExampleDatasources
    {

        public static IDataProvider GetOleDbProviderNorthwindDb()
        {
            return new OleDbConnectionDataProvider(new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|nwind.mdb"));
        }

    }
}
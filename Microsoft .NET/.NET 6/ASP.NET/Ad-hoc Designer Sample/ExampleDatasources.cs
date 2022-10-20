using combit.Reporting.DataProviders;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace AdhocDesignerSample
{
    public static class ExampleDatasources
    {

        public static IDataProvider GetOleDbProviderNorthwindDb()
        {
            DataSet ds = new System.Data.DataSet();
            var xmlFile = Program.NorthwindFullDatabaseXmlFile;
            ds.ReadXml(xmlFile);
            return new AdoDataProvider(ds);
        }

    }
}

using combit.Reporting;
using combit.Reporting.DataProviders;
using Microsoft.Extensions.Caching.Memory;
using System.Data;

namespace VueWebReportingSample.DataAccess
{
    public static class SampleData
    {
        public static DataProviderCollection CreateProviderCollection(string reportName, bool forDesign)
        {
            IMemoryCache? cache = VueWebReportingSample.MemoryCache.Default;
            if (!forDesign && cache?.Get(reportName) is DataProviderCollection cachedCollection)
            {
                return cachedCollection;
            }
            else
            {
                DataProviderCollection providerCollection = new();
                DataSet ds;
                if (CmbtSettings.UnlimitedRecordsList.Contains(reportName))
                {
                    ds = NorthWndDataSetHelper.CreateFullDataSet();
                }
                else
                {
                    ds = NorthWndDataSetHelper.CreateDataSet(CmbtSettings.IsEmployeeList.Contains(reportName));
                    DataSet gDs = LlDemoDataSources.GantDS();
                    providerCollection.Add(new AdoDataProvider(gDs));
                }
                providerCollection.Add(new AdoDataProvider(ds));
                cache?.Set(reportName, providerCollection, DateTimeOffset.Now.AddMinutes(30.0));
                return providerCollection;
            }
        }
    }

    class LlDemoDataSources
    {
        public static DataSet GantDS()
        {
            DataSet ds = new();
            var xmlFile = Program.GanttDatabaseXmlFile;
            var xmlSchemaFile = Path.Combine(
                Path.GetDirectoryName(xmlFile) ?? "",
                Path.GetFileNameWithoutExtension(xmlFile) + "_schema.xml");
            ds.ReadXmlSchema(xmlSchemaFile);
            ds.ReadXml(xmlFile);

            try
            {
                int yearOffset = DateTime.Now.Year - 2010 + 15;
                Dictionary<string, List<string>> tablesWithDates = new()
                {
                    { "Project", new List<string> { "BeginDate" } },
                    { "Pollen", new List<string> { "PeriodBegin", "PeriodEnd" } }
                };

                foreach (string tableName in tablesWithDates.Keys)
                {
                    if (ds.Tables[tableName] is not DataTable dtOrder)
                        continue;

                    List<string> dateColumns = tablesWithDates[tableName];
                    foreach (string dateColumn in dateColumns)
                    {
                        dtOrder.Select().ToList().ForEach(r =>
                            r[dateColumn] = (r[dateColumn] != DBNull.Value)
                                ? ((DateTime)r[dateColumn]).AddYears(yearOffset)
                                : r[dateColumn]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ListLabelException(ex.ToString());
            }

            return ds;
        }
    }

    public static class NorthWndDataSetHelper
    {
        public static DataSet CreateDataSet(bool isEmployeeList)
        {
            DataSet ds = new();
            var xmlFile = isEmployeeList
                ? Program.NorthwindSmallDatabaseWithEmployeeListXmlFile
                : Program.NorthwindSmallDatabaseXmlFile;
            var xmlSchemaFile = Path.Combine(
                Path.GetDirectoryName(xmlFile) ?? "",
                Path.GetFileNameWithoutExtension(xmlFile) + "_schema.xml");
            ds.ReadXmlSchema(xmlSchemaFile);
            ds.ReadXml(xmlFile);

            try
            {
                int yearOffset = DateTime.Now.Year - 2010 + 15;
                if (ds.Tables["Orders"] is not DataTable dtOrder)
                    return ds;

                List<string> dateColumns = new() { "OrderDate", "RequiredDate", "ShippedDate" };
                foreach (string dateColumn in dateColumns)
                {
                    dtOrder.Select().ToList().ForEach(r =>
                        r[dateColumn] = (r[dateColumn] != DBNull.Value)
                            ? ((DateTime)r[dateColumn]).AddYears(yearOffset)
                            : r[dateColumn]);
                }
            }
            catch (Exception ex)
            {
                throw new ListLabelException(ex.ToString());
            }

            return ds;
        }

        public static DataSet CreateFullDataSet()
        {
            DataSet ds = new();
            var xmlFile = Program.NorthwindFullDatabaseXmlFile;
            var xmlSchemaFile = Path.Combine(
                Path.GetDirectoryName(xmlFile) ?? "",
                Path.GetFileNameWithoutExtension(xmlFile) + "_schema.xml");
            ds.ReadXmlSchema(xmlSchemaFile);
            ds.ReadXml(xmlFile);

            try
            {
                int yearOffset = DateTime.Now.Year - 2010 + 15;
                if (ds.Tables["Orders"] is not DataTable dtOrder)
                    return ds;

                List<string> dateColumns = new() { "OrderDate", "RequiredDate", "ShippedDate" };
                foreach (string dateColumn in dateColumns)
                {
                    dtOrder.Select().ToList().ForEach(r =>
                        r[dateColumn] = (r[dateColumn] != DBNull.Value)
                            ? ((DateTime)r[dateColumn]).AddYears(yearOffset)
                            : r[dateColumn]);
                }
            }
            catch (Exception ex)
            {
                throw new ListLabelException(ex.ToString());
            }

            return ds;
        }
    }
}

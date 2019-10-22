using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using combit.ReportServer.DataSources;
using combit.ReportServer.Util;
using combit.ReportServer.Util.Validation;
using CustomDataProvider.Properties;
using System.IO;
using combit.ListLabel25.DataProviders;

namespace combit.ListLabel25.Samples
{
    public class CustomDataProvider : IDataProviderWrapper
    {
        [ConfigOption("ServerOrFile", localizationResourceType: typeof(Resources)), RequiredField, UrlUncFileFormat]
        public string ServerUrl { get; set; }

        [ConfigOption("Username", localizationResourceType: typeof(Resources))]
        public string Username { get; set; }

        [ConfigOption("Password", ConfigOptionAttribute.InputTypes.PasswordEdit, localizationResourceType: typeof(Resources))]
        public string Password { get; set; }

        [ConfigOption("TableName", localizationResourceType: typeof(Resources))]
        public string TableName { get; set; }

        [ConfigOption("SeparatorCharacter", ConfigOptionAttribute.InputTypes.DropDownList, localizationResourceType: typeof(Resources), dropDownListTexts: new string[] { "Comma", "Semicolon", "Space" }, dropDownListValues: new string[] { ",", ";", "space" })]
        public string Separator { get; set; }

        [ConfigOption("FramingCharacter", localizationResourceType: typeof(Resources))]
        public string FramingCharacter { get; set; }

        [ConfigOption("LinesToSkip", localizationResourceType: typeof(Resources))]
        public string LinesToSkip { get; set; }

        [ConfigOption("FirstRowAreColumnNames", ConfigOptionAttribute.InputTypes.CheckBox, localizationResourceType: typeof(Resources))]
        public string FirstLineIsHeader { get; set; }

        protected string Domain
        {
            get
            {
                return Helper.GetDomainFromUsernameString(Username);
            }
        }

        protected string UsernameWithoutDomain
        {
            get
            {
                return Helper.GetUsernameWithoutDomain(Username);
            }
        }

        #region IDataProviderWrapper

        public const string TCode = "CmbtCustomDataProviderWrapper";

        public bool SupportsSchemaRow { get { return false; } }

        public IDataProvider CreateDataProvider(DataSourceModes dataMode, TempDir tempDir)
        {
            // create local copy of the file
            string path = Helper.DownloadFile(tempDir.FullPath, new Uri(ServerUrl), UsernameWithoutDomain, Password, Domain);
            tempDir.TempFiles.Add(path);

            char separator = String.IsNullOrEmpty(Separator) ? ',' : Separator[0];
            if (Separator.Equals("space", System.StringComparison.OrdinalIgnoreCase))
            {
                separator = ' ';
            }

            int linesToSkip = Convert.ToInt32(String.IsNullOrEmpty(LinesToSkip) ? "0" : LinesToSkip);

            if (String.IsNullOrEmpty(TableName))
                TableName = Path.GetFileNameWithoutExtension(ServerUrl);

            CsvDataProvider csvProvider = new CsvDataProvider(path, FirstLineIsHeader.ToUpperInvariant() == "TRUE", TableName, separator, linesToSkip, false);
            if (!String.IsNullOrEmpty(FramingCharacter))
                csvProvider.FramingCharacter = FramingCharacter[0];
            tempDir.PreCleanupActions.Add(() => csvProvider.Dispose());

            return csvProvider;
        }

        public IDataProviderWrapper CreateNewInstance()
        {   
            return new CustomDataProvider();
        }

        public IDataProviderWrapper Deserialize(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return (this as IDataProviderWrapper).CreateNewInstance();
            }

            return SharedDatasourceHelper.Deserialize(data, typeof(CustomDataProvider));
        }

        public DataProviderType GetDataProviderType()
        {
            return DataProviderType.Others;
        }

        public string GetDescription()
        {
            return Resources.Description;
        }

        public string GetName()
        {
            return "CustomDataProvider";
        }

        public string GetTypeCode()
        {
            return TCode;
        }

        public string Serialize()
        {
            return SharedDatasourceHelper.Serialize(this);
        }

        #endregion

    }
}

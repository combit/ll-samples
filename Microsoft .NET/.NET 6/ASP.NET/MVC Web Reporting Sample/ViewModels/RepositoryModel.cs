using System.Collections.Generic;

namespace MvcWebReportingSample.ViewModels
{
    public class RepositoryModel
    {

        /// <summary>
        /// List of items of the custom repository type defined for this sample
        /// </summary>
        public IEnumerable<CustomizedRepositoryItem> RepositoryItems { get; set; }
    }
}
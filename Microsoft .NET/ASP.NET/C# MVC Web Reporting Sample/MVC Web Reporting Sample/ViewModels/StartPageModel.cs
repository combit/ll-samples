using System.Collections.Generic;

namespace WebReporting.ViewModels
{
    public class StartPageModel
    {

        /// <summary>
        /// List of items of the custom repository type defined for this sample
        /// </summary>
        public IEnumerable<CustomizedRepostoryItem> RepositoryItems { get; set; }
    }
}
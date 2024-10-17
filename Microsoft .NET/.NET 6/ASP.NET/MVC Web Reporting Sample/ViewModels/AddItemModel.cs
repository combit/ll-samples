using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MvcWebReportingSample.ViewModels
{
    public class AddItemModel
    {

        public bool WasCreated;

        [Required, MaxLength(100)]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectType { get; set; }

        public IFormFile File1 { get; set; }

        public IFormFile File2 { get; set; }

        public bool ShowInToolbar { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebReporting.ViewModels
{
    public class AddItemModel
    {

        public bool WasCreated;

        [Required, MaxLength(100)]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectType { get; set; }

        public HttpPostedFileBase File1 { get; set; }

        public HttpPostedFileBase File2 { get; set; }

        public bool ShowInToolbar { get; set; }

    }
}

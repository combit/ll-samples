using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Internal;

namespace WebReporting.ViewModels
{
    public class AddItemModel
    {

        public bool WasCreated;

        [Required, MaxLength(100)]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectType { get; set; }

        public FormFile File1 { get; set; }

        public FormFile File2 { get; set; }

        public bool ShowInToolbar { get; set; }

    }
}

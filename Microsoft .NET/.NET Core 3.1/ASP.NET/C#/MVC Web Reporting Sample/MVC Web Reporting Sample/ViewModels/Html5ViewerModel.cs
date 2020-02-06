using combit.ListLabel25.Web;

namespace WebReporting.ViewModels
{
    public class Html5ViewerModel
    {

        public Html5ViewerModel()
        {
            ViewerOptions = new Html5ViewerOptions();
			ViewerOptions.ShowDetailedErrorMessages = true;
        }

        public string ReportName { get; set; }

        public Html5ViewerOptions ViewerOptions { get; set; }

    }
}

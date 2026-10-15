using Microsoft.AspNetCore.Mvc;

namespace ReactWebReportingSample.Controllers
{
    /// <summary>
    /// Simple API controller to expose default settings to the React frontend.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// Returns default configuration values for the frontend.
        /// </summary>
        [HttpGet("defaults")]
        public IActionResult GetDefaults()
        {
            return Ok(new
            {
                defaultSelectedReport = DefaultSettings.DefaultSelectedReport,
                startupProject = DefaultSettings.StartupProject,
                viewerProject = DefaultSettings.ViewerProject,
                dataMember = DefaultSettings.DataMember,
                language = CmbtSettings.LanguageSettings.Language.ToString(),
                unit = CmbtSettings.LanguageSettings.Unit.ToString()
            });
        }
    }
}

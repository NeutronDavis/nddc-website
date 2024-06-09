using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class ProjectDetailsModel : PageModel
    {
        private readonly IProjectsData projDb;
        public MyProjectModel ProjectDetails { get; set; }
        public List<MyActivityImageModel> ProjectPictures { get; set; }
        public readonly string _containerUrl;

        public ProjectDetailsModel(IProjectsData projDb, IConfiguration configuration)
        {
            this.projDb = projDb;
            _containerUrl = configuration.GetConnectionString("RackspaceCDN");
        }
        public void OnGet(int? pid)
        {
            ProjectDetails = projDb.GetProjectDetails(pid.Value);
            ProjectPictures = projDb.GetProjectPictures(pid.Value);
        }
    }
}

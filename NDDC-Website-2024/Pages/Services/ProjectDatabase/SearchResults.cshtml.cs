using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class SearchResultsModel : PageModel
    {
        private readonly IProjectsData proj;
        public List<MyProjectModel> Projects { get; set; }
        [BindProperty(SupportsGet = true)]
        public MyProjectModel Project { get; set; }
        public List<MyStateModel> States { get; set; }
        public List<MyProjectCategoryModel> ProjectCategories { get; set; }
        public SearchResultsModel(IProjectsData proj)
        {
            this.proj = proj;
        }
        public async void OnGet(string projName, int sid, int pcid)
        {
            Project.ProjectName = projName;
            Project.SID = sid;
            Project.PCID = pcid;
            Projects = proj.GetProjectsAdhocAsync(projName, sid, pcid);
            States = proj.GetStates();
            ProjectCategories = proj.GetProjectCategories();
        }
        public async void OnPost()
        {
            States = proj.GetStates();
            ProjectCategories = proj.GetProjectCategories();

            Projects = proj.GetProjectsAdhocAsync(Project.ProjectName, Project.SID, Project.PCID);
        }
    }
}

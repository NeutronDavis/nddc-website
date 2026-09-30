using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class SearchResultsModel : PageModel
    {
        private readonly IProjectsData proj;
        public List<MyProjectModel> Projects { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public MyProjectModel Project { get; set; } = new();
        public List<MyStateModel> States { get; set; } = new();
        public List<MyProjectCategoryModel> ProjectCategories { get; set; } = new();

        public SearchResultsModel(IProjectsData proj)
        {
            this.proj = proj;
        }

        public void OnGet(string? projName, int sid = 0, int pcid = 0)
        {
            Project ??= new MyProjectModel();
            Project.ProjectName = projName;
            Project.SID = sid;
            Project.PCID = pcid;

            try
            {
                States = proj.GetStates() ?? new List<MyStateModel>();
                ProjectCategories = proj.GetProjectCategories() ?? new List<MyProjectCategoryModel>();
                Projects = proj.GetProjectsAdhocAsync(projName ?? "", sid, pcid) ?? new List<MyProjectModel>();
            }
            catch
            {
                States = new List<MyStateModel>();
                ProjectCategories = new List<MyProjectCategoryModel>();
                Projects = new List<MyProjectModel>();
            }
        }

        public void OnPost()
        {
            Project ??= new MyProjectModel();
            try
            {
                States = proj.GetStates() ?? new List<MyStateModel>();
                ProjectCategories = proj.GetProjectCategories() ?? new List<MyProjectCategoryModel>();
                Projects = proj.GetProjectsAdhocAsync(Project.ProjectName ?? "", Project.SID, Project.PCID) ?? new List<MyProjectModel>();
            }
            catch
            {
                States = new List<MyStateModel>();
                ProjectCategories = new List<MyProjectCategoryModel>();
                Projects = new List<MyProjectModel>();
            }
        }
    }
}

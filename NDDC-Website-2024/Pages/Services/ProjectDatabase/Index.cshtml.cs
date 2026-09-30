using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class IndexModel : PageModel
    {
		private readonly IProjectsData projDb;
        public List<MyProjectModel> LatestProjects { get; set; }
        public int RoadsCount { get; set; }
        public List<MyStateModel> States { get; set; }
        public MyStateModel State { get; set; }
        public List<MyProjectCategoryModel> ProjectCategories { get; set; }
        public MyProjectCategoryModel ProjectCategory { get; set; }
        [BindProperty]
        public MyProjectModel Project { get; set; }


        [BindProperty(SupportsGet = true) ]
        public string SearchTerm { get; set; }

        public IndexModel(IProjectsData projDb)
        {
			this.projDb = projDb;
            LatestProjects = new List<MyProjectModel>();
            States = new List<MyStateModel>();
            ProjectCategories = new List<MyProjectCategoryModel>();
            Project = new MyProjectModel();
		}
        public void OnGet()
        {
            try
            {
                LatestProjects = projDb.GetLatestProjects() ?? new List<MyProjectModel>();
                RoadsCount = projDb.CountRoadProjects();
                States = projDb.GetStates() ?? new List<MyStateModel>();
                ProjectCategories = projDb.GetProjectCategories() ?? new List<MyProjectCategoryModel>();
            }
            catch
            {
                // Graceful fallback: allows the page to load even if the PMIS database is offline or unconfigured
                LatestProjects = new List<MyProjectModel>();
                States = new List<MyStateModel>();
                ProjectCategories = new List<MyProjectCategoryModel>();
            }
        }
        public async Task<IActionResult> OnPost()
        {
            return RedirectToPage("SearchResults", new { projName = Project.ProjectName, sid = Project.SID, pcid = Project.PCID });
        }
    }
}

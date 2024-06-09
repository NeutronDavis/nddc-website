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
		}
        public void OnGet()
        {
            LatestProjects = projDb.GetLatestProjects();
            RoadsCount = projDb.CountRoadProjects();
            States = projDb.GetStates();
            ProjectCategories = projDb.GetProjectCategories();
        }
        public async Task<IActionResult> OnPost()
        {
            return RedirectToPage("SearchResults", new { projName = Project.ProjectName, sid = Project.SID, pcid = Project.PCID });
        }
    }
}

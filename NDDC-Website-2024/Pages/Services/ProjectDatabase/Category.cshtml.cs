using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class CategoryModel : PageModel
    {
        private readonly IProjectsData projDb;
        public List<MyProjectModel> Projects { get; set; } = new();
        public MyProjectCategoryModel Category { get; set; } = new();
        public int TotalProjects { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)TotalProjects / PageSize) : 1;
        public int PCID { get; set; } = 1;
        public string? ErrorMessage { get; set; }

        public CategoryModel(IProjectsData projDb)
        {
            this.projDb = projDb;
        }

        public void OnGet(int pcid = 1, int pageNumber = 1)
        {
            PCID = pcid <= 0 ? 1 : pcid;
            CurrentPage = pageNumber < 1 ? 1 : pageNumber;
            try
            {
                Category = projDb.GetCategoryById(PCID) ?? new MyProjectCategoryModel { PCID = PCID, CatName = "Category Projects" };
                TotalProjects = projDb.CountCategoryProjects(PCID);
                Projects = projDb.GetProjectsByCategoryPaged(PCID, CurrentPage, PageSize) ?? new List<MyProjectModel>();
                if (TotalProjects == 0 && Projects.Any())
                {
                    TotalProjects = Projects.Count;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                Category ??= new MyProjectCategoryModel { PCID = PCID, CatName = "Category Projects" };
                Projects = new List<MyProjectModel>();
            }
        }
    }
}

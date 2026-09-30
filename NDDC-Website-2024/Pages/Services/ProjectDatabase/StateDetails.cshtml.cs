using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;
using System.Linq;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class StateDetailsModel : PageModel
    {
        private readonly IProjectsData projDb;
        public MyStateModel State { get; set; } = new();
        public List<MyStateModel> States { get; set; } = new();
        public List<MyProjectModel> Projects { get; set; } = new();
        public int SID { get; set; } = 2;
        public Dictionary<string, int> SectorBreakdown { get; set; } = new();

        public StateDetailsModel(IProjectsData projDb)
        {
            this.projDb = projDb;
        }

        public void OnGet(int sid = 2)
        {
            SID = sid <= 0 ? 2 : sid;
            try
            {
                States = projDb.GetStates() ?? new List<MyStateModel>();
                State = States.FirstOrDefault(s => s.SID == SID) ?? new MyStateModel { SID = SID, StateName = "State Projects" };
                Projects = projDb.GetProjectsAdhocAsync("", SID, 0) ?? new List<MyProjectModel>();

                if (Projects.Any())
                {
                    SectorBreakdown = Projects
                        .GroupBy(p => string.IsNullOrWhiteSpace(p.CatName) ? "Other" : p.CatName)
                        .OrderByDescending(g => g.Count())
                        .ToDictionary(g => g.Key, g => g.Count());
                }
            }
            catch
            {
                States = new List<MyStateModel>();
                State = new MyStateModel { SID = SID, StateName = "State Projects" };
                Projects = new List<MyProjectModel>();
                SectorBreakdown = new Dictionary<string, int>();
            }
        }
    }
}

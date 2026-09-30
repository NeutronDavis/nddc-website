using EFCore_Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class DirectorsModel : PageModel
    {
        private readonly NDDCWebsiteContext context;
        private readonly IHomeData homeDb;
        public readonly string _containerUrl;
        public MyExecMngtModel ChairmanItem { get; set; }
        public List<MyExecMngtModel> BoardMembers { get; set; }
        public List<Director> MyDirectors { get; set; }

        public DirectorsModel(NDDCWebsiteContext context, IHomeData homeDb, IConfiguration configuration)
        {
            this.context = context;
            this.homeDb = homeDb;
            _containerUrl = configuration.GetConnectionString("AWSContainerUrl");
            BoardMembers = new List<MyExecMngtModel>();
            MyDirectors = new List<Director>();
        }
        public void OnGet()
        {
            ChairmanItem = homeDb.GetChairmanSingle();
            BoardMembers = homeDb.GetAllBoardMembers() ?? new List<MyExecMngtModel>();
            MyDirectors = context.Directors.OrderBy(p => p.PositionCount).ToList() ?? new List<Director>();
        }
    }
}

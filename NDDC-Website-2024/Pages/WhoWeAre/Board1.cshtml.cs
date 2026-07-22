using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class Board1Model : PageModel
    {
		private readonly IHomeData homeDb;
		public readonly string _containerUrl;
        public MyExecMngtModel ChairmanItem { get; set; }
        public List<MyExecMngtModel> BoardMembers { get; set; }

        public Board1Model(IHomeData homeDb, IConfiguration configuration)
        {
			this.homeDb = homeDb;
			_containerUrl = configuration.GetConnectionString("AWSContainerUrl");
			BoardMembers = new List<MyExecMngtModel>();
		}
        public void OnGet()
        {
		    ChairmanItem = homeDb.GetChairmanSingle();
            BoardMembers = homeDb.GetAllBoardMembers() ?? new List<MyExecMngtModel>();
        }
    }
}

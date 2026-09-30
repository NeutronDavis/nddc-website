using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class BoardDetails1Model : PageModel
    {
        public MyExecMngtModel BoardDetails { get; set; }
        private readonly IHomeData homeDb;
		private readonly IConfiguration config;
		public readonly string _containerUrl;
		public BoardDetails1Model(IHomeData homeDb, IConfiguration config)
        {
			this.homeDb = homeDb;
			_containerUrl = config.GetConnectionString("AWSContainerUrl");
		}
        public IActionResult OnGet(int? EMID)
        {
            if (!EMID.HasValue || EMID.Value <= 0)
            {
                return RedirectToPage("/WhoWeAre/Board");
            }
            BoardDetails = homeDb.ViewExecMngtDetails(EMID.Value);
            if (BoardDetails == null)
            {
                return RedirectToPage("/WhoWeAre/Board");
            }
            return Page();
        }
    }
}

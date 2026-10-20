using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class BoardDetailsModel : PageModel
    {
        public MyExecMngtModel BoardDetails { get; set; }
        private readonly IHomeData homeDb;
        public readonly string _containerUrl;

        public BoardDetailsModel(IHomeData homeDb, IConfiguration config)
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

            BoardDetails = homeDb.ViewBoardMemberDetails(EMID.Value);

            if (BoardDetails == null)
            {
                return RedirectToPage("/WhoWeAre/Board");
            }

            return Page();
        }
    }
}

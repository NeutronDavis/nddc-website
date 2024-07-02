using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.News
{
    public class AnnouncementDetailsModel : PageModel
    {
		private readonly IHomeData homeDb;
        public MyAnnouncementModel Details { get; set; }
        public AnnouncementDetailsModel(IHomeData homeDb)
        {
			this.homeDb = homeDb;
		}
        public void OnGet(int? Id)
        {
            Details = homeDb.ViewAnnouncementDetails(Id.Value);

		}
    }
}

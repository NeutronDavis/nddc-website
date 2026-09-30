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
        public IActionResult OnGet(int? Id)
        {
            if (!Id.HasValue || Id.Value <= 0)
            {
                return RedirectToPage("/News/Announcements");
            }
            Details = homeDb.ViewAnnouncementDetails(Id.Value);
            if (Details == null)
            {
                return RedirectToPage("/News/Announcements");
            }
            return Page();
        }
    }
}

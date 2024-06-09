using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.News
{
    public class AnnouncementsModel : PageModel
    {
		private readonly IHomeData homeDb;
		public List<MyAnnouncementModel> Announcements { get; set; }
		public AnnouncementsModel(IHomeData homeDb)
        {
			this.homeDb = homeDb;
		}
        public void OnGet()
        {
			Announcements = homeDb.ViewAllAnnoncements();
		}
    }
}

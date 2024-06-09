using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.Media
{
    public class VideosModel : PageModel
    {
		private readonly IHomeData homeDb;
        public List<MyVideoModel> Videos { get; set; }
        public VideosModel(IHomeData homeDb)
        {
			this.homeDb = homeDb;
		}
        public void OnGet()
        {
			Videos = homeDb.DisplayVideos();
		}
    }
}

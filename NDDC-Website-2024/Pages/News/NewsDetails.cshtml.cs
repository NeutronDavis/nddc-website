using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.News
{
    public class NewsDetailsModel : PageModel
    {
        private readonly IHomeData homeDb;
		private readonly IConfiguration config;

		public MyNewsModel NewsDetails { get; set; }
        public List<MyNewsModel> PhotoGallery { get; set; }

        public readonly string _containerUrl;

		public NewsDetailsModel(IHomeData homeDb, IConfiguration config)
		{
            this.homeDb = homeDb;
			_containerUrl = config.GetConnectionString("AWSContainerUrl");
		}
        public void OnGet(int? nid)
        {
            NewsDetails = homeDb.GetNewsDetails(nid.Value);
            PhotoGallery = homeDb.GetNewsPhotoGallery(nid.Value);
        }
    }
}

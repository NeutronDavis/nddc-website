using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.Media
{
    public class PhotoAlbumModel : PageModel
    {
		private readonly IHomeData homeDb;
		public List<MyPhotoSpeakModel> Photos { get; set; }
		private readonly IConfiguration config;
		public readonly string _containerUrl;
		public PhotoAlbumModel(IHomeData homeDb, IConfiguration config)
        {
			this.homeDb = homeDb;
			_containerUrl = config.GetConnectionString("AWSContainerUrl");
		}
        public void OnGet()
        {
			Photos = homeDb.DisplayPhotos();
		}
    }
}

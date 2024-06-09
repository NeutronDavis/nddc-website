using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.News
{
    public class UpdatesModel : PageModel
    {
		private readonly IHomeData homeDb;
		private readonly IConfiguration config;
        public List<MyUpdateModel> Updates { get; set; }
		public MyUpdateModel PhysicalInfraUpdatePhoto { get; set; }
		public MyUpdateModel SocialInfraUpdatePhoto { get; set; }
		public MyUpdateModel PartnershipsPhoto { get; set; }
		public readonly string _containerUrl;
		public UpdatesModel(IHomeData homeDb, IConfiguration config)
        {
			this.homeDb = homeDb;
			_containerUrl = config.GetConnectionString("AWSContainerUrl");
		}
        public void OnGet()
        {
			PhysicalInfraUpdatePhoto = homeDb.GetImageByUpdateCategory("Physical");
			SocialInfraUpdatePhoto = homeDb.GetImageByUpdateCategory("Social");
			PartnershipsPhoto = homeDb.GetImageByUpdateCategory("Partnerships");
		}
    }
}

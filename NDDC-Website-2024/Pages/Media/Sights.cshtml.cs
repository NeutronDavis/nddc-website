using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.Media
{
    public class SightsModel : PageModel
    {
        public List<MySightsAndIconModel> Sights{ get; set; }
        private readonly IHomeData homeDb;
		private readonly IConfiguration config;
		public readonly string _containerUrl;
		public SightsModel(IHomeData homeDb, IConfiguration config)
        {
			this.homeDb = homeDb;
			_containerUrl = config.GetConnectionString("AWSContainerUrl");

		}
		public void OnGet()
        {
			Sights = homeDb.ViewAllSightsAndIcons();
		}
    }
}

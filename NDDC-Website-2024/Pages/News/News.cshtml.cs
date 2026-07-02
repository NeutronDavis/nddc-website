using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages
{
    public class NewsModel : PageModel
    {
        private readonly IHomeData homeDb;
		private readonly IConfiguration config;

		public List<MyNewsModel> NewsList { get; set; }
		public MyNewsModel LatestNews { get; set; }

        public readonly string _containerUrl;
		public NewsModel(IHomeData homeDb, IConfiguration config)
        {
            this.homeDb = homeDb;
			_containerUrl = config.GetConnectionString("AWSContainerUrl");
			NewsList = new List<MyNewsModel>();
		}
        public void OnGet()
        {
            NewsList = homeDb.AllNews() ?? new List<MyNewsModel>();
            LatestNews = homeDb.GetLatestNews();
        }
    }
}

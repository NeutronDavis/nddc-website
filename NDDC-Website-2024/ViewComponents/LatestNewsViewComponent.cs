using Microsoft.AspNetCore.Mvc;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.ViewComponents
{
	public class LatestNewsViewComponent : ViewComponent
	{
		private readonly IHomeData homeDb;

		public LatestNewsViewComponent(IHomeData homeDb)
        {
			this.homeDb = homeDb;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			MyNewsModel latestNews = homeDb.GetLatestNews();

			return View<MyNewsModel>("default", latestNews);
		}
	}
}

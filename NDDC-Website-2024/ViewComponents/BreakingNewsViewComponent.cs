using Microsoft.AspNetCore.Mvc;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;
using System.Threading.Tasks;

namespace NDDC_Website_2024.ViewComponents
{
	public class BreakingNewsViewComponent : ViewComponent
	{
		private readonly IHomeData homeDb;

		public BreakingNewsViewComponent(IHomeData homeDb)
        {
			this.homeDb = homeDb;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			MyNewsModel breakingNews = homeDb.GetBreakingNews();
			
			return View<MyNewsModel>("default", breakingNews);
		}

	}
}

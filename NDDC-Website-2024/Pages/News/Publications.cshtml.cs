using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.News
{
    public class PublicationsModel : PageModel
    {
		private readonly IHomeData homeDb;
		public List<MyPublicationsModel> Publications { get; set; }
		public PublicationsModel(IHomeData homeDb)
        {
			this.homeDb = homeDb;
			Publications = new List<MyPublicationsModel>();
		}
        public void OnGet()
        {
			Publications = homeDb.ViewAllPublications() ?? new List<MyPublicationsModel>();
        }
    }
}

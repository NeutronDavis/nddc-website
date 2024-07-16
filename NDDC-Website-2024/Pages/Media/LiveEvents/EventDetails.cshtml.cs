using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.Media.LiveEvents
{
    public class EventDetailsModel : PageModel
    {
		private readonly IHomeData homeDb;
		public readonly string _containerUrl;

        public MyLiveEventModel EventDetails { get; set; }
        public EventDetailsModel(IHomeData homeDb, IConfiguration configuration)
        {
			this.homeDb = homeDb;

			_containerUrl = configuration.GetConnectionString("AWSContainerUrl");
		}
        public void OnGet(int? Id)
        {
            EventDetails = homeDb.GetLiveEventDetails(Id.Value);

		}
    }
}

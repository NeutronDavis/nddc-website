using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.Media.LiveEvents
{
    public class EventsModel : PageModel
    {
		private readonly IHomeData homeDb;
		public readonly string _containerUrl;
		public bool IsEventLive { get; set; }
		public DateTime CountDownDate { get; set; }
		public MyLiveEventModel LiveEvent { get; set; }
        public EventsModel(IHomeData homeDb, IConfiguration configuration)
        {
			this.homeDb = homeDb;
			_containerUrl = configuration.GetConnectionString("AWSContainerUrl");
		}

        public void OnGet()
        {
			LiveEvent = homeDb.GetLiveEventForEventsPage();
			if (LiveEvent != null)
			{
				CountDownDate = new DateTime(LiveEvent.StartDate.Year, LiveEvent.StartDate.Month, LiveEvent.StartDate.Day, 0, 00, 00);
			}

			IsEventLive = homeDb.GoLive();
		}
    }
}

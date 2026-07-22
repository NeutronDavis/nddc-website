using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages
{
    public class Index1Model : PageModel
    {
        private readonly IHomeData homeDb;
        public List<MyNewsModel> NewsSlide { get; set; }
        public List<MyNewsModel> NewsList { get; set; }
        public readonly string _containerUrl;
        public List<MyPhotoSpeakModel> Photos { get; set; }
        public MyUpdateModel PhysicalInfraUpdatePhoto { get; set; }
        public MyUpdateModel SocialInfraUpdatePhoto { get; set; }
        public MyUpdateModel PartnershipsPhoto { get; set; }
        public MyVideoModel MainVideo { get; set; }
        public List<MyVideoModel> Videos { get; set; }
        public MyAnnouncementModel Announcement { get; set; }
        public MyNewsModel CriticalUpdate { get; set; }
        public List<MyTestimonialModel> Testimonials { get; set; }
        public DateTime CountDownDate { get; set; }
        public MyLiveEventModel LiveEvent { get; set; }
        public bool IsEventLive { get; set; }
        public Index1Model(IHomeData homeDb, IConfiguration configuration)
        {
            this.homeDb = homeDb;
			_containerUrl = configuration.GetConnectionString("AWSContainerUrl");

            // Initialise lists to empty so Razor foreach never receives null
            NewsSlide    = new List<MyNewsModel>();
            NewsList     = new List<MyNewsModel>();
            Photos       = new List<MyPhotoSpeakModel>();
            Videos       = new List<MyVideoModel>();
            Testimonials = new List<MyTestimonialModel>();
		}

        public void OnGet()
        {
            NewsSlide                = homeDb.DisplaySlides()           ?? new List<MyNewsModel>();
            NewsList                 = homeDb.ListHomePageNews()?.Take(3).ToList() ?? new List<MyNewsModel>();
            Photos                   = homeDb.DisplayPhotos()            ?? new List<MyPhotoSpeakModel>();
            PhysicalInfraUpdatePhoto = homeDb.GetImageByUpdateCategory("Physical");
            SocialInfraUpdatePhoto   = homeDb.GetImageByUpdateCategory("Social");
            PartnershipsPhoto        = homeDb.GetImageByUpdateCategory("Partnerships");
            MainVideo                = homeDb.DisplayMainVideo();
            Videos                   = homeDb.DisplayVideos()            ?? new List<MyVideoModel>();
            Announcement             = homeDb.GetAnnouncement();
            CriticalUpdate           = homeDb.GetCriticalNewsUpdate();
            Testimonials             = homeDb.ViewTestimonials()         ?? new List<MyTestimonialModel>();
            //CountDownDate = new DateTime(2024, 7, 10, 07, 00, 00);
            LiveEvent = homeDb.GetLiveEvent();
            if (LiveEvent != null)
            {
				CountDownDate = new DateTime(LiveEvent.StartDate.Year, LiveEvent.StartDate.Month, LiveEvent.StartDate.Day, LiveEvent.StartTime.Hour, LiveEvent.StartTime.Minute, 00);
			}
            
            IsEventLive = homeDb.GoLive();
		}
    }
}
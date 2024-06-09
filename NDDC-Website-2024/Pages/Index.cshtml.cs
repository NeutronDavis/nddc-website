using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages
{
    public class IndexModel : PageModel
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
        public IndexModel(IHomeData homeDb, IConfiguration configuration)
        {
            this.homeDb = homeDb;
			_containerUrl = configuration.GetConnectionString("AWSContainerUrl");
		}

        public void OnGet()
        {
            NewsSlide = homeDb.DisplaySlides();
            NewsList = homeDb.ListHomePageNews();
            Photos = homeDb.DisplayPhotos();
            PhysicalInfraUpdatePhoto = homeDb.GetImageByUpdateCategory("Physical");
            SocialInfraUpdatePhoto = homeDb.GetImageByUpdateCategory("Social");
            PartnershipsPhoto = homeDb.GetImageByUpdateCategory("Partnerships");
            MainVideo = homeDb.DisplayMainVideo();
            Videos = homeDb.DisplayVideos();
            Announcement = homeDb.GetAnnouncement();
            CriticalUpdate = homeDb.GetCriticalNewsUpdate();
        }
    }
}
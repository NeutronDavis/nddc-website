using NddcWebsiteLibrary.Model.Home;

namespace NddcWebsiteLibrary.Data.Home
{
    public interface IHomeData
    {
        List<MyNewsModel> AllNews();
		List<MyVideoModel> DisplayAllVideos();
		MyVideoModel DisplayMainVideo();
        List<MyPhotoSpeakModel> DisplayPhotos();
        List<MyNewsModel> DisplaySlides();
		List<MyUpdateModel> DisplayUpdateSlidesForProgram();
		List<MyUpdateModel> DisplayUpdateSlidesForProjects();
		List<MyVideoModel> DisplayVideos();
		List<MyExecMngtModel> GetAllBoardMembers();
		MyAnnouncementModel GetAnnouncement();
        MyNewsModel GetBreakingNews();
		MyExecMngtModel GetChairmanSingle();
		MyNewsModel GetCriticalNewsUpdate();
        MyUpdateModel? GetImageByUpdateCategory(string updateCategory);
		MyNewsModel GetLatestNews();
		MyLiveEventModel GetLiveEvent();
        MyLiveEventModel GetLiveEventForEventsPage();
        MyNewsModel GetNewsDetails(int nid);
		List<MyNewsModel> GetNewsPhotoGallery(int newsId);
		List<MyUpdateModel> GetUpdatesListForProgram();
		List<MyUpdateModel> GetUpdatesListForProject();
		bool GoLive();
		List<MyNewsModel> ListHomePageNews();
		List<MyAnnouncementModel> ViewAllAnnoncements();
		List<MyExecMngtModel> ViewAllExecutiveManagement();
		List<MyPublicationsModel> ViewAllPublications();
		List<MySightsAndIconModel> ViewAllSightsAndIcons();
		List<MyTenderModel> ViewAllTenders();
		MyAnnouncementModel ViewAnnouncementDetails(int id);
		MyExecMngtModel ViewBoardMemberDetails(int emid);
		MyExecMngtModel ViewExecMngtDetails(int emid);
		MySightsAndIconModel ViewSightsAndIconDetails(int id);
		MyTenderModel ViewTenderDetails(int Id);
		List<MyTestimonialModel> ViewTestimonials();
	}
}
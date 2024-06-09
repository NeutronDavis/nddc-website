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
        MyAnnouncementModel GetAnnouncement();
        MyNewsModel GetBreakingNews();
        MyNewsModel GetCriticalNewsUpdate();
        MyUpdateModel? GetImageByUpdateCategory(string updateCategory);
		MyNewsModel GetLatestNews();
		MyNewsModel GetNewsDetails(int nid);
		List<MyNewsModel> GetNewsPhotoGallery(int newsId);
		List<MyUpdateModel> GetUpdatesListForProgram();
		List<MyUpdateModel> GetUpdatesListForProject();
		List<MyNewsModel> ListHomePageNews();
		List<MyAnnouncementModel> ViewAllAnnoncements();
		List<MyExecMngtModel> ViewAllExecutiveManagement();
		List<MyPublicationsModel> ViewAllPublications();
		List<MySightsAndIconModel> ViewAllSightsAndIcons();
		List<MyTenderModel> ViewAllTenders();
		MyAnnouncementModel ViewAnnouncementDetails(int id);
		MyExecMngtModel ViewExecMngtDetails(int emid);
		MySightsAndIconModel ViewSightsAndIconDetails(int id);
		MyTenderModel ViewTenderDetails(int Id);
    }
}
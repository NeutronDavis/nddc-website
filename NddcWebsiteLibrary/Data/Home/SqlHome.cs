
using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.Home
{
    public class SqlHome : IHomeData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlHome(ISqlDataAccess db)
        {
            this.db = db;
        }

        //News
        public List<MyNewsModel> DisplaySlides()
        {
            return db.LoadData<MyNewsModel, dynamic>("Select Top 3 NID, Subject, Summary, ImageUrl From News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyNewsModel> AllNews()
        {
            return db.LoadData<MyNewsModel, dynamic>("select Top 20 ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide from News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyNewsModel> ListHomePageNews()
        {
            //list all items in home page
            return db.LoadData<MyNewsModel, dynamic>("select top 3 ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide from News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public MyNewsModel GetNewsDetails(int nid)
        {
          
            return db.LoadData<MyNewsModel, dynamic>("Select NID, Subject, Summary, Details, ImageUrl, PublishDate, ExpiryDate, Type from News Where NID = @NID Order By NID DESC", new { NID = nid }, connectionStringName, false).FirstOrDefault();
        }
		public List<MyNewsModel> GetNewsPhotoGallery(int newsId)
		{
			//list all items in home page
			return db.LoadData<MyNewsModel, dynamic>("Select ImageUrl from NewsPhotoGallery Where NewsId = @NewsId Order By Id DESC", new { NewsId = newsId }, connectionStringName, false).ToList();
		}
		public MyNewsModel GetLatestNews()
		{

			return db.LoadData<MyNewsModel, dynamic>("Select Top 1 NID, Subject from News Order By NID DESC", new { }, connectionStringName, false).FirstOrDefault();
		}

		//Photo Speak Methods
		public List<MyPhotoSpeakModel> DisplayPhotos()
        {
            return db.LoadData<MyPhotoSpeakModel, dynamic>("Select Top 40 Id, Title, Location, ImageUrl From PhotoSPeak Order By Id DESC", new { }, connectionStringName, false).ToList();
        }

        //Updates
        public MyUpdateModel GetImageByUpdateCategory(string updateCategory)
        {
            return db.LoadData<MyUpdateModel, dynamic>("select top 1 Id, Title, DescriptionImage from Updates Where UpdateCategory = @UpdateCategory Order By Id DESC", new { UpdateCategory = updateCategory }, connectionStringName, false).SingleOrDefault();
        }
		public List<MyUpdateModel> DisplayUpdateSlidesForProjects()
		{
			return db.LoadData<MyUpdateModel, dynamic>("Select Top 3 Id, Title, DescriptionImage, Location From Updates Where UpdateType = 'Project' Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public List<MyUpdateModel> DisplayUpdateSlidesForProgram()
		{
			return db.LoadData<MyUpdateModel, dynamic>("Select Top 3 Id, Title, DescriptionImage, Location From Updates Where UpdateType = 'Program' Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public List<MyUpdateModel> GetUpdatesListForProject()
		{
			return db.LoadData<MyUpdateModel, dynamic>("Select Top 5 Id, ProjectProgramType, Title, DescriptionImage, Location From Updates Where UpdateType = 'Project' Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public List<MyUpdateModel> GetUpdatesListForProgram()
		{
			return db.LoadData<MyUpdateModel, dynamic>("Select Top 5 Id, ProjectProgramType, Title, DescriptionImage, Location From Updates Where UpdateType = 'Program' Order By Id DESC", new { }, connectionStringName, false).ToList();
		}

		//Videos
		public List<MyVideoModel> DisplayVideos()
        {
            return db.LoadData<MyVideoModel, dynamic>("Select Top 4 Id, VideoTitle, VideoDesc, YoutubeUrl From Videos Order By Id DESC", new { }, connectionStringName, false).ToList();
        }
		public List<MyVideoModel> DisplayAllVideos()
		{
			return db.LoadData<MyVideoModel, dynamic>("Select Top 40 Id, VideoTitle, VideoDesc, YoutubeUrl From Videos Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public MyVideoModel DisplayMainVideo()
        {
            return db.LoadData<MyVideoModel, dynamic>("Select Top 1 Id, VideoTitle, VideoDesc, YoutubeUrl From Videos Order By Id DESC", new { }, connectionStringName, false).FirstOrDefault();
        }

        //Tenders
        public List<MyTenderModel> ViewAllTenders()
        {
            return db.LoadData<MyTenderModel, dynamic>("Select Id, Title, Category, DocumentUrl, AdvertDate, DeadlineDate From Tenders Order By Id DESC", new { }, connectionStringName, false).ToList();
        }
        public MyTenderModel ViewTenderDetails(int id)
        {
            return db.LoadData<MyTenderModel, dynamic>("Select Id, Title, Category, DocumentUrl, AdvertDate, DeadlineDate From Tenders Where Id = @Id Order By Id DESC", new { Id = id }, connectionStringName, false).FirstOrDefault();
        }

        //Breaking News
		public MyNewsModel GetBreakingNews()
		{
			DateTime publishDate = db.LoadData<DateTime, dynamic>("select top 1 PublishDate from News Where DisplayFormat = 'Breaking' Order By NID DESC", new { }, connectionStringName, false).SingleOrDefault();

            DateTime endDate = publishDate.AddDays(3);
            DateTime currDate = DateTime.Now;

			if (currDate < endDate)
			{
				return db.LoadData<MyNewsModel, dynamic>("Select Top 1 NID, Subject from News Where DisplayFormat = 'Breaking' Order By NID DESC", new { }, connectionStringName, false).SingleOrDefault();
			}

			return null;
		}

        //Critical News Update
        public MyNewsModel GetCriticalNewsUpdate()
        {
            DateTime publishDate = db.LoadData<DateTime, dynamic>("select top 1 PublishDate from News Where DisplayFormat = 'Critical' Order By NID DESC", new { }, connectionStringName, false).SingleOrDefault();

            DateTime endDate = publishDate.AddDays(3);
            DateTime currDate = DateTime.Now;

            if (currDate <= endDate)
            {
                return db.LoadData<MyNewsModel, dynamic>("Select Top 1 NID, Subject, ImageUrl from News Where DisplayFormat = 'Critical' Order By NID DESC", new { }, connectionStringName, false).SingleOrDefault();
            }

            return null;
        }

        //Announcement
        public MyAnnouncementModel GetAnnouncement()
        {
            DateTime endDate = db.LoadData<DateTime, dynamic>("select top 1 EndDate from Announcements Order By Id DESC", new { }, connectionStringName, false).SingleOrDefault();

            DateTime currDate = DateTime.Now;

            if (currDate <= endDate)
            {
                return db.LoadData<MyAnnouncementModel, dynamic>("Select Top 1 Id, Title, Details from Announcements Order By Id DESC", new { }, connectionStringName, false).SingleOrDefault();
            }

            return null;
        }
		public List<MyAnnouncementModel> ViewAllAnnoncements()
		{
			return db.LoadData<MyAnnouncementModel, dynamic>("Select Id, Title, StartDate, Details From Announcements Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public MyAnnouncementModel ViewAnnouncementDetails(int id)
		{
			return db.LoadData<MyAnnouncementModel, dynamic>("Select Id, Title, StartDate, Details From Announcements Where Id = @Id Order By Id DESC", new { Id = id }, connectionStringName, false).FirstOrDefault();
		}

		//Publication
		public List<MyPublicationsModel> ViewAllPublications()
		{
			return db.LoadData<MyPublicationsModel, dynamic>("Select PubId, PubTitle, PubUploadUrl From Publications Order By PubId DESC", new { }, connectionStringName, false).ToList();
		}

		//SightsAndIcons
		public List<MySightsAndIconModel> ViewAllSightsAndIcons()
		{
			return db.LoadData<MySightsAndIconModel, dynamic>("Select Id, Title, Summary, ImageUrl From SightsAndIcons Order By Id DESC", new { }, connectionStringName, false).ToList();
		}
		public MySightsAndIconModel ViewSightsAndIconDetails(int id)
		{
			return db.LoadData<MySightsAndIconModel, dynamic>("Select Id, Title, Summary, ImageUrl From SightsAndIcons Where Id = @Id Order By Id DESC", new { Id = id }, connectionStringName, false).FirstOrDefault();
		}

		//Executive Management (Board)
		public List<MyExecMngtModel> ViewAllExecutiveManagement()
		{
			return db.LoadData<MyExecMngtModel, dynamic>("Select EMID, ExecName, Position, ImageUrl, PositionCount From ExecMngt Order By PositionCount DESC", new { }, connectionStringName, false).ToList();
		}
		public MyExecMngtModel ViewExecMngtDetails(int emid)
		{
			return db.LoadData<MyExecMngtModel, dynamic>("Select EMID, ExecName, Position, ImageUrl, Details, PositionCount From ExecMngt Where EMID = @Id", new { Id = emid }, connectionStringName, false).FirstOrDefault();
		}
	}
}

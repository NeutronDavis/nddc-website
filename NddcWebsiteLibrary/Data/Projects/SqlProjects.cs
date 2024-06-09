using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.Home;
using NddcWebsiteLibrary.Model.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.Projects
{
	public class SqlProjects : IProjectsData
	{
		private const string connectionStringName = "PMIS";
		private readonly ISqlDataAccess db;

		public SqlProjects(ISqlDataAccess db)
		{
			this.db = db;
		}

		public List<MyProjectModel> GetLatestProjects()
        {
			return db.LoadData<MyProjectModel, dynamic>("SELECT TOP(6) Projects.PID, Projects.ProjectName, ProjectLocation.Location, ProjectCategory.CatName FROM  Projects INNER JOIN ProjectCategory ON Projects.PCID = ProjectCategory.PCID LEFT OUTER JOIN ProjectLocation ON Projects.LID = ProjectLocation.PLID ORDER BY Projects.PID DESC", new { }, connectionStringName, false).ToList();
		}
		public int CountRoadProjects()
		{
			return db.LoadData<int, dynamic>("Select Count(PID) As ProjCount From Projects Where PCID = 1", new { }, connectionStringName, false).FirstOrDefault();
		}
        public MyProjectModel GetProjectDetails(int pid)
        {
            return db.LoadData<MyProjectModel, dynamic>("SELECT Projects.PID, Projects.ProjectName, Projects.CommencementDate, Projects.Status, Projects.Contractor, ProjectLocation.Location, ProjectCategory.CatName, State.StateName FROM  Projects INNER JOIN ProjectCategory ON Projects.PCID = ProjectCategory.PCID INNER JOIN State ON Projects.SID = State.SID LEFT OUTER JOIN ProjectLocation ON Projects.LID = ProjectLocation.PLID Where PID = @PID", new { PID = pid }, connectionStringName, false).FirstOrDefault();
        }
        public List<MyProjectModel> ViewRoadsAndBridgesProjects()
		{
			return db.LoadData<MyProjectModel, dynamic>("SELECT Projects.ProjectName, State.StateName, ProjectLocation.Location FROM Projects INNER JOIN ProjectLocation ON Projects.PLID = ProjectLocation.PLID CROSS JOIN State Where PCID = 1 Order By NID DESC", new { }, connectionStringName, false).ToList();
		}
        public List<MyActivityImageModel> GetProjectPictures(int pid)
        {
            return db.LoadData<MyActivityImageModel, dynamic>("SELECT ImageUrl From ActivityImages Where PID = @PID", new { PID = pid }, connectionStringName, false).ToList();
        }
        public List<MyStateModel> GetStates()
        {
            return db.LoadData<MyStateModel, dynamic>("SELECT SID, StateName From State Where StateType = 'NDDC'", new { }, connectionStringName, false).ToList();
        }
        public List<MyProjectCategoryModel> GetProjectCategories()
        {
            return db.LoadData<MyProjectCategoryModel, dynamic>("SELECT PCID, CatName From ProjectCategory", new { }, connectionStringName, false).ToList();
        }
		public List<MyProjectModel> GetProjectsAdhocAsync(string projectName, int sid, int pcid)
		{

			//MyPayRollListModel reportModel;
			List<MyProjectModel> Projects = new List<MyProjectModel>();
			//List<Task<decimal>> tasks = new List<Task<decimal>>();

			bool toggle = false;
			string glSchema = "";

			if (projectName != "")
			{
				if (toggle == true)
				{
					glSchema = $"Projects.ProjectName Like '%{projectName}%'";
				}
				else
				{
					glSchema = $"Where Projects.ProjectName Like '%{projectName}%'";
					toggle = true;
				}
			}

			if (sid != 0)
			{
				if (toggle == true)
				{
					glSchema = $"{glSchema} And Projects.SID = {sid}";
				}
				else
				{
					glSchema = $"Where Projects.SID = {sid}";
					toggle = true;
				}
			}
			if (pcid != 0)
			{
				if (toggle == true)
				{
					glSchema = $"{glSchema} And Projects.PCID = {pcid}";
				}
				else
				{
					glSchema = $"Where Projects.PCID = {pcid}";
					toggle = true;
				}
			}

			string SQL2 = $"SELECT Top 50  ROW_NUMBER() OVER (ORDER BY Projects.PID DESC) As SrNo, Projects.PID, Projects.ProjectName, ProjectLocation.Location, ProjectCategory.CatName, State.StateName FROM  Projects INNER JOIN ProjectCategory ON Projects.PCID = ProjectCategory.PCID INNER JOIN State ON Projects.SID = State.SID LEFT OUTER JOIN ProjectLocation ON Projects.LID = ProjectLocation.PLID {glSchema} ORDER BY Projects.PID DESC";

			Projects = db.LoadData<MyProjectModel, dynamic>(SQL2, new { }, connectionStringName, false).ToList();

			return Projects;
		}












	}
}

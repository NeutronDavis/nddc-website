using NddcWebsiteLibrary.Model.Projects;

namespace NddcWebsiteLibrary.Data.Projects
{
	public interface IProjectsData
	{
		int CountRoadProjects();
		List<MyProjectModel> GetLatestProjects();
        List<MyProjectCategoryModel> GetProjectCategories();
        MyProjectModel GetProjectDetails(int pid);
        List<MyActivityImageModel> GetProjectPictures(int pid);
        List<MyProjectModel> GetProjectsAdhocAsync(string projectName, int sid, int pcid);
		List<MyStateModel> GetStates();
        List<MyProjectModel> ViewRoadsAndBridgesProjects();
        List<MyProjectCategoryModel> GetTopCategoriesWithCounts(int count = 4);
        MyProjectCategoryModel GetCategoryById(int pcid);
        int CountCategoryProjects(int pcid);
        List<MyProjectModel> GetProjectsByCategory(int pcid, int top = 50);
        List<MyProjectModel> GetProjectsByCategoryPaged(int pcid, int pageNumber, int pageSize);
        MyProjectInsightsModel GetProjectInsights();
	}
}
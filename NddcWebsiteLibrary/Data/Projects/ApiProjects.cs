using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using NddcWebsiteLibrary.Model.Projects;

namespace NddcWebsiteLibrary.Data.Projects
{
    public class ApiProjects : IProjectsData
    {
        private readonly HttpClient _client;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiProjects(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("PmisApi");
        }

        public List<MyStateModel> GetStates()
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyStateModel>>("states", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyStateModel>();
            }
            catch
            {
                return new List<MyStateModel>();
            }
        }

        public List<MyProjectCategoryModel> GetProjectCategories()
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyProjectCategoryModel>>("categories", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyProjectCategoryModel>();
            }
            catch
            {
                return new List<MyProjectCategoryModel>();
            }
        }

        public List<MyProjectCategoryModel> GetTopCategoriesWithCounts(int count = 4)
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyProjectCategoryModel>>($"categories/top?count={count}", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyProjectCategoryModel>();
            }
            catch
            {
                return new List<MyProjectCategoryModel>();
            }
        }

        public MyProjectCategoryModel GetCategoryById(int pcid)
        {
            try
            {
                return _client.GetFromJsonAsync<MyProjectCategoryModel>($"categories/{pcid}", _jsonOptions).GetAwaiter().GetResult() ?? new MyProjectCategoryModel();
            }
            catch
            {
                return new MyProjectCategoryModel();
            }
        }

        public int CountCategoryProjects(int pcid)
        {
            try
            {
                var res = _client.GetFromJsonAsync<List<MyProjectModel>>($"by-category/{pcid}?pageNumber=1&pageSize=1", _jsonOptions).GetAwaiter().GetResult();
                return res?.Count ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        public List<MyProjectModel> GetLatestProjects()
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyProjectModel>>("latest?top=6", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyProjectModel>();
            }
            catch
            {
                return new List<MyProjectModel>();
            }
        }

        public MyProjectInsightsModel GetProjectInsights()
        {
            try
            {
                return _client.GetFromJsonAsync<MyProjectInsightsModel>("insights", _jsonOptions).GetAwaiter().GetResult() ?? new MyProjectInsightsModel();
            }
            catch
            {
                return new MyProjectInsightsModel();
            }
        }

        public int CountRoadProjects()
        {
            try
            {
                return _client.GetFromJsonAsync<int>("roads/count", _jsonOptions).GetAwaiter().GetResult();
            }
            catch
            {
                return 0;
            }
        }

        public MyProjectModel GetProjectDetails(int pid)
        {
            try
            {
                return _client.GetFromJsonAsync<MyProjectModel>($"{pid}", _jsonOptions).GetAwaiter().GetResult() ?? new MyProjectModel();
            }
            catch
            {
                return new MyProjectModel();
            }
        }

        public List<MyActivityImageModel> GetProjectPictures(int pid)
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyActivityImageModel>>($"{pid}/pictures", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyActivityImageModel>();
            }
            catch
            {
                return new List<MyActivityImageModel>();
            }
        }

        public List<MyProjectModel> GetProjectsAdhocAsync(string projectName, int sid, int pcid)
        {
            try
            {
                var query = $"search?projectName={Uri.EscapeDataString(projectName ?? "")}&sid={sid}&pcid={pcid}";
                return _client.GetFromJsonAsync<List<MyProjectModel>>(query, _jsonOptions).GetAwaiter().GetResult() ?? new List<MyProjectModel>();
            }
            catch
            {
                return new List<MyProjectModel>();
            }
        }

        public List<MyProjectModel> GetProjectsByCategory(int pcid, int top = 50)
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyProjectModel>>($"by-category/{pcid}?pageNumber=1&pageSize={top}", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyProjectModel>();
            }
            catch
            {
                return new List<MyProjectModel>();
            }
        }

        public List<MyProjectModel> GetProjectsByCategoryPaged(int pcid, int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyProjectModel>>($"by-category/{pcid}?pageNumber={pageNumber}&pageSize={pageSize}", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyProjectModel>();
            }
            catch
            {
                return new List<MyProjectModel>();
            }
        }

        public List<MyProjectModel> ViewRoadsAndBridgesProjects()
        {
            try
            {
                return _client.GetFromJsonAsync<List<MyProjectModel>>("by-category/1?pageNumber=1&pageSize=50", _jsonOptions).GetAwaiter().GetResult() ?? new List<MyProjectModel>();
            }
            catch
            {
                return new List<MyProjectModel>();
            }
        }
    }
}

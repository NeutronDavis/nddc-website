using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class ProjectDetailsModel : PageModel
    {
        private readonly IProjectsData projDb;
        public MyProjectModel ProjectDetails { get; set; } = new();
        public List<MyActivityImageModel> ProjectPictures { get; set; } = new();
        public readonly string? _containerUrl;

        public ProjectDetailsModel(IProjectsData projDb, IConfiguration configuration)
        {
            this.projDb = projDb;
            _containerUrl = configuration.GetConnectionString("RackspaceCDN");
        }

        public IActionResult OnGet(int? pid)
        {
            if (!pid.HasValue || pid.Value <= 0)
            {
                return RedirectToPage("/Services/ProjectDatabase/Index");
            }
            try
            {
                ProjectDetails = projDb.GetProjectDetails(pid.Value) ?? new MyProjectModel();
                ProjectPictures = projDb.GetProjectPictures(pid.Value) ?? new List<MyActivityImageModel>();

                // If no photos recorded in DB for this project, provide sample inspection photos for preview
                if (ProjectPictures == null || !ProjectPictures.Any())
                {
                    ProjectPictures = new List<MyActivityImageModel>
                    {
                        new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-1.png", PID = pid.Value },
                        new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-2.png", PID = pid.Value },
                        new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-3.png", PID = pid.Value },
                        new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-4.png", PID = pid.Value }
                    };
                }
            }
            catch
            {
                ProjectDetails = new MyProjectModel();
                ProjectPictures = new List<MyActivityImageModel>
                {
                    new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-1.png", PID = pid.Value },
                    new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-2.png", PID = pid.Value },
                    new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-3.png", PID = pid.Value },
                    new MyActivityImageModel { ImageId = 0, ImageUrl = "/assets/image/portfolio/portfolio-4.png", PID = pid.Value }
                };
            }

            if (ProjectDetails == null || ProjectDetails.PID <= 0)
            {
                return RedirectToPage("/Services/ProjectDatabase/Index");
            }
            return Page();
        }

        public string GetImageUrl(string? rawUrl, int imageId = 0)
        {
            if (!string.IsNullOrWhiteSpace(rawUrl))
            {
                if (rawUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || rawUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    var match = System.Text.RegularExpressions.Regex.Match(rawUrl, @"/images/(\d+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        return $"/images/projects/{match.Groups[1].Value}";
                    }
                    return rawUrl;
                }
                if (rawUrl.StartsWith("/"))
                {
                    return rawUrl;
                }
                if (!string.IsNullOrWhiteSpace(_containerUrl))
                {
                    string baseUrl = _containerUrl.TrimEnd('/');
                    string path = rawUrl.TrimStart('/');
                    return $"{baseUrl}/{path}";
                }
                return "/" + rawUrl;
            }
            if (imageId > 0)
            {
                return $"/images/projects/{imageId}";
            }
            return "/assets/image/department/plan-1.png";
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.WhatWeDo
{
    public class ProjectsModel : PageModel
    {
        private readonly IHomeData home;
        public List<MyUpdateModel> ProjectImageSlide { get; set; }
		public readonly string _containerUrl;

        public List<MyUpdateModel> UpdateProjects { get; set; }
        public ProjectsModel(IHomeData home, IConfiguration config)
        {
            this.home = home;
            _containerUrl = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            ProjectImageSlide = home.DisplayUpdateSlidesForProjects();
            UpdateProjects = home.GetUpdatesListForProject();
        }
    }
}

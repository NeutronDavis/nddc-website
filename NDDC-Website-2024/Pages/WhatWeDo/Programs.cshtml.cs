using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.WhatWeDo
{
    public class ProgramsModel : PageModel
    {
		private readonly IHomeData homeDb;
		public readonly string _containerUrl;

		public List<MyUpdateModel> ProgramImageSlide { get; set; }
		public List<MyUpdateModel> ProgramUpdates { get; set; }

		public ProgramsModel(IHomeData homeDb, IConfiguration config)
        {
			this.homeDb = homeDb;
			_containerUrl = config.GetConnectionString("AWSContainerUrl");
		}
        public void OnGet()
        {
			ProgramImageSlide = homeDb.DisplayUpdateSlidesForProgram();
			ProgramUpdates = homeDb.GetUpdatesListForProgram();
		}
    }
}

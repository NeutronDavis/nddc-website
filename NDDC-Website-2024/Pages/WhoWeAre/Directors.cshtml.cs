using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class DirectorsModel : PageModel
    {
        private readonly IHomeData homedb;
        public readonly string _containerUrl;

        public DirectorsModel(IHomeData homedb, IConfiguration configuration)
        {
            this.homedb = homedb;
            _containerUrl = configuration.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
        }
    }
}

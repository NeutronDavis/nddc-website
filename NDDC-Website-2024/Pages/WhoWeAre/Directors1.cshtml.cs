using EFCore_Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class Directors1Model : PageModel
    {
        private readonly NDDCWebsiteContext context;
        public readonly string _containerUrl;
        public List<Director> MyDirectors { get; set; }

        public Directors1Model(NDDCWebsiteContext context, IConfiguration configuration)
        {
            this.context = context;
            _containerUrl = configuration.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet()
        {
            MyDirectors = context.Directors.OrderBy(p => p.PositionCount).ToList();
        }
    }
}

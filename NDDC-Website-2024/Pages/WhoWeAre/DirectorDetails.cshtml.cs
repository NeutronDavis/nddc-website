using EFCore_Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class DirectorDetailsModel : PageModel
    {
        private readonly NDDCWebsiteContext context;
        public Director DirectorDetails{ get; set; }

        public readonly string _containerUrl;
        public DirectorDetailsModel(NDDCWebsiteContext context, IConfiguration config)
        {
            this.context = context;

            _containerUrl = config.GetConnectionString("AWSContainerUrl");
        }
        public void OnGet(int? Id)
        {
            DirectorDetails = context.Directors.Where(a => a.Id == Id).FirstOrDefault();
        }
    }
}

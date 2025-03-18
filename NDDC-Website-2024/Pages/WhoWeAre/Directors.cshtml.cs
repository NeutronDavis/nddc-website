using EFCore_Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NDDC_Website_2024.Pages.WhoWeAre
{
    public class DirectorsModel : PageModel
    {
        private readonly NDDCWebsiteContext context;
        public List<Director> MyDirectors { get; set; }

        public DirectorsModel(NDDCWebsiteContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            MyDirectors = context.Directors.ToList();
        }
    }
}

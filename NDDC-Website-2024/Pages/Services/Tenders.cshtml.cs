using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages.Services
{
    public class TendersModel : PageModel
    {
        public List<MyTenderModel> Tenders { get; set; }
        private readonly IHomeData homeDb;

        public TendersModel(IHomeData homeDb)
        {
            this.homeDb = homeDb;
        }
        public void OnGet()
        {
            Tenders = homeDb.ViewAllTenders();
        }
    }
}

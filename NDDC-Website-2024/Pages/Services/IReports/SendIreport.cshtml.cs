using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.CloudStorage;
using NddcWebsiteLibrary.Data.IReport;
using NddcWebsiteLibrary.Model.CloudStorage;
using NddcWebsiteLibrary.Model.IReport;

using Microsoft.AspNetCore.Mvc.Rendering;
using NddcWebsiteLibrary.Model.Validators;

namespace NDDC_Website_2024.Pages.Services.IReports
{
    public class SendIreportModel : PageModel
    {
        private readonly IReportData irep;
        private readonly ICloudStorage storage;

        [BindProperty]
        public IFormFile Upload1 { get; set; }
        [BindProperty]
        public IFormFile Upload2 { get; set; }
        [BindProperty]
        public IFormFile Upload3 { get; set; }
        [BindProperty]
        public IFormFile Upload4 { get; set; }

        [BindProperty]
        public MyIReportModel Ireport { get; set; }

        public SendIreportModel(IReportData irep, ICloudStorage storage)
        {
            this.irep = irep;
            this.storage = storage;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            var validator = new IReportValidator();
            var result = validator.Validate(Ireport);

            //if (!result.IsValid)
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //}

            if (result.IsValid)
            {
                if (Upload1 != null)
                {
                    string fileName1 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload1.FileName));
                    MyBlobResponseModel? response = await storage.UploadAsync(Upload1, fileName1);
                    Ireport.ImageUrl1 = response.Blob.Uri;
                }
                if (Upload2 != null)
                {
                    string fileName2 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload2.FileName));
                    MyBlobResponseModel? response = await storage.UploadAsync(Upload2, fileName2);
                    Ireport.ImageUrl2 = response.Blob.Uri;
                }
                if (Upload3 != null)
                {
                    string fileName3 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload3.FileName));
                    MyBlobResponseModel? response = await storage.UploadAsync(Upload3, fileName3);
                    Ireport.ImageUrl3 = response.Blob.Uri;
                }
                if (Upload4 != null)
                {
                    string fileName4 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload4.FileName));
                    MyBlobResponseModel? response = await storage.UploadAsync(Upload4, fileName4);
                    Ireport.ImageUrl4 = response.Blob.Uri;
                }

                Ireport.DateAdded = DateTime.Now;
                irep.AddIReport(Ireport);

                return RedirectToPage("Success");
            }
            else
            {
                return Page();
            }




            //if (Upload1 != null)
            //{
            //    string fileName1 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload1.FileName));
            //    MyBlobResponseModel? response = await storage.UploadAsync(Upload1, fileName1);
            //    Ireport.ImageUrl1 = response.Blob.Uri;
            //}
            //if (Upload2 != null)
            //{
            //    string fileName2 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload2.FileName));
            //    MyBlobResponseModel? response = await storage.UploadAsync(Upload2, fileName2);
            //    Ireport.ImageUrl2 = response.Blob.Uri;
            //}
            //if (Upload3 != null)
            //{
            //    string fileName3 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload3.FileName));
            //    MyBlobResponseModel? response = await storage.UploadAsync(Upload3, fileName3);
            //    Ireport.ImageUrl3 = response.Blob.Uri;
            //}
            //if (Upload4 != null)
            //{
            //    string fileName4 = "IReports/" + Path.ChangeExtension(Path.GetRandomFileName(), Path.GetExtension(Upload4.FileName));
            //    MyBlobResponseModel? response = await storage.UploadAsync(Upload4, fileName4);
            //    Ireport.ImageUrl4 = response.Blob.Uri;
            //}

            //Ireport.DateAdded = DateTime.Now;
            //irep.AddIReport(Ireport);

            //return RedirectToPage("Success");



        }
    }
}

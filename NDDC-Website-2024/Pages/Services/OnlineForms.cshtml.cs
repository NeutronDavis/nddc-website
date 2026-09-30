using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace NDDC_Website_2024.Pages.Services
{
    public class FormItem
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ActionUrl { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string BadgeText { get; set; } = "Active e-Service";
        public string ButtonText { get; set; } = "Open Form";
    }

    public class OnlineFormsModel : PageModel
    {
        public List<FormItem> AvailableForms { get; set; } = new();

        public void OnGet()
        {
            AvailableForms = new List<FormItem>
            {
                new FormItem
                {
                    Title = "Visitor Booking Portal",
                    Category = "Gate Access & Protocol",
                    Description = "Schedule an official in-person visit to any NDDC Directorate, State Office, or Corporate Headquarters in Port Harcourt.",
                    ActionUrl = "/Services/BookVisit",
                    Icon = "calendar_month",
                    BadgeText = "Active e-Service",
                    ButtonText = "Book a Visit Now"
                },
                new FormItem
                {
                    Title = "Submit an i-Report",
                    Category = "Citizen Feedback & Monitoring",
                    Description = "Submit community project feedback, incident reports, or developmental observations directly to NDDC.",
                    ActionUrl = "/Services/IReports/SendIreport",
                    Icon = "campaign",
                    BadgeText = "Active e-Service",
                    ButtonText = "Submit Report"
                }
            };
        }
    }
}

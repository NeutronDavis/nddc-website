using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace NDDC_Website_2024.Pages.WhatWeDo
{
    public class ScholarshipHistoryModel : PageModel
    {
        public class ScholarshipPhotoItem
        {
            public string FileName { get; set; } = string.Empty;
            public string ImageUrl => $"/assets/image/Local and Foreign Scholarship Programme/{FileName}";
            public string Title { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty; // "foreign", "local", "events"
            public string CategoryLabel { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string? YearBadge { get; set; }
        }

        public List<ScholarshipPhotoItem> Photos { get; set; } = new();

        public void OnGet()
        {
            Photos = new List<ScholarshipPhotoItem>
            {
                new ScholarshipPhotoItem
                {
                    FileName = "Foreign Post Graduate Scholarship.jpg",
                    Title = "Foreign Postgraduate Scholars",
                    Category = "foreign",
                    CategoryLabel = "Foreign Scholarship",
                    Description = "Recipients of the NDDC Foreign Postgraduate Scholarship Programme preparing for overseas academic pursuits.",
                    YearBadge = "Foreign Programme"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Foreign Post graduate Scholars 2.jpg",
                    Title = "Foreign Postgraduate Scholars Cohort",
                    Category = "foreign",
                    CategoryLabel = "Foreign Scholarship",
                    Description = "Scholars undergoing induction and pre-departure orientation sessions.",
                    YearBadge = "Foreign Programme"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Beneficiaries of Local Scholarship.JPG",
                    Title = "Beneficiaries of Local Scholarship",
                    Category = "local",
                    CategoryLabel = "Local Scholarship",
                    Description = "A cross-section of Niger Delta youth celebrating selection for the NDDC Local Postgraduate Scholarship.",
                    YearBadge = "Local Programme"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Local Scholarship.JPG",
                    Title = "Local Scholarship Awardees",
                    Category = "local",
                    CategoryLabel = "Local Scholarship",
                    Description = "Successful candidates recognized at the formal presentation ceremony in the Niger Delta.",
                    YearBadge = "Local Programme"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Local scholarship 2.JPG",
                    Title = "Local Scholarship Scholars Gathering",
                    Category = "local",
                    CategoryLabel = "Local Scholarship",
                    Description = "Scholars engaged in academic development and orientation workshops.",
                    YearBadge = "Local Programme"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Local Post Graduate Scholarship 1.jpg",
                    Title = "Local Postgraduate Scholars Induction",
                    Category = "local",
                    CategoryLabel = "Local Scholarship",
                    Description = "Capacity building and milestone celebration for indigenous scholars.",
                    YearBadge = "Local Programme"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Ebie presents Award letter.jpg",
                    Title = "Presentation of Award Letters",
                    Category = "events",
                    CategoryLabel = "Ceremony & Events",
                    Description = "NDDC leadership presenting formal award letters of scholarship to deserving beneficiaries.",
                    YearBadge = "Award Ceremony"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Ogbuku addressing NDDC Scholars.jpg",
                    Title = "MD/CEO Addressing NDDC Scholars",
                    Category = "events",
                    CategoryLabel = "Ceremony & Events",
                    Description = "Managing Director/CEO addressing scholars on academic excellence, leadership, and regional impact.",
                    YearBadge = "Keynote Address"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "CBT for Foreign Scholarship.jpg",
                    Title = "Computer-Based Assessment (CBT)",
                    Category = "events",
                    CategoryLabel = "CBT & Assessments",
                    Description = "Candidates writing the merit-based Computer-Based Test (CBT) for the scholarship selection process.",
                    YearBadge = "Merit Assessment"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "Test for NDDC Foreign Scholarship.JPG",
                    Title = "Foreign Scholarship Examination",
                    Category = "events",
                    CategoryLabel = "CBT & Assessments",
                    Description = "Rigorous, transparent, and merit-driven aptitude testing for prospective foreign scholars.",
                    YearBadge = "Merit Assessment"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "DSC_2984.jpg",
                    Title = "Scholars Assembly & Interactive Session",
                    Category = "events",
                    CategoryLabel = "Ceremony & Events",
                    Description = "Scholars interacting with NDDC executive leadership and education directors.",
                    YearBadge = "Orientation"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "DSC_2996.jpg",
                    Title = "Scholarship Verification & Screening",
                    Category = "events",
                    CategoryLabel = "CBT & Assessments",
                    Description = "Meticulous documentation and physical verification process for selected awardees.",
                    YearBadge = "Verification"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "461987908_943654594246916_3957130001617571530_n.jpg",
                    Title = "Scholars Orientation Forum",
                    Category = "events",
                    CategoryLabel = "Orientation",
                    Description = "Scholars receiving guidance on institutional representation, ethics, and career development.",
                    YearBadge = "Orientation"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "462021922_943654557580253_9123049358258299561_n.jpg",
                    Title = "Beneficiary Recognition Moment",
                    Category = "local",
                    CategoryLabel = "Local Scholarship",
                    Description = "Honoring top academic performers and promising talents across the Niger Delta states.",
                    YearBadge = "Recognition"
                },
                new ScholarshipPhotoItem
                {
                    FileName = "462079559_943654574246918_6830474604959471119_n.jpg",
                    Title = "Executive Interaction with Awardees",
                    Category = "events",
                    CategoryLabel = "Ceremony & Events",
                    Description = "Direct engagement between Commission executives and enthusiastic scholarship winners.",
                    YearBadge = "Ceremony"
                }
            };
        }
    }
}

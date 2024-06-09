using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Home
{
    public class MyUpdateModel
    {
        public int Id { get; set; }
        public string UpdateType { get; set; }
        public string UpdateCategory { get; set; }
        public string ProjectProgramType { get; set; }
        public string Title { get; set; }
        private string mShortTitle;
        public string ShortTitle
        {
            get { 
                if (Title.Length > 60)
                {
                    mShortTitle = Title.Substring(0, 60);
                    return mShortTitle;
                }
                mShortTitle = Title;
                return mShortTitle;
            }
                
        }

        public string Location { get; set; }
        public string GISCordinates { get; set; }
        public string Description { get; set; }
        public string DescriptionImage { get; set; }
        public string Challenges { get; set; }
        public string ChallengeImage { get; set; }
        public string Impact { get; set; }
        public string ImpactImage { get; set; }
        public Boolean HomeFeatured { get; set; }
        public string AddedBy { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

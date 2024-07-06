using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Home
{
	public class MyLiveEventModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public TimeOnly StartTime { get; set; } 
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        public TimeOnly EndTime { get; set; }
        public string BannerImage { get; set; }
        public string TrailerVideo { get; set; }
        public string LiveEventLink { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}

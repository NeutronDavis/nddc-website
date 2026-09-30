using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Projects
{
    public class MyProjectInsightsModel
    {
        public int TotalProjects { get; set; }
        public int CompletedProjects { get; set; }
        public int StatesCovered { get; set; }
        public int TotalCategories { get; set; }
    }
}

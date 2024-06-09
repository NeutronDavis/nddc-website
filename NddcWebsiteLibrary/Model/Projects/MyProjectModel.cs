using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Projects
{
    public class MyProjectModel
    {
        public int SrNo { get; set; }
        public int PID { get; set; }
        public string ProjectName { get; set; }
        public int SID { get; set; }
        public int LID { get; set; }
        public int PLID { get; set; }
        public int PCID { get; set; }
        public DateTime StartDate { get; set; }
        public int CID { get; set; }
        public string Status { get; set; }
        public string StateName { get; set; }
        public string LGA { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Contractor { get; set; }
        public string CatName { get; set; }
        public DateTime CommencementDate { get; set; }
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Home
{
	public class MyPublicationsModel
	{
        public int PubId { get; set; }
        public string PubTitle { get; set; }
        public string PubSummary { get; set; }
        public string OubThumbImage { get; set; }
        public string PubUploadUrl { get; set; }
        public DateTime DateUploaded { get; set; }
        public string UploadedBy { get; set; }
    }
}

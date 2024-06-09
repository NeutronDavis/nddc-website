using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.Home
{
    public class MyPhotoSpeakModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public string AddedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Model.ServiceGate
{
    public class MySuggestionModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

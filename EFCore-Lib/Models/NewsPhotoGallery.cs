using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class NewsPhotoGallery
    {
        public int Id { get; set; }
        public int? NewsId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}

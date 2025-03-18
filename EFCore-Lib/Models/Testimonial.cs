using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class Testimonial
    {
        public int Id { get; set; }
        public string? TestimonialBy { get; set; }
        public string? Occupation { get; set; }
        public string? Testimonial1 { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? AddedBy { get; set; }
    }
}

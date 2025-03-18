using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class EventSpeaker
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherNames { get; set; }
        public string? Title { get; set; }
        public string? SpeakerPhoto { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Occupation { get; set; }
        public string? EventDesignation { get; set; }
        public string? TwitterHandle { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}

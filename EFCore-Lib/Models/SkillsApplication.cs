using System;
using System.Collections.Generic;

namespace EFCore_Lib.Models
{
    public partial class SkillsApplication
    {
        public int Sdid { get; set; }
        public string? RegNo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OtherNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Sex { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? Address { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Education { get; set; }
        public string? CurrentSkill { get; set; }
        public string? ProgramCategory { get; set; }
        public string? Program { get; set; }
        public int? Sid { get; set; }
        public int? Plid { get; set; }
        public string? LgaletterUpload { get; set; }
        public string? InstitutionName { get; set; }
        public string? InstitutionDate { get; set; }
        public bool? Participated { get; set; }
        public string? CertificateUpload { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}

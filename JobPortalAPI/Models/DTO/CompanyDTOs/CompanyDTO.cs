using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models.DTO.CompanyDTOs
{
    public class CompanyDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string About { get; set; }
        public string? Website { get; set; }
    }
}

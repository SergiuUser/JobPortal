using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models.DTO.CompanyDTOs
{
    public class CompanyAddressDTO
    {
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}

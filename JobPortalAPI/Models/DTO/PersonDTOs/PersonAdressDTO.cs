using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models.DTO.PersonDTOs
{
    public class PersonAdressDTO
    {
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}

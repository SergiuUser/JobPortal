using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models.DTO.PersonDTOs
{
    public class PersonDTO
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        [Phone]
        public string? PhoneNumber { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalAPI.Models
{
    public class PersonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        [Phone]
        public string? PhoneNumber { get; set; }
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
        public ICollection<ApplicationModel>? Applications { get; set; }
        public PersonLoginInfoModel? Login{ get; set; }
        public PersonAddressModel? Address{ get; set; }
        public ICollection<JobsModel>? SavedJobs { get; set; }

    }
}

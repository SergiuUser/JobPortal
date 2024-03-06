using JobPortalAPI.Models.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalAPI.Models
{
    public class PersonLoginInfoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public RoleEnums? Role { get; set; } = RoleEnums.seeker;
        public int? PersonID { get; set; }

        public PersonModel? Person { get; set; }

    }
}

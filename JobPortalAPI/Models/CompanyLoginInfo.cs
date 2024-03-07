using JobPortalAPI.Models.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models
{
    public class CompanyLoginInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public RoleEnums? Role { get; set; } = RoleEnums.Company;
        public int? CompanyID { get; set; }

        public CompanyModel? Company { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models
{
    public class CompanyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string About { get; set; }
        public string? Website { get; set; }
        public string? LogoPath { get; set; }
        public ICollection<JobsModel>? Jobs { get; set; }
        public CompanyAddressModel? Adress { get; set; }
        public CompanyLoginInfo? Login { get; set; }
        public ICollection<CategoryRequestModel>? CategoryRequest { get; set; }

    }
}

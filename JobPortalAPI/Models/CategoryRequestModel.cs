using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JobPortalAPI.Models.Helpers;

namespace JobPortalAPI.Models
{
    public class CategoryRequestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int? CompanyID { get; set; }
        public AcceptedEnums Accepted { get; set; } = AcceptedEnums.Pending;

        public CompanyModel? Company { get; set; }
    }
}

using JobPortalAPI.Models.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalAPI.Models
{
    public class ApplicationResponseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public StatusEnums Status { get; set; } = StatusEnums.Pending;
        public string? Message { get; set; }
        public int ApplicationID { get; set; }
        public ApplicationModel? Application { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JobPortalAPI.Models.Helpers;

namespace JobPortalAPI.Models
{
    public class ApplicationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? JobID { get; set; }
        public int? PersonID { get; set; }
        [Required]
        public string ResumePath { get; set; }
        [Required]
        public string? CoverLetter { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        public JobsModel? Jobs { get; set; }
        public PersonModel? Person { get; set; }
        public ApplicationResponseModel? ApplicationResponse { get; set; }

    }
}

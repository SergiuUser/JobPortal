using JobPortalAPI.Models.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalAPI.Models
{
    public class JobsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? CompanyID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public double? Salary { get; set; } = 0;
        public int? ExperienceYears { get; set; } = 0;
        [Required]
        public WorkScheduleEnums WorkSchedule { get; set; }

        public CompanyModel? Company { get; set; }
        public ICollection<ApplicationModel>? Applications { get; set; }
        public ICollection<PersonModel>? people { get; set; }
        public ICollection<JobCategoryModel>? JobCategories { get; set; }
    }
}

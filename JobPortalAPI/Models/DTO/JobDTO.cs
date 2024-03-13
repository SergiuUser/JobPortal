using JobPortalAPI.Models.Helpers;
using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.Models.DTO
{
    public class JobDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public double? Salary { get; set; } = 0;
        public int? ExperienceYears { get; set; } = 0;
        [Required]
        public WorkScheduleEnums WorkSchedule { get; set; }
    }
}

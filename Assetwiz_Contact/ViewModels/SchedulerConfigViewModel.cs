using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assetwiz_Contact.ViewModels
{
    public class SchedulerConfigViewModel
    {
        [Key]
        public long SchedulerConfigID { get; set; }

        [Required]
        public long SchedulerID { get; set; }

        public long? LocationID { get; set; }

        [MaxLength(500)]
        public string? LocationName { get; set; }

        [MaxLength(500)]
        public string? Type { get; set; }

        [Required]
        public int RepeatAt { get; set; } // Stored as int in DB

        [Required]
        public int RepeatMinutes { get; set; }

        public bool? IsEnabled { get; set; }

        public long? CreatedBy { get; set; }

        [MaxLength(500)]
        public string? CreatedByName { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        [MaxLength(500)]
        public string? ModifiedByName { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }
    }
}

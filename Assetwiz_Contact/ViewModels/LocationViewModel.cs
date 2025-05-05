using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assetwiz_Contact.ViewModels
{
    public class LocationViewModel
    {
        [Key]
        public long LocationID { get; set; }

        public long? ModuleID { get; set; }

        [MaxLength(500)]
        public string? ModuleName { get; set; }

        [Required, MaxLength(500)]
        public required string LocationName { get; set; }

        [MaxLength(500)]
        public string? LocationAddress { get; set; }

        [MaxLength(500)]
        public string? LocationCity { get; set; }

        [MaxLength(500)]
        public string? LocationState { get; set; }

        [MaxLength(500)]
        public string? LocationZip { get; set; }

        [MaxLength(500)]
        public string? LocationCountry { get; set; }

        [MaxLength(500)]
        public string? LocationPhone1 { get; set; }

        [MaxLength(500)]
        public string? LocationPhone2 { get; set; }

        [MaxLength(500)]
        public string? LocationMobile { get; set; }

        [MaxLength(500)]
        public string? LocationCode { get; set; }

        public bool? IsEnabled { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public long? UserID { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public long? CreatedBy { get; set; }

        [MaxLength(500)]
        public string? CreatedByName { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }

        public long? ModifiedBy { get; set; }

        [MaxLength(500)]
        public string? ModifiedByName { get; set; }

        public bool? IsSync { get; set; }

        public bool? IsSubscriptionEnabled { get; set; }

        [Required, MaxLength(4000)]
        public required string LocationConfig { get; set; }

        [MaxLength(1000)]
        public string? APIUrl { get; set; }
        public long SchedulerConfigID { get; internal set; }
        public long SchedulerID { get; internal set; }
        public string? Type { get; internal set; }
        public int? RepeatMinutes { get; internal set; }
    }
}

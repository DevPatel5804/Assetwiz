using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assetwiz_Contact.ViewModels
{
    public class MeterLogsViewModel
    {
        [Key]
        public long MeterLogsID { get; set; }

        [ForeignKey("WorkFlowItem")]
        public long? WorkFlowItemID { get; set; }

        [Required]
        public double Value { get; set; }

        public long? LocationID { get; set; }

        [MaxLength(500)]
        public string? LocationName { get; set; }

        public bool? IsConnected { get; set; }

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

        [ForeignKey("Meter")]
        public long MeterID { get; set; }

        [Required]
        [MaxLength(500)]
        public string MeterName { get; set; }

        // Optional navigation properties
        // public virtual Meter Meter { get; set; }
        // public virtual WorkFlowItem WorkFlowItem { get; set; }
    }
}

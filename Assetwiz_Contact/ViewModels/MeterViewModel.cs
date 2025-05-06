using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assetwiz_Contact.ViewModels
{
    public class MeterViewModel
    {
        [Key]
        public long MeterID { get; set; }

        [Required]
        [MaxLength(1000)]
        public string MeterName { get; set; }

        [ForeignKey("Product")]
        public long? ProductID { get; set; }

        [MaxLength(1000)]
        public string? ProductName { get; set; }

        [MaxLength(1000)]
        public string? AlarmType { get; set; }

        public double? AlarmValue { get; set; }

        public long? LocationID { get; set; }

        [MaxLength(1000)]
        public string? LocationName { get; set; }

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

        [MaxLength(1000)]
        public string? UnitType { get; set; }

        // Optional navigation property (if you have a Product entity)
        // public virtual Product Product { get; set; }
    }
}

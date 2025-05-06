using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assetwiz_Contact.ViewModels
{
    public class ProductPartsViewModel
    {
        [Key]
        public long ProductPartsID { get; set; }

        [Required]
        public long ProductID { get; set; }

        [Required]
        public long PartID { get; set; }

        public long? WorkFlowItemID { get; set; }

        [MaxLength(1000)]
        public string? WorkFlowItemName { get; set; }

        [Required]
        public long LocationID { get; set; }

        [MaxLength(1000)]
        public string? LocationName { get; set; }

        [Required]
        public decimal PartsQuantity { get; set; }

        [Required]
        public decimal PartsPrice { get; set; }

        public bool IsEnabled { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public long CreatedBy { get; set; }

        [MaxLength(500)]
        public string? CreatedByName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assetwiz_Contact.ViewModels
{
    public class ProductsViewModel
    {
        [Key]
        public long ProductID { get; set; }

        [Required]
        public long OrganisationID { get; set; }

        [Required, MaxLength(500)]
        public string ProductName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? ProductType { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Unit { get; set; }

        [MaxLength(100)]
        public string? UnitType { get; set; }

        [MaxLength(100)]
        public string? HSN_SAC { get; set; }

        public bool? IsEnabled { get; set; }

        public double? SellingPrice { get; set; }

        public double? PurchasePrice { get; set; }

        public bool? IsStockMaintainEnabled { get; set; }

        public int? MinOrderQuantity { get; set; }

        public decimal? MaximumStock { get; set; }

        public decimal? ReorderStock { get; set; }

        public long? LocationID { get; set; }

        [MaxLength(500)]
        public string? LocationName { get; set; }

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

        [MaxLength(1000)]
        public string? OtherInformation { get; set; }

        public DateTime? EndOfLife { get; set; }

        public DateTime? EndOfWarranty { get; set; }

        [MaxLength(1000)]
        public string? ProductImage { get; set; }

        public decimal? CurrentStock { get; set; }

        [MaxLength(500)]
        public string? Capacity { get; set; }

        [MaxLength(500)]
        public string? MakeModel { get; set; }

        public decimal? MinimumStock { get; set; }

        [MaxLength(500)]
        public string? SerialNo { get; set; }

        [MaxLength(500)]
        public string? Zone { get; set; }

        public long? GroupID { get; set; }

        [MaxLength(500)]
        public string? GroupName { get; set; }

        public long? SubGroupID { get; set; }

        [MaxLength(500)]
        public string? SubGroupName { get; set; }

        public long? WorkFlowID { get; set; }
    }
}

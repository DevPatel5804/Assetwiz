using System.ComponentModel.DataAnnotations;

namespace Assetwiz_Contact.ViewModels
{
    public class ProductTransactionViewModel
    {
        [Key]
        public long ProductTransactionID { get; set; }

        [Required]
        public long ProductID { get; set; }

        [MaxLength(1000)]
        public string? ProductName { get; set; }

        public long? WorkFlowItemID { get; set; }

        public long? LocationID { get; set; }

        [MaxLength(1000)]
        public string? LocationName { get; set; }

        [MaxLength(1000)]
        public string? WorkFlowItemName { get; set; }

        public decimal? PreviousClosingStock { get; set; }

        public decimal? PreviousClosingRate { get; set; }

        public decimal? PreviousClosingValue { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Rate { get; set; }

        public decimal? Amount { get; set; }

        public decimal? CurrentClosingStock { get; set; }

        public decimal? CurrentClosingRate { get; set; }

        public decimal? CurrentClosingValue { get; set; }

        public decimal? OrderedPrice { get; set; }

        public decimal? OrderItemPrice { get; set; }

        public long? ContactID { get; set; }

        [MaxLength(1000)]
        public string? ContactName { get; set; }

        public long? ContactPersonID { get; set; }

        [MaxLength(1000)]
        public string? ContactPersonName { get; set; }

        public int? WorkFlowStatusCode { get; set; }

        public long? WorkFlowStatusID { get; set; }

        public long? ProductCategoryGroupID { get; set; }

        public long? ProductSubCategoryGroupID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? InvoiceDate { get; set; }

        [MaxLength(1000)]
        public string? DCNumber { get; set; }

        [MaxLength(1000)]
        public string? InvoiceNumber { get; set; }

        public DateTime? ExpireDate { get; set; }

        public bool? Tax1IsEnabled { get; set; }

        [MaxLength(1000)]
        public string? Tax1Name { get; set; }

        public decimal? Tax1Rate { get; set; }

        public decimal? Tax1Amount { get; set; }

        public bool? Tax2IsEnabled { get; set; }

        [MaxLength(1000)]
        public string? Tax2Name { get; set; }

        public decimal? Tax2Rate { get; set; }

        public decimal? Tax2Amount { get; set; }

        public bool? Tax3IsEnabled { get; set; }

        [MaxLength(1000)]
        public string? Tax3Name { get; set; }

        public decimal? Tax3Rate { get; set; }

        public decimal? Tax3Amount { get; set; }

        [MaxLength(1000)]
        public string? OrderItemRemark { get; set; }

        public decimal? OrderItemGrossAmount { get; set; }

        public decimal? OrderItemDiscountAmount { get; set; }

        public decimal? OrderItemChargeAmount { get; set; }

        public decimal? OrderItemSubTotalAmount { get; set; }

        public decimal? OrderItemTaxAmount { get; set; }

        public decimal? OrderItemNetTotalAmount { get; set; }

        public long? CreatedBy { get; set; }

        [MaxLength(500)]
        public string? CreatedByName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        [MaxLength(500)]
        public string? ModifiedByName { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [MaxLength(1000)]
        public string? OrderType { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assetwiz_Contact.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public long ContactID { get; set; }

        public long? ContactTypeID { get; set; }

        [Required, MaxLength(500)]
        public required string ContactTypeName { get; set; }

        [Required]
        public long LocationID { get; set; }

        [MaxLength(500)]
        public string? LocationName { get; set; }

        [Required, MaxLength(500)]
        public required string CompanyName { get; set; }

        [MaxLength(500)]
        public string? Email { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(500)]
        public string? City { get; set; }

        [MaxLength(500)]
        public string? State { get; set; }

        public int? ZipCode { get; set; }

        public int? StateCode { get; set; }

        [MaxLength(500)]
        public string? Country { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool? IsEnabled { get; set; }

        [MaxLength(500)]
        public string? PanNo { get; set; }

        [MaxLength(500)]
        public string? GSTIN { get; set; }

        [MaxLength(500)]
        public string? CIN { get; set; }

        [MaxLength(500)]
        public string? PaymentTerms { get; set; }

        [Column("RoundingPrecision")]
        public int? RoundingPrecision { get; set; }

        [Column("ExternalReferenceID"), MaxLength(500)]
        public string? ExternalReferenceID { get; set; }

        [Required, MaxLength(4000)]
        public required string OtherInformation { get; set; }

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
    }
}

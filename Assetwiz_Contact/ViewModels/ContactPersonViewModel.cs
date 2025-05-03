using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assetwiz_Contact.ViewModels
{
    public class ContactPersonViewModel
    {
        [Key]
        public long ContactPersonID { get; set; }

        // Foreign Key
        public long? ContactID { get; set; }

        public ContactViewModel? Contact { get; set; }

        [Required, MaxLength(500)]
        public required string PersonName { get; set; }

        [MaxLength(500)]
        public string? Email { get; set; }

        [MaxLength(500)]
        public string? Mobile { get; set; }

        [MaxLength(500)]
        public string? Designation { get; set; }

        [MaxLength(500)]
        public string? Department { get; set; }

        public bool? IsEnabled { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(500)]
        public string? City { get; set; }

        [MaxLength(500)]
        public string? State { get; set; }

        public int? ZipCode { get; set; }

        [MaxLength(500)]
        public string? Country { get; set; }

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
    }
}

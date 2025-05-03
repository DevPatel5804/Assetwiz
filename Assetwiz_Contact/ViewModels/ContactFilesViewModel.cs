using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assetwiz_Contact.ViewModels
{
    public class ContactFilesViewModel
    {
        [Key]
        public long ContactFilesID { get; set; }

        [Required]
        public long? ContactID { get; set; }
        public ContactViewModel? Contact { get; set; }

        public long? ContactPersonID { get; set; }

        [Required, MaxLength(500)]
        public required string ContactFileName { get; set; }

        [Required, MaxLength(500)]
        public required string ContactFilePath { get; set; }

        [Required, MaxLength(500)]
        public required string ContactFileExtention { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(500)]
        public string? StorageProviderName { get; set; }

        public long? LocationID { get; set; }

        [MaxLength(500)]
        public string? LocationName { get; set; }

        public long? AssignedUserTo { get; set; }

        [MaxLength(500)]
        public string? AssignedUserName { get; set; }

        [MaxLength(500)]
        public string? AssignedUserEmail { get; set; }

        public bool? IsDeleted { get; set; }

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

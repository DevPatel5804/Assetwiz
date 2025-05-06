using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Assetwiz_Contact.ViewModels
{
	public class ProductFilesViewModel
	{
		[Key]
		public long ProductFilesID { get; set; }

		public long? ProductID { get; set; }

		[MaxLength(500)]
		public string? ProductName { get; set; }

		[MaxLength(500)]
		public string? ProductFileName { get; set; }

        [MaxLength(500)]
        public string? ProductFilePath { get; set; }

        [Required, MaxLength(500)]
        public required string ProductFileExtention { get; set; } 

		[MaxLength(1000)]
		public string? Description { get; set; }

		[MaxLength(500)]
		public string? StorageProviderName { get; set; }

		public long? ContactID { get; set; }

        public ContactViewModel? Contact { get; set; }

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

using System.ComponentModel.DataAnnotations;

namespace Assetwiz_Contact.ViewModels
{
    public class GroupViewModel
    {
        [Key]
        public long GroupID { get; set; }

        [Required, MaxLength(500)]
        public required string GroupName { get; set; }

        [Required]
        public long LocationID { get; set; }

        [Required, MaxLength(500)]
        public required string LocationName { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required, MaxLength(500)]
        public required string GroupType { get; set; }

        [MaxLength(500)]
        public string? Url { get; set; }

        [MaxLength(500)]
        public string? DisplayType { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        public long? ReferenceGroupID { get; set; }

        [MaxLength(500)]
        public string? ExternalReferenceID { get; set; }

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

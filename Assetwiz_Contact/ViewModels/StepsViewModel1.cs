using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assetwiz_Contact.ViewModels
{
    public class StepsViewModel
    {
        [Key]
        public long StepID { get; set; }

        [Required]
        [MaxLength(500)]
        public string StepName { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [ForeignKey("Procedure")]
        public long? ProcedureID { get; set; }

        [MaxLength(4000)]
        public string? OtherInformation { get; set; }

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

        public int? DisplayOrder { get; set; }

        public bool? IsEnabled { get; set; }

    }
}
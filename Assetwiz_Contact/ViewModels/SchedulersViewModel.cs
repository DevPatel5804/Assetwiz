using System.ComponentModel.DataAnnotations;

namespace Assetwiz_Contact.ViewModels
{
    public class SchedulersViewModel
    {
        [Key]
        public long SchedulerID { get; set; }
        public string? SchedulerName { get; set; }
        public long LocationID { get; set; }
        public string? LocationName { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? OtherInformation { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

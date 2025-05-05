using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assetwiz_Contact.ViewModels
{
    public class LocationConfigViewModel
    {
        [Key]
        public long LocationConfigID { get; set; }
        public string? ConfigKey { get; set; }
        public string? ConfigValue { get; set; }
        public long LocationID { get; set; }
        public long? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}

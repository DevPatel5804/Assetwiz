using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assetwiz_Contact.ViewModels
{
    public class TeamUsersViewModel
    {
        public long TeamID { get; set; }

        public long UserID { get; set; }

        [Required, MaxLength(500)]
        public required string UserName { get; set; }

        public long? ModuleID { get; set; }

        [MaxLength(500)]
        public string? ModuleName { get; set; }

        [Required]
        public long LocationID { get; set; }

        [MaxLength(500)]
        public string? LocationName { get; set; }

        public long? RoleID { get; set; }

        public bool? IsEnabled { get; set; }

        public long? CreatedBy { get; set; }

        [MaxLength(500)]
        public string? CreatedByName { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        [MaxLength(500)]
        public string? ModifiedByName { get; set; }

        [Required]
        public DateTime ModifiedOn { get; set; }
    }
}

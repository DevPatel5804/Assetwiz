using System;
using System.Collections.Generic;

namespace AssetWiz.ViewModels;

public partial class UserViewModel
{
    public long Id { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public string? ShortName { get; set; }

    public int? Style { get; set; }

    public string Password { get; set; }

    public string? RefreshToken { get; set; }

    public string? ResetToken { get; set; }

    public long? ModuleId { get; set; }

    public string? ModuleName { get; set; }

    public long? LocationId { get; set; }

    public string? LocationName { get; set; }

    public bool IsPasswordReset { get; set; }

    public bool IsActive { get; set; }

    public bool IsLocked { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsProUser { get; set; }

    public int FailedAttempts { get; set; }

    public DateTime LockedOn { get; set; }

    public DateTime LastLoggedOn { get; set; }

    public DateTime FailedAttemptOn { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime ModifiedOn { get; set; }

    public string? UserConfig { get; set; }

    public string? UserGuid { get; set; }

    public virtual ICollection<RoleViewModel> Roles { get; set; }

    public virtual ICollection<TeamViewModel> Teams { get; set; }
}

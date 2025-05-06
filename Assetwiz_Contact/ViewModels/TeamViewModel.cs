using System;
using System.Collections.Generic;

namespace AssetWiz.ViewModels;

public partial class TeamViewModel
{
    public long TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string? Description { get; set; }

    public long UserId { get; set; }

    public long? ModuleId { get; set; }

    public string? ModuleName { get; set; }

    public long LocationId { get; set; }

    public bool IsEnabled { get; set; }

    public long? CreatedBy { get; set; }

    public string? CreatedByName { get; set; }

    public DateTime CreatedOn { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedByName { get; set; }

    public DateTime ModifiedOn { get; set; }

    public virtual UserViewModel User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace api.models.dbEntities;

public partial class User
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? UserProfileImageUrl { get; set; }

    public byte[] Password { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public DateTime Datecreated { get; set; }

    public DateTime LastLogin { get; set; }

    public DateTime LastPfpUpdate { get; set; }

    public bool Isactive { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

using System;
using System.Collections.Generic;

namespace api.models.dbEntities;

public partial class Projectstatus
{
    public int ProjectStatusId { get; set; }

    public string? ProjectStatusName { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}

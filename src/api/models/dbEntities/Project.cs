using System;
using System.Collections.Generic;

namespace api.models.dbEntities;

public partial class Project
{
    public Guid ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ProjectScope { get; set; } = null!;

    public int? ProjectStatusId { get; set; }

    public Guid UserId { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual Projectstatus? ProjectStatus { get; set; }

    public virtual ICollection<Repository> Repositories { get; set; } = new List<Repository>();

    public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();

    public virtual User User { get; set; } = null!;
}

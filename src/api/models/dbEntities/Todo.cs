using System;
using System.Collections.Generic;

namespace api.models.dbEntities;

public partial class Todo
{
    public Guid TaskId { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDescription { get; set; }

    public int? TaskStatusId { get; set; }

    public DateTime? TaskStart { get; set; }

    public DateTime? TaskEnd { get; set; }

    public Guid? ProjectId { get; set; }

    public virtual Project? Project { get; set; }

    public virtual TodoStatus? TaskStatus { get; set; }
}

using System;
using System.Collections.Generic;

namespace api.models.dbEntities;

public partial class TodoStatus
{
    public int TaskStatusId { get; set; }

    public string? TaskStatusName { get; set; }

    public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
}

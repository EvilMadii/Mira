using System;
using System.Collections.Generic;

namespace api.models.dbEntities;

public partial class Note
{
    public string NoteId { get; set; } = null!;

    public string NoteTitle { get; set; } = null!;

    public string NoteBody { get; set; } = null!;

    public Guid ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;
}

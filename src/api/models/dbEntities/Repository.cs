using System;
using System.Collections.Generic;

namespace api.models.dbEntities;

public partial class Repository
{
    public string RepositoryId { get; set; } = null!;

    public string RepositoryName { get; set; } = null!;

    public string RepositoryUrl { get; set; } = null!;

    public Guid ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;
}

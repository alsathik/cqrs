using System;
using System.Collections.Generic;

namespace RepositoryDesignPattren.Models;

public partial class CustomerProfile
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int? Age { get; set; }

    public string? Sex { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace RepositoryDesignPattren.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<CustomerProfile> CustomerProfiles { get; set; } = new List<CustomerProfile>();
}

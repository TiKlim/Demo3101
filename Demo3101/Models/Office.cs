using System;
using System.Collections.Generic;

namespace Demo3101.Models;

public partial class Office
{
    public int OfficeId { get; set; }

    public string? OfficeName { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

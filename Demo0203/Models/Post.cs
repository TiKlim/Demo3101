using System;
using System.Collections.Generic;

namespace Demo0203.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string? PostName { get; set; }

    public virtual ICollection<Staff> Idstaffs { get; set; } = new List<Staff>();
}

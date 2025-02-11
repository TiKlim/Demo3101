using System;
using System.Collections.Generic;

namespace Demo3101.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string? PostName { get; set; }

    public virtual ICollection<StaffPost> StaffPosts { get; set; } = new List<StaffPost>();
}

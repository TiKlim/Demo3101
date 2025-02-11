using System;
using System.Collections.Generic;

namespace Demo3101.Models;

public partial class StaffPost
{
    public int StaffId { get; set; }

    public int PostId { get; set; }

    public int DivisionId { get; set; }

    public virtual Division Division { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}

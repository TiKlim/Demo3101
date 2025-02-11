using System;
using System.Collections.Generic;

namespace Demo3101.Models;

public partial class Department
{
    public int DivId { get; set; }

    public int DepId { get; set; }

    public int SubDepId { get; set; }

    public virtual Division Dep { get; set; } = null!;

    public virtual Division Div { get; set; } = null!;

    public virtual Division SubDep { get; set; } = null!;
}

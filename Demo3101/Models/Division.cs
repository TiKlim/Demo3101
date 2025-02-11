using System;
using System.Collections.Generic;

namespace Demo3101.Models;

public partial class Division
{
    public int DivisionId { get; set; }

    public string? DivisionName { get; set; }

    public virtual ICollection<Department> DepartmentDeps { get; set; } = new List<Department>();

    public virtual ICollection<Department> DepartmentDivs { get; set; } = new List<Department>();

    public virtual ICollection<Department> DepartmentSubDeps { get; set; } = new List<Department>();

    public virtual ICollection<StaffPost> StaffPosts { get; set; } = new List<StaffPost>();
}

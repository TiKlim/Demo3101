using System;
using System.Collections.Generic;

namespace Demo3101.Models;

public partial class Division
{
    public int DivisionId { get; set; }

    public string? DivisionName { get; set; }

    public virtual ICollection<Division> Idadditionaldevis { get; set; } = new List<Division>();

    public virtual ICollection<Division> Idmaindevisions { get; set; } = new List<Division>();

    public virtual ICollection<Staff> Idstaffs { get; set; } = new List<Staff>();
}

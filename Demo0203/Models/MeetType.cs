using System;
using System.Collections.Generic;

namespace Demo0203.Models;

public partial class MeetType
{
    public int MeetTypeId { get; set; }

    public string? MeetTypeName { get; set; }

    public virtual ICollection<MeetingsCalendar> MeetingsCalendars { get; set; } = new List<MeetingsCalendar>();
}

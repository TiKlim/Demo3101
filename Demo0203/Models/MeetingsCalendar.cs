using System;
using System.Collections.Generic;

namespace Demo0203.Models;

public partial class MeetingsCalendar
{
    public int MeetId { get; set; }

    public string? MeetName { get; set; }

    public int? MeetType { get; set; }

    public bool? MeetStatus { get; set; }

    public DateOnly? MeetDate { get; set; }

    public TimeOnly? MeetTimeStart { get; set; }

    public TimeOnly? MeetTimeFinish { get; set; }

    public int? MeetStaff { get; set; }

    public string? MeetDescription { get; set; }

    public virtual Staff? MeetStaffNavigation { get; set; }

    public virtual MeetType? MeetTypeNavigation { get; set; }
}

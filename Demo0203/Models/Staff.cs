using System;
using System.Collections.Generic;

namespace Demo0203.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? StaffSurname { get; set; }

    public string? StaffName { get; set; }

    public string? StaffPatronimic { get; set; }

    public DateOnly? StaffBirthday { get; set; }

    public string? StaffWorkPhone { get; set; }

    public int? StaffOffice { get; set; }

    public string? CorporateEmail { get; set; }

    public virtual ICollection<MeetingsCalendar> MeetingsCalendars { get; set; } = new List<MeetingsCalendar>();

    public virtual Office? StaffOfficeNavigation { get; set; }

    public virtual ICollection<Division> Iddepats { get; set; } = new List<Division>();

    public virtual ICollection<Post> Idroles { get; set; } = new List<Post>();
}

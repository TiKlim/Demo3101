using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo0203.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? StaffSurname { get; set; }

    public string? StaffName { get; set; }

    public string? StaffPatronimic { get; set; }

    public DateTime? StaffBirthday { get; set; }

    public string? StaffWorkPhone { get; set; }

    public int? StaffOffice { get; set; }

    public string? CorporateEmail { get; set; }

    public string GetNameDivision
    {
        get
        {
            return Iddepats.FirstOrDefault()!.DivisionName!;
        }
    }

    public string GetNameRole
    {
        get
        {
            return Idroles.FirstOrDefault()!.PostName!;
        }
    }

    public DateTime? CalendarDates
    {
        get
        {
            return MeetDates.FirstOrDefault()!.MeetDate!;
        }
    }

    public string NamesMeet
    {
        get
        {
            return MeetingsCalendars.FirstOrDefault()!.MeetName!;
        }
    }

    public virtual ICollection<MeetingsCalendar> MeetingsCalendars { get; set; } = new List<MeetingsCalendar>();

    public virtual Office? StaffOfficeNavigation { get; set; }

    public virtual ICollection<Division> Iddepats { get; set; } = new List<Division>();

    public virtual ICollection<Post> Idroles { get; set; } = new List<Post>();

    public virtual ICollection<MeetingsCalendar> MeetDates { get; set; } = new List<MeetingsCalendar>();
}
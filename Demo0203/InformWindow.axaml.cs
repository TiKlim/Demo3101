using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Demo0203.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo0203;

public partial class InformWindow : Window
{
    //private List<MeetingsCalendar> meetingsCalendars = 

    public InformWindow()
    {
        InitializeComponent();
        logo.Click += Logo_Click;
        calendar.Loaded += Calendar_Loaded;
        calendar.DisplayDateChanged += Calendar_DisplayDateChanged;

        SetData();
    }

    private void CalendarColors()
    {
        foreach (var point in calendar.GetVisualDescendants())
        {
            if (point is CalendarDayButton dayButton)
            {
                var now = (calendar as Calendar).DisplayDate;
                string contentDay = dayButton.Content!.ToString()!;

                try
                {
                    
                }
                catch
                {
                    
                }
            }
        }
    }

    private void Calendar_DisplayDateChanged(object? sender, CalendarDateChangedEventArgs e)
    {
        CalendarColors();
    } 

    private void Calendar_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        CalendarColors();
    } 

    private void Logo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow firstWindow = new MainWindow();
        firstWindow.Show();
        Close();
    }

    private void SetData()
    {
        var searchList = DataSource.Helper.dataBase.Staff.Include(x => x.MeetingsCalendars).ToList();

        string searchSearch = searchTB.Text?.ToLower() ?? "";
        if (searchSearch.Length > 0)
        {
            searchList = searchList.Where(x => x.StaffName.ToLower().Contains(searchSearch) && 
            x.StaffSurname.ToLower().Contains(searchSearch) && 
            x.StaffPatronimic.ToLower().Contains(searchSearch) && 
            x.CorporateEmail.ToLower().Contains(searchSearch) && 
            x.StaffWorkPhone.ToLower().Contains(searchSearch)).ToList();
        }

        var sortList = DataSource.Helper.dataBase.MeetingsCalendars.ToList();
        var meetDates = sortList.Select(x => x.MeetDate).ToList();

        staffLB.ItemsSource = DataSource.Helper.dataBase.Staff;
        meetingsLB.ItemsSource = DataSource.Helper.dataBase.MeetingsCalendars.Include(x => x.MeetStaffNavigation);
    }
}
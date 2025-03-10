using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using Demo0203.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo0203;

public partial class InformWindow : Window
{
    List<DateTime?> listDate = new List<DateTime?>();
    List<DateTime?> listBirth = new List<DateTime?>();

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
        foreach (var index in calendar.GetVisualDescendants())
        {
            if (index is CalendarDayButton dayButton)
            {
                var now = (calendar as Calendar).DisplayDate;
                string display = dayButton.Content!.ToString()!;
                DateOnly dateNow = new DateOnly(now.Year, now.Month, int.Parse(display));
                var bbb = dateNow.ToDateTime(new TimeOnly());
                /*
                var birthNow = new DateTime(now.Year, now.Month, int.Parse(display));*/

                try
                {
                    if (listDate.Contains(bbb) && listBirth.Contains(bbb) && calendar.SelectedDates.Count >= 2 && calendar.SelectedDates.Count < 5)
                    {
                        dayButton.Background = Brushes.Yellow;
                        dayButton.Foreground = Brushes.Black;
                    }
                    else
                    {
                        dayButton.Background = Brushes.LightGray;
                        dayButton.Foreground = Brushes.Black;
                    }

                    if (listDate.Contains(bbb) && listBirth.Contains(bbb) && calendar.SelectedDates.Count >= 5)
                    {
                        dayButton.Background = Brushes.Red;
                        dayButton.Foreground = Brushes.Black;
                    }
                    else
                    {
                        dayButton.Background = Brushes.LightGray;
                        dayButton.Foreground = Brushes.Black;
                    }

                    if (listDate.Contains(bbb) && listBirth.Contains(bbb) && calendar.SelectedDates.Count < 2)
                    {
                        dayButton.Background = Brushes.Green;
                        dayButton.Foreground = Brushes.Black;
                    }
                    else
                    {
                        dayButton.Background = Brushes.LightGray;
                        dayButton.Foreground = Brushes.Black;
                    }
                }
                catch
                {
                    dayButton.Background = Brushes.LightGray;
                    dayButton.Foreground = Brushes.Black;
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
        //listDate = DataSource.Helper.dataBase.MeetingsCalendars.Include(x => x.MeetStaffNavigation!.StaffBirthday).Select(x => x.MeetDate).ToList();
        //listDate = DataSource.Helper.dataBase.MeetingsCalendars.Include(x => x.MeetStaffNavigation).Select(x => x.MeetDate).Select(x => x.StaffBirthday).ToList();
        listDate = DataSource.Helper.dataBase.Staff.Select(x => x.StaffBirthday).ToList();
        listBirth = DataSource.Helper.dataBase.MeetingsCalendars.Select(x => x.MeetDate).ToList();

        //&& x.MeetStaffNavigation.StaffBirthday

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
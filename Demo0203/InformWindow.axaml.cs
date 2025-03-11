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
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Avalonia.Media.Imaging;
using System.Drawing;

namespace Demo0203;

public partial class InformWindow : Window
{
    List<DateTime?> listDate = new List<DateTime?>();
    List<DateTime?> listBirth = new List<DateTime?>();
    List<News.Class1> newsWeek = new List<News.Class1>();
    public Bitmap bitmap = new Bitmap($@"Assets\\cake.png");

    public Image image = new Image()
    {
        Source = new Bitmap($@"Assets\\cake.png"),
        Width = 40,
        Height = 40,
    };

    public InformWindow()
    {
        InitializeComponent();
        logo.Click += Logo_Click;
        calendar.Loaded += Calendar_Loaded;
        calendar.DisplayDateChanged += Calendar_DisplayDateChanged;
        searchTB.TextChanged += SearchTB_TextChanged;

        SetData();
    }

    private void SearchTB_TextChanged(object? sender, TextChangedEventArgs e) => Search();
      
    private void CalendarColors()
    {
        foreach (var index in calendar.GetVisualDescendants())
        {
            if (index is CalendarDayButton dayButton)
            {
                var now = (calendar as Calendar).DisplayDate;
                string display = dayButton.Content!.ToString()!;

                try
                {
                    if (listBirth.Contains(new DateTime(now.Year, now.Month, int.Parse(display))))
                    {
                        dayButton.Background = Brushes.White;
                        dayButton.Content = new Image()
                        {
                            Source = new Bitmap($@"Assets\\cake.png"),
                            Width = 40,
                            Height = 43,
                        };
                    }
                    else
                    {
                        dayButton.Background = Brushes.White;
                        dayButton.Foreground = Brushes.Black;
                    }

                    if (listDate.Contains(new DateTime(now.Year, now.Month, int.Parse(display))) 
                        || listBirth.Contains(new DateTime(now.Year, now.Month, int.Parse(display))) 
                        && calendar.SelectedDates.Count < 2)
                    {
                        dayButton.Background = Brushes.Green;
                        dayButton.Foreground = Brushes.Black;
                    }
                    else
                    {
                        dayButton.Background = Brushes.White;
                        dayButton.Foreground = Brushes.Black;
                    }
                }
                catch
                {
                    dayButton.Background = Brushes.White;
                    dayButton.Foreground = Brushes.Black;
                }

                try
                {
                    if (listDate.Contains(new DateTime(now.Year, now.Month, int.Parse(display)))
                        || listBirth.Contains(new DateTime(now.Year, now.Month, int.Parse(display)))
                        && calendar.SelectedDates.Count >= 5)
                    {
                        dayButton.Background = Brushes.Red;
                        dayButton.Foreground = Brushes.Black;
                    }
                    else
                    {
                        dayButton.Background = Brushes.White;
                        dayButton.Foreground = Brushes.Black;
                    }
                }
                catch
                {
                    dayButton.Background = Brushes.White;
                    dayButton.Foreground = Brushes.Black;
                }

                try
                {
                    if (listDate.Contains(new DateTime(now.Year, now.Month, int.Parse(display)))
                        || listBirth.Contains(new DateTime(now.Year, now.Month, int.Parse(display)))
                        && calendar.SelectedDates.Count >= 2
                        && calendar.SelectedDates.Count < 5)
                    {
                        dayButton.Background = Brushes.Yellow;
                        dayButton.Foreground = Brushes.Black;
                    }
                    else
                    {
                        dayButton.Background = Brushes.White;
                        dayButton.Foreground = Brushes.Black;
                    }
                }
                catch
                {
                    dayButton.Background = Brushes.White;
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
        listDate = DataSource.Helper.dataBase.MeetingsCalendars.Select(x => x.MeetDate).ToList();
        listBirth = DataSource.Helper.dataBase.Staff.Select(x => x.StaffBirthday).ToList();

        var baseDirectory = AppContext.BaseDirectory;
        var jsonPath = Path.Combine(baseDirectory, "News", "news_response.json");
        var jsonFile = File.ReadAllText(jsonPath);

        newsWeek = JsonConvert.DeserializeObject<List<News.Class1>>(jsonFile);

        var sortList = DataSource.Helper.dataBase.MeetingsCalendars.ToList();
        var meetDates = sortList.Select(x => x.MeetDate).ToList();

        staffLB.ItemsSource = DataSource.Helper.dataBase.Staff;
        meetingsLB.ItemsSource = DataSource.Helper.dataBase.MeetingsCalendars.Include(x => x.MeetStaffNavigation);
        newsLB.ItemsSource = newsWeek;
    }

    private void Calendar_SelectedDatesChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) => CalendarColors();

    private void Search()
    {
        var searchList = DataSource.Helper.dataBase.Staff.Include(x => x.MeetingsCalendars).ToList();

        string searchSearch = searchTB.Text?.ToLower() ?? "";
        if (searchSearch.Length > 0)
        {
            try
            {
                searchList = searchList.Where(x => x.StaffName.ToLower().Contains(searchSearch.ToLower()) ||
            x.StaffSurname.ToLower().Contains(searchSearch.ToLower()) ||
            x.StaffPatronimic.ToLower().Contains(searchSearch.ToLower()) ||
            x.CorporateEmail.ToLower().Contains(searchSearch.ToLower()) ||
            x.StaffWorkPhone.ToLower().Contains(searchSearch.ToLower())).ToList();
            }
            catch
            {

            }
        }

        staffLB.ItemsSource = searchList;
    }
}
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Demo0203;

public partial class InformWindow : Window
{
    public InformWindow()
    {
        InitializeComponent();
        logo.Click += Logo_Click;

        SetData();
    }

    private void Logo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow firstWindow = new MainWindow();
        firstWindow.Show();
        Close();
    }

    /*private static void UpdateCalendar()
    {
        var sortList = DataSource.Helper.dataBase.MeetingsCalendars.ToList();
        Calendar.SelectedDateProperty = sortList.Select(x => x.MeetDate);
    }*/

    private void SetData()
    {
        var sortList = DataSource.Helper.dataBase.MeetingsCalendars.ToList();
        var meetDates = sortList.Select(x => x.MeetDate).ToList();

        staffLB.ItemsSource = DataSource.Helper.dataBase.Staff;
        meetingsLB.ItemsSource = DataSource.Helper.dataBase.MeetingsCalendars.Include(x => x.MeetStaffNavigation);

        // Очищаем предыдущие выбранные даты, если они есть
        //calendar.SelectedDates.Clear();

        // Добавляем каждую дату в SelectedDates
        //foreach (var date in meetDates)
        //{
            //calendar.SelectedDates.Add(date);
        //}
    }
}
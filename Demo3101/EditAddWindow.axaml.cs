using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo3101.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo3101;

public partial class EditAddWindow : Window
{
    Staff Staff { get; set; }
    public EditAddWindow()
    {
        InitializeComponent();
        Staff = new Staff();
        //gridData.DataContext = DataSource.Helper.dataBase.Staff.Include(x => x.StaffOfficeNavigation).Include(x => x.Iddepats).Include(x => x.Idroles);
        gridData.DataContext = Staff;

        toPresent.Click += ToPresent_Click;
        toPresent3.Click += ToPresent3_Click;
        toPast.Click += ToPast_Click;
        toPast2.Click += ToPast2_Click;
        toFuture.Click += ToFuture_Click;
        toFuture2.Click += ToFuture2_Click;
        save.Click += Save_Click;

        SetData();
    }

    private void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Staff.StaffId == 0)
        {
            Staff.StaffSurname = sur.Text;
            Staff.StaffName = name.Text;
            Staff.StaffPatronimic = patron.Text;
            Staff.StaffBirthday = new DateOnly(birth.SelectedDate.Value.Year, birth.SelectedDate.Value.Month, birth.SelectedDate.Value.Day);
            Staff.StaffWorkPhone = phone.Text;
            
            DataSource.Helper.dataBase.Staff.Add(Staff);
            DataSource.Helper.dataBase.SaveChanges();

            MainWindow main = new MainWindow();
            Close();
        }
    } 

    private void ToFuture_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        future.IsVisible = true;
        present.IsVisible = false;
        past.IsVisible = false;
    } 

    private void ToFuture2_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        future.IsVisible = true;
        present.IsVisible = false;
        past.IsVisible = false;
    } 

    private void ToPast2_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        past.IsVisible = true;
        present.IsVisible = false;
        future.IsVisible = false;
    } 

    private void ToPast_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        past.IsVisible = true;
        present.IsVisible = false;
        future.IsVisible = false;
    } 

    private void ToPresent3_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        present.IsVisible = true;
        future.IsVisible = false;
        past.IsVisible = false;
    } 

    private void ToPresent_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        present.IsVisible = true;
        future.IsVisible = false;
        past.IsVisible = false;
    } 

    public EditAddWindow(Staff staff)
    {
        InitializeComponent();
        Staff = staff;
        gridData.DataContext = Staff;

        SetData();
    }

    private void SetData()
    {
        var sortList = DataSource.Helper.dataBase.Staff.Include(x => x.StaffOfficeNavigation).Include(x => x.Iddepats).Include(x => x.Idroles);


    }
}
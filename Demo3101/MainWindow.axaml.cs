using Avalonia.Controls;
using Demo3101.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Demo3101
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            toFirstDep.Click += ToFirstDep_Click;
            adminHoz.Click += AdminHoz_Click;
            toFirst.Click += ToFirst_Click;
            toMain.Click += ToMain_Click;
            SetData();
        }

        private void ToMain_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            firstDep.IsVisible = false;
        } 

        private void ToFirst_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            firstPodDepAdminHoz.IsVisible = false;
        } 

        private void AdminHoz_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            firstPodDepAdminHoz.IsVisible = true;
        } 

        private void ToFirstDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            firstDep.IsVisible = true;
        } 

        private void SetData()
        {
            staffLB.ItemsSource = DataSource.Helper.dataBase.Staff.Include(x => x.Idroles).Include(x => x.Iddepats).Include(x => x.StaffOfficeNavigation);
        }
    }
}
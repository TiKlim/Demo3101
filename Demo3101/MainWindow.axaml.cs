using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
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
            toSecondDep.Click += ToSecondDep_Click;
            toMain2.Click += ToMain2_Click;
            toThirdDep.Click += ToThirdDep_Click;
            mainButton.Click += MainButton_Click;
            SetData();
        }

        private void MainButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            mainButton.Background = Brushes.Green;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            toFirstDep.Background = solidColorBrush;
            toSecondDep.Background = solidColorBrush;
            toThirdDep.Background = solidColorBrush;
            toFourthDep.Background = solidColorBrush;
            toFifthDep.Background = solidColorBrush;
            toSixthDep.Background = solidColorBrush;
            toSeventhDep.Background = solidColorBrush;
            toEighthDep.Background = solidColorBrush;
            toNinthDep.Background = solidColorBrush;
            toTenthDep.Background = solidColorBrush;
            toEleventhDep.Background = solidColorBrush;
            toTwelfthDep.Background = solidColorBrush;
        } 

        private void ToThirdDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            toThirdDep.Background = Brushes.Green;
            mainButton.Background = solidColorBrush;
        } 

        private void ToMain2_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            secondDep.IsVisible = false;
        } 

        private void ToSecondDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            secondDep.IsVisible = true;
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
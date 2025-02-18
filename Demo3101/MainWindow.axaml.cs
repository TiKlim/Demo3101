using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.VisualTree;
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
            toFourthDep.Click += ToFourthDep_Click;
            toMain3.Click += ToMain3_Click;
            depCom.Click += DepCom_Click;
            depProjectAnalitic.Click += DepProjectAnalitic_Click;
            depNetProg.Click += DepNetProg_Click;
            depEdOrg.Click += DepEdOrg_Click;
            smartRoads.Click += SmartRoads_Click;
            toFourthPodDep.Click += ToFourthPodDep_Click;
            toMain4.Click += ToMain4_Click;
            fourthPodDep.Click += FourthPodDep_Click;
            fourthPodDepTwo.Click += FourthPodDepTwo_Click;
            toFourthPodDepTwo.Click += ToFourthPodDepTwo_Click;
            depToWorkWithMedia.Click += DepToWorkWithMedia_Click;
            depDigitalCom.Click += DepDigitalCom_Click;
            depPress.Click += DepPress_Click;
            toMain5.Click += ToMain5_Click;
            SetData();
        }

        private void ToMain5_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Press.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            toMain3.Background = Brushes.Green;
            toMain5.Background = Brushes.Green;
        } 

        private void DepPress_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depPress.Background = Brushes.Green;
        } 

        private void DepDigitalCom_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depDigitalCom.Background = Brushes.Green;
        } 

        private void DepToWorkWithMedia_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depToWorkWithMedia.Background = Brushes.Green;
        } 

        private void ToFourthPodDepTwo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Press.IsVisible = true;
            toMain5.Background = Brushes.Green;
        } 

        private void FourthPodDepTwo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            fourthPodDepTwo.Background = Brushes.Green;
        } 

        private void FourthPodDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            fourthPodDep.Background = Brushes.Green;
        } 

        private void ToMain4_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            fourthPod.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            toMain3.Background = Brushes.Green;
            toMain4.Background = Brushes.Green;
        } 

        private void ToFourthPodDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            fourthPod.IsVisible = true;
            toMain4.Background = Brushes.Green;
        } 

        private void SmartRoads_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            smartRoads.Background = Brushes.Green;
        } 

        private void DepEdOrg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depEdOrg.Background = Brushes.Green;
        } 

        private void DepNetProg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depNetProg.Background = Brushes.Green;
        } 

        private void DepProjectAnalitic_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depProjectAnalitic.Background = Brushes.Green;
        } 

        private void DepCom_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depCom.Background = Brushes.Green;
        } 

        private void ToMain3_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            fourthDep.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain3.Background = Brushes.Green;
        } 

        private void ToFourthDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            fourthDep.IsVisible = true;
            toMain3.Background = Brushes.Green;
        } 

        private void MainButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons) 
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
        } 

        private void ToThirdDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            toThirdDep.Background = Brushes.Green;
        } 

        private void ToMain2_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            secondDep.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }  
            mainButton.Background = Brushes.Green;
            toMain2.Background = Brushes.Green;
        } 

        private void ToSecondDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            secondDep.IsVisible = true;
        } 

        private void ToMain_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            firstDep.IsVisible = false;
            mainButton.Background = Brushes.Green; 
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
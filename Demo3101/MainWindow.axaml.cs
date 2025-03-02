using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.VisualTree;
using Demo3101.Context;
using Demo3101.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo3101
{
    public partial class MainWindow : Window
    {
        private List<Staff> staffs;
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
            toFifthDep.Click += ToFifthDep_Click;
            depMarketing.Click += DepMarketing_Click;
            toMain6.Click += ToMain6_Click;
            toMain7.Click += ToMain7_Click;
            depMarketingAndPartner.Click += DepMarketingAndPartner_Click;
            depPartner.Click += DepPartner_Click;
            depLicense.Click += DepLicense_Click;
            upravMarketing.Click += UpravMarketing_Click;
            depBusiness.Click += DepBusiness_Click;
            toMain8.Click += ToMain8_Click;
            depNewClients.Click += DepNewClients_Click;
            depMeetings.Click += DepMeetings_Click;
            toSixthDep.Click += ToSixthDep_Click;
            toSeventhDep.Click += ToSeventhDep_Click;
            toEighthDep.Click += ToEighthDep_Click;
            toTenthDep.Click += ToTenthDep_Click;
            toNinthDep.Click += ToNinthDep_Click;
            depAnalytic.Click += DepAnalytic_Click;
            depProject.Click += DepProject_Click;
            toMain9.Click += ToMain9_Click;
            toEleventhDep.Click += ToEleventhDep_Click;
            toMain11.Click += ToMain11_Click;
            buhNagManag.Click += BuhNagManag_Click;
            kaznaManag.Click += KaznaManag_Click;
            finEcDep.Click += FinEcDep_Click;
            finEcManag.Click += FinEcManag_Click;
            toMain12.Click += ToMain12_Click;
            depOperation.Click += DepOperation_Click;
            toTwelfthDep.Click += ToTwelfthDep_Click;
            standartManag.Click += StandartManag_Click;
            depLaw.Click += DepLaw_Click;
            toMain13.Click += ToMain13_Click;
            adminDepart.Click += AdminDepart_Click;
            add.Click += Add_Click;
            logo.Click += Logo_Click;
            SetData();
        }

        private void Logo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            FirstWindow firstWindow = new FirstWindow();
            firstWindow.Show();
            Close();
        } 

        private void Add_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            EditAddWindow editAddWindow = new EditAddWindow();
            editAddWindow.Show();
            Effect = new BlurEffect { Radius = 10 };
            IsHitTestVisible = false;
        } 

        private void AdminDepart_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            adminDepart.Background = Brushes.Green;

            staffLB.ItemsSource = DataSource.Helper.dataBase.Staff.Include(x => x.Idroles).Include(x => x.Iddepats).Include(x => x.StaffOfficeNavigation);
        } 

        private void ToMain13_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            lawDep.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain11.Background = Brushes.Green;
            toMain13.Background = Brushes.Green;
        } 

        private void DepLaw_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depLaw.Background = Brushes.Green;
        } 

        private void StandartManag_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            standartManag.Background = Brushes.Green;
        } 

        private void ToTwelfthDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            lawDep.IsVisible = true;
            toMain13.Background = Brushes.Green;
        } 

        private void DepOperation_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depOperation.Background = Brushes.Green;
        }
        
        private void ToMain12_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depKazna.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain11.Background = Brushes.Green;
            toMain12.Background = Brushes.Green;
        } 

        private void FinEcManag_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            finEcManag.Background = Brushes.Green;
        } 

        private void FinEcDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            finEcDep.Background = Brushes.Green;
        } 

        private void KaznaManag_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depKazna.IsVisible = true;
            toMain12.Background = Brushes.Green;
        } 

        private void BuhNagManag_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            buhNagManag.Background = Brushes.Green;
        } 

        private void ToMain11_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depFinEc.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain6.Background = Brushes.Green;
            toMain11.Background = Brushes.Green;
        } 

        private void ToEleventhDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depFinEc.IsVisible = true;
            toMain11.Background = Brushes.Green;
        } 

        private void ToMain9_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depStrategAndPlan.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain6.Background = Brushes.Green;
            toMain9.Background = Brushes.Green;
        } 

        private void DepProject_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depProject.Background = Brushes.Green;
        } 

        private void DepAnalytic_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depAnalytic.Background = Brushes.Green;
        } 

        private void ToNinthDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depStrategAndPlan.IsVisible = true;
            toMain9.Background = Brushes.Green;
        }

        private void ToTenthDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            toTenthDep.Background = Brushes.Green;
        } 

        private void ToEighthDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            toEighthDep.Background = Brushes.Green;
        } 

        private void ToSeventhDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            toSeventhDep.Background = Brushes.Green;
        } 

        private void ToSixthDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            toSixthDep.Background = Brushes.Green;
        } 

        private void DepMeetings_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depMeetings.Background = Brushes.Green;
        } 

        private void DepNewClients_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depNewClients.Background = Brushes.Green;
        } 

        private void ToMain8_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depBus.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain6.Background = Brushes.Green;
            toMain8.Background = Brushes.Green;
        } 

        private void DepBusiness_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depBus.IsVisible = true;
            toMain8.Background = Brushes.Green;
        } 

        private void UpravMarketing_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            upravMarketing.Background = Brushes.Green;
        } 

        private void DepLicense_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depLicense.Background = Brushes.Green;
        } 

        private void DepPartner_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depPartner.Background = Brushes.Green;
        } 

        private void DepMarketingAndPartner_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            depMarketingAndPartner.Background = Brushes.Green;
        } 

        private void ToMain7_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depMark.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain6.Background = Brushes.Green;
            toMain7.Background = Brushes.Green;
        } 

        private void ToMain6_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depMarkAndPart.IsVisible = false;
            SolidColorBrush solidColorBrush = new SolidColorBrush(Color.Parse("#e1f4c8"));
            var listButtons = this.GetVisualDescendants().OfType<Button>().ToList();
            foreach (var button in listButtons)
            {
                button.Background = solidColorBrush;
            }
            mainButton.Background = Brushes.Green;
            toMain6.Background = Brushes.Green;
        } 

        private void DepMarketing_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depMark.IsVisible = true;
            toMain7.Background = Brushes.Green;
        }
         
        private void ToFifthDep_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            depMarkAndPart.IsVisible = true;
            toMain6.Background = Brushes.Green;
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
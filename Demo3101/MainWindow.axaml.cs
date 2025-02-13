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
            SetData();
        }

        private void SetData()
        {
            staffLB.ItemsSource = DataSource.Helper.dataBase.Staff.Include(x => x.Idroles).Include(x => x.Iddepats).Include(x => x.StaffOfficeNavigation);
        }
    }
}
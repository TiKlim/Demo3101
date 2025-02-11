using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;

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
            staffLB.ItemsSource = DataSource.Helper.dataBase.Staff.Include(x => x.StaffPosts);
        }
    }
}
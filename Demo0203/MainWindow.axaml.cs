using Avalonia.Controls;

namespace Demo0203;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        toStructure.Click += ToStructure_Click;
        toInform.Click += ToInform_Click;
    }

    private void ToInform_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        InformWindow informWindow = new InformWindow();
        informWindow.Show();
        Close();
    }

    private void ToStructure_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OrganizationWindow organizationWindow = new OrganizationWindow();
        organizationWindow.Show();
        Close();
    }
}
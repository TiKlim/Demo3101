using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Demo3101;

public partial class FirstWindow : Window
{
    public FirstWindow()
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
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    } 
}
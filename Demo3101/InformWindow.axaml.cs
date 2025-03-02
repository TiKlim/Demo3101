using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Demo3101;

public partial class InformWindow : Window
{
    public InformWindow()
    {
        InitializeComponent();
        logo.Click += Logo_Click;
    }

    private void Logo_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        FirstWindow firstWindow = new FirstWindow();
        firstWindow.Show();
        Close();
    } 
}
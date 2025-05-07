using Avalonia.Controls;
using Avalonia.Interactivity;
using CounselingOrganizationPlatform.AvaloniaUI.Views;

namespace CounselingOrganizationPlatform.AvaloniaUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UserManagementButton_Click(object? sender, RoutedEventArgs e)
        {
            MainContent.Content = new UserManagementView();
        }
    }
}

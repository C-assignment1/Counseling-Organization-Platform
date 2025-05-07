using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Controls.Primitives;
using CounselingOrganizationPlatform.AvaloniaUI.Views;

namespace CounselingOrganizationPlatform.AvaloniaUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Directly use the generated field MainContent from XAML
            if (MainContent == null)
                throw new Exception("MainContent control not found");
            MainContent.Content = new UserManagementView();
        }

        private void UserManagementButton_Click(object? sender, RoutedEventArgs e)
        {
            if (MainContent != null)
            {
                MainContent.Content = new UserManagementView();
            }
        }
    }
}

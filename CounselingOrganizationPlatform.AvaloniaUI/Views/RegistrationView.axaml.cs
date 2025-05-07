using Avalonia.Controls;
using Avalonia.Interactivity;
using CounselingOrganizationPlatform.BLL;

namespace CounselingOrganizationPlatform.AvaloniaUI.Views
{
    public partial class RegistrationView : UserControl
    {
        private readonly AuthService authService = new AuthService();

        public RegistrationView()
        {
            InitializeComponent();

            RegisterButton.Click += RegisterButton_Click;
            BackToLoginButton.Click += BackToLoginButton_Click;
        }

        private void RegisterButton_Click(object? sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            // TODO: Implement registration logic using authService
            bool success = authService.Register(name, email, password);

            var mainWindow = (MainWindow)this.VisualRoot;

            if (success)
            {
                var dialog = new Window
                {
                    Content = new TextBlock { Text = "Registration successful. Please login." },
                    Width = 300,
                    Height = 100,
                    WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner,
                    CanResize = false
                };
                dialog.ShowDialog((Window)this.VisualRoot);
                mainWindow.MainContent.Content = new LoginView();
            }
            else
            {
                var dialog = new Window
                {
                    Content = new TextBlock { Text = "Registration failed. Please try again." },
                    Width = 300,
                    Height = 100,
                    WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner,
                    CanResize = false
                };
                dialog.ShowDialog((Window)this.VisualRoot);
            }
        }

        private void BackToLoginButton_Click(object? sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)this.VisualRoot;
            mainWindow.MainContent.Content = new LoginView();
        }
    }
}

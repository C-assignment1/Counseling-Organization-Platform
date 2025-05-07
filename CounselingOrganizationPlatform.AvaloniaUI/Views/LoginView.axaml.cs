using Avalonia.Controls;
using Avalonia.Interactivity;
using CounselingOrganizationPlatform.AvaloniaUI.BLL;

namespace CounselingOrganizationPlatform.AvaloniaUI.Views
{
    public partial class LoginView : UserControl
    {
        private readonly AuthService authService = new AuthService();

        public LoginView()
        {
            InitializeComponent();

            LoginButton!.Click += LoginButton_Click;
            RegisterButton!.Click += RegisterButton_Click;
        }

        private void LoginButton_Click(object? sender, RoutedEventArgs e)
        {
            string email = EmailTextBox!.Text;
            string password = PasswordTextBox!.Text;

            if (authService.Login(email, password))
            {
                // TODO: Navigate to MainWindow or main content
                var mainWindow = (MainWindow) this.VisualRoot;
                // Replace MainContent.Content with appropriate navigation logic
                // For example, if MainWindow has a ContentControl named MainContent:
mainWindow.MainContent!.Content = new UserManagementView();
                // If not, you need to implement navigation accordingly.
            }
            else
            {
                var dialog = new Window
                {
                    Content = new TextBlock { Text = "Invalid email or password." },
                    Width = 300,
                    Height = 100,
                    WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterOwner,
                    CanResize = false
                };
                dialog.ShowDialog((Window)this.VisualRoot);
            }
        }

        private void RegisterButton_Click(object? sender, RoutedEventArgs e)
        {
            // TODO: Navigate to RegistrationView
var mainWindow = (MainWindow)this.VisualRoot;
    mainWindow.MainContent!.Content = new RegistrationView();
        }
    }
}

using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CounselingPlatform.ViewModels;

namespace CounselingPlatform.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

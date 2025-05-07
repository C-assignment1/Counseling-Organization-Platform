using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace CounselingPlatform.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly AuthService _authService = new();

        private string _email;
        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; }
        public ReactiveCommand<Unit, Unit> NavigateRegisterCommand { get; }

        private readonly MainViewModel _mainViewModel;

        public LoginViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            LoginCommand = ReactiveCommand.CreateFromTask(Login);
            NavigateRegisterCommand = ReactiveCommand.Create(() =>
                _mainViewModel.CurrentView = new RegisterViewModel(_mainViewModel));
        }

        private async Task Login()
        {
            var success = await _authService.LoginAsync(Email, Password);
            if (success)
            {
                // TODO: Navigate to dashboard view
            }
        }
    }
}

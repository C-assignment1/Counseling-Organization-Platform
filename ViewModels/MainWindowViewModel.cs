using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace CounselingPlatform.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }

        public MainViewModel()
        {
            CurrentView = new LoginViewModel(this);
        }
    }

    public abstract class ViewModelBase : ReactiveObject
    {
    }
}

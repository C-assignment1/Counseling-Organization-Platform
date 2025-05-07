using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace CounselingOrganizationPlatform.AvaloniaUI
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            // Set FluentTheme Mode programmatically due to XAML Mode property issue
            var fluentTheme = Styles.OfType<Avalonia.Themes.Fluent.FluentTheme>().FirstOrDefault();
            if (fluentTheme != null)
            {
                fluentTheme.Mode = Avalonia.Themes.Fluent.FluentThemeMode.Light;
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}

using System.Configuration;
using System.Data;
using System.Windows;
using Wpf.Ui.Appearance;

namespace OpenAIClient
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ApplicationThemeManager.Apply(ApplicationTheme.Dark);
            base.OnStartup(e);
        }
    }

}

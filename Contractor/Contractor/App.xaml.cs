using Contractor.Enums;
using Contractor.Utils;

namespace Contractor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        string wantedDesign = Preferences.Get("theme", Design.Default.ToString());

        if(wantedDesign == Design.Default.ToString())
        {
            Current.UserAppTheme = AppTheme.Unspecified;
        }
        else if (wantedDesign == Design.Light.ToString())
        {
            Current.UserAppTheme = AppTheme.Light;
        }
        else if (wantedDesign == Design.Dark.ToString()) 
        {
            Current.UserAppTheme = AppTheme.Dark;
        }


		Shell.Current.GoToAsync("//MainPage");
	}

    protected override Window CreateWindow(IActivationState activationState) 
    {
        var Window = base.CreateWindow(activationState);

        if(DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            Window.Width= 505;

            Window.Height = 700;
        }

        Window.Created += (s, e) =>
        {
            Load();
        };

        Window.Resumed += (s, e) =>
        {
            Load();
        };

        Window.Destroying += (s, e) =>
        {
            Save();
        };

        Window.Stopped += (s, e) =>
        {
            Save();
        };

        return Window;
    }

    private void Load() => DataSaver.Load();
    private void Save() => DataSaver.Save();
}

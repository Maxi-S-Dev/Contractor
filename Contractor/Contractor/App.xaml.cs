using Contractor.Enums;

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
            Application.Current.UserAppTheme = AppTheme.Unspecified;
        }
        else if (wantedDesign == Design.Light.ToString())
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }
        else if (wantedDesign == Design.Dark.ToString()) 
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
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

        Window.Destroying += (s, e) =>
        {
            Utils.DataSaver.Save();
        };

        return Window;
    }
}

using System.Diagnostics;

namespace Contractor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

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

/* Unmerged change from project 'Contractor (net7.0-windows10.0.19041.0)'
Before:
            Container.SaveData.Save();
After:
            SaveData.Save();
*/
            Contractor.Services.DataSaver.Save();
        };

        return Window;
    }
}

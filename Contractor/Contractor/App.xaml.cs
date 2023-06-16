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
            Utils.DataSaver.Save();
        };

        return Window;
    }
}

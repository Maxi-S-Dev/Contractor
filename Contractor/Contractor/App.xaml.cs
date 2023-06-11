namespace Contractor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		Shell.Current.GoToAsync("//MainPage");
	}

#if WINDOWS
    protected override Window CreateWindow(IActivationState activationState)
    {
        var Window = base.CreateWindow(activationState);

		Window.Width= 505;

		Window.Height = 700;

		return Window;
    }
#endif
}

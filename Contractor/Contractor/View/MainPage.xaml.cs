using Contractor.ViewModel;
using System.Diagnostics;
namespace Contractor.View;

public partial class MainPage : ContentPage
{
    MainViewModel _mainVm;
	public MainPage()
	{
		InitializeComponent();
        _mainVm = new MainViewModel();
        BindingContext = _mainVm;

        if (DeviceInfo.Platform == DevicePlatform.WinUI)
		{
			var component = new Components.TimeListView();

			component.VerticalOptions = LayoutOptions.Center;
            component.BindingContext = _mainVm.TimerCarouselVm;

            ProgressbarGrid.Add(component);

		}

        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            var component = new Components.TimerCarouselView();

            component.VerticalOptions = LayoutOptions.Center;
            component.BindingContext = _mainVm.TimerCarouselVm;

            ProgressbarGrid.Add(component);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Trace.WriteLine("clicked");
    }
}


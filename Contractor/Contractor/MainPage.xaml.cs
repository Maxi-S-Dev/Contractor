using Contractor.Timers;
using Contractor.ViewModel;

namespace Contractor;

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

            MainGrid.Add(component, 0, 1);
		}

        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            var component = new Components.TimerCarouselView();

            component.VerticalOptions = LayoutOptions.Center;
            component.BindingContext = _mainVm.TimerCarouselVm;

            MainGrid.Add(component, 0, 1);
        }
    }
}


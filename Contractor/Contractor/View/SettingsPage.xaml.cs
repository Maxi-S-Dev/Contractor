using Microsoft.Maui.Handlers;
using System.Diagnostics;
using Contractor.ViewModel;
using Contractor.Enums;

namespace Contractor.View;
public partial class SettingsPage : ContentPage
{
    SettingsViewModel vm;

    Picker p;

    const string pName = "Picker";

	public SettingsPage()
	{
		InitializeComponent();
        
        vm = new SettingsViewModel();
        BindingContext = vm;

        Application.Current.RequestedThemeChanged += (s, e) =>
        {
            LoadPicker();
        };

        LoadPicker();
    }

    private void LoadPicker()
    {
        if (p is not null)
        {
            DesignGrid.Remove(p);
        }

        p = new();
        p.MinimumWidthRequest = 120;
        p.MinimumHeightRequest = 40;
        p.VerticalOptions = LayoutOptions.Center;

        if (Application.Current.UserAppTheme == AppTheme.Dark)
        {
            p.BackgroundColor = Color.FromArgb("#ff1e1e1e");
            p.TextColor = Colors.White;
        }
        else
        {
            p.BackgroundColor = Color.FromArgb("#fff8fafd");
            p.TextColor = Colors.Black;
        }

        DesignGrid.Add(p, 2, 0);
        p.ItemsSource = vm.DesignStates;
        p.SelectedItem = vm.CurrentDesign;
        


        p.SelectedIndexChanged += (s, e) =>
        {
            if(p.SelectedItem.ToString() == Design.Light.ToString())
            {
                vm.CurrentDesign = Design.Light;
                return;
            }
            if (p.SelectedItem.ToString() == Design.Dark.ToString())
            {
                vm.CurrentDesign = Design.Dark;
                return;
            }
            if (p.SelectedItem.ToString() == Design.Default.ToString())
            {
                vm.CurrentDesign = Design.Default;
                return;
            }
        };
    }
}
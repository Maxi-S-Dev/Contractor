using Microsoft.Maui.Handlers;
using System.Diagnostics;
using Contractor.ViewModel;
using Contractor.Enums;

namespace Contractor.View;
public partial class SettingsPage : ContentPage
{
    SettingsViewModel vm;

    Picker p;

    private const string darkModeColor = "#ff1e1e1e";
    private const string lightModeColor = "#fff8fafd";

    Entry prodEntry;
    Entry freeEntry;
    Entry factorEntry;

    public SettingsPage()
	{
		InitializeComponent();
        
        vm = new SettingsViewModel();
        BindingContext = vm;

        Application.Current.RequestedThemeChanged += (s, e) =>
        {
            LoadUI();
        };

        LoadUI();
    }

    private void LoadUI()
    {
        LoadPicker();
        LoadEntrys();
    }

    private void LoadEntrys()
    {
        prodEntry = StyleEntry(prodEntry);
        freeEntry = StyleEntry(freeEntry);
        factorEntry = StyleEntry(factorEntry);

        prodEntry.Text = vm.MaxProdTime;
        freeEntry.Text = vm.MaxFreeTime;
        factorEntry.Text = vm.Factor;

        MaxProdTimeGrid.Add(prodEntry, 2, 0);
        MaxFreeTimeGrid.Add(freeEntry, 2, 0);
        FactorGrid.Add(factorEntry, 2, 0);

        prodEntry.TextChanged += (s, e) =>
        {
            vm.MaxProdTime = e.NewTextValue;
        };

        freeEntry.TextChanged += (s, e) =>
        {
            vm.MaxFreeTime = e.NewTextValue;
        };

        factorEntry.TextChanged += (s, e) =>
        {
            vm.Factor = e.NewTextValue;
        };
    }

    private Entry StyleEntry(Entry entry) 
    {
        if (entry is not null) (entry.Parent as Grid).Remove(entry);

        entry = new();
        entry.WidthRequest = 40;
        entry.MinimumHeightRequest = 18;
        entry.FontSize = 14;
        entry.VerticalOptions = LayoutOptions.Center;
        entry.VerticalTextAlignment = TextAlignment.Center;
        entry.HorizontalTextAlignment = TextAlignment.Center;

        if (Application.Current.UserAppTheme == AppTheme.Dark)
        {
            p.BackgroundColor = Color.FromArgb(darkModeColor);
            p.TextColor = Colors.White;
        }
        else
        {
            p.BackgroundColor = Color.FromArgb(lightModeColor);
            p.TextColor = Colors.Black;
        }

        return entry;
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
            p.BackgroundColor = Color.FromArgb(darkModeColor);
            p.TextColor = Colors.White;
        }
        else
        {
            p.BackgroundColor = Color.FromArgb(lightModeColor);
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
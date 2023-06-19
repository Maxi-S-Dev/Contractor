using Contractor.Enums;
using Contractor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        DataStore DataStore = Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore;
        public string MaxProdTime 
        {
            get 
            {
                return DataStore.MaxProductiveTime/3600 + "h";
            }
            set 
            { 
                string val = value.Split('h')[0];
                int.TryParse(val, out int newTime);

                DataStore.MaxProductiveTime = newTime * 3600;
                OnPropertyChanged(nameof(MaxProdTime));
            }
        }
        public string MaxFreeTime 
        {
            get
            {
                return DataStore.MaxFreeTime/3600 + "h";
            }
            set
            {
                string val = value.Split('h')[0];
                int.TryParse(val, out int newTime);

                DataStore.MaxFreeTime = newTime * 3600;
                OnPropertyChanged(nameof(MaxFreeTime));
            }
        }
        public string Factor 
        {
            get
            {
                return DataStore.Factor.ToString();
            }
            set
            {
                int.TryParse(value, out int newFactor);

                DataStore.Factor= newFactor;
                OnPropertyChanged(nameof(Factor));
            }
        }

        public List<Design> DesignStates { get { return Enum.GetValues(typeof(Design)).OfType<Design>().ToList(); } }

        public Design CurrentDesign
        {
            get 
            {
                switch (Application.Current.UserAppTheme)
                {
                    case AppTheme.Dark:
                        return Design.Dark;

                    case AppTheme.Light:
                        return Design.Light;

                    case AppTheme.Unspecified:
                        return Design.Default;

                    default:
                        return Design.Default;
                }
            }
            set
            {
                switch(value)
                {
                    case Design.Default:
                        Application.Current.UserAppTheme = AppTheme.Unspecified;
                        Preferences.Set("theme", Design.Default.ToString());
                        break;

                    case Design.Light:
                        Application.Current.UserAppTheme = AppTheme.Light;
                        Preferences.Set("theme", Design.Light.ToString());
                        break;

                    case Design.Dark:
                        Application.Current.UserAppTheme = AppTheme.Dark;
                        Preferences.Set("theme", Design.Dark.ToString());
                        break;
                }
                OnPropertyChanged();
            }
        }
        public SettingsViewModel() { }
    }
}

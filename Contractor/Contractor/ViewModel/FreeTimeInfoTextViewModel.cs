using Contractor.Services;
using Contractor.Utils;
using System.ComponentModel;

namespace Contractor.ViewModel
{
    public class FreeTimeInfoTextViewModel : ViewModelBase
    {
        DataStore ds = Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore;
        public string Text
        {
            get
            {
                int hours = (int)(ds.FreeSeconds / 3600);
                int mins = (int)((ds.FreeSeconds % 3600) / 60);

                return $"{hours}h and {mins}mins";
            }
        }

        public FreeTimeInfoTextViewModel(MainViewModel mainVm)
        {
            MainTimer.Dispatcher.Tick += (s, e) =>
            {
                OnPropertyChanged(nameof(Text));
            };

            mainVm.PropertyChanged += MainViewModelPropertyChanged;
        }

        private void MainViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Services.DataStore)) 
            {
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}
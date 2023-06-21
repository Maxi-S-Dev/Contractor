using Contractor.Services;
using Contractor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public FreeTimeInfoTextViewModel()
        {
            MainTimer.Dispatcher.Tick += (s, e) =>
            {
                OnPropertyChanged(nameof(Text));
            };
        }
    }
}

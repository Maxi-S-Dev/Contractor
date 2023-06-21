using Contractor.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Contractor.Model;
using System.ComponentModel;
using System.Diagnostics;

namespace Contractor.ViewModel
{
    public class TimerCarouselViewModel : ViewModelBase
    {
        //View Model for the Productive Timer
        public RoundProgressBarViewModel productiveTimer;
        public RoundProgressBarViewModel ProductiveTimer 
        {
            get => productiveTimer;
            private set
            { 
                productiveTimer = value;
                OnPropertyChanged(nameof(ProductiveTimer));
            } 
        }

        //View Model for the FreeTime Timer
        public RoundProgressBarViewModel freeTimeTimer;
        public RoundProgressBarViewModel FreeTimeTimer 
        { get => freeTimeTimer; 
            private set
            {
                freeTimeTimer = value;
                OnPropertyChanged(nameof(FreeTimeTimer));
            }
                 
        }

        //List used to Display both Timers in the CarouselView
        private ObservableCollection<Model.Timer> timerList;

        public ObservableCollection<Model.Timer> TimerList
        {
            get => timerList;
            set
            {
                timerList = value;
                OnPropertyChanged();
            }
        }

        //Applys both ViewModels and creates the list
        public TimerCarouselViewModel(MainViewModel mainVm) 
        {
            mainVm.PropertyChanged += MainViewModelPropertyChanged;

            productiveTimer = new RoundProgressBarViewModel(TimerType.Productive, this);
            freeTimeTimer = new RoundProgressBarViewModel(TimerType.FreeTime, this);

            TimerList = new ObservableCollection<Model.Timer> { new Model.Timer() { Context = productiveTimer }, new Model.Timer() { Context = freeTimeTimer } };
        }

        private void MainViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Services.DataStore))
            {
                Trace.WriteLine("CarousellView");
                OnPropertyChanged(nameof(Services.DataStore));
            }
        }
    }
}

using Contractor.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.ViewModel
{
    public class TimerCarouselViewModel : ViewModelBase
    {
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

        public RoundProgressBarViewModel freeTimeTimer;
        public RoundProgressBarViewModel FreeTimeTimer 
        { get => freeTimeTimer; 
            private set
            {
                freeTimeTimer = value;
                OnPropertyChanged(nameof(FreeTimeTimer));
            }
                 
        }

        private ObservableCollection<Timer> timerList;

        public ObservableCollection<Timer> TimerList
        {
            get => timerList;
            set
            {
                timerList = value;
                OnPropertyChanged();
            }
        }

        public TimerCarouselViewModel() 
        {
            productiveTimer = new RoundProgressBarViewModel(TimerType.Productive);
            freeTimeTimer = new RoundProgressBarViewModel(TimerType.FreeTimer);

            TimerList = new ObservableCollection<Timer> { new Timer() { Context = productiveTimer }, new Timer() { Context = freeTimeTimer } };
        }
    }

    public class Timer
    {
        public RoundProgressBarViewModel Context { get; set; }
    }
}

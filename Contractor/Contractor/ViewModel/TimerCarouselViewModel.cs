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
        private ObservableCollection<Timer> timerList;

        RoundProgressBarViewModel roundProgressBarViewModel1;
        RoundProgressBarViewModel roundProgressBarViewModel2;

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
            TimerList = new ObservableCollection<Timer> { new Timer() { Context = new RoundProgressBarViewModel(0) }, new Timer() { Context = new RoundProgressBarViewModel(1) } };
        }
    }

    public class Timer
    {
        public RoundProgressBarViewModel Context { get; set; }
    }
}

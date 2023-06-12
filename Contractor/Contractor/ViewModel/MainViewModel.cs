using Contractor.Drawables;
using Contractor.Timers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Contractor.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        TimerCarouselViewModel timerCarouselVm;
        public TimerCarouselViewModel TimerCarouselVm 
        { 
            get => timerCarouselVm; 
            set
            {
                timerCarouselVm = value;
                OnPropertyChanged(nameof(TimerCarouselVm));
            }
        }

        public ICommand FreeTimeCommand { get; private set; }
        public ICommand ProductiveTimeCommand { get; private set; }

        public MainViewModel() 
        {
            TimerCarouselVm = new TimerCarouselViewModel();

            FreeTimeCommand = new Command(() => 
            {
                Trace.WriteLine("Toggeled");
                MainTimer.ToggleFreeTime();
            });


            ProductiveTimeCommand = new Command(() =>
            {
                MainTimer.ToggleProductiveTime();
            });
        }
    }
}

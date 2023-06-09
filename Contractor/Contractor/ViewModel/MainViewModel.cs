using Contractor.Drawables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MainViewModel() 
        {
            TimerCarouselVm = new TimerCarouselViewModel();
        }
    }
}

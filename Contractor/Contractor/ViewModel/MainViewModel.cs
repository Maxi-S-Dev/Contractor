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
        private string productiveButtonText = "Start Being ";
        public string ProductiveButtonText 
        {
            get => productiveButtonText;
            set 
            {
                productiveButtonText = value;
                OnPropertyChanged(nameof(ProductiveButtonText));
            } 
        }

        
        private string freeTimeButtonText = "Start Being ";
        public string FreeTimeButtonText
        {
            get => freeTimeButtonText;
            set
            {
                freeTimeButtonText = value;
                OnPropertyChanged(nameof(FreeTimeButtonText));
            }
        }

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
                MainTimer.ToggleFreeTime();

                ProductiveButtonText = "Start Being ";

                if (MainTimer.Dispatcher.IsRunning)
                {
                    FreeTimeButtonText = "Stop your ";
                    return;
                }
                FreeTimeButtonText = "Start your ";
            });


            ProductiveTimeCommand = new Command(() =>
            {
                MainTimer.ToggleProductiveTime();

                FreeTimeButtonText = "Start your ";

                if (MainTimer.Dispatcher.IsRunning) 
                {
                    ProductiveButtonText = "Stop Being ";
                    return;
                }
                ProductiveButtonText = "Start Being ";
            });
        }
    }
}

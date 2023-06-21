using Contractor.Drawables;
using Contractor.Utils;
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
        //First half of the Productive Button Text 
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

        //First half of the Free Time Button Text 
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

        public FreeTimeInfoTextViewModel freeTimeInfoTextViewModel { get; set; }
        public FreeTimeInfoTextViewModel FreeTimeInfoTextViewModel 
        {
            get => freeTimeInfoTextViewModel; 
            set
            {
                freeTimeInfoTextViewModel = value;
                OnPropertyChanged(nameof(FreeTimeInfoTextViewModel));
            }
        }

        public ICommand FreeTimeCommand { get; private set; }
        public ICommand ProductiveTimeCommand { get; private set; }

        private SynchronizationContext _uiContext;


        /// <summary>
        /// Creates the View Model for the Carousel/ListView
        /// </summary>
        public MainViewModel() 
        {
            _uiContext = SynchronizationContext.Current;


            TimerCarouselVm = new TimerCarouselViewModel(this);
            FreeTimeInfoTextViewModel = new FreeTimeInfoTextViewModel(this);

            DataSaver.Load().ContinueWith(task =>
            {
                _uiContext.Post(_ =>
                {
                    OnPropertyChanged(nameof(Services.DataStore));
                }, null);
            });
            OnPropertyChanged("Time");
            CreateCommands();
        }

        /// <summary>
        /// Creates the Commands for the Buttons
        /// They Start the Acording Timer
        /// They update the Text from the Buttons
        /// </summary>
        private void CreateCommands()
        {
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

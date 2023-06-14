using Contractor.Drawables;
using Contractor.Enums;
using Contractor.Container;
using System.Xml;
using System.Reflection.Metadata;
using System.Diagnostics;
using Contractor.Timers;

namespace Contractor.ViewModel
{
    public class RoundProgressBarViewModel : ViewModelBase
    {
        //Displayed Time 
        private string time;
        public string Time 
        { 
            get => time;
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        
        }

        //Text below Time
        string text;
        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public ClockDrawable ClockDrawable { get; }

    
        /// <summary>
        /// Creates the RoundProgessBar(ClockDrawable)
        /// </summary>
        /// <param name="timerType"></param>
        public RoundProgressBarViewModel(TimerType timerType)
        {
            ClockDrawable = new ClockDrawable(timerType);

            SetTimerTick(timerType);
        }

        //Updates the UI on every Timer Tick
        private void SetTimerTick(TimerType timerType)
        {
            MainTimer.Dispatcher.Tick += (s, e) =>
            {
                float percent = (DataStorage.ProdSeconds * 100) / DataStorage.MaxProductiveTime;

                ClockDrawable.SetDegreesUsingPercent(percent);
                OnPropertyChanged(nameof(ClockDrawable));

                SetTimeText(timerType);
            };
        }

        //Calculates and Updates the Text shown in the Progressbar
        private void SetTimeText(TimerType timerType)
        {
            int time = 0;

            if (timerType == TimerType.Productive)
            {
                Text = "Time elapsed";
                time = DataStorage.ProdSeconds;
            }
            else if (timerType == TimerType.FreeTime)
            {
                Text = "Time remaining";
                time = DataStorage.FreeSeconds;
            }

            string hours = (time / 3600).ToString();
            if (hours.Length == 1) hours = "0" + hours;
            
            string minutes = ((time % 3600) / 60).ToString();
            if (minutes.Length == 1) minutes = "0" + minutes;

            Time = $"{hours}:{minutes}";
        }        
    }
}
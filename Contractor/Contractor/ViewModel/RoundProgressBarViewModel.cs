using Contractor.Drawables;
using Contractor.Enums;
using System.Xml;
using System.Reflection.Metadata;
using System.Diagnostics;
using Contractor.Utils;
using Contractor.Services;
using System.ComponentModel;

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
                OnPropertyChanged(nameof(LoadingText));
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

        public string LoadingText
        {
            get
            {
                if(string.IsNullOrEmpty(Time))
                {
                    return "Loading ...";
                }
                else
                {
                    return "";
                }
            }
        }

        public ClockDrawable ClockDrawable { get; }

        DataStore dataStore;

        private TimerType timerType;
        /// <summary>
        /// Creates the RoundProgessBar(ClockDrawable)
        /// </summary>
        /// <param name="timerType"></param>
        public RoundProgressBarViewModel(TimerType _timerType, TimerCarouselViewModel vm)
        {
            timerType = _timerType;
            vm.PropertyChanged += ViewModelPropertyChanged;

            ClockDrawable = new ClockDrawable(timerType);

            SetTimerTick(timerType);

            dataStore = Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore;

            SetTimeText(timerType);
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Services.DataStore)) 
            {
                Trace.WriteLine("RoundTimer");
                SetTimeText(timerType);
                UpdateClockdrawable();
            }
        }

        //Updates the UI on every Timer Tick
        private void SetTimerTick(TimerType timerType)
        {
            MainTimer.Dispatcher.Tick += (s, e) =>
            {
                UpdateClockdrawable();

                SetTimeText(timerType);
            };
        }

        private void UpdateClockdrawable()
        {
            float percent = timerType == TimerType.Productive ? (dataStore.ProdSeconds * 100) / dataStore.MaxProductiveTime : (dataStore.FreeSeconds * 100) / dataStore.MaxFreeTime;

            ClockDrawable.SetDegreesUsingPercent(percent);
            OnPropertyChanged(nameof(ClockDrawable));
        }

        //Calculates and Updates the Text shown in the Progressbar
        private void SetTimeText(TimerType timerType)
        {
            int time = 0;

            if (timerType == TimerType.Productive)
            {
                Text = "Time elapsed";
                time = (int)dataStore.ProdSeconds;
            }
            else if (timerType == TimerType.FreeTime)
            {
                Text = "Time remaining";
                time = (int)dataStore.FreeSeconds;
            }

            string prefix = time < 0 ? "-" : "";

            string hours = Math.Abs(time / 3600).ToString();
            if (hours.Length == 1) hours = "0" + hours;
            
            string minutes = Math.Abs((time % 3600) / 60).ToString();
            if (minutes.Length == 1) minutes = "0" + minutes;

            Time = $"{prefix}{hours}:{minutes}";
        }        
    }
}
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

        float tickRate = 0;
        float degree;

        public RoundProgressBarViewModel(TimerType timerType)
        {
            ClockDrawable = new ClockDrawable(timerType);

            CalculateDegrees(timerType);

            MainTimer.Dispatcher.Tick += (s, e) =>
            {
                //ClockDrawable.AddDegrees(degree);

                float percent = (DataStorage.ProdSeconds * 100) / DataStorage.MaxProductiveTime;

                ClockDrawable.SetDegreesUsingPercent(percent);
                OnPropertyChanged(nameof(ClockDrawable));

                SetTimeText(timerType);
            };
        }

        private void CalculateDegrees(TimerType timerType)
        {
            if (timerType == TimerType.Productive)
            {
                degree = 360 / DataStorage.MaxProductiveTime;
                return;
            }
        }

        private void CalculateTickRate(TimerType timerType)
        {
            if(timerType == TimerType.Productive)
            { 
                tickRate = DataStorage.MaxProductiveTime / 720;
                return;
            }

            tickRate = DataStorage.MaxFreeTime / 720;
        }

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
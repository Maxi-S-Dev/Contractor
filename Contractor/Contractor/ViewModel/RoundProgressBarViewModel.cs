using Contractor.Drawables;
using Contractor.Enums;
using Contractor.Container;
using System.Xml;
using System.Reflection.Metadata;
using System.Diagnostics;

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

            CalculateTickRate(timerType);
            CalculateDegrees(timerType);
            SetText(timerType);

            if (timerType == TimerType.Productive) SetTimeText(DataStorage.ProdSeconds);
            else if (timerType == TimerType.FreeTimer) SetTimeText(DataStorage.FreeSeconds);

            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                ClockDrawable.AddDegrees(degree);
                OnPropertyChanged(nameof(ClockDrawable));


                if (timerType == TimerType.Productive)
                {
                    DataStorage.ProdSeconds += 1;
                    Trace.WriteLine(DataStorage.ProdSeconds);
                }

                if (timerType == TimerType.Productive) SetTimeText(DataStorage.ProdSeconds);
                else if (timerType == TimerType.FreeTimer) SetTimeText(DataStorage.FreeSeconds);
            };
            timer.Start();
        }

        private void CalculateDegrees(TimerType timerType)
        {
            if (timerType == TimerType.Productive)
            {
                degree = 360 / DataStorage.MaxProductiveTime;
                return;
            }

            tickRate = DataStorage.MaxFreeTime / 720;
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

        private void SetText(TimerType timerType)
        {
            if (timerType == TimerType.Productive)
            {
                Text = "Time elapsed";
                return;
            }
            Text = "Time remaining";
        }

        private void SetTimeText(int time)
        {
            string hours = (time / 3600).ToString();
            if (hours.Length == 1) hours = "0" + hours;
            
            string minutes = ((time % 3600) / 60).ToString();
            if (minutes.Length == 1) minutes = "0" + minutes;

            Time = $"{hours}:{minutes}";
        }
    }
}
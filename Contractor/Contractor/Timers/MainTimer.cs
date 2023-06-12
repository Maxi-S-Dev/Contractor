using Contractor.Container;
using Contractor.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Timers
{
    public static class MainTimer
    {
        private static bool firstRun = true;
        private static TimerType currentTimer = TimerType.Productive;


        public static IDispatcherTimer Dispatcher = Application.Current.Dispatcher.CreateTimer();
        public static void StartTimer()
        {
            if (firstRun)
            {
                SetUpTimer();
                firstRun = false;
            }
            Dispatcher.Start();
        }

        private static void SetUpTimer()
        {
            Dispatcher.Interval = TimeSpan.FromSeconds(.01);

            Dispatcher.Tick += (s, e) =>
            {
                if (currentTimer == TimerType.Productive)
                    DataStorage.IncreaseProd();
                else
                    DataStorage.DecreaseFree();
            };
        }

        public static void StopTimer() => Dispatcher.Stop();

        public static void ToggleFreeTime()
        {
            if(Dispatcher.IsRunning && currentTimer == TimerType.FreeTime) 
            {
                StopTimer();
                return;
            }

            if(!Dispatcher.IsRunning || (Dispatcher.IsRunning && currentTimer != TimerType.FreeTime))
            {
                StartTimer();
                currentTimer = TimerType.FreeTime;
            }
        }

        public static void ToggleProductiveTime() 
        {
            if (Dispatcher.IsRunning && currentTimer == TimerType.Productive)
            {
                StopTimer();
                return;
            }

            if (!Dispatcher.IsRunning || (Dispatcher.IsRunning && currentTimer != TimerType.Productive))
            {
                StartTimer();
                currentTimer = TimerType.Productive;
            }
        }
    }
}

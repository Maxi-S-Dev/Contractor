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
        public static IDispatcherTimer Dispatcher = Application.Current.Dispatcher.CreateTimer();
        public static void StartTimer(TimerType timerType)
        {
            Dispatcher.Interval = TimeSpan.FromSeconds(1);

            Dispatcher.Tick += (s, e) =>
            {
                if (timerType == TimerType.Productive) DataStorage.ProdSeconds++;
                else DataStorage.FreeSeconds--;
            };
            Dispatcher.Start();
        }
        
        public static void StopTimer() => Dispatcher.Stop();
    }
}

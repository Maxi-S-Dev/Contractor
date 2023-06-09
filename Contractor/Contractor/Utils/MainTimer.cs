﻿using Contractor.Enums;
using Contractor.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Utils
{
    public static class MainTimer
    {
        private static bool firstRun = true;
        private static TimerType currentTimer = TimerType.Productive;


        public static IDispatcherTimer Dispatcher = Application.Current.Dispatcher.CreateTimer();
        static DataStore dataStore = Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore; 

        /// <summary>
        /// Starts the Timer
        /// If it is the first start it creates the Tick Event to add the seconds
        /// </summary>
        public static void StartTimer()
        {
            if (firstRun)
            {
                SetUpTimer();
                firstRun = false;
            }
            Dispatcher.Start();
        }

        //Timer Setup
        private static void SetUpTimer()
        {
            Dispatcher.Interval = TimeSpan.FromSeconds(1);

            Dispatcher.Tick += (s, e) =>
            {
                //Trace.WriteLine("Tick");
                if (currentTimer == TimerType.Productive)
                    dataStore.IncreaseProd();
                else
                    dataStore.DecreaseFree();
            };
        }

        //What it says
        public static void StopTimer() => Dispatcher.Stop();

        //Enables/Disables the FreeTime Timer
        public static void ToggleFreeTime()
        {
            if (Dispatcher.IsRunning && currentTimer == TimerType.FreeTime)
            {
                StopTimer();
                return;
            }

            if (!Dispatcher.IsRunning || Dispatcher.IsRunning && currentTimer != TimerType.FreeTime)
            {
                StartTimer();
                currentTimer = TimerType.FreeTime;
            }
        }

        //Enables/Disables the Productive Timer
        public static void ToggleProductiveTime()
        {
            if (Dispatcher.IsRunning && currentTimer == TimerType.Productive)
            {
                StopTimer();
                return;
            }

            if (!Dispatcher.IsRunning || Dispatcher.IsRunning && currentTimer != TimerType.Productive)
            {
                StartTimer();
                currentTimer = TimerType.Productive;
            }
        }
    }
}

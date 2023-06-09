using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Contractor.Drawables;
using Color = Microsoft.Maui.Graphics.Color;

namespace Contractor.ViewModel
{
    public class RoundProgressBarViewModel : ViewModelBase
    {
        public ClockDrawable MyDrawable { get; }

        public RoundProgressBarViewModel(int i)
        {
            if(i == 1) MyDrawable = new ClockDrawable(1);
            else MyDrawable = new ClockDrawable(2);


            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += (s, e) =>
            {
                MyDrawable.AddDegrees(.5f);
                OnPropertyChanged(nameof(MyDrawable));
            };
            timer.Start();
        }   
    }
}


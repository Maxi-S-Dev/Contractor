using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Utils
{
    public static class DataStore
    {
        private const int eightHours = 28800;

        public static float Factor = 10f;

        private static int prodSeconds = 0;
        public static int ProdSeconds
        {
            get => Preferences.Get("ProdSeconds", 0);
            set
            {
                try
                {
                    Preferences.Set("ProdSeconds", value);
                }
                catch (Exception ex) { Trace.WriteLine(ex); }
            }
        }

        public static int FreeSeconds
        {
            set
            {
                ProdSeconds = ProdSeconds -= Convert.ToInt32(1 * Factor);
            }
            get
            {
                int time = Convert.ToInt32(ProdSeconds / Factor);

                if (time <= MaxFreeTime) return time;

                else return MaxFreeTime;
            }
        }

        public static int MaxProductiveTime { get; set; } = eightHours;

        public static int MaxFreeTime { get; set; } = eightHours;


        public static void IncreaseProd() => ProdSeconds += 1;
        public static void DecreaseFree() => FreeSeconds -= 1;
    }
}

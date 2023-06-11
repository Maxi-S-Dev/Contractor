using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Container
{
    public static class DataStorage
    {
        private const int eightHours = 28800;

        public static float Factor = 1.5f;
        
        public static int ProdSeconds = eightHours;
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
    }
}

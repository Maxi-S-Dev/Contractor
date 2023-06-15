using Contractor.Interfaces;

namespace Contractor.Utils
{
    public class DataStore : IAppData
    {
        private const int eightHours = 28800;

        public float Factor { get; set; } = 1.5f;

        private int prodSeconds = 0;
        public int ProdSeconds
        {
            get => prodSeconds;
            set
            {
                prodSeconds = value;
            }
        }

        public int FreeSeconds
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

        public int MaxProductiveTime { get; set; } = eightHours;

        public int MaxFreeTime { get; set; } = eightHours;


        public void IncreaseProd() => ProdSeconds += 1;
        public void DecreaseFree() => FreeSeconds -= 1;
    }
}

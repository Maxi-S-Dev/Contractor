using Contractor.Interfaces;

namespace Contractor.Services
{
    public class DataStore : IAppData
    {
        private const int eightHours = 28800;

        public float Factor { get; set; } = .5f;

        private int prodSeconds = 0;
        public int ProdSeconds
        {
            get => prodSeconds;
            set
            {
                prodSeconds = value;
            }
        }

        private float freeSeconds;
        public float FreeSeconds
        {
            get => freeSeconds;

            set
            {
                if (value >= MaxFreeTime)
                {
                    freeSeconds = MaxFreeTime;
                    return;
                }
                freeSeconds = value;
            }
        }

        public int MaxProductiveTime { get; set; } = eightHours;

        public int MaxFreeTime { get; set; } = eightHours;


        public void IncreaseProd()
        {
            ProdSeconds += 1;
            FreeSeconds += Factor;
        }
            
        public void DecreaseFree() => FreeSeconds -= 1;
    }
}

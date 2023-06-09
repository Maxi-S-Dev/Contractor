﻿using Contractor.Interfaces;
using System.Diagnostics;

namespace Contractor.Services
{
    public class DataStore : IAppData
    {
        private const int eightHours = 28800;

        public float Factor { get; set; } = .5f;

        private float prodSeconds = 0;
        public float ProdSeconds
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

        public DateTime lastDate { get; set; } = DateTime.Now.Date;


        public void IncreaseProd()
        {
            ProdSeconds += 1;
            FreeSeconds += Factor;
        }
            
        public void DecreaseFree() => FreeSeconds -= 1;
    } 
}

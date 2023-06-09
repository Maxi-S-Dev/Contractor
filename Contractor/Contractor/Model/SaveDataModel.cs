﻿using Contractor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Model
{
    public class SaveDataModel : IAppData
    {
        public float Factor { get; set; }
        public float ProdSeconds { get; set; }

        public int FreeSeconds { get; set; }
        public int MaxProductiveTime { get; set; }
        public int MaxFreeTime { get; set; }

        public DateTime lastDate { get; set; }
    }
}

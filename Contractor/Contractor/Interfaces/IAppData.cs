using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Interfaces
{
    public interface IAppData
    {
        public float Factor { get; set; }

        public  int ProdSeconds { get; set; }
        
        public  int MaxProductiveTime { get; set; }

        public int MaxFreeTime { get; set; }
    }
}

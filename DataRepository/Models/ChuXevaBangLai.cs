using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class ChuXevaBangLai
    {
        public int ChuxeId { get; set; }
        public Chuxe Chuxe { get; set; }

        public int BanglaiId { get; set; }
        public Banglai Banglai { get; set; }
    }
}

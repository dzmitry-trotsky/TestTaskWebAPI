using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public class ShippedByntPassportDto
    {
        public string SmeltingNum { get; set; }
        public string Specification { get; set; }
        public string? Lot { get; set; }
        public string SteelGrade { get; set; }
        public string Profile { get; set; }
        public DateTime WeighingByntTime { get; set; }
        public DateTime ShippedByntTime { get; set; }
        public string? ByntNum { get; set; }
        public string? ByntWeight { get; set; }
    }
}

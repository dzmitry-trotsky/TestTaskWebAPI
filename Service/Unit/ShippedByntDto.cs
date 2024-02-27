using Data.Entities;
using Service.PassportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Unit
{
    public class ShippedByntDto
    {
        public UnitEntity Unit { get; set; }
        public ShippedByntPassportDto Passport { get; set; }
    }
}

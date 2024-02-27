using Data.Entities;
using Service.PassportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Unit
{
    public class IssuedToMillDto
    {
        public IssuedToMillPassportDto Passport { get; set; }

        public UnitEntity Unit { get; set; }
    }
}

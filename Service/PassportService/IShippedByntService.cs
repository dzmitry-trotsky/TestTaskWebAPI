﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public interface IShippedByntService
    {
        ShippedByntPassportDto GetPassportForShippedByntByUnit(long unitId);
    }
}

﻿using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public class ByntWeightPassportService: IByntWeightPassportService
    {
        private readonly IRepositoryBase<PassportEntity> _passportRepository;

        public ByntWeightPassportService(IRepositoryBase<PassportEntity> passportRepository)
        {
            _passportRepository = passportRepository;
        }

        public string? GetByntWeightPassportByUnitId(long unitId)
        {
            return _passportRepository.Collection.Where(_ => _.UnitId == unitId && _.ParamId == 10000132).FirstOrDefault()?.ValueS;
        }
    }
}

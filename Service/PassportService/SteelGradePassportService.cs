using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public class SteelGradePassportService : ISteelGradePassportService
    {
        private readonly IRepositoryBase<PassportEntity> _passportRepository;

        public SteelGradePassportService(IRepositoryBase<PassportEntity> passportRepository)
        {
            _passportRepository = passportRepository;
        }

        public string? GetSteelGradePassportByUnitId(long unitId)
        {
            return _passportRepository.Collection.Where(_ => _.UnitId == unitId && _.ParamId == 10000143).FirstOrDefault()?.ValueS;
        }
    }
}

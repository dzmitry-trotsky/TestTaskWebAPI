using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public class ProfilePassportService: IProfilePassportService
    {
        private readonly IRepositoryBase<PassportEntity> _passportRepository;

        public ProfilePassportService(IRepositoryBase<PassportEntity> passportRepository)
        {
            _passportRepository = passportRepository;
        }

        public string? GetProfilePassportByUnitId(long unitId)
        {
            return _passportRepository.Collection.Where(_ => _.UnitId == unitId && _.ParamId == 10000144).FirstOrDefault()?.ValueS;
        }
    }
}

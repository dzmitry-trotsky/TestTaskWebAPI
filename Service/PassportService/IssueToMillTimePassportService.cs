using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public class IssueToMillTimePassportService: IIssueToMillTimePassportService
    {
        private readonly IRepositoryBase<PassportEntity> _passportRepository;

        public IssueToMillTimePassportService(IRepositoryBase<PassportEntity> passportRepository)
        {
            _passportRepository = passportRepository;
        }

        public string? GetIssueToMillTimePassportByUnitId(long unitId)
        {
            return _passportRepository.Collection.Where(_ => _.UnitId == unitId && _.ParamId == 60006).FirstOrDefault()?.ValueS;
        }

    }
}

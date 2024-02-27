using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public class PassportService : IPassportService
    {
        private readonly IRepositoryBase<PassportEntity> _repo;
        private readonly ISmeltingNumPassportService _smeltingNumPassportService;
        private readonly ISpecificationPassportService _specificationPassportService;
        private readonly ISteelGradePassportService _steelGradePassportService;

        public PassportService(IRepositoryBase<PassportEntity> repo, 
                               ISmeltingNumPassportService smeltingNumPassportService, 
                               ISpecificationPassportService specificationPassportService, 
                               ISteelGradePassportService steelGradePassportService)
        {
            _repo = repo;
            _smeltingNumPassportService = smeltingNumPassportService;
            _specificationPassportService = specificationPassportService;
            _steelGradePassportService = steelGradePassportService;
        }

        public List<PassportEntity> GetAllPassportsByUnit(long unitId)
        {
            return _repo.Collection.Where(_ => _.UnitId == unitId).ToList();
        }

        public List<SmeltingNumUnitPassportDto> GetPassportsBySmeltingNum(string smeltingNum)
        {
            List<SmeltingNumUnitPassportDto> result = new List<SmeltingNumUnitPassportDto>();

            var units = _repo.Collection.Where(_ => _.ParamId == 10000001 && _.ValueS ==  smeltingNum).ToList();

            foreach ( var unit in units )
            {
                SmeltingNumUnitPassportDto smeltingNumUnitPassportDto = new SmeltingNumUnitPassportDto();
                smeltingNumUnitPassportDto.SmeltingNum = smeltingNum;

                var specificationRes = _specificationPassportService.GetSpecificationPassportByUnitId(unit.Id);
                if (specificationRes != null) smeltingNumUnitPassportDto.Specification = specificationRes;

                var steelGradeRes = _steelGradePassportService.GetSteelGradePassportByUnitId(unit.Id);
                if (steelGradeRes != null) smeltingNumUnitPassportDto.SteelGrade = steelGradeRes;

                result.Add(smeltingNumUnitPassportDto);
            }

            return result;
        }
    }
}

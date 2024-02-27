using Data.Entities;
using System;

namespace Service.PassportService
{
    public class ShippedByntService : IShippedByntService
    {
        private readonly IByntNumPassportService _byntNumPassportService;
        private readonly IByntWeightPassportService _byntWeightPassportService;
        private readonly IProfilePassportService _profilePassportService;
        private readonly ISmeltingNumPassportService _smeltingNumPassportService;
        private readonly ISpecificationPassportService _specificationPassportService;
        private readonly ISteelGradePassportService _steelGradePassportService;
        private readonly IWeighingByntTimePassportService _weighingByntTimePassportService;

        public ShippedByntService(IByntNumPassportService byntNumPassportService, 
                                  IByntWeightPassportService byntWeightPassportService,
                                  IProfilePassportService profilePassportService,
                                  ISmeltingNumPassportService smeltingNumPassportService,
                                  ISpecificationPassportService specificationPassportService,
                                  ISteelGradePassportService steelGradePassportService,
                                  IWeighingByntTimePassportService weighingByntTimePassportService)
        {
            _byntNumPassportService = byntNumPassportService;
            _byntWeightPassportService = byntWeightPassportService;
            _profilePassportService = profilePassportService;
            _smeltingNumPassportService = smeltingNumPassportService;
            _specificationPassportService = specificationPassportService;
            _steelGradePassportService = steelGradePassportService;
            _weighingByntTimePassportService = weighingByntTimePassportService;
        }

        public ShippedByntPassportDto GetPassportForShippedByntByUnit(long unitId)
        {
            var passport = new ShippedByntPassportDto();

            var byntNumRes = _byntNumPassportService.GetByntNumPassportByUnitId(unitId);
            if (byntNumRes != null) passport.ByntNum = byntNumRes;

            var byntWeightRes = _byntWeightPassportService.GetByntWeightPassportByUnitId(unitId);
            if (byntWeightRes != null) passport.ByntWeight = byntWeightRes;

            var profileRes = _profilePassportService.GetProfilePassportByUnitId(unitId);
            if (profileRes != null) passport.Profile = profileRes;

            var smeltingNumRes = _smeltingNumPassportService.GetSeltingNumPassportByUnitId(unitId);
            if (smeltingNumRes != null) passport.SmeltingNum = smeltingNumRes;

            var specificationRes = _specificationPassportService.GetSpecificationPassportByUnitId(unitId);
            if (specificationRes != null) passport.Specification = specificationRes;

            var steelGradeRes = _steelGradePassportService.GetSteelGradePassportByUnitId(unitId);
            if (steelGradeRes != null) passport.SteelGrade = steelGradeRes;

            var weighingByntTimeRes = _weighingByntTimePassportService.GetWeighingByntTimeByUnitId(unitId);
            if (weighingByntTimeRes != null) passport.WeighingByntTime = weighingByntTimeRes.Value;
            return passport;
        }
    }
}

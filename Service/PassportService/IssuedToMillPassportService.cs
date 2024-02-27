using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportService
{
    public class IssuedToMillPassportService : IIssuedToMillPassportService
    {

        private readonly IByntNumPassportService _byntNumPassportService;
        private readonly IByntWeightPassportService _byntWeightPassportService;
        private readonly IIssueToMillTimePassportService _issueToMillTimePassportService;
        private readonly IProfilePassportService _profilePassportService;
        private readonly ISmeltingNumPassportService _smeltingNumPassportService;
        private readonly ISpecificationPassportService _specificationPassportService;
        private readonly ISteelGradePassportService _steelGradePassportService;
        private readonly IWorkpieceNumPassportService _workpieceNumPassportService;
        private readonly IWorkpieceWeightPassportService _workpieceWeightPassportService;

        public IssuedToMillPassportService(IByntNumPassportService byntNumPassportService, 
                                           IByntWeightPassportService byntWeightPassportService, 
                                           IIssueToMillTimePassportService issueToMillTimePassportService, 
                                           IProfilePassportService profilePassportService, 
                                           ISmeltingNumPassportService smeltingNumPassportService, 
                                           ISpecificationPassportService specificationPassportService, 
                                           ISteelGradePassportService steelGradePassportService, 
                                           IWorkpieceNumPassportService workpieceNumPassportService, 
                                           IWorkpieceWeightPassportService workpieceWeightPassportService)
        {
            _byntNumPassportService = byntNumPassportService;
            _byntWeightPassportService = byntWeightPassportService;
            _issueToMillTimePassportService = issueToMillTimePassportService;
            _profilePassportService = profilePassportService;
            _smeltingNumPassportService = smeltingNumPassportService;
            _specificationPassportService = specificationPassportService;
            _steelGradePassportService = steelGradePassportService;
            _workpieceNumPassportService = workpieceNumPassportService;
            _workpieceWeightPassportService = workpieceWeightPassportService;
        }

        public IssuedToMillPassportDto GetPassportForIssuedToMillByUnit(long unitId)
        {
            var passport = new IssuedToMillPassportDto();

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

            var workpieceNumRes = _workpieceNumPassportService.GetWorkpieceNumPassportByUnitId(unitId);
            if (workpieceNumRes != null) passport.WorkpieceNum = workpieceNumRes;

            var workpieceWeightRes = _workpieceWeightPassportService.GetWorkpieceWeightPassportByUnitId(unitId);
            if (workpieceWeightRes != null) passport.WorkpieceWeight = workpieceWeightRes;

            return passport;
        }
    }
}

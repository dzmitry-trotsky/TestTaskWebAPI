using AutoMapper;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Service.PassportParams;
using Service.PassportService;
using Service.Unit.GrouppedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Unit
{
    public class UnitService : IUnitService
    {
        private readonly IRepositoryBase<LocationEntity> _locationRepository;
        private readonly IIssuedToMillPassportService _issuedToMillPassportService;
        private readonly IShippedByntService _shippedByntService;
        private readonly IPassportService _passportService;

        public UnitService(IRepositoryBase<LocationEntity> locationRepository, 
                           IIssuedToMillPassportService issuedToMillPassportService,
                           IShippedByntService shippedByntService,
                           IPassportService passportService)
        {
            _locationRepository = locationRepository;
            _issuedToMillPassportService = issuedToMillPassportService;
            _shippedByntService = shippedByntService;
            _passportService = passportService;
        }

        public IEnumerable<IssuedToMillDto> GetIssuedToMillByPeriod(DateTime from, DateTime to)
        {
            var result = new List<IssuedToMillDto>();

            var res = _locationRepository.Collection.Where(_ => _.Node.NodeCode == "Вход в стан и 1 клеть" 
                                                                && _.TmBeg >= from
                                                                && _.TmEnd <= to)
                                                                .Select(_ => new { Unitt = _.Unit, TmBegin = _.TmBeg }).ToList();
            foreach (var item in res)
            {
                IssuedToMillDto issuedToMillDto = new IssuedToMillDto() { Unit = item.Unitt };
                var issuedToMillPassportDto = _issuedToMillPassportService.GetPassportForIssuedToMillByUnit(item.Unitt.Id);
                issuedToMillPassportDto.IssuedToMillStan = item.TmBegin;
                issuedToMillDto.Passport = issuedToMillPassportDto;
                result.Add(issuedToMillDto);
            }

            return result;
        }
        public IEnumerable<ShippedByntDto> GetShippedByntByPeriod(DateTime from, DateTime to)
        {
            var result = new List<ShippedByntDto>();

            var res = _locationRepository.Collection.Where(_ => _.Node.NodeCode == "Отгрузка бунта"
                                                                && _.TmBeg >= from
                                                                && _.TmEnd <= to)
                                                                .Select(_ => new {Unitt = _.Unit, TmBegin = _.TmBeg}).ToList();
            foreach(var item in res)
            {
                ShippedByntDto shippedByntDto = new ShippedByntDto() { Unit = item.Unitt};
                var shippedByntPassportDto = _shippedByntService.GetPassportForShippedByntByUnit(item.Unitt.Id);
                shippedByntPassportDto.ShippedByntTime = item.TmBegin;

                shippedByntDto.Passport = shippedByntPassportDto;
                result.Add(shippedByntDto);
            }

            return result;
        }
        public IEnumerable<BaseGrouppedModel> GetGroupedShippedByntByPeriod(DateTime from, DateTime to, string groupBy)
        {
            var result = new List<ShippedByntDto>();

            var res = _locationRepository.Collection.Where(_ => _.Node.NodeCode == "Отгрузка бунта"
                                                                && _.TmBeg >= from
                                                                && _.TmEnd <= to)
                                                                .Select(_ => new {Unitt = _.Unit, TmBegin = _.TmBeg}).ToList();
            foreach(var item in res)
            {
                ShippedByntDto shippedByntDto = new ShippedByntDto() { Unit = item.Unitt};
                var shippedByntPassportDto = _shippedByntService.GetPassportForShippedByntByUnit(item.Unitt.Id);
                shippedByntPassportDto.ShippedByntTime = item.TmBegin;

                shippedByntDto.Passport = shippedByntPassportDto;
                result.Add(shippedByntDto);
            }

            IEnumerable<BaseGrouppedModel> model = new List<BaseGrouppedModel>();

            if (groupBy == "smelting_num")
                model = result.GroupBy(_ => _.Passport.SmeltingNum, _ => _, 
                        (key, g) => new GrouppedShippedByntBySmeltingNumModel() { SmeltingNum = key, Units = g.ToList() });

            else if (groupBy == "specification")
                model = result.GroupBy(_ => _.Passport.Specification, _ => _,
                        (key, g) => new GrouppedShippedByntBySpecificationModel() { Specification = key, Units = g.ToList() });

            else if (groupBy == "steel_grade")
                model = result.GroupBy(_ => _.Passport.SteelGrade, _ => _,
                        (key, g) => new GrouppedShippedByntBySteelGradeModel() { SteelGrade = key, Units = g.ToList() });

            return model;

        }

        public IEnumerable<BaseCountGrouppedModel> GetUnitCountBySmeltingNum(string smeltingNum, string groupBy)
        {
            var result = _passportService.GetPassportsBySmeltingNum(smeltingNum);

            IEnumerable<BaseCountGrouppedModel> model = new List<BaseCountGrouppedModel>();

            if (groupBy == "specification")
                model = result.GroupBy(_ => _.Specification).Select(group =>
                                new BaseCountGrouppedModel() { Count = group.Count(), Key = group.Key }).ToList();

            else if (groupBy == "steel_grade")
                model = result.GroupBy(_ => _.SteelGrade).Select(group =>
                                new BaseCountGrouppedModel() { Count = group.Count(), Key = group.Key }).ToList();

            return model;
        }

    }
}

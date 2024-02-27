using AutoMapper;
using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service.PassportParams
{
    public class PassportParamsService: IPassportParamsService
    {
        private readonly IRepositoryBase<PassportParamEntity> _passportParamRepository;

        private readonly string[] IssuedToMillNames = new string[10]
        {
            "Номер плавки",
            "Спецификация",
            "Лот",
            "Марка стали",
            "Профиль",
            "Номер заготовки внутри плавки по входу в печь",
            "Вес заготовки",
            "Начало выдачи",
            "Номер бунта",
            "Вес бунтов"
        };

        public PassportParamsService(IRepositoryBase<PassportParamEntity> passportParamRepository)
        {
            _passportParamRepository = passportParamRepository;
        }

        public List<long> GetIssuedToMillPassportParam()
        {
            var baseResult = _passportParamRepository.Collection
                                .Where(_ => IssuedToMillNames.Contains(_.ParamName)).Select(_ => _.Id);
            return baseResult.ToList();
        }
    }
}

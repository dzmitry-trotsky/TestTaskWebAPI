using Service.PassportService;
using Service.Unit.GrouppedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Unit
{
    public interface IUnitService
    {
        IEnumerable<IssuedToMillDto> GetIssuedToMillByPeriod(DateTime from, DateTime to);
        IEnumerable<ShippedByntDto> GetShippedByntByPeriod(DateTime from, DateTime to);
        IEnumerable<BaseGrouppedModel> GetGroupedShippedByntByPeriod(DateTime from, DateTime to, string groupBy);
        IEnumerable<BaseCountGrouppedModel> GetUnitCountBySmeltingNum(string smeltingNum, string groupBy);
    }
}

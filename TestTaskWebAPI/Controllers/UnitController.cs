using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Unit;

namespace TestTaskWebAPI.Controllers
{
    [Route("api/unit")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        public readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet("issuedToMill")]
        public IActionResult GetIssuedToMill(DateTime from, DateTime to)
        {

            var result = _unitService.GetIssuedToMillByPeriod(from, to);

            return Ok(result);
        }

        [HttpGet("shippedBynt")]
        public IActionResult GetShippedBynt(DateTime from, DateTime to)
        {

            var result = _unitService.GetShippedByntByPeriod(from, to);

            return Ok(result);
        }

        [HttpGet("grouppedShippedBynt")]
        public IActionResult GetGroupedShippedByntByPeriod(DateTime from, DateTime to, string groupBy)
        {

            var result = _unitService.GetGroupedShippedByntByPeriod(from, to, groupBy);

            return Ok(result);
        }

        [HttpGet("unitCountBySmeltingNum")]
        public IActionResult GetUnitCountBySmeltingNum(string smeltingNum, string groupBy)
        {

            var result = _unitService.GetUnitCountBySmeltingNum(smeltingNum, groupBy);

            return Ok(result);
        }

    }
}

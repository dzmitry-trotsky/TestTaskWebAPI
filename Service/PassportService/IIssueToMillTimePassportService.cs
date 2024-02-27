using Data.Entities;

namespace Service.PassportService
{
    public interface IIssueToMillTimePassportService
    {
        public string? GetIssueToMillTimePassportByUnitId(long unitId);
    }
}
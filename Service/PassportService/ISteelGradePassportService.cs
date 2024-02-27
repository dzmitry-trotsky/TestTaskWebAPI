using Data.Entities;

namespace Service.PassportService
{
    public interface ISteelGradePassportService
    {
        public string? GetSteelGradePassportByUnitId(long unitId);
    }
}
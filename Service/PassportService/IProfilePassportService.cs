using Data.Entities;

namespace Service.PassportService
{
    public interface IProfilePassportService
    {
        public string? GetProfilePassportByUnitId(long unitId);
    }
}
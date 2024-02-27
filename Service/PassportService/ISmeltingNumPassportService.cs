using Data.Entities;

namespace Service.PassportService
{
    public interface ISmeltingNumPassportService
    {
        public string? GetSeltingNumPassportByUnitId(long unitId);
    }
}
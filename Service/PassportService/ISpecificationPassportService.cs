using Data.Entities;

namespace Service.PassportService
{
    public interface ISpecificationPassportService
    {
        public string? GetSpecificationPassportByUnitId(long unitId);
    }
}
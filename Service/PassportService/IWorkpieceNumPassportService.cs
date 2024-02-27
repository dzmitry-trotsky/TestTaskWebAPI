using Data.Entities;

namespace Service.PassportService
{
    public interface IWorkpieceNumPassportService
    {
        public string? GetWorkpieceNumPassportByUnitId(long unitId);
    }
}
using Data.Entities;

namespace Service.PassportService
{
    public interface IWorkpieceWeightPassportService
    {
        public string? GetWorkpieceWeightPassportByUnitId(long unitId);
    }
}
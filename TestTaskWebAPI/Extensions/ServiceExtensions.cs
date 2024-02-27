using Data.Configuration;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.PassportParams;
using Service.PassportService;
using Service.Unit;
using ThreadEntity = Data.Entities.ThreadEntity;

namespace TestTaskWebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MtsbaseContext>(options => options.UseSqlite(configuration.GetSection("SqlliteOptions:ConnectionString").Value));
        }
        public static void ConfigureSqlOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlliteOptions>(configuration.GetSection("SqlliteOptions"));
        }
        public static void ConfigureReposiories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryBase<LocationEntity>, RepositoryBase<LocationEntity>>();
            services.AddTransient<IRepositoryBase<NodeEntity>, RepositoryBase<NodeEntity>>();
            services.AddTransient<IRepositoryBase<PassportEntity>, RepositoryBase<PassportEntity>>();
            services.AddTransient<IRepositoryBase<PassportParamEntity>, RepositoryBase<PassportParamEntity>>();
            services.AddTransient<IRepositoryBase<ThreadEntity>, RepositoryBase<ThreadEntity>>();
            services.AddTransient<IRepositoryBase<UnitEntity>, RepositoryBase<UnitEntity>>();
            services.AddTransient<IRepositoryBase<UnitsRelationEntity>, RepositoryBase<UnitsRelationEntity>>();
            services.AddTransient<IRepositoryBase<UnitTypeEntity>, RepositoryBase<UnitTypeEntity>>();
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitService, UnitService>();
            services.AddTransient<IPassportParamsService, PassportParamsService>();
            services.AddTransient<IPassportService, PassportService>();

            services.AddTransient<IByntNumPassportService, ByntNumPassportService>();
            services.AddTransient<IByntWeightPassportService, ByntWeightPassportService>();
            services.AddTransient<IIssueToMillTimePassportService, IssueToMillTimePassportService>();
            services.AddTransient<IProfilePassportService, ProfilePassportService>();
            services.AddTransient<ISmeltingNumPassportService, SmeltingNumPassportService>();
            services.AddTransient<ISpecificationPassportService, SpecificationPassportService>();
            services.AddTransient<ISteelGradePassportService, SteelGradePassportService>();
            services.AddTransient<IWorkpieceNumPassportService, WorkpieceNumPassportService>();
            services.AddTransient<IWorkpieceWeightPassportService, WorkpieceWeightPassportService>();
            services.AddTransient<IWeighingByntTimePassportService, WeighingByntTimePassportService>();

            services.AddTransient<IIssuedToMillPassportService, IssuedToMillPassportService>();
            services.AddTransient<IShippedByntService, ShippedByntService>();
        }
    }
}

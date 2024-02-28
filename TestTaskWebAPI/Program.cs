using Service.PassportParams;
using Service.Unit;
using TestTaskWebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

builder.Services.ConfigureSqlOptions(builder.Configuration);

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureReposiories();
builder.Services.ConfigureServices();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

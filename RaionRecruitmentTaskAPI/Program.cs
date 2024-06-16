using RaionRecruitmentTaskInfrastructure;
using RaionRecruitmentTaskInfrastructure.Seeders;
using RaionRecruitmentTaskApplication;
using RaionRecruitmentTaskAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRaionRecruitmentTaskSeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();



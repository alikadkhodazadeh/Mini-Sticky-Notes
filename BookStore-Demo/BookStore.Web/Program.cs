var builder = WebApplication.CreateBuilder(args);

#region Services Collection
var services = builder.Services;

builder.Configuration.AddAppSettings();

services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<EFContext>()
    .AddDefaultTokenProviders();

services.AddDbContext<EFContext>(options =>
{
    options.UseSqlServer(AppSettingExtentions.DatabaseConnection);
});
#endregion

#region Middleware
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion

using StickyNotes.Helper;

var builder = WebApplication.CreateBuilder(args);

#region Services
var services = builder.Services;

services.AddSingleton<IDatabaseConnection, DatabaseConnection>();

services.AddControllers()
    .AddJsonOptions(options=>options.JsonSerializerOptions.WriteIndented = true);
#endregion

#region Middleware
var app = builder.Build();

app.MapDefaultControllerRoute();
app.Run();
#endregion

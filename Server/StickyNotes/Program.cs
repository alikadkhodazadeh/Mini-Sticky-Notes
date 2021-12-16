using StickyNotes.Helper;

var builder = WebApplication.CreateBuilder(args);

#region Services
var services = builder.Services;

services.AddSingleton<IDatabaseConnection, DatabaseConnection>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

services.AddControllers()
    .AddJsonOptions(options=>options.JsonSerializerOptions.WriteIndented = true);
#endregion

#region Middleware
var app = builder.Build();

app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.MapDefaultControllerRoute();
app.Run();
#endregion

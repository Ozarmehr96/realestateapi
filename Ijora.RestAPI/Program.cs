using Ijora.Data.Infrastructure;
using Ijora.Domain.Infrastructure;
using Ijora.RestAPI.Middleware;
using Ijora.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Formatting = Formatting.Indented;
});
services.AddMediatR(opt => opt.AsSingleton(), typeof(IRepository).Assembly);
services.AddSingleton<IRepositoryProvider, RepositoryProvider>();

builder.Services.AddDbContext<IjoraServiceContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
    options.UseMySQL(connectionString, o =>
    {
        o.CommandTimeout(180);
        o.MigrationsAssembly("Ijora.RestAPI");
    });
});
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IjoraServiceContext>();
    dbContext.Database.Migrate();
    // Add-Migration DBInit 
    // Update-Database
}

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = "swagger"; // Делает Swagger UI доступным по корню URL
});
//}

// Configure the HTTP request pipeline.
app.UseMiddleware<ApiExceptionMiddleware>();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

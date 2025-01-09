using Ijora.Data.Infrastructure;
using Ijora.Domain.Infrastructure;
using Ijora.RestAPI.Middleware;
using Ijora.Storage;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers();
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

var app = builder.Build();
app.UseMiddleware<ApiExceptionMiddleware>();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IjoraServiceContext>();
    dbContext.Database.Migrate();
    // Add-Migration DBInit
}
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

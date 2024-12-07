using DrugsBot.Infrastructure.Dal.EntityFramework;
using DrugsBot.Infrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DataBaseSettings>(builder.Configuration.GetSection(nameof(DataBaseSettings)));

builder.Services.AddDbContext<DrugBotDbContext>((serviceProvider, options) =>
{
    var dataBaseSettings = serviceProvider.GetRequiredService<IOptions<DataBaseSettings>>().Value;
    
    options.UseNpgsql(dataBaseSettings.ConnectionStrings, npgsqlOptions =>
    {
        npgsqlOptions.CommandTimeout(dataBaseSettings.CommandTimeout);
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
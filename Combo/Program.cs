using Combo;
using Combo.Database;
using Combo.Features;
using Combo.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.BindAppSettings(out var appSettings);

builder.ConfigureLogging(out var logger);

builder.Services.AddComboContext(appSettings);

builder.Services.AddFeatureServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

logger.Information("Запуск сервера");
app.Run();

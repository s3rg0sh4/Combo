using Carter;

using Combo;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddCarter();

builder.Services.AddOptions<AppSettings>().BindConfiguration(AppSettings.SectionName);
var applicationSettings = new AppSettings();
builder.Configuration.GetSection(AppSettings.SectionName).Bind(applicationSettings);

builder.Services.AddDbContext<Combo.Database.ComboContext>(db 
	=> db.UseNpgsql(applicationSettings.ConnectionStrings.Postgres));

builder.Services.AddScoped<Combo.Features.Waybills.WaybillService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapCarter();
app.MapControllers();
app.Run();

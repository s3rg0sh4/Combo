using Carter;

using Combo;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddCarter();

builder.Services.AddOptions<AppSettings>().BindConfiguration(AppSettings.SectionName);
var applicationSettings = new AppSettings();
builder.Configuration.GetSection(AppSettings.SectionName).Bind(applicationSettings);

builder.Services.AddDbContext<Combo.Database.ComboContext>();

//builder.Services.AddScoped<Combo.Features.Waybills.WaybillService>();

var app = builder.Build();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

app.MapCarter();
app.Run();

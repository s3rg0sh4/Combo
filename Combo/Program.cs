using Combo;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddOptions<AppSettings>().BindConfiguration(AppSettings.SectionName);
var applicationSettings = new AppSettings();
builder.Configuration.GetSection(AppSettings.SectionName).Bind(applicationSettings);

builder.Services.AddDbContext<Combo.Database.ComboContext>(db 
	=> db.UseNpgsql(applicationSettings.ConnectionStrings.Postgres));

builder.Services.AddScoped<Combo.Features.Waybills.WaybillService>();
builder.Services.AddScoped<Combo.Features.Orders.OrderService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
	options.InputFormatters.Insert(0, JsonPatchInputFormatter.GetFormatter());
});

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();

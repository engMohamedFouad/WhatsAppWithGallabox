using WhatsAppWithGallabox.Helpers;
using WhatsAppWithGallabox.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<WhatsAppService>();
WhatsAppSettings whatsAppSettings = new WhatsAppSettings();
builder.Configuration.GetSection(nameof(whatsAppSettings)).Bind(whatsAppSettings);
builder.Services.AddSingleton(whatsAppSettings);
builder.Services.AddTransient<IWhatsAppService, WhatsAppService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

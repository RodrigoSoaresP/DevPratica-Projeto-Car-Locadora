using AspNetCoreRateLimit;
using CarLocadora.API.Extensoes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurarServicos();
builder.Services.ConfigurarJWT();
builder.Services.ConfigurarSwagger();

builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseIpRateLimiting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

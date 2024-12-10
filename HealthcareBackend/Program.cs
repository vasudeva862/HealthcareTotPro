using HealthCareTestingLabPortel.Models;
using HealthCareTestingLabPortel.Services;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;



var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<HealthCareDatabaseSettings>(
    builder.Configuration.GetSection(nameof(HealthCareDatabaseSettings)));

builder.Services.AddSingleton<IHealthCareDatabaseSettings>(
    hc => hc.GetRequiredService<IOptions<HealthCareDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(
    s => new MongoClient(builder.Configuration.GetValue<string>("HealthCareDatabaseSettings:ConnectionString")));



builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IUserRoleService, UserRoleServices>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IDiagnosisService, DiagnosisService>();
builder.Services.AddScoped<ILabDetailService, LabDetailServices>();
builder.Services.AddScoped<IUserDetailsService, UserDetailsService>();
builder.Services.AddCors(o => o.AddPolicy("corsApi", builder => {builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));




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
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("corsApi");

app.UseAuthorization();

app.MapControllers();

app.Run();

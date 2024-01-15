using EWS.API.Repositories;
using EWS.API.Services;
using Microsoft.EntityFrameworkCore;
using EWS.API.Entities;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStringsDev"));
builder.Services.AddDbContext<EWSDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<T_MsEwsRepository>();
builder.Services.AddScoped<T_MsEwsServices>();


builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

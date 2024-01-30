using EWS.API.Services;
using EWS.API.Entities;
using EWS.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStringsDev"));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<EWSDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<T_MsEwsRepository>();
builder.Services.AddScoped<T_MsEwsServices>();


builder.RegisterAutoMapper();


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
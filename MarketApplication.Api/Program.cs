
using AutoMapper;
using MarketApplication.Core.Mapping;
using MarketApplication.Core.Services;
using MarketApplication.EF;
using MarketApplication.EF.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

int DBCommandTimeout = builder.Configuration.GetValue<int?>("DBCommandTimeout") ?? 300;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{ options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"),
    opts=>opts.CommandTimeout(DBCommandTimeout));
});

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

var MappingConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
IMapper automapper = MappingConfig.CreateMapper();
builder.Services.AddSingleton(automapper);


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

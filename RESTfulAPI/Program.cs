using Microsoft.EntityFrameworkCore;
using RESTfulAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServersContext>(ConfigureApplicationContextOptions); 
builder.Services.AddDbContext<ChannelsContext>(ConfigureApplicationContextOptions);
builder.Services.AddScoped<IServersGateway, ServersGateway>();
var app = builder.Build();

builder.Configuration.GetConnectionString("Database");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.Run();

void ConfigureApplicationContextOptions(DbContextOptionsBuilder options)
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Database"));
}
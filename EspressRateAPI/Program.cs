using Microsoft.EntityFrameworkCore;
using EspressRateAPI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IEspressoRepository, EspressoRepository>();
builder.Services.AddDbContext<EspressoContext>(opt =>
        opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Initial Catalog=EspressoRate; Integrated Security=true;")
        );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

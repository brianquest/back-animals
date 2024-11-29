using animals.Models;
using animals.Services;
using animals.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSqlServer<animalsContext>(
        builder.Configuration.GetConnectionString("DefaultConnection"),
    options => options.EnableRetryOnFailure()   
);

builder.Services.AddScoped<ISpecieService, SpecieService>(); // Instancio la clase SpecieService para todo el programa 
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Cambia al puerto de tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();

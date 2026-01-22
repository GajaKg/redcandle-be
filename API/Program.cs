using API.Interfaces;
using API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<API.Data.ApplicationDBContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("WebApiDatabase")
    )
);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200",
                               "https://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials(); // Optional, if using cookies/auth
        });
});



builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "redcandle API", Version = "v1" });
});
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularLocalhost");
app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using ShopOnline.WebAPI.Data;
using ShopOnline.WebAPI.Repositories;
using ShopOnline.WebAPI.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<ShopOnlineDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:5232", "https://localhost:5232")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

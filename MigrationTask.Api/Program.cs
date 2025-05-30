
using Microsoft.EntityFrameworkCore;
using Migration_Task.Data;
using MigrationTask.DAL.IRepositories;
using MigrationTask.DAL.Repositories;
using MigrationTask.BLL.Interfaces;
using MigrationTask.BLL.Services;
using MigrationTask.BLL.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();

builder.Services.AddDbContext<MigrationTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MTConnectionString")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddLogging();



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

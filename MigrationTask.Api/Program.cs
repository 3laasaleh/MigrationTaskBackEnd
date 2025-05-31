
using Microsoft.EntityFrameworkCore;
using Migration_Task.Data;
using MigrationTask.DAL.IRepositories;
using MigrationTask.DAL.Repositories;
using MigrationTask.BLL.Interfaces;
using MigrationTask.BLL.Services;
using MigrationTask.BLL.Mapper;
using MigrationTask.BLL.Dtos;
using Microsoft.AspNetCore.Identity;
using MigrationTask.Data.IdentityContext;
using Migration_Task.Confiqurations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();

builder.Services.AddDbContext<MigrationTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MTConnectionString")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnectionString")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // ?? Add JWT auth to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token in this format: Bearer {your token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddJwtIdentityConfig(builder.Configuration);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped(typeof(IGenericResponse<>), typeof(GenericResponse<>));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddLogging();
builder.Services.AddCrosConfiguration();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("*");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

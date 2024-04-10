using CycleAPI.Application.Repositories;
using CycleAPI.Application.Services;
using CycleAPI.infrastructure.Auth;
using CycleAPI.infrastructure.dbContext;
using CycleAPI.infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Registrar la configuraci�n
ConfigurationManager configuration = builder.Configuration;

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Agregar servicios de base de datos
builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseSqlServer(
    configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("CycleAPI")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Agregar SwaggerGen para la generaci�n de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    // Agregar definici�n de seguridad para la autenticaci�n con clave de API
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        Name = "X-API-Key",
        In = ParameterLocation.Header,
        Description = "Autenticaci�n con clave de API"
    });

    // Agregar requisitos de seguridad para la autenticaci�n con clave de API
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new List<string>()
        }
    });

    // Incluir comentarios XML para la documentaci�n
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
});

// Registrar servicios de autenticaci�n
builder.Services.AddSingleton<ApiAuthorizationFilter>();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

// Configurar pol�tica CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Construir la aplicaci�n
var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");

        // Habilitar autenticaci�n en Swagger UI
        c.DefaultModelsExpandDepth(-1); // Evitar expandir todos los modelos por defecto
    });
}

// Usar CORS
app.UseCors("AllowAll");

// Usar autorizaci�n y mapear controladores
app.UseAuthorization();
app.MapControllers();
app.Run();

using LoadSentinel.Data;
using LoadSentinel.Services;
using Microsoft.EntityFrameworkCore;
using LoadSentinel.Exceptions;
var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURATION DES SERVICES (Le conteneur IoC)

// AJOUT CRUCIAL : Indique à l'app d'aller chercher tes classes [ApiController] dans le dossier Controllers
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", poilicyBuilder =>
    {
        poilicyBuilder.WithOrigins("http://localhost:5173", "http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration de la base de données
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LoadSentinelDbContext>(options =>
    options.UseSqlServer(connectionString));

// Injection de ton service (Scoped est parfait pour les services qui utilisent un DbContext)
builder.Services.AddScoped<ITestRunService, TestRunService>();
builder.Services.AddScoped<IScenarioService, ScenarioService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// 2. CONFIGURATION DU PIPELINE HTTP (Middleware)

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseCors("AllowReactApp");
// Sécurité de base
app.UseAuthorization();

// 3. MAPPING DES ROUTES
// C'est cette ligne qui fait le lien entre l'URL /api/TestRun et ta classe TestRunController
app.MapControllers(); 

app.Run();
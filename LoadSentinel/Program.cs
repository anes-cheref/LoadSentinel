using LoadSentinel.Data;
using LoadSentinel.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURATION DES SERVICES (Le conteneur IoC)

// AJOUT CRUCIAL : Indique à l'app d'aller chercher tes classes [ApiController] dans le dossier Controllers
builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration de la base de données
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LoadSentinelDbContext>(options =>
    options.UseSqlServer(connectionString));

// Injection de ton service (Scoped est parfait pour les services qui utilisent un DbContext)
builder.Services.AddScoped<ITestRunService, TestRunService>();

var app = builder.Build();

// 2. CONFIGURATION DU PIPELINE HTTP (Middleware)

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Sécurité de base
app.UseAuthorization();

// 3. MAPPING DES ROUTES
// C'est cette ligne qui fait le lien entre l'URL /api/TestRun et ta classe TestRunController
app.MapControllers(); 

app.Run();
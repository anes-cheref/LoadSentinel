using LoadSentinel.Data;
using LoadSentinel.DTOs;
using LoadSentinel.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadSentinel.Services;

public class ScenarioService : IScenarioService
{
    LoadSentinelDbContext _context;
    
    public ScenarioService(LoadSentinelDbContext context)
    {
        _context = context;
    }
    public async Task AddScenarioAsync(CreateScenarioDto createScenarioDto)
    {
        var scenario = new Scenario
        {
            Name = createScenarioDto.Name,
            ThreshholdMaxResponseTimeMs = createScenarioDto.ThreshholdMaxResponseTimeMs,
        };
        _context.Scenario.Add(scenario);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Scenario>> GetAllScenariosAsync()
    {
        return await _context.Scenario.ToListAsync();
    }
}
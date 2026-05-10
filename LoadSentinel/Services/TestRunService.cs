using LoadSentinel.Data;
using LoadSentinel.DTOs;
using LoadSentinel.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadSentinel.Services;

public class TestRunService : ITestRunService
{
    private readonly LoadSentinelDbContext _context;
    
    public TestRunService(LoadSentinelDbContext context)
    {
        _context = context;
    }
    
    public async Task AddTestRunAsync(CreateTestRunDto createTestRunDto)
    {
        var scenario = await _context.Scenario.FindAsync(createTestRunDto.ScenarioId);
        if (scenario == null)
        {
            throw new KeyNotFoundException($"Le scénario avec l'ID {createTestRunDto.ScenarioId} n'existe pas.");
        }
        var testRun = new TestRun
        {
            ScenarioId = createTestRunDto.ScenarioId,
            VirtualUsersCount = createTestRunDto.VirtualUserCount,
            AverageResponseTime =  createTestRunDto.AverageResponseTime,
            
            ExecutionDate =  DateTime.UtcNow,
            IsSuccess = createTestRunDto.AverageResponseTime <= scenario.ThreshholdMaxResponseTimeMs
        };
        
        _context.TestRuns.Add(testRun);
        
        await _context.SaveChangesAsync();
    }

    public async Task<List<TestRunResponseDto>> GetAllTestRunsAsync()
    {
        return await _context.TestRuns
            .Include(t => t.Scenario) 
            .Select(t => new TestRunResponseDto 
            {
                Id = t.Id,
                ExecutionDate = t.ExecutionDate,
                VirtualUsersCount = t.VirtualUsersCount,
                AverageResponseTime = t.AverageResponseTime,
                IsSuccess = t.IsSuccess,
                ScenarioName = t.Scenario != null ? t.Scenario.Name : "Inconnu"
            })
            .ToListAsync();
    }
}
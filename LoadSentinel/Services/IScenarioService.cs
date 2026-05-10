using LoadSentinel.DTOs;
using LoadSentinel.Models;
namespace LoadSentinel.Services;

public interface IScenarioService
{
    public Task AddScenarioAsync(CreateScenarioDto createScenarioDto);
    public Task<List<Scenario>> GetAllScenariosAsync();
    
}
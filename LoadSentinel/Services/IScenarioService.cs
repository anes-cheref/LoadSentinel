using LoadSentinel.DTOs;
using LoadSentinel.Models;
namespace LoadSentinel.Services;

public interface IScenarioService
{
    public Task<Scenario> AddScenarioAsync(CreateScenarioDto createScenarioDto);
    public Task<List<Scenario>> GetAllScenariosAsync();

    Task<Scenario> GetByIdAsync(int id);
}
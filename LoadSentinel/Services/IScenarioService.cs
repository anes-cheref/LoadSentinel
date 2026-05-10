using LoadSentinel.DTOs;

namespace LoadSentinel.Services;

public interface IScenarioService
{
    public Task AddScenarioAsync(CreateScenarioDto createScenarioDto);
}
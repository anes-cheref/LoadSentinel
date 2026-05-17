using LoadSentinel.DTOs;
using LoadSentinel.Models;
using LoadSentinel.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoadSentinel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScenarioController(IScenarioService scenarioService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllScenariosAsync()
    {
        var scenarios = await scenarioService.GetAllScenariosAsync();
        return Ok(scenarios);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetScenarioById(int id) 
    {
        var scenario = await scenarioService.GetByIdAsync(id);
        return scenario == null ? NotFound() : Ok(scenario);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddScenarioAsync(CreateScenarioDto createScenarioDto)
    {
        
        var createdScenario = await scenarioService.AddScenarioAsync(createScenarioDto);
    
        return CreatedAtAction(
            nameof(GetScenarioById), 
            new { id = createdScenario.Id }, 
            createdScenario);
    }
}
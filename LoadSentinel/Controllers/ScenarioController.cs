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
    
    [HttpPost]
    public async Task<IActionResult> AddScenarioAsync(CreateScenarioDto createScenarioDto)
    {
         await scenarioService.AddScenarioAsync(createScenarioDto);
         return CreatedAtAction(nameof(GetAllScenariosAsync), null);
    }
}
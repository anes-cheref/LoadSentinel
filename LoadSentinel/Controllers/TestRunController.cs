using LoadSentinel.DTOs;
using LoadSentinel.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoadSentinel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestRunController(ITestRunService service) : ControllerBase
{
    private readonly ITestRunService _testRunService = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var testRuns = await _testRunService.GetAllTestRunsAsync();
        return Ok(testRuns);
    }

    [HttpPost]
    public async Task<IActionResult> AddTestRunAsync(CreateTestRunDto createTestRunDto)
    {
        await _testRunService.AddTestRunAsync(createTestRunDto);
        
        return CreatedAtAction(nameof(GetAll), null);
    }
}
using LoadSentinel.DTOs;
using LoadSentinel.Models;

namespace LoadSentinel.Services;

public interface ITestRunService
{
    public Task AddTestRunAsync(CreateTestRunDto createTestRunDto);
    public Task<List<TestRunResponseDto>> GetAllTestRunsAsync();
}
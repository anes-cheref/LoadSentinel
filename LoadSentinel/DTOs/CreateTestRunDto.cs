namespace LoadSentinel.DTOs;

public record CreateTestRunDto(int ScenarioId, int VirtualUserCount, int AverageResponseTime);
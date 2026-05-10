namespace LoadSentinel.DTOs;

public class TestRunResponseDto
{
    public int Id { get; set; }
    public DateTime ExecutionDate { get; set; }
    public int VirtualUsersCount { get; set; }
    public double AverageResponseTime { get; set; }
    public bool IsSuccess { get; set; }
    
    // On ne renvoie que ce dont le React a besoin (pas tout l'objet Scenario)
    public string ScenarioName { get; set; } = string.Empty;
}
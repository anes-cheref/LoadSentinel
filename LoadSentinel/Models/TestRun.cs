namespace LoadSentinel.Models;

public class TestRun
{
    public int Id { get; set; }
    
    // Clé étrangère
    public int ScenarioId { get; set; }
    
    public DateTime ExecutionDate  { get; set; }
    public int VirtualUsersCount { get; set; }
    public double AverageResponseTime { get; set; }
    public bool IsSuccess { get; set; }
    
    public Scenarios? Scenario { get; set; }
}
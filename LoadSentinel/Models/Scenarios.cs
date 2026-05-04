namespace LoadSentinel.Models;

public class Scenarios
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ThreshholdMaxResponseTimeMs { get; set; }
    
    public List<TestRun> TestRuns { get; set; }
}
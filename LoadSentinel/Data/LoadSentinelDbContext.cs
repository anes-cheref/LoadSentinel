using LoadSentinel.Models;

namespace LoadSentinel.Data;
using Microsoft.EntityFrameworkCore;
public class LoadSentinelDbContext : DbContext
{
    public LoadSentinelDbContext(DbContextOptions<LoadSentinelDbContext> options) : base(options){ }
    
    public DbSet<Scenario> Scenario { get; set; }
    public DbSet<TestRun> TestRuns { get; set; }
}
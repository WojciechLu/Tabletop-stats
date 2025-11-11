using Microsoft.EntityFrameworkCore;
using TabletopStats.Infrastructure.Entity;

namespace TabletopStats.Infrastructure;

public class RpgContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Person>  Persons { get; set; }
    public DbSet<SessionLog>  SessionLogs { get; set; }
    public DbSet<RpgSystem>  RpgSystems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SessionLog>()
            .HasMany(e => e.Players)
            .WithMany(e => e.SessionPlayed)
            .UsingEntity<Dictionary<string, object>>(j => j.ToTable("PlayerSessionLog"));

        modelBuilder.Entity<SessionLog>()
            .HasOne(e => e.GameMaster)
            .WithMany(e => e.SessionRan)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<SessionLog>()
            .ToTable("SessionLogs");
    }
}
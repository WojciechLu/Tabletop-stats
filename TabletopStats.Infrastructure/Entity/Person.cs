using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TabletopStats.Infrastructure.Entity;

public class Person
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    public Collection<SessionLog> SessionPlayed { get; set; } = new Collection<SessionLog>();
    public Collection<SessionLog> SessionRan { get; set; } = new Collection<SessionLog>();
}
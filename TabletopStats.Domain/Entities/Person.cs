using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TabletopStats.Domain.Entities;

public class Person
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public string Name { get; set; }

    public Collection<SessionLog> SessionPlayed { get; set; } = new Collection<SessionLog>();
    public Collection<SessionLog> SessionRan { get; set; } = new Collection<SessionLog>();
}
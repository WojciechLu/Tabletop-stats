using System.ComponentModel.DataAnnotations;

namespace TabletopStats.Domain.Entities;

public class Adventure
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public List<SessionLog> Sessions { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace TabletopStats.Infrastructure.Entity;

public class RpgSystem
{
    [Key]
    public Guid SystemId { get; set; }
    
    [Required]
    public string Name { get; set; }
}
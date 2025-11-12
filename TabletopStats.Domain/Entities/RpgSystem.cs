using System.ComponentModel.DataAnnotations;

namespace TabletopStats.Domain.Entities;

public class RpgSystem
{
    [Key]
    public Guid SystemId { get; set; }
    
    [Required]
    public string Code { get; set; }
    
    [Required]
    public string Name { get; set; }
}
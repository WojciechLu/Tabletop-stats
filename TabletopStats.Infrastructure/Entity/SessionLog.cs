using System.ComponentModel.DataAnnotations;

namespace TabletopStats.Infrastructure.Entity;

public class SessionLog
{
    [Key]
    public Guid SessionId { get; set; }
    
    [Required]
    public string SessionName { get; set; }
    
    [Required]
    public DateTime StartTime { get; set; }
    
    [Required]
    public DateTime EndTime { get; set; }
    
    [Required]
    public RpgSystem RpgSystem { get; set; }
    
    // public Guid? GameMasterId { get; set; }
    public Person? GameMaster { get; set; }
    
    [Required]
    public ICollection<Person> Players { get; set; }
}
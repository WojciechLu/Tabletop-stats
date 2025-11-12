using System.ComponentModel.DataAnnotations;

namespace TabletopStats.Domain.Entities;

public class Campaign
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Adventure> Adventures { get; set; }
}
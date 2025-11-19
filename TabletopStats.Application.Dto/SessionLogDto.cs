namespace TabletopStats.Application.Dto;

public record SessionLogDto
{
    public Guid SessionId { get; set; }
    public Guid? AdventureId { get; set; }
    public Guid? CampaignId { get; set; }
    
    public string SessionName { get; set; }
    public string Description { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public TimeSpan Duration { get; set; }
    
    public ICollection<PersonDto> Players { get; set; }
    public PersonDto? GameMaster { get; set; }
    public RpgSystemDto RpgSystem { get; set; }
}
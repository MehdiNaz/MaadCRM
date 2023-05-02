namespace Domain.Models;

public class BaseEntity
{
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime DateLastUpdate { get; set; } = DateTime.UtcNow;
    
    public uint Version { get; set; }
}
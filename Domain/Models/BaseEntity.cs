namespace Domain.Models;

public class BaseEntity
{
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateLastUpdate { get; set; } = DateTime.Now;
}
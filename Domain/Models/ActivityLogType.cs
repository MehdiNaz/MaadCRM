namespace Domain.Models;

public class ActivityLogType:BaseEntity
{
    public string SystemKeyword { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; }
    public ICollection<ActivityLog> ActivityLogs { get; set; }
}
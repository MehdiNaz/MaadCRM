using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Users;

namespace Domain.Models.General;

public class ActivityLog:BaseEntity
{
    public string Comment { get; set; }
    public string IpAddress { get; set; }
    public string EntityName { get; set; }
    public int ActivityLogTypeId { get; set; }
    public int UserId { get; set; }
    public int EntityId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [ForeignKey(nameof(ActivityLogTypeId))]
    public ActivityLogType ActivityLogType { get; set; }
}
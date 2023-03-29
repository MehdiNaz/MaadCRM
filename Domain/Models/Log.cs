namespace Domain.Models;

/// <summary>
/// History of a user's actions
/// </summary>
public class Log
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public LogKinds Kind { get; set; }
    public DateTime DateCreated { get; set; }

    public User User { get; init; }
}
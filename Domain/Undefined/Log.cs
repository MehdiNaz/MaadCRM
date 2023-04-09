namespace Domain.UnDifined;

/// <summary>
/// History of a user's actions
/// </summary>
public class Log : BaseEntity
{
    public Log()
    {
        Id = Ulid.NewUlid();
    }

    public Ulid Id { get; set; }
    public string UserId { get; set; }
    public LogKinds Kind { get; set; }
    public DateTime DateCreated { get; set; }

    public User User { get; init; }
}
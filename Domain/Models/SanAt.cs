namespace Domain.Models;

public class SanAt : BaseEntity
{
    public SanAt()
    {
        SanAtId = Ulid.NewUlid();
        SanAtStatus = Status.Show;
    }

    public Ulid SanAtId { get; set; }
    public string SanAtName { get; set; }
    public string UserId { get; set; }
    public Status SanAtStatus { get; set; }


    public User User { get; set; }
}
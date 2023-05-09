namespace Domain.Models;

public class SanAt : BaseEntity
{
    public SanAt()
    {
        Id = Ulid.NewUlid();
        SanAtStatusType = StatusType.Show;
    }

    public Ulid Id { get; set; }
    public string SanAtName { get; set; }
    public string UserId { get; set; }
    public StatusType SanAtStatusType { get; set; }


    //public User User { get; set; }
}
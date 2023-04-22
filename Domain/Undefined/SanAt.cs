namespace Domain.Models;

public class SanAt : BaseEntity
{
    public SanAt()
    {
        Id = Ulid.NewUlid();
        SanAtStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public string SanAtName { get; set; }
    public string UserId { get; set; }
    public Status SanAtStatus { get; set; }


    //public User User { get; set; }
}
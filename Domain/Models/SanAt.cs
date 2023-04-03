namespace Domain.Models;

public class SanAt : BaseEntity
{
    public SanAt()
    {
        SanAtId = Ulid.NewUlid();
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid SanAtId { get; set; }
    public string SanAtName { get; set; }
    public string UserId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }


    public User User { get; set; }
}
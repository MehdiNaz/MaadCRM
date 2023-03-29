namespace Domain.Models;

public class SanAt : BaseEntity
{
    public SanAt()
    {
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid SanAtId { get; set; }
    public string SanAtName { get; set; }
    public Ulid UserId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }


    public User User { get; set; }
}
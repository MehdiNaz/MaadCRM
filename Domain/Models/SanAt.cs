namespace Domain.Models;

public class SanAt : BaseEntity
{
    public SanAt()
    {
        IsDeleted = (byte)Status.NotDeleted;
    }

    public Ulid SanAtId { get; set; }
    public string SanAtName { get; set; }
    public string IdUser { get; set; }
    public byte IsDeleted { get; set; }


    public ApplicationUser User { get; set; }
}
namespace Domain.Models.Customers.Notes;

public class CustomerHashTag : BaseEntity
{
    public CustomerHashTag()
    {
        IsDeleted = Status.NotDeleted;
    }

    public Ulid CustomerHashTagId { get; set; }
    public string Title { get; set; }
    public Ulid CustomerNoteId { get; set; }
    public Status IsDeleted { get; set; }


    public CustomerNote CustomerNote { get; set; }
}
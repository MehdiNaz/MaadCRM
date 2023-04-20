namespace Domain.Models.Businesses;

public class BusinessPlan : BaseEntity
{
    public BusinessPlan()
    {
        Id = Ulid.NewUlid();
        BusinessPlansStatus = Status.Show;
    }

    public Ulid Id { get; set; }
    public Ulid PlanId { get; set; }
    public Ulid BusinessId { get; set; }
    public uint CountOfDay { get; set; }
    public uint CountOfUsers { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    public Status BusinessPlansStatus { get; set; }

    // public Business Business { get; set; }
    // public Plan Plan { get; set; }
}
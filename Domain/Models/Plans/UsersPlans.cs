namespace Domain.Models.Plans;

public class UsersPlans
{
    public UsersPlans()
    {
        UsersPlansId = Ulid.NewUlid();
        UsersPlansStatus = Status.Show;
    }

    public Ulid UsersPlansId { get; set; }
    public Ulid PlanId { get; set; }
    public string UserId { get; set; }
    public string Days { get; set; }
    public string KarbarCounts { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    public Status UsersPlansStatus { get; set; }

    public User User { get; set; }
    public Plan Plan { get; set; }
}
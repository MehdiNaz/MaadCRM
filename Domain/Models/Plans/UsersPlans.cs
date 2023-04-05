namespace Domain.Models.Plans;

public class UsersPlans
{
    public Ulid UsersPlansId { get; set; }
    public Ulid PlanId { get; set; }
    public string UserId { get; set; }
    public string Days { get; set; }
    public string KarbarCounts { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
}
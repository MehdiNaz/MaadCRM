namespace Application.Requests;

public class RequestCreateUsersPlans
{
    public required Ulid PlanId { get; set; }
    public required string UserId { get; set; }
    public required string Days { get; set; }
    public required string KarbarCounts { get; set; }
}
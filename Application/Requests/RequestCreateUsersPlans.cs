namespace Application.Requests;

public class RequestCreateUsersPlans
{
    public required Ulid PlanId { get; set; } 
    public string UserId { get; set; }
    public uint CountOfDay { get; set; }
    public uint CountOfUsers { get; set; }
}
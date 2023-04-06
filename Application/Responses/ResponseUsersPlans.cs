namespace Application.Responses;

public class ResponseUsersPlans
{
    public Ulid UsersPlansId { get; set; }
    public string Days { get; set; }
    public string KarbarCounts { get; set; }
    public string PlanName { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
}
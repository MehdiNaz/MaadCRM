namespace Domain.Models.Businesses.Plans;

public class BusinessPlan : BaseEntityWithUserId
{
    public BusinessPlan()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
    }

    public Ulid Id { get; set; }
    
    
    public decimal Price { get; set; }
    public uint CountOfUsers { get; set; }

    public DateTime DateStarted { get; set; }
    public DateTime DateFinished { get; set; }
    public uint CountOfDay { get; set; }
    
    public StatusType Status { get; set; }
    
    public Ulid IdPlan { get; set; }
    public Plan IdPlanNavigation { get; set; }

    public Ulid IdBusiness { get; set; }
    public Business IdBusinessNavigation { get; set; }
    
    public Ulid IdPardakht { get; set; }
    public Pardakht IdPardakhtNavigation { get; set; }
}
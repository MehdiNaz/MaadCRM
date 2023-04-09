namespace Application.Services.BusinessPlansService.Queries;

public struct BusinessPlansByIdQuery : IRequest<BusinessPlans?>
{
    public Ulid BusinessPlansId { get; set; }
    //public Ulid UsersPlansId { get; set; }
    //public uint CountOfUsers { get; set; }
    //public uint CountOfDay { get; set; }
    //public string PlanName { get; set; }
    //public decimal PriceOfDay { get; set; }
    //public decimal PriceOfUsers { get; set; }
    //public DateTime StartDate { get; set; }
    //public DateTime FinishDate { get; set; }
}
namespace Application.Services.CustomerService.Query;

public struct CustomerByFilterItemsQuery : IRequest<Result<CustomerDashboardResponse>>
{
    public Ulid? CustomerId { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? CityId { get; set; }
    public Ulid? ProvinceId { get; set; }
    public Ulid? ProductId { get; set; }
    public CustomerStateTypes? CustomerState { get; set; }
    public DateTime? From { get; set; }
    public DateTime? UpTo { get; set; }
    public Ulid? MoshtaryMoAref { get; set; }
    public Ulid? ProductCustomerFavorite { get; set; }
}
namespace Application.Requests;

public class CustomerFilterRequest
{
    public Ulid? CustomerId { get; set; }
    public DateOnly? BirthDayDate { get; set; }
    public GenderTypes? Gender { get; set; }
    public Ulid? CityId { get; set; }
    public Ulid? ProvinceId { get; set; }
    public CustomerStateTypes? CustomerState { get; set; }
    public DateTime? From { get; set; }
    public DateTime? UpTo { get; set; }
    public Ulid? MoshtaryMoAref { get; set; }
    public Ulid? ProductCustomerFavorite { get; set; }
    public Ulid ProductId { get; set; }
    public string ProductName { get; set; }
    public string UserId { get; set; }

}
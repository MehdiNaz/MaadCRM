namespace Application.Services.CustomerService.Commands;

public struct UpdateCustomerCommand : IRequest<Customer>
{
    public Ulid CustomerId { get; set; }
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly BirthDayDate { get; set; }
    public byte[] CustomerPic { get; set; }
    public required string UserId { get; set; }
    public required Ulid CityId { get; set; }
    public required Ulid BusinessId { get; set; }
    public required Ulid CustomerCategoryId { get; set; }
    public required GenderTypes Gender { get; set; }
    public ShowTypes IsShown { get; set; }
    public required CustomerStateTypes CustomerState { get; set; }
    public required CustomerStatus CustomerStatus { get; set; }
    public required string InsertedBy { get; set; }
    public Status IsDeleted { get; set; }
    public string UpdatedBy { get; set; }
    public Ulid CustomerMoarefId { get; set; }
}
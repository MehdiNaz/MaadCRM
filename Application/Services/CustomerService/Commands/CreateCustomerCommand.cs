namespace Application.Services.CustomerService.Commands;

public struct CreateCustomerCommand : IRequest<Customer>
{
    public string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly BirthDayDate { get; set; }
    public byte[] CustomerPic { get; set; }
    public required string InsertedBy { get; set; }
    public string UpdatedBy { get; set; }
    public string? UserId { get; set; }
    public required Ulid CityId { get; set; }
    public required Ulid BusinessId { get; set; }
    public required Ulid CustomerCategoryId { get; set; }
    public required GenderTypes Gender { get; set; }
    public required Ulid CustomerMoarefId { get; set; }
}
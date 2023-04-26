namespace Application.Services.CustomerCategoryService.Commands;

public struct DeleteCustomerCategoryCommand : IRequest<Result<CustomerCategory>>
{
    public Ulid Id { get; set; }
    public string UserId { get; set; }
}
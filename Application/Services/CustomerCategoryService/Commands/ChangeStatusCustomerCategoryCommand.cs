namespace Application.Services.CustomerCategoryService.Commands;

public struct ChangeStatusCustomerCategoryCommand : IRequest<Result<CustomerCategory>>
{
    public Ulid Id { get; set; }
    public Status CustomerCategoryStatus { get; set; }
}
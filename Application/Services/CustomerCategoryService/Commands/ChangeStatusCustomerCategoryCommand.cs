namespace Application.Services.CustomerCategoryService.Commands;

public struct ChangeStatusCustomerCategoryCommand : IRequest<CustomerCategory?>
{
    public Ulid Id { get; set; }
    public Status CustomerCategoryStatus { get; set; }
}
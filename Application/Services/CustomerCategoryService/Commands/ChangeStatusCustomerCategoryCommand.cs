namespace Application.Services.CustomerCategoryService.Commands;

public struct ChangeStatusCustomerCategoryCommand : IRequest<CustomerCategory?>
{
    public Ulid CustomerCategoryId { get; set; }
    public Status CustomerCategoryStatus { get; set; }
}
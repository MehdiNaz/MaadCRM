namespace Application.Services.CustomerCategoryService.Commands;

public struct DeleteCustomerCategoryCommand : IRequest<CustomerCategory>
{
    public Ulid CustomerCategoryId { get; set; }
}
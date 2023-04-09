namespace Application.Services.CustomerCategoryService.Queries;

public struct ByIdCustomerCategoryQuery : IRequest<CustomerCategory>
{
    public Ulid CustomerCategoryId { get; set; }
}
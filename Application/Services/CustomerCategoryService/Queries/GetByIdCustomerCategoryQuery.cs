namespace Application.Services.CustomerCategoryService.Queries;

public struct GetByIdCustomerCategoryQuery : IRequest<CustomerCategory>
{
    public Ulid CustomerCategoryId { get; set; }
}
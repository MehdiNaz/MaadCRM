namespace Application.Services.CustomerCategoryService.Queries;

public struct GetByIdCustomerCategoryQuery : IRequest<CustCategory>
{
    public Ulid CustCategoryId { get; set; }
}
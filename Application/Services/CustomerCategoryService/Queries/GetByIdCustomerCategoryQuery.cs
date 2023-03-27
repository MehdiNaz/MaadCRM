namespace Application.Services.CustomerCategoryService.Queries;

public class GetByIdCustomerCategoryQuery : IRequest<CustCategory>
{
    public Ulid CustCategoryId { get; set; }
}
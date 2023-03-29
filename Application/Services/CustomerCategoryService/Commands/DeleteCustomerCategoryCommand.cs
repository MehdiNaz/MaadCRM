namespace Application.Services.CustomerCategoryService.Commands;

public struct DeleteCustomerCategoryCommand : IRequest<CustCategory>
{
    public Ulid CustCategoryId { get; set; }
}
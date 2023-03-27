namespace Application.Services.CustomerCategoryService.Commands;

public class DeleteCustomerCategoryCommand : IRequest<CustCategory>
{
    public Ulid CustCategoryId { get; set; }
}
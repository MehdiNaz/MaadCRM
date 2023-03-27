namespace Application.Services.CustomerCategoryService.Commands;

public class CreateCustomerCategoryCommand : IRequest<CustCategory>
{
    public string CustomerCategoryName { get; set; }
    public byte IsDeleted { get; set; }
    public byte IsShown { get; set; }
    public Ulid CategoryId { get; set; }
}
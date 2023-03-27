namespace Application.Services.CustomerCategoryService.Commands;

public class UpdateCustomerCategoryCommand:IRequest<CustCategory>
{
    public Ulid CustCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
    public byte IsDeleted { get; set; }
    public byte IsShown { get; set; }
    public Ulid CategoryId { get; set; }
}
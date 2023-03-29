namespace Application.Services.CustomerCategoryService.Commands;

public struct UpdateCustomerCategoryCommand:IRequest<CustCategory>
{
    public Ulid CustCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
    public ShowTypes IsShown { get; set; }
    public Ulid CategoryId { get; set; }
}
namespace Application.Services.CustomerCategoryService.Commands;

public struct CreateCustomerCategoryCommand : IRequest<Result<CustomerFeedbackCategory>>
{
    public string UserId { get; set; }
    public string CustomerCategoryName { get; set; }
}
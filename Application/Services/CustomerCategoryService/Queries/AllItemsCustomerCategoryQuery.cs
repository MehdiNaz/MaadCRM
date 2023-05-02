namespace Application.Services.CustomerCategoryService.Queries;

public struct AllItemsCustomerCategoryQuery : IRequest<Result<ICollection<CustomerFeedbackCategory>>>
{
    public string UserId{ get; set; }
}
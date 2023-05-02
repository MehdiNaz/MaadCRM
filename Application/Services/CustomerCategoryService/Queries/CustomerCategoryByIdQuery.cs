namespace Application.Services.CustomerCategoryService.Queries;

public struct CustomerCategoryByIdQuery : IRequest<Result<CustomerFeedbackCategory>>
{
    public Ulid CustomerCategoryId { get; set; }
    public string UserId { get; set; }
}
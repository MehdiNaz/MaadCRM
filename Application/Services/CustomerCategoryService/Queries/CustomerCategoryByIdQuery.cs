namespace Application.Services.CustomerCategoryService.Queries;

public struct CustomerCategoryByIdQuery : IRequest<Result<CustomerCategory>>
{
    public Ulid CustomerCategoryId { get; set; }
    public string UserId { get; set; }
}
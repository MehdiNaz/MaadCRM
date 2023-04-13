namespace Application.Services.CustomerCategoryService.Queries;

public struct CustomerCategoryByIdQuery : IRequest<CustomerCategory>
{
    public Ulid CustomerCategoryId { get; set; }
    public string UserId { get; set; }
}
﻿using Application.Responses.Product;

namespace Application.Services.ProductCategoryService.Commands;

public struct CreateProductCategoryCommand : IRequest<Result<ProductCategoryResponse>>
{
    public byte? Order { get; set; }
    public required string ProductCategoryName { get; set; }
    public string Description { get; set; }
    public string? Icon { get; set; }
    public Ulid BusinessId { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
}
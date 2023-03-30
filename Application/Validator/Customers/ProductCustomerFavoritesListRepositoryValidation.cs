namespace Application.Validator.Customers;

public class ProductCustomerFavoritesListRepositoryValidation : AbstractValidator<ProductCustomerFavoritesList>
{
    public ProductCustomerFavoritesListRepositoryValidation()
    {
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
    }
}
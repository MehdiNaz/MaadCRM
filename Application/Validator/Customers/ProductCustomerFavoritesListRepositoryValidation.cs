namespace Application.Validator.Customers;

public class ProductCustomerFavoritesListRepositoryValidation : AbstractValidator<ProductCustomerFavoritesList>
{
    public ProductCustomerFavoritesListRepositoryValidation()
    {
        RuleFor(x => x.IdCustomer).NotEmpty();
        RuleFor(x => x.IdProduct).NotEmpty();
    }
}
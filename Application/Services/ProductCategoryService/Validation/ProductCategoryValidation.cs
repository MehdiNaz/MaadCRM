namespace Application.Services.ProductCategoryService.Validation;

public class ProductCategoryValidation : AbstractValidator<ProductCategory>
{
    public ProductCategoryValidation()
    {
        RuleFor(x => x.Order).NotEmpty();
        RuleFor(x => x.ProductCategoryName).NotEmpty().WithMessage("لطفاً نام دسته بندی محصول را وارد نمائید");
        RuleFor(x => x.Description).NotEmpty().WithMessage("لطفاً توضیحات محصول را وارد نمائید");
    }
}

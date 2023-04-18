namespace Application.Services.ProductService.Validation;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("لطفاً نام محصول را وارد نمائید");
        RuleFor(x => x.ProductCategoryId).NotEmpty().WithMessage("لطفاً دسته بندی محصول را وارد نمائید");
        RuleFor(x => x.Title).NotEmpty().WithMessage("لطفاً عنوان محصول را وارد نمائید");
        RuleFor(x => x.Summery).NotEmpty().WithMessage("لطفاً توضیحات محصول را وارد نمائید");
        RuleFor(x => x.Price).NotEmpty().WithMessage("لطفاً قیمت اولیه محصول را وارد نمائید");
        RuleFor(x => x.SecondaryPrice).NotEmpty().WithMessage("لطفاً قیمت نهایی محصول را وارد نمائید");
    }
}
namespace Application.Services.Login.Queries.Validation;

public class VerifyCodeValidation : AbstractValidator<VerifyCodeQuery>
{
    public VerifyCodeValidation()
    {
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.Phone).Must(x => x.Length == 11);
        RuleFor(x => x.Phone).Must(x => x.StartsWith("09"));
        RuleFor(x => x.Code).Must(x => x.All(char.IsDigit));

        
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Code).Must(x => x.Length == 4);
        RuleFor(x => x.Code).Must(x => x.All(char.IsDigit));
    }
}
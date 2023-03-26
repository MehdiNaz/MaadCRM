namespace WebApi.StartupConfiguration;

public static class FluentValidationConfiguration
{
    public static void Configure(IServiceCollection collection)
    {
        collection.AddFluentValidationAutoValidation();
        collection.AddFluentValidationAutoValidation();
        collection.AddFluentValidationClientsideAdapters();
        collection.AddValidatorsFromAssembly(typeof(CustomerValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(RequestLoginByPhoneAndPasswordValidator).Assembly);
        collection.AddValidatorsFromAssembly(typeof(RequestLoginByPhoneValidator).Assembly);
        collection.AddValidatorsFromAssembly(typeof(AttributeOptionsValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(AttributeOptionsValueValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(BusinessAttributeValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CategoryAttributeValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustCategoryValidation).Assembly);

    }
}
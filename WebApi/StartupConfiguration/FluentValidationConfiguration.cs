using Application.Validation;

namespace WebApi.StartupConfiguration;

public static class FluentValidationConfiguration
{
    public static void Configure(IServiceCollection collection)
    {
        collection.AddFluentValidationAutoValidation();
        collection.AddFluentValidationAutoValidation();
        collection.AddFluentValidationClientsideAdapters();

        // Models DTO :
        collection.AddValidatorsFromAssembly(typeof(RequestLoginByPhoneAndPasswordValidator).Assembly);
        collection.AddValidatorsFromAssembly(typeof(RequestLoginByPhoneValidator).Assembly);
        collection.AddValidatorsFromAssembly(typeof(AttributeOptionsValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(AttributeOptionsValueValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(BusinessAttributeValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CategoryAttributeValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomerCategoryValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomerValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomersPhoneNumberValidator).Assembly);
        collection.AddValidatorsFromAssembly(typeof(SanAtValidator).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomersEmailAddressValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactGroupValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactPhoneNumberValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactsEmailAddressValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ProductCustomerFavoritesListRepositoryValidation).Assembly);



        // Request DTO :
        collection.AddValidatorsFromAssembly(typeof(RequestLoginByMailValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(RequestLoginByPhoneValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(RequestLoginByPhoneAndPasswordValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(RequestProfileValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(RequestRegisterValidation).Assembly);



        // Response DTO :
    }
}
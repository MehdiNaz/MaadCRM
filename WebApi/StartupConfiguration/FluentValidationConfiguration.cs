﻿using Application.Services.Customer.CustomerPeyGiryService.Validation;

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
        collection.AddValidatorsFromAssembly(typeof(CreateBusinessPlanValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(UpdateBusinessPlanValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomerActivityValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomersPhoneNumberValidator).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomerAddressValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomerNoteValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(SanAtValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomersEmailAddressValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactGroupValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactPhoneNumberValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ContactsEmailAddressValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ProductCustomerFavoritesListRepositoryValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CityValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(NoteHashTagValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(NoteAttachmentValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(CustomerPeyGiryValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(PeyGiryAttachmentValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ProductValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ProductCategoryValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ForooshOrderValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(ForooshFactorValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(NoteHashTableValidation).Assembly);


        collection.AddValidatorsFromAssembly(typeof(CreateUsersPlanValidation).Assembly);
        collection.AddValidatorsFromAssembly(typeof(UpdateUsersPlanValidation).Assembly);

    }
}
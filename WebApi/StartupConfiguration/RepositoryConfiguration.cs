namespace WebApi.StartupConfiguration;

public static class RepositoryConfiguration
{
    public static void Configure(IServiceCollection collection)
    {
        // builder.Services.AddTransient<ScheduleDatabaseInvocable>();

        // var serviceProvider = builder.Services.BuildServiceProvider();
        // var logger = serviceProvider.GetService<ILogger<ScheduleDatabaseInvocable>>();
        // builder.Services.AddSingleton(typeof(ILogger), logger!);

        collection.AddTransient<ITestService, TestService>();

        //Application ==> Interfaces :
        collection.AddTransient<ICustomerCategoryRepository, CustomerCategoryRepository>();
        collection.AddTransient<ICustomerRepository, CustomerRepository>();
        collection.AddTransient<ICustomersEmailAddressRepository, CustomersEmailAddressRepository>();
        collection.AddTransient<ICustomersPhoneNumberRepository, CustomersPhoneNumberRepository>();
        collection.AddTransient<ICustomersAddressRepository, CustomersAddressRepository>();
        collection.AddTransient<ICustomerNoteRepository, CustomerNoteRepository>();
        collection.AddTransient<INoteHashTagRepository, NoteHashTagRepository>();
        collection.AddTransient<INoteAttachmentRepository, NoteAttachmentRepository>();
        collection.AddTransient<ICustomerPeyGiryRepository, CustomerPeyGiryRepository>();
        collection.AddTransient<IPeyGiryAttachmentRepository, PeyGiryAttachmentRepository>();


        collection.AddTransient<IProductCustomerFavoritesListRepository, ProductCustomerFavoritesListRepository>();
        collection.AddTransient<ILogService, LogService>();
        collection.AddTransient<IPlanRepository, PlanRepository>();
        collection.AddTransient<ISanAtRepository, SanAtRepository>();
        collection.AddTransient<IBusinessRepository, BusinessRepository>();

        //Application ==> Interfaces ==> SpecialFields
        collection.AddTransient<IAttributeOptionsRepository, AttributeOptionsRepository>();
        collection.AddTransient<IAttributeOptionsValueRepository, AttributeOptionsValueRepository>();
        collection.AddTransient<IBusinessAttributeRepository, BusinessAttributeRepository>();
        collection.AddTransient<ICategoryAttributeRepository, CategoryAttributeRepository>();

        collection.AddTransient<IContactGroupRepository, ContactGroupRepository>();
        collection.AddTransient<IContactRepository, ContactRepository>();
        collection.AddTransient<IContactPhoneNumberRepository, ContactPhoneNumberRepository>();
        collection.AddTransient<IContactsEmailAddressRepository, ContactsEmailAddressRepository>();
        
        
        collection.AddTransient<ICityRepository, CityRepository>();
    }
}
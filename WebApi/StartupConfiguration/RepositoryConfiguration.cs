namespace WebApi.StartupConfiguration;

public static class RepositoryConfiguration
{
    public static void Configure(IServiceCollection collection)
    {
        // Repository :
        collection.AddTransient<ILoginRerpository, LoginRepository>();
        collection.AddTransient<IProfileRepository, ProfileRepository>();


        // builder.Services.AddTransient<ScheduleDatabaseInvocable>();

        // var serviceProvider = builder.Services.BuildServiceProvider();
        // var logger = serviceProvider.GetService<ILogger<ScheduleDatabaseInvocable>>();
        // builder.Services.AddSingleton(typeof(ILogger), logger!);

        collection.AddTransient<ITestService, TestService>();

        // TODO: Remove test
        collection.AddTransient<ITest1Service, Test1Service>();

        //Application ==> Interfaces :
        collection.AddTransient<ICustomerCategoryRepository, CustomerCategoryRepository>();
        collection.AddTransient<ICustomerRepository, CustomerRepository>();
        collection.AddTransient<ICustomersEmailAddressRepository, CustomersEmailAddressRepository>();
        collection.AddTransient<ICustomersPhoneNumberRepository, CustomersPhoneNumberRepository>();
        collection.AddTransient<ICustomersAddressRepository, CustomersAddressRepository>();
        collection.AddTransient<ICustomerActivityRepository, CustomerActivityRepository>();
        collection.AddTransient<ICustomerNoteRepository, CustomerNoteRepository>();
        collection.AddTransient<INoteHashTagRepository, NoteHashTagRepository>();
        collection.AddTransient<INoteAttachmentRepository, NoteAttachmentRepository>();
        collection.AddTransient<ICustomerPeyGiryRepository, CustomerPeyGiryRepository>();
        collection.AddTransient<IPeyGiryAttachmentRepository, PeyGiryAttachmentRepository>();

        collection.AddTransient<IProductRepository, ProductRepository>();
        collection.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();


        collection.AddTransient<IForoshOrderRepository, ForoshOrderRepository>();
        collection.AddTransient<IForoshFactorRepository, ForoshFactorRepository>();


        collection.AddTransient<IProductCustomerFavoritesListRepository, ProductCustomerFavoritesListRepository>();
        //collection.AddTransient<ILogService, LogService>();

        collection.AddTransient<IPlanRepository, PlanRepository>();
        collection.AddTransient<IBusinessPlanRepository, BusinessPlanRepository>();


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
        collection.AddTransient<IContactsEmailAddressRepository, ContactEmailAddressRepository>();
        collection.AddTransient<ICustomerFeedbackRepository, CustomerFeedbackRepository>();


        collection.AddTransient<ICityRepository, CityRepository>();
    }
}
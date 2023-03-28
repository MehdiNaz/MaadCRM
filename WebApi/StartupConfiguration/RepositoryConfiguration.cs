namespace WebApi.StartupConfiguration;

public static class RepositoryConfiguration
{
    public static void Configure(IServiceCollection collection)
    {
        // builder.Services.AddTransient<ScheduleDatabaseInvocable>();

        // var serviceProvider = builder.Services.BuildServiceProvider();
        // var logger = serviceProvider.GetService<ILogger<ScheduleDatabaseInvocable>>();
        // builder.Services.AddSingleton(typeof(ILogger), logger!);

        collection.AddTransient<IAccountService, AccountService>();
        collection.AddTransient<ITestService, TestService>();

        //Application ==> Interfaces :
        collection.AddTransient<ICustCategoryRepository, CustCategoryRepository>();
        collection.AddTransient<ICustomerRepository, CustomerRepository>();
        collection.AddTransient<ICustomersEmailAddressRepository, CustomersEmailAddressRepository>();
        collection.AddTransient<ICustomersPhoneNumberRepository, CustomersPhoneNumberRepository>();
        collection.AddTransient<ILogService, LogService>();
        collection.AddTransient<IMoarefRepository, MoarefRepository>();
        collection.AddTransient<IPlanRepository, PlanRepository>();
        collection.AddTransient<IPostRepository, PostRepository>();
        collection.AddTransient<ISanAtRepository, SanAtRepository>();
        collection.AddTransient<IBusinessRepository, BusinessRepository>();

        //Application ==> Interfaces ==> SpecialFields
        collection.AddTransient<IAttributeOptionsRepository, AttributeOptionsRepository>();
        collection.AddTransient<IAttributeOptionsValueRepository, AttributeOptionsValueRepository>();
        collection.AddTransient<IBusinessAttributeRepository, BusinessAttributeRepository>();
        collection.AddTransient<ICategoryAttributeRepository, CategoryAttributeRepository>();

        collection.AddTransient<IContactGroupRepository, ContactGroupRepository>();
    }
}
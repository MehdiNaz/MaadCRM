using Application.Interfaces.Notification;
using Application.Interfaces.TeamMates;
using DataAccess.Repositories.Notification;
using DataAccess.Repositories.TeamMates;

namespace WebApi.StartupConfiguration;

public static class RepositoryConfiguration
{
    public static void Configure(IServiceCollection collection)
    {
        // builder.Services.AddTransient<ScheduleDatabaseInvocable>();

        // var serviceProvider = builder.Services.BuildServiceProvider();
        // var logger = serviceProvider.GetService<ILogger<ScheduleDatabaseInvocable>>();
        // builder.Services.AddSingleton(typeof(ILogger), logger!);
        
        collection.AddTransient<IUserRepository, UserRepository>();
        collection.AddTransient<ITeamMateRepository, TeamMateRepository>();
        collection.AddTransient<ITeamMateGroupRepository, TeamMateGroupRepository>();
        
        collection.AddTransient<INotificationRepository, NotificationRepository>();

        collection.AddTransient<ILoginRepository, LoginRepository>();
        
        collection.AddTransient<IProfileRepository, ProfileRepository>();

        collection.AddTransient<ICustomerRepository, CustomerRepository>();
        collection.AddTransient<ICustomersEmailAddressRepository, CustomersEmailAddressRepository>();
        collection.AddTransient<ICustomersPhoneNumberRepository, CustomersPhoneNumberRepository>();
        collection.AddTransient<ICustomersAddressRepository, CustomersAddressRepository>();
        collection.AddTransient<ICustomerActivityRepository, CustomerActivityRepository>();
        collection.AddTransient<ICustomerNoteRepository, CustomerNoteRepository>();
        collection.AddTransient<INoteHashTagRepository, NoteHashTagRepository>();
        collection.AddTransient<INoteAttachmentRepository, NoteAttachmentRepository>();
        collection.AddTransient<ICustomerPeyGiryRepository, CustomerPeyGiryRepository>();
        collection.AddTransient<IPeyGiryCategoryRepository, PeyGiryCategoryRepository>();
        collection.AddTransient<IPeyGiryAttachmentRepository, PeyGiryAttachmentRepository>();

        collection.AddTransient<IProductRepository, ProductRepository>();
        collection.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();


        collection.AddTransient<IForooshOrderRepository, ForooshOrderRepository>();
        collection.AddTransient<IForooshFactorRepository, ForooshFactorRepository>();
        collection.AddTransient<IForooshPaymentRepository, PaymentRepository>();


        collection.AddTransient<IProductCustomerFavoritesListRepository, ProductCustomerFavoritesListRepository>();

        collection.AddTransient<IPlanRepository, PlanRepository>();
        collection.AddTransient<IBusinessPlanRepository, BusinessPlanRepository>();


        collection.AddTransient<IBusinessRepository, BusinessRepository>();

        collection.AddTransient<IAttributeRepository, AttributeRepository>();
        collection.AddTransient<IAttributeOptionsRepository, AttributeOptionsRepository>();
        collection.AddTransient<IAttributeCustomerRepository, AttributeCustomerRepository>();

        collection.AddTransient<IContactGroupRepository, ContactGroupRepository>();
        collection.AddTransient<IContactRepository, ContactRepository>();
        collection.AddTransient<IContactPhoneNumberRepository, ContactPhoneNumberRepository>();
        collection.AddTransient<IContactsEmailAddressRepository, ContactEmailAddressRepository>();
        collection.AddTransient<ICustomerFeedbackRepository, CustomerFeedbackRepository>();
        collection.AddTransient<ICustomerFeedbackCategoryRepository, CustomerFeedbackCategoryRepository>();
        collection.AddTransient<ICustomerFeedbackAttachmentRepository, CustomerFeedbackAttachmentRepository>();
        
        collection.AddTransient<ICountryRepository, CountryRepository>();
        collection.AddTransient<IProvinceRepository, ProvinceRepository>();
        collection.AddTransient<ICityRepository, CityRepository>();

        collection.AddTransient<INoteHashTableRepository, NoteHashTableRepository>();

        collection.AddTransient<ILogRepository, LogRepository>();
    }
}
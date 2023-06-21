namespace DataAccess;

public class MaadContext : IdentityDbContext
{
    public MaadContext(DbContextOptions<MaadContext> opt) : base(opt)
    {
    }

    public new DbSet<User> Users { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessPlan> BusinessPlans { get; set; }
    public DbSet<Attribute> Attributes { get; set; }
    public DbSet<AttributeOptionValue> AttributeOptionsValues { get; set; }
    public DbSet<AttributeOption> AttributeOptions { get; set; }
    public DbSet<CustomersPhoneNumber> CustomersPhoneNumbers { get; set; }
    public DbSet<CustomersEmailAddress> CustomersEmailAddresses { get; set; }
    public DbSet<CustomerAddress> CustomersAddresses { get; set; }
    public DbSet<ContactGroup> ContactGroups { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactPhoneNumber> ContactPhoneNumbers { get; set; }
    public DbSet<ContactsEmailAddress> ContactsEmailAddresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductCustomerFavoritesList>? ProductCustomerFavoritesLists { get; set; }
    public DbSet<CustomerPeyGiry> CustomerPeyGiries { get; set; }
    public DbSet<PeyGiryCategory> PeyGiryCategories { get; set; }
    public DbSet<CustomerNote> CustomerNotes { get; set; }
    public DbSet<CustomerNoteHashTag> NoteHashTags { get; set; }
    public DbSet<CustomerNoteHashTable> NoteHashTables { get; set; }
    public DbSet<CustomerNoteAttachment> NoteAttachments { get; set; }
    public DbSet<PeyGiryAttachment> PeyGiryAttachments { get; set; }
    public DbSet<ForooshOrder> ForooshOrders { get; set; }
    public DbSet<ForooshFactor> ForooshFactors { get; set; }
    public DbSet<ForooshPayment> Payments { get; set; }
    public DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
    public DbSet<CustomerFeedbackAttachment> CustomerFeedbackAttachments { get; set; }
    public DbSet<CustomerFeedbackCategory> CustomerFeedbackCategories { get; set; }
    
    public DbSet<Notif> Notifications { get; set; }


    // Undefined Model :
    public DbSet<CustomerActivity> CustomerActivities { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMapping());
        builder.ApplyConfiguration(new UserGroupMapping());

        builder.ApplyConfiguration(new CustomerMapping());
        builder.ApplyConfiguration(new CustomersAddressMapping());
        builder.ApplyConfiguration(new CustomerFeedbackMapping());
        builder.ApplyConfiguration(new CustomerFeedbackAttachmentMapping());
        builder.ApplyConfiguration(new CustomerFeedbackCategoryMapping());
        builder.ApplyConfiguration(new CustomersPhoneNumberMapping());
        builder.ApplyConfiguration(new CustomerNoteMapping());
        builder.ApplyConfiguration(new NoteHashTableMapping());
        builder.ApplyConfiguration(new CustomerPeyGiryMapping());
        builder.ApplyConfiguration(new PeyGiryCategoryMapping());
        builder.ApplyConfiguration(new NotificationMapping());
        builder.ApplyConfiguration(new NoteHashTagMapping());
        builder.ApplyConfiguration(new NoteAttachmentMapping());
        builder.ApplyConfiguration(new PeyGiryAttachmentMapping());


        builder.ApplyConfiguration(new CityMapping());
        builder.ApplyConfiguration(new CountryMapping());
        builder.ApplyConfiguration(new ProvinceMapping());
        builder.ApplyConfiguration(new AttributeOptionsValueMapping());
        builder.ApplyConfiguration(new PlanMapping());
        builder.ApplyConfiguration(new UsersPlansMapping());

        builder.ApplyConfiguration(new CustomersEmailAddressMapping());
        builder.ApplyConfiguration(new ContactGroupMapping());
        builder.ApplyConfiguration(new ContactMapping());
        builder.ApplyConfiguration(new ContactPhoneNumberMapping());
        builder.ApplyConfiguration(new ContactsEmailAddressMapping());
        builder.ApplyConfiguration(new ProductsMapping());
        builder.ApplyConfiguration(new ProductCategoryMapping());
        builder.ApplyConfiguration(new ProductCustomerFavoritesListMapping());

        builder.ApplyConfiguration(new BusinessMapping());
        builder.ApplyConfiguration(new BusinessPlanMapping());


        builder.ApplyConfiguration(new ForooshOrderMapping());
        builder.ApplyConfiguration(new ForooshFactorMapping());
        builder.ApplyConfiguration(new PaymentMapping());


        builder.ApplyConfiguration(new AttributeMapping());
        builder.ApplyConfiguration(new AttributeOptionsMapping());
        builder.ApplyConfiguration(new AttributeOptionsValueMapping());

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            // Find the properties that are our strongly-typed ID
            var properties = entityType
                .ClrType
                .GetProperties()
                .Where(p => p.PropertyType == typeof(Ulid) || p.PropertyType == typeof(Ulid?));

            foreach (var property in properties)
            {
                // Use the value converter for the property
                builder
                    .Entity(entityType.Name)
                    .Property(property.Name)
                    .HasConversion(new UlidToStringConverter());
            }
        }

        // TODO: Seed Database
        // new DbInitializer(builder).Seed();

        base.OnModelCreating(builder);
    }
}


public class UlidToStringConverter : ValueConverter<Ulid, string>
{
    private static readonly ConverterMappingHints defaultHints = new(size: 26);

    public UlidToStringConverter(ConverterMappingHints mappingHints = null) : base(
            convertToProviderExpression: x => x.ToString(),
            convertFromProviderExpression: x => Ulid.Parse(x),
            mappingHints: defaultHints.With(mappingHints))
    { }
}
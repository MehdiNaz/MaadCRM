using Domain.Mapping.BusinessMapping;
using Domain.Mapping.Customers.Foroosh;
using Domain.Models.Customers.Foroosh;

namespace DataAccess;

public class MaadContext : IdentityDbContext
{
    protected MaadContext()
    {
    }
    public MaadContext(DbContextOptions<MaadContext> opt) : base(opt)
    {
    }

    public DbSet<Log> Logs { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<SanAt> SanAts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerCategory> CustomerCategories { get; set; }
    public DbSet<CustomerActivity> CustomerActivities { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessPlan> BusinessPlans { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<CategoryAttribute> CategoryAttributes { get; set; }
    public DbSet<BusinessAttribute> BusinessAttributes { get; set; }
    public DbSet<AttributeOptionsValue> AttributeOptionsValues { get; set; }
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
    //public DbSet<Note>? Notes { get; set; }
    public DbSet<CustomerPeyGiry> CustomerPeyGiries { get; set; }
    public DbSet<CustomerNote> CustomerNotes { get; set; }
    public DbSet<CustomerNoteHashTag> NoteHashTags { get; set; }
    public DbSet<CustomerNoteHashTable> NoteHashTables { get; set; }
    public DbSet<CustomerNoteAttachment> NoteAttachments { get; set; }
    public DbSet<PeyGiryAttachment> PeyGiryAttachments { get; set; }
    public DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
    public DbSet<CustomerRepresentativeHistory> CustomerRepresentativeHistories { get; set; }
    public DbSet<CustomerSubmission> CustomerSubmissions { get; set; }
    public DbSet<ForooshOrder> ForoshOrders { get; set; }
    public DbSet<ForooshFactor> ForoshFactors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Identity : ==>
        builder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        builder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
        builder.ApplyConfiguration(new UserMapping());

        //Customers
        builder.ApplyConfiguration(new CustomerActivityMapping());
        builder.ApplyConfiguration(new CustomerFeedbackHistoryMapping());
        builder.ApplyConfiguration(new CustomerFeedbackMapping());
        builder.ApplyConfiguration(new CustomerMapping());
        builder.ApplyConfiguration(new CustomersAddressMapping());
        builder.ApplyConfiguration(new CustomerCategoryMapping());
        builder.ApplyConfiguration(new CustomerRepresentativeHistoryMapping());
        builder.ApplyConfiguration(new CustomerRepresentativeTypeMapping());
        builder.ApplyConfiguration(new CustomerSubmissionMapping());
        builder.ApplyConfiguration(new CustomersPhoneNumberMapping());
        builder.ApplyConfiguration(new CustomerNoteMapping());
        builder.ApplyConfiguration(new NoteHashTableMapping());
        builder.ApplyConfiguration(new CustomerPeyGiryMapping());
        builder.ApplyConfiguration(new NoteHashTagMapping());
        builder.ApplyConfiguration(new NoteAttachmentMapping());
        builder.ApplyConfiguration(new PeyGiryAttachmentMapping());


        builder.ApplyConfiguration(new AddressMapping());
        builder.ApplyConfiguration(new CityMapping());
        builder.ApplyConfiguration(new CountryMapping());
        builder.ApplyConfiguration(new ProvinceMapping());
        builder.ApplyConfiguration(new AttributeOptionsValueMapping());
        builder.ApplyConfiguration(new LogMapping());
        //builder.ApplyConfiguration(new NoteMapping());
        builder.ApplyConfiguration(new PlanMapping());
        builder.ApplyConfiguration(new UsersPlansMapping());

        builder.ApplyConfiguration(new SanAtMapping());
        builder.ApplyConfiguration(new SettingMapping());
        builder.ApplyConfiguration(new BusinessAttributeMapping());
        builder.ApplyConfiguration(new CategoryAttributeMapping());
        builder.ApplyConfiguration(new AttributeOptionsMapping());
        builder.ApplyConfiguration(new CustomersEmailAddressMapping());
        builder.ApplyConfiguration(new ContactGroupMapping());
        builder.ApplyConfiguration(new ContactMapping());
        builder.ApplyConfiguration(new ContactPhoneNumberMapping());
        builder.ApplyConfiguration(new ContactsEmailAddressMapping());
        builder.ApplyConfiguration(new ProductsMapping());
        builder.ApplyConfiguration(new ProductCategoryMapping());
        builder.ApplyConfiguration(new ProductCustomerFavoritesListMapping());

        builder.ApplyConfiguration(new BusinessMapping());


        builder.ApplyConfiguration(new ForooshOrderMapping());
        builder.ApplyConfiguration(new ForooshFactorMapping());
        
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

        base.OnModelCreating(builder);
    }
}


public class UlidToStringConverter : ValueConverter<Ulid, string>
{
    private static readonly ConverterMappingHints defaultHints = new ConverterMappingHints(size: 26);

    public UlidToStringConverter(ConverterMappingHints mappingHints = null)
        : base(
            convertToProviderExpression: x => x.ToString(),
            convertFromProviderExpression: x => Ulid.Parse(x),
            mappingHints: defaultHints.With(mappingHints))
    {
    }
}
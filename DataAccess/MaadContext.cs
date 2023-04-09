namespace DataAccess;

public class MaadContext : IdentityDbContext
{
    protected MaadContext()
    {
    }
    public MaadContext(DbContextOptions<MaadContext> opt) : base(opt)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // if (!optionsBuilder.IsConfigured)
        // {
        // optionsBuilder.UseNpgsql(
        //     "Host=localhost;Port=5432;Database=MaadDb;Username=postgres;Password=mysecretpassword");
        // }
    }

    public DbSet<Log>? Logs { get; set; }
    public DbSet<Plan>? Plans { get; set; }
    public DbSet<SanAt>? SanAts { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<CustomerCategory>? CustomerCategories { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Province>? Provinces { get; set; }
    public DbSet<Business>? Businesses { get; set; }
    public DbSet<BusinessPlans>? BusinessPlans { get; set; }
    public DbSet<Setting>? Settings { get; set; }
    public DbSet<CategoryAttribute>? CategoryAttributes { get; set; }
    public DbSet<BusinessAttribute>? BusinessAttributes { get; set; }
    public DbSet<AttributeOptionsValue>? AttributeOptionsValues { get; set; }
    public DbSet<AttributeOptions>? AttributeOptions { get; set; }
    public DbSet<CustomersPhoneNumber>? PhoneNumbers { get; set; }
    public DbSet<CustomersEmailAddress>? EmailAddresses { get; set; }
    public DbSet<CustomersAddress>? CustomersAddresses { get; set; }
    public DbSet<ContactGroup>? ContactGroups { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<ContactPhoneNumber>? ContactPhoneNumbers { get; set; }
    public DbSet<ContactsEmailAddress>? ContactsEmailAddresses { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<ProductCategory>? ProductCategories { get; set; }
    public DbSet<ProductCustomerFavoritesList>? ProductCustomerFavoritesLists { get; set; }
    //public DbSet<Note>? Notes { get; set; }
    public DbSet<CustomerPeyGiry>? CustomerPeyGiries { get; set; }
    public DbSet<CustomerNote>? CustomerNotes { get; set; }
    public DbSet<NoteHashTag>? NoteHashTags { get; set; }
    public DbSet<NoteAttachment>? NoteAttachments { get; set; }
    public DbSet<PeyGiryAttachment>? PeyGiryAttachments { get; set; }
    public DbSet<CustomerFeedback>? CustomerFeedbacks { get; set; }
    public DbSet<CustomerRepresentativeHistory>? CustomerRepresentativeHistories { get; set; }
    public DbSet<CustomerSubmission>? CustomerSubmissions { get; set; }
    public DbSet<ForoshOrder>? ForoshOrders { get; set; }
    public DbSet<ForoshFactor>? ForoshFactors { get; set; }
    public DbSet<BusinessPlans>? UsersPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Identity : ==>
        builder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        builder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
        builder.ApplyConfiguration(new UserMapping());

        //Customers
        builder.ApplyConfiguration(new CustomerActivityHistoryMapping());
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


        builder.ApplyConfiguration(new ForoshOrderMapping());
        builder.ApplyConfiguration(new ForoshFactorMapping());
        
        foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(Customer).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Customer.CustomerId)).ValueGeneratedNever();
            if (typeof(Customer).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Customer.BusinessId)).ValueGeneratedNever();


            //if (typeof(User).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(User.CustomerId)).ValueGeneratedNever();


            if (typeof(CustomerActivityHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerActivityHistory.CustomerActivityHistoryId)).ValueGeneratedNever();
            if (typeof(CustomerActivityHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerActivityHistory.CustomerId)).ValueGeneratedNever();



            if (typeof(CustomerRepresentativeHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerRepresentativeHistory.CustomerRepresentativeHistoryId)).ValueGeneratedNever();
            if (typeof(CustomerRepresentativeHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerRepresentativeHistory.CustomerId)).ValueGeneratedNever();



            if (typeof(Log).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Log)).ValueGeneratedNever();
            if (typeof(Plan).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Plan)).ValueGeneratedNever();
            if (typeof(SanAt).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(SanAt)).ValueGeneratedNever();




            if (typeof(CustomerCategory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerCategory.CustomerCategoryId)).ValueGeneratedNever();
            if (typeof(CustomerCategory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerCategory.CustomerId)).ValueGeneratedNever();


            if (typeof(CustomerSubmission).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerSubmission.CustomerSubmissionId)).ValueGeneratedNever();
            if (typeof(CustomerSubmission).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerSubmission.CustomerId)).ValueGeneratedNever();




            if (typeof(Address).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Address.AddressId)).ValueGeneratedNever();




            if (typeof(City).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(City.CityId)).ValueGeneratedNever();
            if (typeof(City).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(City.CustomerId)).ValueGeneratedNever();




            if (typeof(Country).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Country)).ValueGeneratedNever();
            if (typeof(Province).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Province)).ValueGeneratedNever();




            if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.BusinessId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.BusinessAttributeId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.AttributeOptionsId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.AttributeOptionsValueId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.ContactGroupId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.ContactId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.CustomerId)).ValueGeneratedNever();
            // if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.UserId)).ValueGeneratedNever();



            if (typeof(Setting).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Setting)).ValueGeneratedNever();
            if (typeof(CategoryAttribute).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CategoryAttribute)).ValueGeneratedNever();



            if (typeof(BusinessAttribute).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(BusinessAttribute.BusinessAttributeId)).ValueGeneratedNever();



            if (typeof(AttributeOptionsValue).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOptionsValue.AttributeOptionsValueId)).ValueGeneratedNever();
            if (typeof(AttributeOptionsValue).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOptionsValue.AttributeOptionId)).ValueGeneratedNever();



            if (typeof(AttributeOptions).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOptions)).ValueGeneratedNever();
            if (typeof(CustomersPhoneNumber).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomersPhoneNumber)).ValueGeneratedNever();
            if (typeof(CustomersEmailAddress).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomersEmailAddress)).ValueGeneratedNever();
            if (typeof(CustomersAddress).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomersAddress)).ValueGeneratedNever();
            
            if (typeof(ContactGroup).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactGroup.ContactGroupId)).ValueGeneratedNever();
            if (typeof(ContactGroup).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactGroup.BusinessId)).ValueGeneratedNever();



            if (typeof(Contact).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Contact.ContactId)).ValueGeneratedNever();
            if (typeof(Contact).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Contact.BusinessId)).ValueGeneratedNever();



            if (typeof(ContactPhoneNumber).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactPhoneNumber.ContactPhoneNumberId)).ValueGeneratedNever();
            if (typeof(ContactPhoneNumber).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactPhoneNumber.CustomerId)).ValueGeneratedNever();




            if (typeof(ContactsEmailAddress).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactsEmailAddress)).ValueGeneratedNever();



            if (typeof(Product).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Product.ProductId)).ValueGeneratedNever();
            if (typeof(Product).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Product.FavoritesListId)).ValueGeneratedNever();



            if (typeof(ProductCustomerFavoritesList).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ProductCustomerFavoritesList)).ValueGeneratedNever();
            //if (typeof(Note).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Note)).ValueGeneratedNever();
            if (typeof(CustomerPeyGiry).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerPeyGiry)).ValueGeneratedNever();
            if (typeof(CustomerNote).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerNote)).ValueGeneratedNever();
            if (typeof(NoteHashTag).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(NoteHashTag)).ValueGeneratedNever();
            if (typeof(NoteAttachment).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(NoteAttachment)).ValueGeneratedNever();


            if (typeof(PeyGiryAttachment).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(PeyGiryAttachment.PeyGiryAttachmentId)).ValueGeneratedNever();
            if (typeof(PeyGiryAttachment).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(PeyGiryAttachment.PeyGiryNoteId)).ValueGeneratedNever();


            foreach (IMutableProperty property in entityType.GetProperties())
                if (property.ClrType == typeof(Ulid) || property.ClrType == typeof(Ulid?))
                    property.SetValueConverter(new UlidToStringConverter());
        }

        base.OnModelCreating(builder);
    }
}

public class UlidToStringConverter : ValueConverter<Ulid, string>
{
    private static readonly ConverterMappingHints DefaultHints = new(size: 26);

    public UlidToStringConverter(ConverterMappingHints mappingHints = null!)
        : base(
            convertToProviderExpression: x => x.ToString(),
            convertFromProviderExpression: x => Ulid.Parse(x),
            mappingHints: DefaultHints.With(mappingHints))
    {
    }
}

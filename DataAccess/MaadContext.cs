#pragma warning disable CS8618

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
    public DbSet<CustomersAddress> CustomersAddresses { get; set; }
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
    public DbSet<NoteHashTag> NoteHashTags { get; set; }
    public DbSet<NoteHashTable> NoteHashTables { get; set; }
    public DbSet<NoteAttachment> NoteAttachments { get; set; }
    public DbSet<PeyGiryAttachment> PeyGiryAttachments { get; set; }
    public DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
    public DbSet<CustomerRepresentativeHistory> CustomerRepresentativeHistories { get; set; }
    public DbSet<CustomerSubmission> CustomerSubmissions { get; set; }
    public DbSet<ForoshOrder> ForoshOrders { get; set; }
    public DbSet<ForoshFactor> ForoshFactors { get; set; }

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

        builder.ApplyConfiguration(new Domain.Mapping.BusinessMapping.BusinessMapping());


        builder.ApplyConfiguration(new ForoshOrderMapping());
        builder.ApplyConfiguration(new ForoshFactorMapping());

        foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(Customer).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Customer.Id)).ValueGeneratedNever();
            if (typeof(Customer).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid?>(nameof(Customer.CityId)).ValueGeneratedNever();


            //if (typeof(CreatorUser).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CreatorUser.Id)).ValueGeneratedNever();


            // if (typeof(CustomerActivityHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerActivityHistory.CustomerActivityHistoryId)).ValueGeneratedNever();
            if (typeof(ForoshFactor).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ForoshFactor.CustomerId)).ValueGeneratedNever();
            if (typeof(Customer).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid?>(nameof(Customer.CustomerCategoryId)).ValueGeneratedNever();


            if (typeof(CustomerRepresentativeHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerRepresentativeHistory.CustomerRepresentativeHistoryId)).ValueGeneratedNever();
            if (typeof(CustomerRepresentativeHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerRepresentativeHistory.CustomerId)).ValueGeneratedNever();


            if (typeof(Log).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Log.Id)).ValueGeneratedNever();
            if (typeof(Plan).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Plan.PlanId)).ValueGeneratedNever();
            if (typeof(SanAt).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(SanAt.SanAtId)).ValueGeneratedNever();


            if (typeof(CustomerCategory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerCategory.CustomerCategoryId)).ValueGeneratedNever();
            //if (typeof(CustomerCategory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerCategory.Id)).ValueGeneratedNever();


            if (typeof(CustomerSubmission).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerSubmission.CustomerSubmissionId)).ValueGeneratedNever();
            if (typeof(CustomerSubmission).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerSubmission.CustomerId)).ValueGeneratedNever();



            if (typeof(Address).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Address.AddressId)).ValueGeneratedNever();
            if (typeof(Address).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Address.CityId)).ValueGeneratedNever();



            if (typeof(City).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(City.CityId)).ValueGeneratedNever();
            if (typeof(City).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(City.ProvinceId)).ValueGeneratedNever();




            if (typeof(Country).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Country.CountryId)).ValueGeneratedNever();
            if (typeof(Province).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Province.CountryId)).ValueGeneratedNever();




            if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.BusinessId)).ValueGeneratedNever();

            if (typeof(ForoshOrder).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ForoshOrder.ProductId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.AttributeOptionsId)).ValueGeneratedNever();

            if (typeof(CustomerActivity).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerActivity.CustomerId)).ValueGeneratedNever();
            if (typeof(CustomerFeedbackHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerFeedbackHistory.CustomerFeedbackHistoryId)).ValueGeneratedNever();
            if (typeof(CustomerFeedbackHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerFeedbackHistory.CustomerId)).ValueGeneratedNever();
            if (typeof(CustomerFeedbackHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerFeedbackHistory.CustomerFeedbackId)).ValueGeneratedNever();
            //if (typeof(Business).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Business.ContactId)).ValueGeneratedNever();
            if (typeof(BusinessPlan).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(BusinessPlan.BusinessId)).ValueGeneratedNever();
            if (typeof(BusinessPlan).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(BusinessPlan.PlanId)).ValueGeneratedNever();


            if (typeof(CustomerRepresentativeHistory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerRepresentativeHistory.CustomerRepresentativeTypeId)).ValueGeneratedNever();



            // if (typeof(Setting).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Setting.SettingId)).ValueGeneratedNever();
            if (typeof(CategoryAttribute).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CategoryAttribute.CategoryAttributeId)).ValueGeneratedNever();


            //if (typeof(BusinessAttribute).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(BusinessAttribute.BusinessAttributeId)).ValueGeneratedNever();


            if (typeof(AttributeOptionsValue).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOptionsValue.AttributeOptionsValueId)).ValueGeneratedNever();
            if (typeof(AttributeOptionsValue).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOptionsValue.AttributeOptionId)).ValueGeneratedNever();
            if (typeof(AttributeOptionsValue).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOptionsValue.BusinessId)).ValueGeneratedNever();
            if (typeof(AttributeOptionsValue).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOptionsValue.CustomerId)).ValueGeneratedNever();



            if (typeof(AttributeOption).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOption.AttributeOptionsId)).ValueGeneratedNever();
            if (typeof(AttributeOption).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(AttributeOption.BusinessAttributeId)).ValueGeneratedNever();
            if (typeof(AttributeOption).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid?>(nameof(AttributeOption.BusinessId)).ValueGeneratedNever();
            if (typeof(CustomersPhoneNumber).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomersPhoneNumber.CustomerId)).ValueGeneratedNever();
            if (typeof(CustomersEmailAddress).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomersEmailAddress.CustomerId)).ValueGeneratedNever();
            if (typeof(CustomersAddress).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomersAddress.CustomerId)).ValueGeneratedNever();

            if (typeof(ContactGroup).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactGroup.ContactGroupId)).ValueGeneratedNever();
            if (typeof(ContactGroup).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactGroup.BusinessId)).ValueGeneratedNever();



            if (typeof(Contact).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Contact.ContactId)).ValueGeneratedNever();
            if (typeof(Contact).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Contact.BusinessId)).ValueGeneratedNever();
            if (typeof(Contact).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Contact.ContactGroupId)).ValueGeneratedNever();
            if (typeof(Contact).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Contact.EmailId)).ValueGeneratedNever();
            if (typeof(Contact).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Contact.MobileNumberId)).ValueGeneratedNever();



            if (typeof(ContactPhoneNumber).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactPhoneNumber.ContactPhoneNumberId)).ValueGeneratedNever();
            if (typeof(ContactPhoneNumber).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactPhoneNumber.CustomerId)).ValueGeneratedNever();




            if (typeof(ContactsEmailAddress).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ContactsEmailAddress.CustomersEmailAddressId)).ValueGeneratedNever();



            if (typeof(Product).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Product.ProductId)).ValueGeneratedNever();
            if (typeof(Product).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Product.FavoritesListId)).ValueGeneratedNever();


            //if (typeof(ProductCustomerFavoritesList).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ProductCustomerFavoritesList.CustomerId)).ValueGeneratedNever();
            //if (typeof(ProductCustomerFavoritesList).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ProductCustomerFavoritesList.ProductId)).ValueGeneratedNever();
            //if (typeof(Note).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Note)).ValueGeneratedNever();
            
            if (typeof(CustomerPeyGiry).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerPeyGiry.CustomerId)).ValueGeneratedNever();
            if (typeof(CustomerNote).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(CustomerNote.CustomerId)).ValueGeneratedNever();
            if (typeof(NoteHashTag).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(NoteHashTag.CustomerNoteId)).ValueGeneratedNever();
            if (typeof(NoteAttachment).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(NoteAttachment.CustomerNoteId)).ValueGeneratedNever();


            if (typeof(PeyGiryAttachment).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(PeyGiryAttachment.PeyGiryAttachmentId)).ValueGeneratedNever();
            if (typeof(PeyGiryAttachment).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(PeyGiryAttachment.PeyGiryNoteId)).ValueGeneratedNever();


            if (typeof(User).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(User.BusinessId)).ValueGeneratedNever();
            if (typeof(User).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid?>(nameof(User.CityId)).ValueGeneratedNever();


            if (typeof(BusinessAttribute).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(BusinessAttribute.BusinessAttributeId)).ValueGeneratedNever();
            if (typeof(BusinessAttribute).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(BusinessAttribute.CategoryAttributeId)).ValueGeneratedNever();


            if (typeof(CustomerNote).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid?>(nameof(CustomerNote.ProductId)).ValueGeneratedNever();


            if (typeof(Product).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(Product.ProductId)).ValueGeneratedNever();
            if (typeof(ProductCategory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ProductCategory.ProductCategoryId)).ValueGeneratedNever();
            if (typeof(ProductCategory).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(ProductCategory.BusinessId)).ValueGeneratedNever();

            if (typeof(NoteHashTable).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(NoteHashTable.Id)).ValueGeneratedNever();
            if (typeof(NoteHashTable).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(NoteHashTable.BusinessId)).ValueGeneratedNever();
            if (typeof(NoteHashTag).IsAssignableFrom(entityType.ClrType)) builder.Entity(entityType.ClrType).Property<Ulid>(nameof(NoteHashTag.NoteHashTableId)).ValueGeneratedNever();



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
#pragma warning restore CS8618

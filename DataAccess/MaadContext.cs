namespace DataAccess;

public class MaadContext : IdentityDbContext
{
    public MaadContext(DbContextOptions<MaadContext> opt) : base(opt)
    {
    }

    //Identity : ==>
    public DbSet<Role>? Roles { get; set; }
    public DbSet<RoleClaim>? RoleClaims { get; set; }
    public DbSet<UserClaim>? UserClaims { get; set; }
    public DbSet<UserLogin>? UserLogins { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<UserToken>? UserTokens { get; set; }

    public DbSet<Post>? Posts { get; set; }
    public DbSet<Log>? Logs { get; set; }
    public DbSet<Plan>? Plans { get; set; }
    public DbSet<SanAt>? SanAts { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<CustomerCategory>? CustCategories { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Province>? Provinces { get; set; }
    public DbSet<Business>? Businesses { get; set; }
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
    public DbSet<ProductCustomerFavoritesList>? ProductCustomerFavoritesLists { get; set; }
    public DbSet<Note>? Notes{ get; set; }
    public DbSet<CustomerPeyGiry>? CustomerPeyGiries{ get; set; }
    public DbSet<CustomerNote>? CustomerNotes{ get; set; }
    public DbSet<CustomerHashTag>? CustomerHashTags { get; set; }
    public DbSet<NoteAttachment>? NoteAttachments { get; set; }
    public DbSet<PeyGiryAttachment>? PeyGiryAttachments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Identity : ==>
        builder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        builder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
        builder.ApplyConfiguration(new RoleMapping());
        builder.ApplyConfiguration(new RoleClaimMapping());
        builder.ApplyConfiguration(new UserClaimMapping());
        builder.ApplyConfiguration(new UserLoginMapping());
        builder.ApplyConfiguration(new UserRoleMapping());
        builder.ApplyConfiguration(new UserMapping());
        builder.ApplyConfiguration(new UserTokenMapping());

        //Customers
        builder.ApplyConfiguration(new CustomerActivityHistoryMapping());
        builder.ApplyConfiguration(new CustomerActivityMapping());
        builder.ApplyConfiguration(new CustomerFeedbackHistoryMapping());
        builder.ApplyConfiguration(new CustomerMapping());
        builder.ApplyConfiguration(new CustomersAddressMapping());
        builder.ApplyConfiguration(new CustomerCategoryMapping());
        builder.ApplyConfiguration(new CustomerRepresentativeHistoryMapping());
        builder.ApplyConfiguration(new CustomerRepresentativeTypeMapping());
        builder.ApplyConfiguration(new CustomerSubmissionMapping());
        builder.ApplyConfiguration(new CustomersPhoneNumberMapping());
        builder.ApplyConfiguration(new CustomerNoteMapping());
        builder.ApplyConfiguration(new CustomerPeyGiryMapping());
        builder.ApplyConfiguration(new CustomerHashTagMapping());
        builder.ApplyConfiguration(new NoteAttachmentMapping());
        builder.ApplyConfiguration(new PeyGiryAttachmentMapping());


        builder.ApplyConfiguration(new AddressMapping());
        builder.ApplyConfiguration(new CityMapping());
        builder.ApplyConfiguration(new CountryMapping());
        builder.ApplyConfiguration(new ProvinceMapping());
        builder.ApplyConfiguration(new AttributeOptionsValueMapping());
        builder.ApplyConfiguration(new LogMapping());
        builder.ApplyConfiguration(new NoteMapping());
        builder.ApplyConfiguration(new PlanMapping());
        builder.ApplyConfiguration(new PostMapping());
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
        builder.ApplyConfiguration(new ProductCustomerFavoritesListMapping());
        base.OnModelCreating(builder);
    }
}
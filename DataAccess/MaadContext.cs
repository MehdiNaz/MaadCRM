namespace DataAccess;

public class MaadContext : IdentityDbContext
{
    public MaadContext(DbContextOptions<MaadContext> opt) : base(opt)
    {
    }

    public DbSet<Post>? Posts { get; set; }
    public DbSet<Log>? Logs { get; set; }
    public DbSet<Plan>? Plans { get; set; }
    public DbSet<SanAt>? SanAts { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<CustCategory>? CustCategories { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Province>? Provinces { get; set; }
    public DbSet<Moaref>? Moarefs { get; set; }
    public DbSet<Business>? Businesses { get; set; }
    public DbSet<Setting>? Settings { get; set; }
    public DbSet<CategoryAttribute>? CategoryAttributes { get; set; }
    public DbSet<BusinessAttribute>? BusinessAttributes { get; set; }
    public DbSet<AttributeOptionsValue>? AttributeOptionsValues { get; set; }
    public DbSet<AttributeOptions>? AttributeOptions { get; set; }
    public DbSet<PhoneNumber>? PhoneNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CustomerActivityHistoryMapping());
        builder.ApplyConfiguration(new CustomerActivityMapping());
        builder.ApplyConfiguration(new CustomerFeedbackHistoryMapping());
        builder.ApplyConfiguration(new CustomerMapping());
        builder.ApplyConfiguration(new CusCategoryMapping());
        builder.ApplyConfiguration(new CustomerRepresentativeHistoryMapping());
        builder.ApplyConfiguration(new CustomerRepresentativeTypeMapping());
        builder.ApplyConfiguration(new CustomerSubmissionMapping());
        builder.ApplyConfiguration(new PhoneNumberMapping());
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
        builder.ApplyConfiguration(new MoarefMapping());
        builder.ApplyConfiguration(new SettingMapping());
        builder.ApplyConfiguration(new BusinessAttributeMapping());
        builder.ApplyConfiguration(new CategoryAttributeMapping());
        builder.ApplyConfiguration(new AttributeOptionsMapping());
        base.OnModelCreating(builder);
    }
}
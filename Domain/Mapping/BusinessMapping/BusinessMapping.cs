namespace Domain.Mapping.BusinessMapping;

public class BusinessMapping : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.ToTable("Businesses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.BusinessName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Url).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.Hosts).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.CompanyName).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.CompanyAddress).HasMaxLength(255).IsRequired(false);
        
        // builder.HasMany(x => x.Customers).WithOne(x => x.Business).HasForeignKey(x => x.Id);

        //builder.HasOne(x => x.CreatorUser).WithMany(x => x.Businesses).HasForeignKey(x => x.CreatedBy);
        //builder.HasOne(x => x.CreatorUser).WithMany(x => x.Businesses).HasForeignKey(x => x.UpdatedBy);
    }
}
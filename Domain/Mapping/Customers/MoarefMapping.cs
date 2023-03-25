namespace Domain.Mapping.Customers;

public class MoarefMapping:IEntityTypeConfiguration<Moaref>
{
    public void Configure(EntityTypeBuilder<Moaref> builder)
    {
        builder.ToTable("Moarefs");
        builder.HasKey(x => x.MoarefId);
        builder.Property(x => x.MoarefName).HasMaxLength(250).IsRequired();
        builder.Property(x => x.MoarefFamily).HasMaxLength(250).IsRequired();
        builder.Property(x => x.MoarefPhone).HasMaxLength(250).IsRequired();
    }
}
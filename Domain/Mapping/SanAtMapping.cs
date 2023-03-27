namespace Domain.Mapping;

public class SanAtMapping : IEntityTypeConfiguration<SanAt>
{
    public void Configure(EntityTypeBuilder<SanAt> builder)
    {
        builder.ToTable("SanAts");
        builder.HasKey(x => x.SanAtId);
        builder.Property(x => x.SanAtName).HasMaxLength(250).IsRequired();
        builder.Property(x => x.IdUser).HasMaxLength(250).IsRequired();

        builder.HasOne(x => x.User).WithMany(x => x.SanAts).HasForeignKey(x => x.IdUser);
    }
}
using Domain.UnDifined;

namespace Domain.Mapping;

public class SettingMapping : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.ToTable("Settings");
        builder.HasKey(x => x.SettingId);
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Value).HasMaxLength(255).IsRequired();

        
        builder.HasOne(x => x.Business).WithMany(x => x.Setting).HasForeignKey(x => x.BusinessId);
    }
}
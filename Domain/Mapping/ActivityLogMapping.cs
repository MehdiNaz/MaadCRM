using Domain.UnDifined;

namespace Domain.Mapping;

public class ActivityLogMapping : IEntityTypeConfiguration<ActivityLog>
{
    public void Configure(EntityTypeBuilder<ActivityLog> builder)
    {
        builder.ToTable("ActivityLogs");
        builder.Property(x => x.Comment).HasMaxLength(255).IsRequired();
        builder.Property(x => x.IpAddress).HasMaxLength(255).IsRequired();
        builder.Property(x => x.EntityName).HasMaxLength(255).IsRequired();
    }
}
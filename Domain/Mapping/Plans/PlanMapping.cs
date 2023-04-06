namespace Domain.Mapping.Plans;

public class PlanMapping : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");
        builder.HasKey(x => x.PlanId);
        builder.Property(x => x.PlanName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Discount).HasMaxLength(255);
        builder.Property(x => x.DayDurations).IsRequired();
        builder.Property(x => x.CountOfUsers).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Discount).HasMaxLength(250);
    }
}
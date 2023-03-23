namespace Domain.Mapping;

public class PlanMapping : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.PlanName).HasMaxLength(250).IsRequired();
        builder.Property(x => x.DayDurations).IsRequired();
        builder.Property(x => x.CountOfUsers).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.Discount).HasMaxLength(250).IsRequired();
        builder.Property(x => x.FinalPrice).IsRequired();
    }
}

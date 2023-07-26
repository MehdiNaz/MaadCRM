namespace Domain.Mapping.Business.Plans;

public class PlanMapping : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CountOfUsers).IsRequired();
        builder.Property(x => x.PriceOfEachUsers).IsRequired();
        builder.Property(x => x.CountOfDay).IsRequired();
        builder.Property(x => x.PriceOfEachDay).IsRequired();
        builder.Property(x => x.MaxUser).IsRequired();
        builder.Property(x => x.MinUser).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        
        builder.Property(e => e.Version).IsRowVersion();
        
        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.PlansUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_Plan_User");
        
        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.PlansAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_Plan_User");
        
        

    }
}
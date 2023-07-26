namespace Domain.Mapping.Business.Plans;

public class BusinessPlanMapping : IEntityTypeConfiguration<BusinessPlan>
{
    public void Configure(EntityTypeBuilder<BusinessPlan> builder)
    {
        builder.ToTable("BusinessPlan");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CountOfUsers).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.CountOfDay).IsRequired();
        builder.Property(x => x.DateStarted).IsRequired();
        builder.Property(x => x.DateFinished).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        
        builder.Property(e => e.Version).IsRowVersion();

        builder.HasOne(x => x.IdBusinessNavigation)
            .WithMany(x => x.BusinessPlans)
            .HasForeignKey(d => d.IdBusiness)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BusinessPlan_Business");
        
        builder.HasOne(x => x.IdPlanNavigation)
            .WithMany(x => x.BusinessPlans)
            .HasForeignKey(d => d.IdPlan)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BusinessPlan_Plan");
        
        builder.HasOne(x => x.IdPardakhtNavigation)
            .WithMany(x => x.BusinessPlans)
            .HasForeignKey(d => d.IdPardakht)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BusinessPlan_Pardakht");
        
        builder.HasOne(x => x.IdUserNavigation)
            .WithMany(x => x.BusinessPlans)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_BusinessPlan_User");
        
        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.BusinessPlansUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_BusinessPlan_User");
        
        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.BusinessPlansAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_BusinessPlan_User");
    }
}
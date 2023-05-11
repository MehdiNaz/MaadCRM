namespace Domain.Mapping.Customers.PeyGiry;

public class PeyGiryCategoryMapping : IEntityTypeConfiguration<PeyGiryCategory>
{
    public void Configure(EntityTypeBuilder<PeyGiryCategory> builder)
    {
        builder.ToTable("PeyGiryCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Kind).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.IdBusinessNavigation)
            .WithMany(x => x.PeyGiryCategories)
            .HasForeignKey(x => x.BusinessId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Business_PeyGiryCategory");

        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.PeyGiryCategoriesAdded)
            .HasForeignKey(x => x.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_UserAdded_PeyGiryCategory");

        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.PeyGiryCategoriesUpdated)
            .HasForeignKey(x => x.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_UserUpdated_PeyGiryCategory");
    }
}
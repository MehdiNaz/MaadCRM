namespace Domain.Mapping.Customers.PeyGiry;

public class CustomerPeyGiryMapping : IEntityTypeConfiguration<CustomerPeyGiry>
{
    public void Configure(EntityTypeBuilder<CustomerPeyGiry> builder)
    {
        builder.ToTable("CustomerPeyGiries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.Property(e => e.Version).IsRowVersion();

        builder.HasOne(x => x.IdCustomerNavigation)
            .WithMany(x => x.CustomerPeyGiries)
            .HasForeignKey(x => x.IdCustomer)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerPeyGiry_Customers");

        builder.HasOne(x => x.IdPeyGiryCategoryNavigation)
            .WithMany(x => x.CustomerPeyGiries)
            .HasForeignKey(x => x.IdPeyGiryCategory)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PeyGiryCategory_CustomerPeyGiry");

        builder.HasOne(x => x.IdUserUpdateNavigation)
            .WithMany(x => x.CustomerPeyGiriesUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Update_CustomerPeyGiry_User");
        
        builder.HasOne(x => x.IdUserAddNavigation)
            .WithMany(x => x.CustomerPeyGiriesAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_CustomerPeyGiry_User");
        
        builder.HasOne(x => x.IdUserNavigation)
            .WithMany(x => x.CustomerPeyGiries)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_user_CustomerPeyGiry_User");
    }
}

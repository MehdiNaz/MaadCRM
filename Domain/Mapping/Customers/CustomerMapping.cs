namespace Domain.Mapping.Customers;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        
        builder.HasOne(x => x.IdCityNavigation)
            .WithMany(x => x.Customers)
            .HasForeignKey(d => d.IdCity)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customer_City");
        
        builder.HasOne(x => x.IdUserNavigation)
            .WithMany(x => x.Customers)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customer_User");
        
        builder.HasOne(x => x.IdUserNavigation)
            .WithMany(x => x.Customers)
            .HasForeignKey(d => d.IdUserAdded)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Add_Customer_User");
        
        builder.HasOne(x => x.IdUserNavigation)
            .WithMany(x => x.Customers)
            .HasForeignKey(d => d.IdUserUpdated)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_update_Customer_User");

        
        builder.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customer_User");

        builder.HasOne(d => d.IdUserAddNavigation)
            .WithMany(p => p.CustomersAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .HasConstraintName("Customers_AspNetUsers_Added");

        builder.HasOne(d => d.IdUserUpdateNavigation)
            .WithMany(p => p.CustomersUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .HasConstraintName("Customers_AspNetUsers_Updated");


        builder.HasOne(d => d.CustomerMoaref)
            .WithMany(p => p.CustomerMoarefs)
            .HasForeignKey(d => d.CustomerMoarefId)
            .HasConstraintName("Customers_Customer_MoAref");

        // builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.CreatedBy);
        // builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.UpdatedBy);

        // SelfRelation
        // builder.HasOne(x => x.CustomerMoaref).WithMany(x => x.CustomersMoaref).HasForeignKey(x => x.CustomerMoarefId);

    }
}
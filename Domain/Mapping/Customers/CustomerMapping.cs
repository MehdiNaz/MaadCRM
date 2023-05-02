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

        builder.HasOne(d => d.CustomerMoaref)
            .WithMany(p => p.CustomerMoarefs)
            .HasForeignKey(d => d.CustomerMoarefId)
            .HasConstraintName("FK_Customer_MoAref");
        
        builder.HasOne(d => d.IdUserNavigation)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.IdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Customer_User");
        
        builder.HasOne(d => d.IdUserAddNavigation)
            .WithMany(p => p.CustomersAdded)
            .HasForeignKey(d => d.IdUserAdded)
            .HasConstraintName("FK_Customers_User_Added");
        
        builder.HasOne(d => d.IdUserUpdateNavigation)
            .WithMany(p => p.CustomersUpdated)
            .HasForeignKey(d => d.IdUserUpdated)
            .HasConstraintName("FK_Customers_User_Updated");
    }
}
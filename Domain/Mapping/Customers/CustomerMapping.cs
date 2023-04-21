namespace Domain.Mapping.Customers;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
        
        builder.Property(e => e.RowVersion)
            .IsRequired()
            .HasColumnName("rowversion")
            .IsRowVersion()
            .IsConcurrencyToken();
        
        
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


        // builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.CreatedBy);
        // builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.UpdatedBy);

        // SelfRelation
        // builder.HasOne(x => x.CustomerMoaref).WithMany(x => x.CustomersMoaref).HasForeignKey(x => x.CustomerMoarefId);

    }
}
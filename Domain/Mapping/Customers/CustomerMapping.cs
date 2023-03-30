namespace Domain.Mapping.Customers;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.CustomerId);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.EmailAddress).WithMany(x => x.EmaCollection).HasForeignKey(x => x.EmailId);
        builder.HasOne(x => x.PhoneNumber).WithMany(x => x.Customers).HasForeignKey(x => x.PhoneNumberId);
        builder.HasOne(x => x.CustCategory).WithMany(x => x.Customers).HasForeignKey(x => x.CategoryId);

        builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.InsertedBy);
        builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.UpdatedBy);
        builder.HasOne(x => x.ProductCustomerFavoritesList).WithMany(x => x.Customers).HasForeignKey(x => x.FavoritesListId);

        //SelfRelation
        builder.HasOne(x => x.CustomerMoarf).WithMany(x => x.CustomersMoarf).HasForeignKey(x => x.CustomerMoarefId);
    }
}
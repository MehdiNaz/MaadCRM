﻿namespace Domain.Mapping.Customers;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.CustomerId);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();


        builder.HasOne(x => x.user).WithMany(x => x.Customers).HasForeignKey(x => x.InsertedBy);
        builder.HasOne(x => x.user).WithMany(x => x.Customers).HasForeignKey(x => x.UpdatedBy);


        // New Relations ==> OK
        builder.HasMany(x => x.CustomersAddresses).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        builder.HasMany(x => x.FavoritesLists).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        builder.HasMany(x => x.EmailAddresses).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        builder.HasMany(x => x.PhoneNumbers).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        builder.HasMany(x => x.CustomerNotes).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
        builder.HasMany(x => x.CustomerPeyGiries).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

        builder.HasOne(x => x.user).WithMany(x => x.Customers).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.CustomerCategory).WithMany(x => x.Customers).HasForeignKey(x => x.CustomerCategoryId);



        // SelfRelation
        builder.HasOne(x => x.CustomerMoarf).WithMany(x => x.CustomersMoarf).HasForeignKey(x => x.CustomerMoarefId);
    }
}
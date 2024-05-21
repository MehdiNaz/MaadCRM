﻿namespace Domain.Mapping.Business;

public class BusinessMapping : IEntityTypeConfiguration<Models.Businesses.Business>
{
    public void Configure(EntityTypeBuilder<Models.Businesses.Business> builder)
    {
        builder.ToTable("Businesses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.BusinessName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.Url).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.Hosts).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.CompanyName).HasMaxLength(255).IsRequired(false);
        builder.Property(x => x.CompanyAddress).HasMaxLength(255).IsRequired(false);
    }
}
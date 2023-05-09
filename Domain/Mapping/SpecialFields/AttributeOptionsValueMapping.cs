﻿namespace Domain.Mapping.SpecialFields;

public class AttributeOptionsValueMapping : IEntityTypeConfiguration<AttributeOptionValue>
{
    public void Configure(EntityTypeBuilder<AttributeOptionValue> builder)
    {
        builder.ToTable("AttributeOptionsValues");
        builder.HasKey(x => x.AttributeOptionsValueId);
        builder.Property(x => x.AttributeDescriptionValue).HasMaxLength(500).IsRequired();
        builder.Property(x => x.AttributeXMLValue).HasMaxLength(500).IsRequired();
        builder.Property(x => x.AttributeJsonValue).HasMaxLength(500).IsRequired();
        builder.Property(x => x.FilePath).HasMaxLength(500).IsRequired();
        builder.Property(x => x.ImagePath).HasMaxLength(500).IsRequired();

        // builder.HasOne(x => x.Customer).WithMany(x => x.AttributeOptionsValues).HasForeignKey(x => x.CustomerId);
        // builder.HasOne(x => x.AttributeOptions).WithMany(x => x.AttributeOptionsValues).HasForeignKey(x => x.AttributeOptionId);
        // builder.HasOne(x => x.Business).WithMany(x => x.AttributeOptionsValues).HasForeignKey(x => x.Id);
    }
}
﻿namespace Domain.Mapping;

public class SanAtMapping : IEntityTypeConfiguration<SanAt>
{
    public void Configure(EntityTypeBuilder<SanAt> builder)
    {
        builder.ToTable("SanAts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SanAtName).HasMaxLength(250).IsRequired();

        // builder.HasOne(x => x.User).WithMany(x => x.SanAts).HasForeignKey(x => x.UserId);
    }
}
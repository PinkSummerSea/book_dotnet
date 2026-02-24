using System;

namespace AutoLot.Samples.Models.Configuration;

public class RadioConfiguration : IEntityTypeConfiguration<Radio>
{
    public void Configure(EntityTypeBuilder<Radio> builder)
    {
        builder.HasIndex(d => d.CarId, "IX_Radios_CarId").IsUnique();
        builder.HasOne(d => d.CarNavigation).WithOne(p=>p.RadioNavigation).HasForeignKey<Radio>(d=>d.CarId);
    }
}

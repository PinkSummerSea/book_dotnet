using System;

namespace AutoLot.Samples.Models.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasOne(d => d.MakeNavigation)
                .WithMany(p => p.Cars)
                .HasForeignKey(d => d.MakeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Makes_MakeId");

        builder
            .HasMany(p => p.Drivers)
            .WithMany(p => p.Cars)
            .UsingEntity<CarDriver>(
               j => j
                   .HasOne(cd => cd.DriverNavigation)
                   .WithMany(d => d.CarDrivers)
                   .HasForeignKey(nameof(CarDriver.DriverId))
                   .HasConstraintName("FK_InventoryDriver_Drivers_DriverId")
                   .OnDelete(DeleteBehavior.Cascade),
               j => j
                   .HasOne(cd => cd.CarNavigation)
                   .WithMany(c => c.CarDrivers)
                   .HasForeignKey(nameof(CarDriver.CarId))
                   .HasConstraintName("FK_InventoryDriver_Inventory_InventoryId")
                   .OnDelete(DeleteBehavior.ClientCascade),
               j =>
                   {
                       j.HasKey(cd => new { cd.CarId, cd.DriverId });
                   });
    }
}

using System;

namespace AutoLot.Samples.Models;

[Table("InventoryToDrivers", Schema ="dbo")]
public class CarDriver:BaseEntity
{
    [Column("InventoryId")]
    public int CarId {get;set;}
    [ForeignKey(nameof(CarId))]
    public Car CarNavigation {get;set;}
    public int DriverId {get;set;}
    [ForeignKey(nameof(DriverId))]
    public Driver DriverNavigation {get;set;}
}

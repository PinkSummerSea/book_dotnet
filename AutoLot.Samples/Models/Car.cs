using System;

namespace AutoLot.Samples.Models;
[Table("Inventory", Schema = "dbo")]
[Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
[EntityTypeConfiguration(typeof(CarConfiguration))]
public class Car:BaseEntity
{
    [Required, StringLength(50)]
    public string Color { get; set; }
    [Required, StringLength(50)]
    public string PetName { get; set; }
    public int MakeId {get;set;}
    [ForeignKey(nameof(MakeId))]
    public Make MakeNavigation {get;set;}
    public Radio RadioNavigation {get;set;}
    [InverseProperty(nameof(Driver.Cars))]
    public IEnumerable<Driver> Drivers {get;set;}=new List<Driver>();

    [InverseProperty(nameof(CarDriver.CarNavigation))]
    public IEnumerable<CarDriver> CarDrivers {get;set;}=new List<CarDriver>();
    
    // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    // public string Display { get; set; }
}

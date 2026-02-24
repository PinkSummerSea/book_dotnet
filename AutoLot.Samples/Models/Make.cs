using System;

namespace AutoLot.Samples.Models;

public class Make:BaseEntity
{
    [InverseProperty(nameof(Car.MakeNavigation))]
    public IEnumerable<Car> Cars { get; set; } = new List<Car>();
    [Required, StringLength(50)]
    public string Name { get; set; }
}

using System;
using System.Collections;

namespace ComparableCar;

public class Car:IComparable
{
    public int CarId { get; set; }
    public string Name { get; set; } = "";
    public int Speed { get; set; }

    public static IComparer SortByName => new CarNameComparor();
    public Car(string name, int speed, int id)
    {
        CarId = id;
        Name = name;
        Speed = speed;
    }
    public Car()
    {

    }
    int IComparable.CompareTo(object? obj)
    {
        if (obj is Car c)
        {
            return CarId.CompareTo(c.CarId);
        }
        throw new Exception("parameter is not a car");
    }
}

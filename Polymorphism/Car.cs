using System;
using System.Collections;

namespace Polymorphism;

public class Car:IComparable
{
    public string Name { get; set; }
    public int Id { get; set; }
    public static IComparer CompareByName => new CarNameComparer();

    public Car(string name="no name")
    {
        Name=name;
    }
    public Car(int id,string name="no name")
    {
        Name=name;
        Id = id;
    }

    int IComparable.CompareTo(object? obj)
    {
        if(obj is Car c)
        {
            return Id.CompareTo(c.Id);
        }
        throw new Exception("parameter is not a car");
    }
}

using System;

namespace Polymorphism;

public class Circle:Shape
{
    public int Radius { get; set; }
    public Circle(){}
    public Circle(string name) : base(name){}
    public override void DrawSpecific()
    {
        Console.WriteLine("drawing a specific circle {0}",PetName);
    }

    // operator overloading
    public static Circle operator *(Circle c, int i)
    {
        return new Circle {Radius=c.Radius*i};
    }
}

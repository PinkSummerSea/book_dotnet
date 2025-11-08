using System;

namespace CustomInterfaces;

public class Triangle: Shape, IPointy
{
    public Triangle() { }
    public Triangle(string name):base(name)
    {
        
    }
    public override void Draw()
    {
        Console.WriteLine($"drawing triangle {PetName}");
    }
    public byte Points => 3;
}

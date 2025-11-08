using System;

namespace CustomInterfaces;

public class Hexagon: Shape, IPointy, IDraw3D
{
    public Hexagon(){}
    public Hexagon(string name) : base(name) { }
    public override void Draw()
    {
        Console.WriteLine($"drawing hexagon {PetName}");
    }
    public byte Points
    {
        get { return 6; }
    }

    public void Draw3D() => Console.WriteLine("drawing hexagon in 3d");
}

using System;

namespace Polymorphism;

public class Hexagon:Shape,IPointy
{
    public Hexagon(){}
    public Hexagon(string name):base(name){}
    public override void Draw()
    {
        Console.WriteLine("inside Hexagon.Draw()");
    }
    public override void DrawSpecific()
    {
        Console.WriteLine("drawing a specific hexagon {0}", PetName);
    }
    public int Points => 6;
}

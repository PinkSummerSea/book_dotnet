using System;

namespace Polymorphism;

public abstract class Shape
{
    public string PetName {get;set;}
    protected Shape(string name = "no name")
    {
        PetName=name;
    }
    public virtual void Draw()
    {
        Console.WriteLine("inside Shape.Draw()");
    }

    public abstract void DrawSpecific();
}

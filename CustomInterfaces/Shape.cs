using System;

namespace CustomInterfaces;
public abstract class Shape
{
    public string PetName { get; set; } = "default";
    public Shape(){}
    public Shape(string name)
    {
        PetName = name;
    }
    public abstract void Draw();
}

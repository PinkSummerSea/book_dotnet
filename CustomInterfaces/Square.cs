using System;

namespace CustomInterfaces;

public class Square:Shape, IRegularPointy
{
    public Square()
    {

    }
    public Square(string name):base(name)
    {
        
    }
    public override void Draw()
    {
        Console.WriteLine("drawing a square {0}", PetName);
    }
    public int SideLength { get; set; }
    public int NumberOfSides { get; set; }
    public byte Points => 4;
}

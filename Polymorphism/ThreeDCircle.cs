using System;

namespace Polymorphism;

public class ThreeDCircle:Circle
{
    //ignore the DrawSpecific() implementation above me
    public new void DrawSpecific()
    {
        Console.WriteLine("3d drawing in progress...");
    }
}

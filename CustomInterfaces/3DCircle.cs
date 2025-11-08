using System;

namespace CustomInterfaces;

public class ThreeDCircle:Circle,IDraw3D,IDrawable
{
    // public void Draw3D()
    // {
    //     Console.WriteLine("drawing circle in 3d");
    // }
    void IDraw3D.Draw3D()
    {
        Console.WriteLine("this method belongs to IDraw3D interface");
    }
    void IDrawable.Draw3D()
    {
        Console.WriteLine("this method belongs to IDrawable interface");
    }
}

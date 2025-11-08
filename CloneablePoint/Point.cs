using System;

namespace CloneablePoint;

public class Point:ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point(int xPos, int yPos)
    {
        X = xPos;
        Y = yPos;
    }
    public Point()
    {

    }
    public override string ToString() => $"X: {X}, Y: {Y}";
    // public object Clone()
    // {
    //     return new Point(X, Y);
    // }
    public object Clone() => MemberwiseClone();
}

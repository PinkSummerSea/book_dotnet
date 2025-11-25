using System;

namespace AdvancedCSharpLanguageFeatures;

public struct Square
{
    public int Length { get; set; }
    public Square(int l):this()
    {
        Length=l;
    }
    public override string ToString()
    {
        return $"length: {Length}.";
    }
    //rectangles can be explicitly converted to squares
    public static explicit operator Square(Rectangle r)
    {
        return new Square(r.Width);
    }
    public static explicit operator Square(int l)
    {
        return new Square(l);
    }
    public static explicit operator int(Square s)
    {
        return s.Length;
    }
}

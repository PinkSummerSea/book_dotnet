using System;

namespace AdvancedCSharpLanguageFeatures;

public struct Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Rectangle(int w, int h)
    {
        Width=w;
        Height=h;
    }
    public override string ToString()
    {
        return $"width: {Width}, height: {Height}.";
    }
    // when implicit operator is defined, the caller can use explicit conversion as well
    public static implicit operator Rectangle(Square s)
    {
        return new Rectangle(s.Length,s.Length*2);
    }
}

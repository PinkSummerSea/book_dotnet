using System;

namespace CustomGenericMethods;

public struct Point<T>
{
    private T _xPos;
    private T _yPos;

    public Point(T xVal, T yVal)
    {
        _xPos = xVal;
        _yPos = yVal;
    }

    public T X { get => _xPos; set => _xPos = value; }
    public T Y { get => _yPos; set => _yPos = value; }
    public override string ToString()
    {
        return $"X: {X}, Y: {Y}";
    }
    public void resetPoint()
    {
        _xPos = default;
        _yPos = default(T);
    }
}

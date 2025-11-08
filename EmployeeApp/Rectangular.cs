using System;

namespace EmployeeApp;

public class Rectangular:Shape
{
    public Point TopLeft { get; set; } = new Point();
    public Point BottomRight { get; set; } = new Point();
    public void DisplayStats()
    {
        Console.WriteLine($"topleft point x: {TopLeft.X}, y: {TopLeft.Y}, color: {TopLeft.Color}");
        Console.WriteLine($"bottomright point x: {BottomRight.X}, y: {BottomRight.Y}, color: {BottomRight.Color}");
    }

    public override void Draw()
    {
        Console.WriteLine("drawing rectanglular");
    }

    public new void TestMemberShadowing()
    {
        Console.WriteLine("function defined in child class called");
    }
}

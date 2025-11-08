using System;

namespace EmployeeApp;

public abstract class Shape
{
    public abstract void Draw();
    public void TestMemberShadowing()
    {
        Console.WriteLine("function defined in parent class called");
    }
}

using System;

namespace CustomInterfaces;

public interface IRegularPointy:IPointy
{
    int SideLength { get; set; }
    int NumberOfSides { get; set; }
    int Perimeter => SideLength * NumberOfSides;

    //static members
    static string ExampleStaticProperty { get; set; }
    static IRegularPointy()
    {
        ExampleStaticProperty = "foo";
    }
}

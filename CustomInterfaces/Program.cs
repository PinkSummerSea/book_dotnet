using CustomInterfaces;

Hexagon hex = new Hexagon();
Console.WriteLine("Points: {0}", hex.Points);
IPointy itfPointy = hex as IPointy;
if (itfPointy == null)
{
    Console.WriteLine("not pointy");
}
else
{
    Console.WriteLine("it is pointy, with {0} points", itfPointy.Points);
}
if (hex is IPointy itfPointy2)
{
    Console.WriteLine("Again, it is pointy, with {0} points", itfPointy2.Points);
}
Square squ = new();
squ.Draw();
squ.NumberOfSides = 4;
squ.SideLength = 2;
Console.WriteLine("perimiter is {0}", ((IRegularPointy)squ).Perimeter);
IRegularPointy itfrpt = new Square("Super Square")
{
    NumberOfSides = 4,
    SideLength = 10
};
Console.WriteLine("perimeter is {0}", itfrpt.Perimeter);
Console.WriteLine(IRegularPointy.ExampleStaticProperty);
IRegularPointy.ExampleStaticProperty = "updated";
Console.WriteLine(IRegularPointy.ExampleStaticProperty);

static void DrawIn3D(IDraw3D item)
{
    item.Draw3D();
}

Shape[] shapes = [new Hexagon(), new Circle(), new ThreeDCircle()];
for (int i = 0; i < shapes.Length; i++)
{
    if (shapes[i] is IDraw3D itf)
    {
        DrawIn3D(itf);
    }
}
ThreeDCircle c = new();
((IDraw3D)c).Draw3D();
((IDrawable)c).Draw3D();
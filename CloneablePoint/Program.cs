// See https://aka.ms/new-console-template for more information
using CloneablePoint;

Point p1 = new(1, 2);
Point p2 = (Point)p1.Clone();
Console.WriteLine(p1);
Console.WriteLine(p2);
p2.X = 3;
Console.WriteLine(p1);
Console.WriteLine(p2);

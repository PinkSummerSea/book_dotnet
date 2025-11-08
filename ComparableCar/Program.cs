// See https://aka.ms/new-console-template for more information
using ComparableCar;

Car[] cars = new Car[3];
cars[0] = new("c", 10, 2);
cars[1] = new("b", 10, 1);
cars[2] = new("a", 10, 3);
// Array.Sort(cars);
// foreach(Car c in cars)
// {
//     Console.WriteLine("car {0}, id {1}", c.Name,c.CarId);
// }
//Array.Sort(cars, new CarNameComparor());
Array.Sort(cars, Car.SortByName);
foreach(Car c in cars)
{
    Console.WriteLine("car {0}, id {1}", c.Name,c.CarId);
}

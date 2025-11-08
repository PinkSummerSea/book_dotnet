// See https://aka.ms/new-console-template for more information
using System.Collections;
using CustomEnumerator;

Garage g = new Garage();
foreach (Car c in g)
{
    Console.WriteLine("the car {0}'s speed is {1}", c.Name, c.Speed);
}
// IEnumerator carEnumerator = g.GetEnumerator();
// carEnumerator.MoveNext();
// carEnumerator.MoveNext();
// Car currentCar = (Car)carEnumerator.Current;
// Console.WriteLine("current car is {0}", currentCar.Name);
ParkingLot p = new();
// IEnumerator carEnumerator = p.GetEnumerator();
// Console.ReadLine();
foreach(Car c in p.GetCars(true))
{
    Console.WriteLine("the car {0}'s speed is {1}", c.Name, c.Speed);
}

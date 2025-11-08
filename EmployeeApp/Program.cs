// See https://aka.ms/new-console-template for more information
using EmployeeApp;

Employee emp = new("Jane", 30, 1, 100000, "333", EmployeePayTypeEnum.Other);
// emp.DisplayStats();
emp.Age++;
// emp.DisplayStats();
emp.GiveBonus(100);
// Console.WriteLine(emp.Pay);

SavingsAccount acc = new(200000);
SavingsAccount.InterestRate = 0.02;
// acc.DisplayStats();

Rectangular r = new Rectangular
{
    TopLeft = new Point { X = 0, Y = 0, Color = "Pink" },
    BottomRight = new Point { X = 6, Y = 6 }
};
// r.Draw();
// r.TestMemberShadowing();
// ((Shape)r).TestMemberShadowing();
// object r2 = new Rectangular();
// object[] objects = new object[2];
// objects[0] = new Rectangular();
// objects[1] = new Employee();
// foreach(object o in objects)
// {
//     Rectangular rec = o as Rectangular;
//     if (rec == null)
//     {
//         Console.WriteLine("not a rectangular");
//     }
//     else
//     {
//         rec.Draw();
//     }

// }
// r.DisplayStats();

CarRecord carRecord = new("Mazda", "CX5", "Black");
// Console.WriteLine(carRecord);
carRecord.Deconstruct(out string make, out string model, out string color);
// Console.WriteLine($"{make}, {model}, {color}");
var (a, b, c) = carRecord;
(string x, string y, string z) = carRecord;
//Console.WriteLine($"{a}, {b}, {c}");
//Console.WriteLine($"{x}, {y}, {z}");

CarRecord carRecordCopy = carRecord;
//Console.WriteLine(carRecordCopy.Equals(carRecord));
//Console.WriteLine(ReferenceEquals(carRecord, carRecordCopy));
CarRecord otherCarRecord = carRecord with { Model = "CX9" };
// Console.WriteLine(otherCarRecord);
// Console.WriteLine(otherCarRecord.Equals(carRecord));
// Console.WriteLine(ReferenceEquals(carRecord, otherCarRecord));

var tupleExample = ("Jane", 30);
//Console.WriteLine($"{tupleExample.Item1}, {tupleExample.Item2}");
var tupleExample2 = (Name: "Jane", Age: 30);
//Console.WriteLine($"{tupleExample2.Name}, {tupleExample2.Age}");
(string Name, int Age) tupleExample3 = ("Jane", 30);
//Console.WriteLine($"{tupleExample3.Name}, {tupleExample3.Age}");
var (name, age) = ("Jane", 30);
//Console.WriteLine($"{name}, {age}");

Manager m = new() { Name = "Jane", Age = 30, StockOptions = 10 };
m.DisplayStats();

Manager m2 = new Manager("Kate", 35, 3, 200000, "ccc", 20);
m2.DisplayStats();
Console.WriteLine(m2.StockOptions);
Console.WriteLine(m2.GetBenefitCost());
m2.GiveBonus(10);
m2.DisplayStats();

SalesPerson s = new() { Name = "John", Pay = 50000 };
s.GiveBonus(10);
s.DisplayStats();

s.GivePromotion();
m.GivePromotion();
m2.GivePromotion();

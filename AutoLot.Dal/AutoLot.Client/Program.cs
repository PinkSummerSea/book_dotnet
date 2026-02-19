using AutoLot.Dal.Models;
using AutoLot.Dal.DataOperations;
using AutoLot.Dal.BulkImport;
InventoryDal dal = new();
List<CarViewModel> list = dal.GetAllInventory();
Console.WriteLine("========== All Cars ==========");
Console.WriteLine("Id\tMake\tColor\tPet Name");
foreach(CarViewModel c in list)
{
    Console.WriteLine($"{c.Id}\t{c.Make}\t{c.Color}\t{c.PetName}");
}
Console.WriteLine("=========== First Car By Color =========");
CarViewModel car = dal.GetCar(list.OrderBy(x=>x.Color).Select(x=>x.Id).First());
Console.WriteLine("Id\tMake\tColor\tPet Name");
Console.WriteLine($"{car.Id}\t{car.Make}\t{car.Color}\t{car.PetName}");
Console.WriteLine("====================");
try
{
    dal.DeleteCar(5);
    Console.WriteLine("CAR DELETED");
}
catch (Exception e)
{
    Console.WriteLine($"an exception occured: {e.Message}");
}

dal.InsertAuto(new Car{Color="Blue", MakeId=5, PetName="TowMonster"});
list = dal.GetAllInventory();
var newCar = list.First(x=>x.PetName=="TowMonster");
Console.WriteLine("=========== New Car =========");
Console.WriteLine("Id\tMake\tColor\tPet Name");
Console.WriteLine($"{newCar.Id}\t{newCar.Make}\t{newCar.Color}\t{newCar.PetName}");
var firstCarPetName = dal.LookUpPetName(1);
Console.WriteLine("=========== PetName of the First Car By Id =========");
Console.WriteLine($"{firstCarPetName}");
Console.WriteLine("=========== Transaction Test =========");
dal.ProcessCreditRisk(false, 1);

void DoBulkCopy()
{
    Console.WriteLine("=========== Do Bulk Copy =========");
    var cars = new List<Car>
    {
        new(){Color="Blue", MakeId=1, PetName="MyCar1"},
        new(){Color="Pink", MakeId=2, PetName="MyCar2"},
        new(){Color="Yellow", MakeId=3, PetName="MyCar3"},
        new(){Color="Purple", MakeId=4, PetName="MyCar4"}
    };
    ProcessBulkImport.ExecuteBulkCopy(cars, "Inventory");
    InventoryDal dal = new();
    List<CarViewModel> list = dal.GetAllInventory();
    Console.WriteLine("========== All Cars ==========");
    Console.WriteLine("Id\tMake\tColor\tPet Name");
    foreach(var c in list)
    {
        Console.WriteLine($"{c.Id}\t{c.Make}\t{c.Color}\t{c.PetName}");
    }
}
DoBulkCopy();
Console.WriteLine("More Fun with Entity Framework Core");

// ClearSampleData();
// AddRecords();
ClearSampleData();
LoadMakeAndCarData();
//QueryData();
//FilterData();
//SortData();
//Paging();
//SingleRecordQueries();
//RelatedData();
//ManyToMany();
static void LoadMakeAndCarData()
{
    //The factory is not meant to be used like this, but it’s demo code :-)
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    List<Make> makes = new()
    {
        new() { Name = "VW" },
        new() { Name = "Ford" },
        new() { Name = "Saab" },
        new() { Name = "Yugo" },
        new() { Name = "BMW" },
        new() { Name = "Pinto" },
    };
    context.Makes.AddRange(makes);
    context.SaveChanges();

    List<Car> inventory = new()
    {
        new() { MakeId = 1, Color = "Black", PetName = "Zippy" },
        new() { MakeId = 2, Color = "Rust", PetName = "Rusty" },
        new() { MakeId = 3, Color = "Black", PetName = "Mel" },
        new() { MakeId = 4, Color = "Yellow", PetName = "Clunker" },
        new() { MakeId = 5, Color = "Black", PetName = "Bimmer" },
        new() { MakeId = 5, Color = "Green", PetName = "Hank" },
        new() { MakeId = 5, Color = "Pink", PetName = "Pinky" },
        new() { MakeId = 6, Color = "Black", PetName = "Pete" },
        new() { MakeId = 4, Color = "Brown", PetName = "Brownie" },
        new() { MakeId = 1, Color = "Rust", PetName = "Lemon", IsDrivable = false },
    };
    context.Cars.AddRange(inventory);
    context.SaveChanges();
    //context.Cars.Add(new() { MakeId = 1, Color = "Rust", PetName = "Lemon", IsDrivable = false});
    //context.SaveChanges();
}
static void AddRecords()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    var newMake = new Make{Name="BMW"};
    //Console.WriteLine(context.Entry(newMake).State);
    context.Makes.Add(newMake);
    //Console.WriteLine(context.Entry(newMake).State);
    context.SaveChanges();
    //Console.WriteLine(context.Entry(newMake).State);

    List<Car> cars = new()
    {
        new Car{Color="Yellow", MakeId=newMake.Id,PetName="Herbie"},
        new(){Color="White", MakeId=newMake.Id,PetName="Mach 5"},
        new(){Color="Pink", MakeId=newMake.Id,PetName="Avon"},
        new(){Color="Blue", MakeId=newMake.Id,PetName="Blueberry"},
    };
    context.Cars.AddRange(cars);

    var anotherMake = new Make {Name="Mazda"};
    var anotherCar = new Car {Color="Red", PetName="Apple"};
    ((List<Car>)anotherMake.Cars).Add(anotherCar);
    context.Makes.Add(anotherMake);
    context.SaveChanges();

    var drivers = new List<Driver>
    {
        new() { PersonInfo = new Person { FirstName = "Fred", LastName = "Flinstone" } },
        new() { PersonInfo = new Person { FirstName = "Wilma", LastName = "Flinstone" } },
        new() { PersonInfo = new Person { FirstName = "BamBam", LastName = "Flinstone" } },
        new() { PersonInfo = new Person { FirstName = "Barney", LastName = "Rubble" } },
        new() { PersonInfo = new Person { FirstName = "Betty", LastName = "Rubble" } },
        new() { PersonInfo = new Person { FirstName = "Pebbles", LastName = "Rubble" } }
    };

    var carsForM2M = context.Cars.Take(2).ToList();
    ((List<Driver>)carsForM2M[0].Drivers).AddRange(drivers[..3]);
    ((List<Driver>)carsForM2M[1].Drivers).AddRange(drivers[3..]);
    context.SaveChanges();
}

static void ClearSampleData()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    var entities = new[]
    {
        typeof(CarDriver).FullName,
        typeof(Radio).FullName,
        typeof(Driver).FullName,
        typeof(Car).FullName,
        typeof(Make).FullName
    };
    foreach(var entityName in entities)
    {
        var entity = context.Model.FindEntityType(entityName);
        var tableName = entity.GetTableName();
        var schemaName = entity.GetSchema();
        context.Database.ExecuteSqlRaw($"DELETE FROM {schemaName}.{tableName}");
        context.Database.ExecuteSqlRaw($"DBCC CHECKIDENT (\"{schemaName}.{tableName}\", RESEED, 0);");
    }
    
}

static void QueryData()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    IQueryable<Car> cars = context.Cars;
    foreach(var car in cars)
    {
        Console.WriteLine($"{car.PetName} is {car.Color}");
    }
    context.ChangeTracker.Clear();
    List<Car> cars2 = context.Cars.ToList();
    foreach(var car in cars2)
    {
        Console.WriteLine($"{car.PetName} is {car.Color}");
    }
}

static void FilterData()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    IQueryable<Car> cars = context.Cars.Where(c => c.Color=="Yellow" && c.PetName=="Clunker");
    Console.WriteLine("yellow cars named Clunker:");
    foreach(var car in cars)
    {
        Console.WriteLine($"{car.PetName} is {car.Color}");
    }
    context.ChangeTracker.Clear();
    IQueryable<Car> colorfulCars = context.Cars.Where(c => !string.IsNullOrWhiteSpace(c.Color));
    Console.WriteLine("car with color:");
    foreach(var car in colorfulCars)
    {
        Console.WriteLine($"{car.PetName} is {car.Color}");
    }
    context.ChangeTracker.Clear();
}

static void SortData()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    IQueryable<Car> cars = context.Cars.OrderBy(c=>c.PetName).ThenByDescending(c=>c.Color).Reverse();
    foreach(var car in cars)
    {
        Console.WriteLine($"{car.PetName} is {car.Color}");
    }
    context.ChangeTracker.Clear();
}

static void Paging()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    IQueryable<Car> cars = context.Cars.Skip(2).Take(2);
    foreach(var car in cars)
    {
        Console.WriteLine($"{car.PetName} is {car.Color}");
    }
    context.ChangeTracker.Clear();
}

static void SingleRecordQueries()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    var firstCar = context.Cars.First(c=>c.Color=="Yellow");
    Console.WriteLine($"first car is {firstCar.PetName}");
    var firstYellowCar = context.Cars.First(c=>c.Color=="Yellow");
    Console.WriteLine($"first yellow car is {firstYellowCar.PetName}");
    var firstCarNotFound = context.Cars.FirstOrDefault(c=>c.Color=="ddd");
    Console.WriteLine(firstCarNotFound==null);
    var lastYellowCar = context.Cars.OrderBy(c=>c.Id).Last(c=>c.Color=="Rust");
    Console.WriteLine($"last rust car is {lastYellowCar.PetName}");
    var foundCar = context.Cars.Find(1);
    Console.WriteLine($"found car is {foundCar.PetName}");
    context.ChangeTracker.Clear();
}

static void RelatedData()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    var carWithMakes = context.Cars.Include(c => c.MakeNavigation).ToList();
    foreach(var c in carWithMakes)
    {
        Console.WriteLine($"{c.PetName} is a {c.Color} {c.MakeNavigation.Name}");
    }
    context.ChangeTracker.Clear();
}

static void ManyToMany()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    var carWithDrivers = context.Cars.Include(c => c.Drivers).Where(c => c.Drivers.Any());
    foreach(var c in carWithDrivers)
    {
        Console.WriteLine($"{c.PetName} has {c.Drivers.Count()} drivers");
    }
    context.ChangeTracker.Clear();
}

//UpdateData();
static void UpdateData()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    var car = context.Cars.First();
    car.Color="Green";
    context.SaveChanges();
}
static void DeleteData()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    var car = context.Cars.First();
    context.Cars.Remove(car);

    context.SaveChanges();
}
UsingFromSql();
static void UsingFromSql()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    IEntityType metadata = context.Model.FindEntityType(typeof(Car).FullName);
    Console.WriteLine(metadata.GetSchema());
    Console.WriteLine(metadata.GetTableName());
    int id = 1;
    var car = context.Cars.FromSqlInterpolated($"SELECT * FROM dbo.Inventory WHERE Id={id}").Include(c=>c.MakeNavigation).First();
  
    Console.WriteLine(car.PetName);
}

static void Projections()
{
    var context = new ApplicationDbContextFactory().CreateDbContext(null);
    List<int> ids = context.Cars.Select(c => c.Id).ToList();

    var cmvs = context.Cars.Select(c => new CarMakeViewModel
    {
        MakeId = c.MakeId,
        Make = c.MakeNavigation.Name,
        CarId = c.Id,
        IsDrivable = c.IsDrivable,
        Display = c.Display,
        DateBuilt = c.DateBuilt.GetValueOrDefault(new DateTime(2020,01,01)),
        Color = c.Color,
        PetName = c.PetName
    });
}
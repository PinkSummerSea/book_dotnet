// See https://aka.ms/new-console-template for more information
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Polymorphism;

Circle c1 = new Circle();
Console.WriteLine(c1.PetName);
c1.Draw();
Hexagon h1 = new Hexagon("hhh");
Console.WriteLine(h1.PetName);
h1.Draw();

Shape[] shapes = {new Circle("a"), new Hexagon("b"), new Circle("c")};
foreach(Shape s in shapes)
{
    s.DrawSpecific();
}

ThreeDCircle ccc = new();
ccc.DrawSpecific();
((Circle)ccc).DrawSpecific();

IPointy[] pointyThings = {new Fork(), new Hexagon()};
foreach(IPointy p in pointyThings)
{
    Console.WriteLine(p.Points);
}
Car[] myCars =
{
    new Car(3,"zz"),
    new Car(2,"yy"),
    new Car(1,"xx"),
    new Car(4,"uu")
};

//Array.Sort(myCars);
//Array.Sort(myCars, new CarNameComparer());
Array.Sort(myCars, Car.CompareByName);
foreach(Car c in myCars)
{
    //Console.WriteLine(c.Id);
    Console.WriteLine(c.Name);
}

// blend collection initialization syntax with object initialization syntax
List<Car> myCarList = new List<Car>
{
    new Car {Name="fancy car", Id=888},
};

List<Car> myCarList2 = [
    new(){Name="fancy car 2", Id=8888},
];

Dictionary<string, Car> myCarDic1 = new Dictionary<string, Car>
{
    {"a", new Car {Name="a", Id=55}},
    {"b", new Car {Name="b", Id=555}},
};
Dictionary<string,Car> myCarDic2 = new()
{
    ["a"]=new Car {Name="a",Id=66},
    ["b"]=new(){Name="b",Id=666}
};
Dictionary<string,Car> myCarDic3 = new();
myCarDic3.Add("a", new Car{Name="a",Id=777});

ObservableCollection<Car> observableCarList = new()
{
    new Car {Name="lala", Id=234},
    new Car {Name="haha", Id=567}
};

observableCarList.CollectionChanged+=carListChanged;
static void carListChanged(object sender, NotifyCollectionChangedEventArgs e)
{
    Console.WriteLine("action for this event: {0}",e.Action);
    // if item added
    if (e.Action == NotifyCollectionChangedAction.Add)
    {
        Console.WriteLine("here are the new items:");
        // show new items that were inserted
        foreach(Car c in e.NewItems)
        {
            Console.WriteLine(c.Name);
        }
    }
    // if item removed  
    if (e.Action == NotifyCollectionChangedAction.Remove)
    {
        Console.WriteLine("here are the old items:");
        //show old items
        foreach(Car c in e.OldItems)
        {
            Console.WriteLine(c.Name);
        }
    }
}

observableCarList.Add(new Car {Name="kaka",Id=987});
observableCarList.RemoveAt(0);

string s1 = "abc";
Console.WriteLine(s1.ToDouble());

Circle cc = new Circle {Radius=2};
Circle doubled = cc*2;
Console.WriteLine(doubled.Radius);
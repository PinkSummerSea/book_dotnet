using Linq;

static void QueryOverStrings()
{
    string[] strings = {"abc", "xyz 2", "lala lala"};
    
    var subset =
     strings.Where(s=>s.Contains(' ')).OrderBy(s=>s).Select(s=>s);
    foreach(string s in subset)
    {
        Console.WriteLine("Item: {0}",s);
    }

    string[] subsetArray = 
        (from s in strings
        where s.Contains(' ')
        orderby s
        select s).ToArray();
    var query = from s in strings
        where s.Contains('d')
        orderby s
        select s;
    List<string> subsetList = query.ToList();
    var first = query.FirstOrDefault("default value");
    Console.WriteLine("first or default result of the query is {0}", first);
    int count = query.Count();
    Console.WriteLine("result count of the query is {0}", count);
}

QueryOverStrings();

static void DisplayDiff()
{
    var first = new(string Name, int Age)[]
    {
        ("Amy", 30),
        ("Dorcy", 40)
    };

    var second = new(string Name, int Age)[]
    {
        ("Bob", 30),
        ("Kevin", 22)
    };

    var diffByAge = first.ExceptBy(second.Select(p2=>p2.Age), p1=>p1.Age);
    foreach(var p in diffByAge)
    {
        Console.WriteLine(p);
    }
}
DisplayDiff();

static void DisplayIntersection()
{
    List<string> myCars = new()
    {
        "Yugo","Aztec","BMW"
    };
    List<string> yourCars = new List<string>
    {
        "BMW","Saab","Aztec"
    };
    var query1 = from m in myCars select m;
    var query2 = from y in yourCars select y;
    var intersection = query1.Intersect(query2);
    foreach(var car in intersection)
    {
        Console.WriteLine(car);
    }
}

DisplayIntersection();

ProductInfo[] items =
[
    new ProductInfo{Name="coffee", Description="yummy",NumberInStock=10},
    new ProductInfo{Name="milk", Description="silky",NumberInStock=3},
    new ProductInfo{Name="sugar", Description="sweet",NumberInStock=5},
    new ProductInfo{Name="sausage", Description="juicy",NumberInStock=33},
    new ProductInfo{Name="cookie", Description="crunchy",NumberInStock=56}
];

void PagingWithRanges()
{
    var list = (from item in items where item.NumberInStock > 5 select item).Take(..^2);//skip the last 2 item in result

    foreach(var item in list)
    {
        Console.WriteLine(item);
    }
}
PagingWithRanges();
Console.WriteLine(".........");
void ProjectToDifferentDataType()
{
    var query = 
        from item 
        in items
        where item.NumberInStock > 10
        select new ProductInfoSmall{Name=item.Name, Description=item.Description};
        //select new { item.Name, item.Description}; anonymous type
    foreach(var item in query)
    {
        Console.WriteLine(item);
    }
};
ProjectToDifferentDataType();
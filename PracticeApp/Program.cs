// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// SimpleArrays();
// PrintArrays(CreateArray());
// Add(2, 6, out int ans, out string truth, out _);
// Console.WriteLine(ans);
// Console.WriteLine(truth);
// string a = "团团";
// string b = "可爱";
// Console.WriteLine($"{a}, {b}");
// SwapStrings(ref a, ref b);
// Console.WriteLine($"{a}, {b}");
// Console.WriteLine(Sum(1.1, 1.2, 4.9));
// Console.WriteLine(Sum());
// Console.WriteLine(Sum([3, 6]));
// AskForBonus(EmployeeTypeEnum.Manager);
// Console.WriteLine(Enum.GetUnderlyingType(typeof(EmployeeTypeEnum)));
// Console.WriteLine((int)EmployeeTypeEnum.Manager);
// Person danny = new Person(88, "Danny");
// danny.Display();
// SendPersonByValue(danny);
// danny.Display();
// Person amy = new Person(88, "amy");
// amy.Display();
// SendPersonByRef(ref amy);
// amy.Display();
// int? myInt = 1;
// Console.WriteLine($"{myInt.Value}");
// Array enumData = Enum.GetValues(typeof(EmployeeTypeEnum));
// for(int i = 0; i<enumData.Length; i++)
// {
//     Console.WriteLine($"name:{enumData.GetValue(i)}, value:{enumData.GetValue(i):D}");
// }
TestNull(null);
static void TestNull(string[] args)
{
    Console.WriteLine($"you sent me {args?.Length??0} arguments.");
}
static void SimpleArrays()
{
    int[] myInts = [1, 2, 3];
    foreach (int i in myInts)
    {
        Console.WriteLine(i);
    }
    string[] books = new string[100];
    var a = new[] { 1, 2 };
    Console.WriteLine(a.ToString());
    object[] b = [false, 1];
    Console.WriteLine(b[0].GetType());
}
static void PrintArrays(int[] myInts)
{
    foreach (int i in myInts)
    {
        Console.WriteLine(i);
    }
}
static int[] CreateArray()
{
    int[] arr = [1, 2, 9, 91];
    Array.Clear(arr, 1, 1);
    Array.Reverse(arr);
    Range r = 0..3;
    int[] newArr = arr[r];
    Index idx = ^2;
    newArr[idx] = 100;
    Console.WriteLine(newArr.ElementAt(^1));
    return newArr;
}
static void Add(int a, int b, out int c, out string d, out bool e)
{
    c = a + b;
    d = "团团美美猪";
    e = true;
}
static void SwapStrings(ref string s1, ref string s2)
{
    string temp = s1;
    s1 = s2;
    s2 = temp;
    // can also use tuple to swap values (s1, s2)=(s2,s1)
}
static double Sum(params double[] values)
{
    double sum = 0;
    for (int i = 0; i < values.Length; i++)
    {
        sum += values[i];
    }
    return sum;
}

static void AskForBonus(EmployeeTypeEnum t)
{
    switch (t)
    {
        case EmployeeTypeEnum.Manager:
            Console.WriteLine("ok");
            break;
        case EmployeeTypeEnum.Contractor:
            Console.WriteLine("no");
            break;
    }
}

static void SendPersonByValue(Person p)
{
    p.age = 99;
    p = new Person(100, "Anson");
}

static void SendPersonByRef(ref Person p)
{
    p.age = 99;
    p = new Person(100, "Anson");
}
enum EmployeeTypeEnum
{
    Manager,
    Contractor,
    President
}

class Person
{
    public int age;
    public string? name;

    public Person(int a, string n)
    {
        age = a;
        name = n;
    }

    public Person() { }
    public void Display()
    {
        Console.WriteLine($"name: {name}, age: {age}.");
    }
}


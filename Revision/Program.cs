// See https://aka.ms/new-console-template for more information
using Revision;


Console.WriteLine(Revision.Program.SayHello());
Console.WriteLine("Hello, World!");
for(int i = 0; i<args.Length; i++)
{
    Console.WriteLine("Arg: {0}", args[i]);
}
//number formatting
Console.WriteLine("currency format: {0:c}", 99999);
Console.WriteLine("d9 format: {0:d9}", 99999);
Console.WriteLine("f3 format: {0:f3}", 99999);
Console.WriteLine("n format: {0:n}",99999);
Console.WriteLine("char.IsWhiteSpace('hello world',5):{0}", char.IsWhiteSpace("hello world", 5));
bool b = bool.Parse("True");
int k = int.Parse("8");
char c = char.Parse("w");
Console.WriteLine(b);
Console.WriteLine(k);
Console.WriteLine(c);

static void ParseFromStringWithTryParse(string s)
{
    if(bool.TryParse(s, out bool result))
    {
        Console.WriteLine("bool tryparse succeeded, out is {0}", result);
    }
    else
    {
        Console.WriteLine("default value of bool out is {0}", result);
    }

    if(double.TryParse(s, out double result2))
    {
        Console.WriteLine("double tryparse succeeded, out is {0}", result2);
    }else
    {
        Console.WriteLine("default value of double out is {0}", result2);
    }
}

ParseFromStringWithTryParse("22");

static void UseDatesAndTimes()
{
    DateTime dt = new(2025,6,30);
    Console.WriteLine(dt);
    Console.WriteLine("the day of {0} is {1}", dt.Date, dt.DayOfWeek);
    Console.WriteLine(dt.AddMonths(7));
    TimeSpan ts = new(1,20,10); //hour, min, seconds
    Console.WriteLine(ts);
    Console.WriteLine(ts.Subtract(new TimeSpan(0,15,10)));
}

UseDatesAndTimes();

string[] carTypes = {"Ford","Toyota"};
foreach(string s in carTypes)
{
    Console.WriteLine("car type is {0}", s);
}

string stringData = "haha";

Console.WriteLine(stringData.Length > 5 ? "longer than 5" : "not longer than 5");
// Console.Write("enter your favorite day of the week: ");
// if(Enum.TryParse(Console.ReadLine(), ignoreCase:true, out DayOfWeek day))
// {
//     Console.WriteLine("you like {0}", day.ToString().ToUpper());
//     switch (day)
//     {
//         case DayOfWeek.Friday:
//             Console.WriteLine("friday is the best");
//             break;
//         case DayOfWeek.Saturday:
//         case DayOfWeek.Sunday:
//             Console.WriteLine("I like the weekends, too!");
//             break;
//         case DayOfWeek.Monday:
//             goto case DayOfWeek.Tuesday;
//         case DayOfWeek.Tuesday:
//             Console.WriteLine("wow,interesting...");
//             break;
//         default:
//             Console.WriteLine("alright.");
//             break;
//     }
// }
// else
{
    Console.WriteLine("invalid day");
};

// Console.WriteLine("1 [C#], 2 [VB]");
// Console.Write("Pick your language preference:");

// object? pref = Console.ReadLine();
// var choice = int.TryParse(pref?.ToString(), out int p) ? p:pref;
// switch (choice)
// {
//     case int i when i == 2:
//     case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
//         Console.WriteLine("ok it's vb.");
//         break;
//     case int i when i ==1:
//     case string s when s.Equals("c#", StringComparison.OrdinalIgnoreCase):
//         Console.WriteLine("ok it's c#");
//         break;
//     default:
//         Console.WriteLine("ok you have your own preference.");
//         break;
// }

static string RockPaperScissors(string first, string second)
{
    return (first, second) switch
    {
        ("paper","rock") => "paper wins",
        ("paper","scissors")=> "scissors wins",
        (_,_)=>"too lazy to list",
    };
}

//Console.WriteLine(RockPaperScissors("paper","scissors"));

static void FillTheseValues(out int a, out string b, out string c)
{
    a = 1;
    b="lala";
    c="wawa";
}

FillTheseValues(out int myInt, out string myStr1, out string myStr2);
Console.WriteLine("{0},{1},{2}", myInt, myStr1, myStr2);

// reference parameters
static void SwapStrings(ref string s1, ref string s2)
{
    string temp = s1;
    s1 = s2;
    s2 = temp;
}

string s1 = "s1";
string s2 = "s2";
SwapStrings(ref s1, ref s2);
Console.WriteLine("s1 is now {0}, s2 is now {1}", s1, s2);

EmployerTypeEnum e = EmployerTypeEnum.Contractor;
static void AskForBonus(EmployerTypeEnum e)
{
    Console.WriteLine((int)e);
    Console.WriteLine(Enum.GetUnderlyingType(e.GetType()));
    Array a = Enum.GetValues(e.GetType());
    for(int i = 0; i < a.Length; i++)
    {
        Console.WriteLine("name {0}, value {0:D}", a.GetValue(i));
    }
    switch (e)
    {
        case EmployerTypeEnum.Manager:
            Console.WriteLine("bonus 100");
            break;
        case EmployerTypeEnum.Contractor:
            Console.WriteLine("bonus 50");
            break;
        case EmployerTypeEnum.Sales:
            Console.WriteLine("bonus 10");
            break;
        default:
            Console.WriteLine("invalid");
            break;
    }
}
AskForBonus(e);
Employee emp = new Employee(name:"Ken",age:22,id:1,pay:100,payType:EmployeePayTypeEnum.Hourly);
emp.HireDate=DateTime.Today;
Console.WriteLine(emp.PayType);
emp.GiveBonus(10);
Console.WriteLine(emp.Pay);

// object init syntax
Employee emp2 = new Employee {Name="Lily", Age=22,Id=2,Pay=900,PayType=EmployeePayTypeEnum.Commission,HireDate=new DateTime(2020,11,21)};


emp2.GiveBonus(10);
Console.WriteLine(emp2.Pay);


enum EmployerTypeEnum
{
    Manager,
    Contractor,
    Sales
}



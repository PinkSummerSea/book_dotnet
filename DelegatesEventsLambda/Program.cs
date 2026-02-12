using DelegatesEventsLambda;

// create a BinaryOp delegate object, make it point to method SimpleMath.Add
BinaryOp b = new(SimpleMath.Add);

// invoke the Add method indirectly using the delgate object
Console.WriteLine("1+2={0}",b(1,2));

Car c = new();
c.RegisterMethodToList(OnCarEngineEvent);
c.RegisterMethodToList(new Car.CarEngineHandler(OnCarEngineEvent2));
c.UnRegisterMethodToList(OnCarEngineEvent);
c.AboutToExplode+=OnCarEngineEvent;
c.AboutToExplode += delegate (object sender, CarEventArgs e)
{
    if(sender is Car c)
    {
        Console.WriteLine("message no.3 from {0}", c.PetName);
        Console.WriteLine(e.msg);
    }
};
c.AboutToExplode+=(_,_) => Console.WriteLine("hahaha, lambda expression with discards"); // lambda expression
for(int i = 0; i<11; i++)
{
    c.Accelarate(10);
}

static void OnCarEngineEvent(object sender, CarEventArgs e)
{
    if(sender is Car c)
    {
        Console.WriteLine("message from the car object {0}:", c.PetName);
        Console.WriteLine(e.msg);
    }
   
}

static void OnCarEngineEvent2(object sender, CarEventArgs e)
{
    if(sender is Car c)
    {
        Console.WriteLine("message no.2 from the car object {0}:", c.PetName);
        Console.WriteLine(e.msg);
    }
}


GenericDel<string> g = new((string s) => Console.WriteLine(s));
GenericDel<int> g2 = new(AddOne);

g("haha");
g2(9);

static void AddOne(int i)
{
    i+=1;
    Console.WriteLine(i);
}

Action<string, int> action = new(DisplayMsg);
action("display me",3);
Func<int, int, int> func = new(SimpleMath.Add);
Console.WriteLine(func(9,8));






static void DisplayMsg(string msg, int time)
{
    for(int i = 0; i < time; i++)
    {
        Console.WriteLine(msg);
    }
}

// define a delegate type
public delegate int BinaryOp(int x, int y);
//define a generic delegate type that takes one param and returns void
public delegate void GenericDel<T>(T x);


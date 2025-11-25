using DelegatesEventsAndLambda;

Car car = new("Oreo", 100, 10);

car.RegisterWithCarEngine(OnCarEngineEvent);
car.RegisterWithCarEngine(OnCarEngineEvent2);

static void OnCarEngineEvent(string msg)
{
  Console.WriteLine("message from car object:");
  Console.WriteLine(msg);  
}

static void OnCarEngineEvent2(string msg)
{
  Console.WriteLine("message from car object in all CAP:");
  Console.WriteLine(msg.ToUpper());  
}

car.Accelerate(20);
car.Accelerate(77);
car.Accelerate(27);

car.UnRegisterWithCarEngine(OnCarEngineEvent);

car.Accelerate(27);

// generic delegates
MyGenericDelegate<string> d1 = new(methodOne);

MyGenericDelegate<int> d2 = methodTwo;
d2+=methodThree;

static void methodOne(string arg)
{
    Console.WriteLine(arg);
}

static void methodTwo(int arg)
{
    Console.WriteLine(arg+1);
}

static void methodThree(int arg)
{
    Console.WriteLine(arg+2);
}

d1.Invoke("hahaha");
d2.Invoke(22);

// the generic Action<> and Func<> delegates that save you
// from creating your own custom delegates

static void DisplayMsg(string msg, ConsoleColor txtColor, int printCount)
{
    ConsoleColor previous = Console.ForegroundColor;
    Console.ForegroundColor = txtColor;

    for(int i = 0; i < printCount; i++)
    {
        Console.WriteLine(msg);
    }

    Console.ForegroundColor=previous;
}

Action<string, ConsoleColor, int> myAction = DisplayMsg;
myAction.Invoke("ACTION INVOKED", ConsoleColor.DarkMagenta, 3);

static int Add(int x, int y)
{
    return x+y;
}

static string SumToString(int x, int y)
{
    return (x+y).ToString();
}

Func<int,int,int> myFuncOne = Add;
Func<int,int,string> myFuncTwo = SumToString;

int r1 = myFuncOne.Invoke(3,3);
string r2 = myFuncTwo.Invoke(6,6);
Console.WriteLine(r1);
Console.WriteLine(r2);
// a generic delegate that can represent any method
// returning void and takes one parameter of type T
public delegate void MyGenericDelegate<T>(T arg);



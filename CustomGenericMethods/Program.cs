using CustomGenericMethods;
int a = 1;
int b = 2;
SwapFunctions.Swap<int>(ref a, ref b);
Console.WriteLine("a is now {0}", a);
Console.WriteLine("b is now {0}", b);
string c = "hello";
string d = "hey";
SwapFunctions.Swap<string>(ref c, ref d);
Console.WriteLine("c is now {0}", c);
Console.WriteLine("d is now {0}", d);
Point<int> p = new(1, 2);
Console.WriteLine(p);
Point<double> p2 = new(1.1, 2.2);
Console.WriteLine(p2);
p2.resetPoint();
Console.WriteLine(p2);
Point<string> p3 = default;
Console.WriteLine(p3);
Point<int> p4 = default;
Console.WriteLine(p4);

static void PatternMatching<T>(Point<T> p)
{
    switch (p)
    {
        case Point<string> pString:
            Console.WriteLine("point is based on string type");
            return;
        case Point<int> pInt:
            Console.WriteLine("point is based on int type");
            return;
    }
}

PatternMatching(p3);
PatternMatching(p4);
using System;

namespace CustomGenericMethods;

public class SwapFunctions
{
    public static void Swap<T>(ref T a, ref T b)
    {
        Console.WriteLine("the type of items you are swapping is {0}.", typeof(T));
        T temp = a;
        a = b;
        b = temp;
    }
}

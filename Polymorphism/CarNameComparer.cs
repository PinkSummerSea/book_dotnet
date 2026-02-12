using System;
using System.Collections;

namespace Polymorphism;

public class CarNameComparer:IComparer
{
    int IComparer.Compare(object? x, object? y)
    {
        if(x is Car c1 && y is Car c2)
        {
            return string.Compare(c1.Name,c2.Name);
        }
        throw new Exception("paremeter are not cars");
    }
}

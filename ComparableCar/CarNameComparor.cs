using System;
using System.Collections;

namespace ComparableCar;

public class CarNameComparor:IComparer
{
    int IComparer.Compare(object? o1, object? o2)
    {
        if (o1 is Car c1 && o2 is Car c2)
        {
            return string.Compare(c1.Name, c2.Name);
        }
        throw new Exception("parameter are not both cars");
    }
}

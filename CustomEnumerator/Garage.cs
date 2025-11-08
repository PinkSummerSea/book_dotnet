using System;
using System.Collections;

namespace CustomEnumerator;

public class Garage:IEnumerable
{
    private Car[] Cars { get; set; }
    public Garage()
    {
        Cars = new Car[4];
        Cars[0] = new Car("a", 10);
        Cars[1] = new Car("b", 20);
        Cars[2] = new Car("c", 30);
        Cars[3] = new Car("d", 40);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Cars.GetEnumerator();
    }
}

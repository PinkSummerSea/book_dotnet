using System;
using System.Collections;

namespace CustomEnumerator;

public class ParkingLot
{
    private Car[] Cars { get; set; }
    public ParkingLot()
    {
        Cars = new Car[4];
        Cars[0] = new Car("a", 10);
        Cars[1] = new Car("b", 20);
        Cars[2] = new Car("c", 30);
        Cars[3] = new Car("d", 40);
    }

    public IEnumerator GetEnumerator()
    {
        Console.WriteLine("reached");
        return ActualImp();
        IEnumerator ActualImp()
        {
            foreach (Car c in Cars)
            {
                yield return c;
            }
        }
    }
    
    public IEnumerable GetCars(bool reversed)
    {
        return ActualImp();
        IEnumerable ActualImp()
        {
            if (reversed)
            {
                for(int i = Cars.Length - 1; i >= 0; i--)
                {
                    yield return Cars[i];
                }
            }
            else
            {
                foreach(Car c in Cars)
                {
                    yield return c;
                }
            }
        }
        
    }
}

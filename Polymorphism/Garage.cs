using System;
using System.Collections;

namespace Polymorphism;

public class Garage:IEnumerable
{
    private Car[] carArray = new Car[4];
    public Car[] Cars => carArray;
    public Garage()
    {
        carArray[0] = new Car(3,"zz");
        carArray[0] = new Car(2,"yy");
        carArray[0] = new Car(1,"xx");
        carArray[0] = new Car(4,"uu");
    }

    public IEnumerator GetEnumerator()
    {
        return carArray.GetEnumerator();
    }
}

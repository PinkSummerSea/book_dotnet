using System;

namespace DelegatesEventsAndLambda;

public class Car
{
    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; } = 100;
    public string PetName { get; set; } = "Momo";
    private bool _carIsDead;
    public Car(){}
    public Car(string name, int maxSp, int currSp)
    {
        PetName=name;
        MaxSpeed=maxSp;
        CurrentSpeed=currSp;
    }

    public delegate void CarEngineHandler(string msgForCaller);

    private CarEngineHandler _listOfHandlers;

    public void RegisterWithCarEngine(CarEngineHandler methodToCall)
    {
        _listOfHandlers += methodToCall;
    }

    public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
    {
        _listOfHandlers -= methodToCall;
    }

    public void Accelerate(int delta)
    {
        if (_carIsDead)
        {
            _listOfHandlers?.Invoke("sorry car is dead");
        }
        else
        {
            CurrentSpeed+= delta;
            if (MaxSpeed - CurrentSpeed <= 10)
            {
                _listOfHandlers?.Invoke("car almost dead");
            }
            if(CurrentSpeed >= MaxSpeed)
            {
                _carIsDead=true;
            }
            else
            {
                Console.WriteLine("current speed is {0}", CurrentSpeed);
            }
        }
    }
}

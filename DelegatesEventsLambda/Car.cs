using System;

namespace DelegatesEventsLambda;

public class Car
{
    public string PetName { get; set; }="no name";
    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; } = 100;
    private bool _isCarDead;

    public delegate void CarEngineHandler(object sender, CarEventArgs e);
    public event CarEngineHandler AboutToExplode;
    //public event EventHandler<CarEventArgs> AboutToExplode;

    private CarEngineHandler _listOfHandlers;

    public void RegisterMethodToList(CarEngineHandler handler)
    {
        _listOfHandlers+=handler;
    }

    public void UnRegisterMethodToList(CarEngineHandler handler)
    {
        _listOfHandlers-=handler;
    }

    public void Accelarate(int amount)
    {
        if (_isCarDead || CurrentSpeed+amount > MaxSpeed)
        {
            _isCarDead = true;
            CurrentSpeed = MaxSpeed;
            _listOfHandlers?.Invoke(this, new CarEventArgs("car is dead!"));
        } else if(CurrentSpeed + 20 >= MaxSpeed)
        {
            AboutToExplode?.Invoke(this, new CarEventArgs("car is about to explode!"));
            CurrentSpeed += amount;
        }else
        {
            CurrentSpeed += amount;
            Console.WriteLine("current speed is {0}", CurrentSpeed);
        }
    }

    public Car(){}
    public Car(string name, int speed, int maxSpeed)
    {
        PetName=name;
        CurrentSpeed=speed;
        MaxSpeed=maxSpeed;
    }
}

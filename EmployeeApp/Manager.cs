using System;

namespace EmployeeApp;

public class Manager:Employee
{
    public int StockOptions { get; set; }
    public Manager(){}
    public Manager(string name, int age, int id, float pay, string ssn, int stockOptions)
    : base(name, age, id, pay, ssn, EmployeePayTypeEnum.Salaried)
    {
        StockOptions = stockOptions;
        Console.WriteLine(TestMember);
    }

    public override void GiveBonus(float amount)
    {
        amount += 100;
        base.GiveBonus(amount);
    }
}

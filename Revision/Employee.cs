using System;

namespace Revision;

public class Employee
{
    private int _testPrivateField = 1;
    public int Age { get; set; }
    public string Name { get; set; }="";
    public int Id { get; set; }
    public float Pay {get;set;}
    public DateTime HireDate {get;set;}
    public EmployeePayTypeEnum PayType { get; set; }
    public Employee(){}
    public Employee(string name, int age, float pay, int id, EmployeePayTypeEnum payType)
    {
        Name=name;
        Age=age;
        Pay=pay;
        Id=id;
        PayType=payType;
    }

    //property pattern matching
    public void GiveBonus(float amount)
    {
        Pay = this switch
        {
            {Age:>=18,PayType:EmployeePayTypeEnum.Hourly, HireDate.Year: >= 2020 }=>Pay+amount*0.1F,
            {Age:>=18,PayType:EmployeePayTypeEnum.Commission, HireDate.Year: >= 2020 }=>Pay+amount,
            _ => Pay+0
        };
    }
}

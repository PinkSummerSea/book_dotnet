using System;

namespace EmployeeApp;

public class Employee
{
    private int _empId;
    private string _empName ="";
    private float _currPay;
    private int _empAge;
    private string _ssn = "";
    private EmployeePayTypeEnum _payType;

    protected string TestMember = "abc";

    protected BenefitPackage EmpBenefits = new();

    public int Id { get => _empId; set => _empId = value; }
    public string Name
    {
        get => _empName;
        set
        {
            if (value.Length < 15)
                _empName = value;
            else
                Console.WriteLine("error, name cannot be longer than 15 chars");
        }
    }
    public float Pay
    {
        get => _currPay;
        set => _currPay = value;
    }

    public int Age { get => _empAge; set => _empAge = value; }
    public string SSN { get => _ssn; private set => _ssn = value; }
    public EmployeePayTypeEnum PayType { get => _payType; set => _payType = value; }
    public DateTime HireDate { get; set; }

    public BenefitPackage Benefits { get; set; }
    public Employee() { }
    public Employee(string name, int id, float pay, string ssn)
    :this(name, 0, id, pay, ssn,EmployeePayTypeEnum.Salaried){}

    public Employee(string name, int age, int id, float pay, string ssn, EmployeePayTypeEnum payType)
    {
        Name = name;
        Age = age;
        Id = id;
        Pay = pay;
        SSN = ssn;
        PayType = payType;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"name: {Name}, age: {Age}, id: {Id}, pay: {Pay}");
    }
    public virtual void GiveBonus(float amount)
    {
        // Pay = this switch
        // {
        //     { PayType: EmployeePayTypeEnum.Hourly, Age: >= 18, HireDate: { Year: >= 2000 } } => Pay += amount * 0.1F,
        //     { PayType: EmployeePayTypeEnum.Salaried, Age: >= 18, HireDate.Year: >= 2000 } => Pay += amount * 0.2F,
        //     { PayType: EmployeePayTypeEnum.Commission, Age: >= 18 } => Pay += amount * 0.3F,
        //     _ => Pay += 0
        // };
        Pay += amount;
    }

    public double GetBenefitCost()
    {
        return EmpBenefits.ComputePayDeduction();
    }
    
    public void GivePromotion()
    {
        // if (this is Manager m)
        // {
        //     Console.WriteLine($"promoted manager {m.Name}, stock options: {m.StockOptions}");
        // }
        // else if (this is SalesPerson s)
        // {
        //     Console.WriteLine($"promoted salesperson {s.Name}, sale amount: {s.SaleAmount}");
        // }
        switch (this)
        {
            case Manager m when m.Age > 30:
                Console.WriteLine($"promoted 30+ year old manager {m.Name}, stock options: {m.StockOptions}");
                break;
            case SalesPerson s:
                Console.WriteLine($"promoted salesperson {s.Name}, sale amount: {s.SaleAmount}");
                break;
            case Employee _:
                Console.WriteLine("not able to promote");
                break;
        }
        
    }
};


using System;

namespace EmployeeApp;

public class SavingsAccount
{
    private static double _currInterestRate;
    public static double InterestRate
    {
        get => _currInterestRate;
        set => _currInterestRate = value;
    }
    public double Balance{ get; set; }
    public SavingsAccount(double balance)
    {
        Balance = balance;
    }
    public void DisplayStats()
    {
        Console.WriteLine($"balance: {Balance}, rate: {InterestRate}");
    }
}

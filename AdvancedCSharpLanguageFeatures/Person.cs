using System;

namespace AdvancedCSharpLanguageFeatures;

public class Person:IComparable<Person>
{
    public string Name { get; set; }="default";
    public int Age {get;set;}

    public Person(){ }
    public Person(string name)
    {
        Name=name;
    }

    public Person(string name, int age)
    {
        Name=name;
        Age=age;
    }

    public override string ToString()
    {
        return $"The person is {Name}. Their age is {Age}.";
    }

    public int CompareTo(Person other)
    {
        if(Age < other.Age)
        {
            return -1;
        }
        if(Age > other.Age)
        {
            return 1;
        }
        return 0;
    }

    public static bool operator > (Person p1, Person p2) => p1.CompareTo(p2) > 0;
    public static bool operator < (Person p1, Person p2) => p1.CompareTo(p2) < 0;
    public static bool operator >= (Person p1, Person p2) => p1.CompareTo(p2) >= 0;
    public static bool operator <= (Person p1, Person p2) => p1.CompareTo(p2) <= 0;

    // overloaded + operator
    public static string operator + (Person p1, Person p2)
    {
        return $"{p1.Name} and {p2.Name} are together!";
    } 

    // overloaded ++ operator
    public static Person operator ++(Person p)
    {
        
        return new Person(p.Name, p.Age+1);
    }

    // overloaded -- operator
    public static Person operator --(Person p)
    {
        return new Person(p.Name, p.Age-1);
    }
}

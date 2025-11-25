using System;
using System.Collections;

namespace AdvancedCSharpLanguageFeatures;

public class PersonCollection : IEnumerable
{
    private ArrayList people = new ArrayList();

    public IEnumerator GetEnumerator()
    {
        return people.GetEnumerator();
    }

    public PersonCollection()
    {
        people.Add(new Person("Amy"));
        people.Add(new Person("Bob"));
    }
    // custom indexer for this class
    public Person this[int index]
    {
        get {return (Person)people[index];}
        set {people.Insert(index, value);}
    }
}

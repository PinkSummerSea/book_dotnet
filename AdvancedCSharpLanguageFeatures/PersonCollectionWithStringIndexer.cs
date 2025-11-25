using System;
using System.Collections;

namespace AdvancedCSharpLanguageFeatures;

public class PersonCollectionWithStringIndexer:IEnumerable
{
    private Dictionary<string, Person> people = new();
    
    public IEnumerator GetEnumerator()
    {
        return people.GetEnumerator();
    }

    public Person this[string index]
    {
        get {return (Person)people[index];}
        set {people[index]=value;}
    }
}

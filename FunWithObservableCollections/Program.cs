using System.Collections.ObjectModel;
using System.Collections.Specialized;
using FunWithObservableCollections;



ObservableCollection<Person> people = new ObservableCollection<Person>
{
    new Person{FirstName="Abby", LastName="Mo", Age=30},
    new Person{FirstName="Bobby", LastName="Mo", Age=30}
};

people.CollectionChanged += people_CollectionChanged;

static void people_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
{
    Console.WriteLine("the action for this event is {0}", e.Action);
    if (e.Action == NotifyCollectionChangedAction.Add)
    {
        Console.WriteLine("NEW ITEMS THAT WERE INSERTED:");
        foreach (Person p in e.NewItems)
        {
            Console.WriteLine(p);
        }
    }
    if (e.Action == NotifyCollectionChangedAction.Remove)
    {
        Console.WriteLine("OLD ITEMS:");
        foreach (Person p in e.OldItems)
        {
            Console.WriteLine(p);
        }
    }
}

people.Add(new Person("David", "Mo", 22));
people.RemoveAt(0);
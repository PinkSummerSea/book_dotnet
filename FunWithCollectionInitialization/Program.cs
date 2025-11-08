using System.Collections;
using System.Drawing;
using FunWithCollectionInitialization;
//UseGenericList();
//UseGenericStack();
//UseGenericQueue();
//UseGenericPriorityQueue();
//UseGenericSortedSet();
UseGenericDictionary();

static void UseGenericList()
{
    List<Person> people = new List<Person>
    {
        new() {FirstName="Jane", LastName="Doe", Age=30},
        new Person {FirstName="John", LastName="Doe",Age=35}
    };
    Console.WriteLine("there are {0} items in the list", people.Count);
    foreach (Person p in people)
    {
        Console.WriteLine(p);
    }
    people.Insert(1, new Person("Anny", "Doe", 33));
    Console.WriteLine("after insertion, there are {0} items in the list", people.Count);
    Person[] peopleArray = people.ToArray();
    //Person[] peopleArray = [.. people];
    foreach (Person p in peopleArray)
    {
        Console.WriteLine("first name: {0}", p.FirstName);
    }
}

static void UseGenericStack()
{
    Stack<Person> stackOfPeople = new();
    stackOfPeople.Push(new Person("Homer", "Simpson", 20));
    stackOfPeople.Push(new Person("Marge", "Simpson", 21));
    stackOfPeople.Push(new Person("Lisa", "Simpson", 22));

    Console.WriteLine("first item : {0}", stackOfPeople.Peek());
    Console.WriteLine("popped off: {0}", stackOfPeople.Pop());
    Console.WriteLine("first item: {0}", stackOfPeople.Peek());
    Console.WriteLine("popped off: {0}", stackOfPeople.Pop());
    Console.WriteLine("first item: {0}", stackOfPeople.Peek());
    Console.WriteLine("popped off: {0}", stackOfPeople.Pop());

    try
    {
        Console.WriteLine("first item: {0}", stackOfPeople.Peek());
        Console.WriteLine("popped off: {0}", stackOfPeople.Pop());
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine("error! {0}", ex.Message);
    }
}

static void UseGenericQueue()
{
    Queue<Person> peopleQ = new();
    peopleQ.Enqueue(new Person("Sunny", "Wu", 21));
    peopleQ.Enqueue(new Person("Dennis", "Wu", 31));
    peopleQ.Enqueue(new Person("Howard", "Wu", 41));
    Console.WriteLine("first person in the queue is {0}", peopleQ.Peek().FirstName);

    GetCoffee(peopleQ.Dequeue());
    GetCoffee(peopleQ.Dequeue());
    GetCoffee(peopleQ.Dequeue());

    static void GetCoffee(Person p)
    {
        Console.WriteLine("{0} got coffee!", p.FirstName);
    }
}

static void UseGenericPriorityQueue()
{
    PriorityQueue<Person, int> peopleQ = new();
    peopleQ.Enqueue(new Person("Sunny", "Wu", 21), 3);
    peopleQ.Enqueue(new Person("Dennis", "Wu", 31), 1);
    peopleQ.Enqueue(new Person("Howard", "Wu", 41), 2);

    while (peopleQ.Count > 0)
    {
        Console.WriteLine("{0} was dequeued", peopleQ.Dequeue().FirstName);
    }
}

static void UseGenericSortedSet()
{
    SortedSet<Person> people = new SortedSet<Person>(new SortPeopleByAge())
    {
        new Person("Amy","Smith",40),
        new Person("Bob","Smith",80),
        new("Celine","Smith",10)
    };
    foreach (Person p in people)
    {
        Console.WriteLine(p);
    }
    Console.WriteLine("=====");
    people.Add(new("Kate", "Smith", 3));
    foreach (Person p in people)
    {
        Console.WriteLine(p);
    }
}

static void UseGenericDictionary()
{
    Dictionary<string, Person> peopleA = new()
    {
        { "Amy", new Person("Amy", "Smith", 10) },
        { "Bob", new Person("Bob", "Smith", 10) },
        { "Celine", new Person("Celine", "Smith", 10) }
    };

    Person amy = peopleA["Amy"];
    Console.WriteLine(amy);

    
}
using AdvancedCSharpLanguageFeatures;

PersonCollection people = new PersonCollection();
//Console.WriteLine(people[0]); 
//Console.WriteLine(people[1]); 
people[2]=new Person("Gina");
//Console.WriteLine(people[2]); 

static void UseGenericListOfPeople()
{
    List<Person> people2 = new();
    people2.Add(new Person("Daniel"));
    people2.Add(new Person("Julie"));
    // indexer method comes for free with generic types
    people2[0]=new Person("Charles");
    for(int i = 0; i<people2.Count; i++)
    {
        Console.WriteLine("The index {0} is {1}.", i,people2[i].Name);
    }
}

//UseGenericListOfPeople();

PersonCollectionWithStringIndexer people3 = new();
people3["Cooper"] = new Person("Cooper");
people3["key"] = new Person("Drake");
foreach(KeyValuePair<string, Person> kvp in people3)
{
    //Console.WriteLine("the key is: {0}, the value is: {1}", kvp.Key, kvp.Value);
}

Person p1 = new Person("George",30);
Person p2 = new Person("William",33);
// Console.WriteLine(p1+p2);
// Console.WriteLine("p1++ = {0}",p1++);
// Console.WriteLine("++p2 = {0}",++p2);

// Console.WriteLine(p1>p2);
// Console.WriteLine(p1<=p2);

Rectangle r = new(1,2);
Square s = (Square)r;
Console.WriteLine(s);
Square s2 = (Square)2;
Console.WriteLine(s2);
int l = (int)s2;
Console.WriteLine(l);

Square s3 = new Square(3);
Rectangle r3 = s3;
Console.WriteLine(r3);
Rectangle r4 = (Rectangle)s3;
Console.WriteLine(r4); 

int myInt = 12345;
Console.WriteLine(myInt.ReverseDigits());
string myStr = "cute baby";
myStr.PrintUpper();

// System.Array implements IEnumerable

string[] strings = ["wow","this","is","cool"];
strings.PrintDataAndBeep();

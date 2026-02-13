using System;

namespace Linq;

public class ProductInfoSmall
{
    public string Name { get; set; }="";
    public string Description { get; set; }="";
    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}";
    }
}

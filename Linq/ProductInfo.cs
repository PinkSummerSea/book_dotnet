using System;

namespace Linq;

public class ProductInfo
{
    public string Name { get; set; }="";
    public string Description { get; set; }="";
    public int NumberInStock { get; set; }=0;
    public override string ToString()=>$"Name={Name},Description={Description},Number in stock={NumberInStock}";
}

# Are There?

I wanted to have a quick play with F# and xUnit, and this sounded like a simple enough project to get started with.


```cs
using CSRakowski.AreThere;

var elements = GetElements();

if (ThereAre.Any(elements))
    Console.WriteLine("There are some elements");

if (ThereAre.No(elements))
    Console.WriteLine("There are no elements");

if (ThereAre.AtLeast(4, elements))
    Console.WriteLine("There are at least 4 elements");
```

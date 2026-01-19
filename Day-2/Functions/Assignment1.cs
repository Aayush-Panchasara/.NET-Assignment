using System;

class Utility
{
    public void Add(int a, int b)
    {
        Console.WriteLine($"Addition of {a} and {b} is {a+b}");
    }

    public void Gretting(string name = "Gentalman")
    {
        Console.WriteLine($"Hello {name}, Good Morning");   
    }

    public void Generate(int a, out int square, out int addTen)
    {
        square = a * a;
        addTen = a + 10;
    }
}


class Assignment1
{
    public static void Main(string[] args)
    {
        int a = 12, b = 19, square, addTen;
        Utility util = new Utility();

        util.Add(a, b);
        util.Gretting("Aayush");
        util.Gretting();
        util.Generate(a,out square, out addTen);

        Console.WriteLine($"Square: {square}, AddTen: {addTen}");

    }
}
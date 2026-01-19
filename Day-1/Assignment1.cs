using System;

public class Program
{
    public static void Main(string []args)
    {
        
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Data: {DateTime.Now}");
        Console.WriteLine($"Device name: {Environment.MachineName}");

    }

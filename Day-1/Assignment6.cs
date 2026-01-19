public class Tax
{
    public const int TaxRate = 4;
    public readonly string OrderId;
    
    public Tax(string Id)
    {
        OrderId = Id;
    }

    public void tryModification()
    {
        System.Console.WriteLine("Try to modify the const and readonly field");
         //TaxRate = 3;  //It will throw error

         //OrderId = "AKU124"; //It will also throw error

    }
}

public class Program
{
    public static void Main()
    {
        Tax t1 = new Tax("DBS123");

        t1.tryModification();
        
    }
}
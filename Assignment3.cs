public class RefrenceType
{
    public int ID {get; set;}
    public String Name {get; set;}
}
public struct ValueType
{
    public int ID {get; set;}
    public String Name {get; set;}
}

public class Program
{
    public static void modifyValueType(ValueType temp)
    {
        temp.Name= "Piyush";
        temp.ID = 2;
    }
    public static void modifyRefrenceType(RefrenceType temp)
    {
        temp.ID = 2;
        temp.Name= "Piyush";
    }
    public static void Main(string[] args)
    {
        // ValueType Struct --------------------------------------------------
        // ValueType v1 = new ValueType { ID = 1, Name = "Aayush"};

        // System.Console.WriteLine($"Before method call : ID = {v1.ID}, Name = {v1.Name}");
        
        // modifyValueType(v1);
        // System.Console.WriteLine($"After method call : ID = {v1.ID}, Name = {v1.Name}");


        // RefrenceType Class --------------------------------------------------------

        RefrenceType r1 = new RefrenceType {ID = 1, Name = "Aayush"};

        System.Console.WriteLine($"Before method call : ID = {r1.ID}, Name = {r1.Name}");
        modifyRefrenceType(r1);

        System.Console.WriteLine($"After method call : ID = {r1.ID}, Name = {r1.Name}");

    }
}
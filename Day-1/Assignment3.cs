
public class Program
{
    public static void modifyValueType(int temp)
    {
        temp = 10;
    }
    public static void modifyRefrenceType(ref int temp)
    {
        temp = 10;
    }
    public static void Main(string[] args)
    {
        int valueType = 5,refrenceType = 5;
        
        Console.WriteLine($"Before: {valueType}");
        modifyValueType(valueType);
        Console.WriteLine($"After: {valueType}");


        Console.WriteLine($"Before: {refrenceType}");
        modifyRefrenceType(ref refrenceType);
        Console.WriteLine($"After: {refrenceType}");
    }
}
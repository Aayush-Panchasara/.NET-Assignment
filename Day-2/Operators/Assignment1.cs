using System;

class Assignment1
{
    public static double Add(double x, double y)
    {
        x += y;
        return x; 
    }
    public static double Substract(double x, double y)
    {
        x -= y;
        return x; 
    }
    public static double Multiply(double x, double y)
    {
        x *= y;
        return x; 
    }
    public static double Divide(double x, double y)
    {
        try
        {
            x /= y;
        }
        catch(DivideByZeroException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        return x;
    }
    public static double Modulo(double x, double y)
    {
        x %= y;
        return x; 
    }
    public static void Main(string[] args)
    {
        double num1, num2,result;
        char operation;

        Console.Write("Enter the value of first operand: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the value of second operand: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What operation you want to perform?");
        Console.WriteLine("Type '+' For Addition");
        Console.WriteLine("Type '-' For Substraction");
        Console.WriteLine("Type '*' For Multiplication");
        Console.WriteLine("Type '/' For Division");
        Console.WriteLine("Type '%' For Division");
        Console.Write("Enter the operation: ");
        operation = Convert.ToChar(Console.ReadLine());

        switch (operation) {
            case '+': 
                result = Add(num1, num2);
                Console.WriteLine($"Addition of {num1} and {num2} is {result}");
                break;
            case '-':
                result = Substract(num1, num2);
                Console.WriteLine($"Substraction of {num1} and {num2} is {result}");
                break;
            case '*':
                result = Multiply(num1, num2);
                Console.WriteLine($"Multiplication of {num1} and {num2} is {result}");
                break;
            case '/':
                result = Divide(num1, num2);
                Console.WriteLine($"Division of {num1} and {num2} is {result}");
                break;
            case '%':
                result = Modulo(num1, num2);
                Console.WriteLine($"Remainder of {num1} and {num2} is {result}");
                break;
        }
        
        
    }
}
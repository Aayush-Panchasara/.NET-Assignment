using System;

public class Assignment1
{
	public static void Main(string[] args)
	{
		int marks;

		Console.Write("Enter the marks out of 100: ");
		marks = Convert.ToInt32(Console.ReadLine());

		if(marks > 100 || marks < 0)
		{
			Console.WriteLine("Invalid Input");
		}



		//Using simple If-else
		Console.Write("Obtained Grade: ");

		if(marks >= 90) // 90-100
		{
			Console.WriteLine("AA");
		}
		else if(marks >= 80) //80-90
		{
			Console.WriteLine("AB");
		}
		else if(marks >= 70) //70-80
		{
			Console.WriteLine("BB");
		}
		else if(marks >= 65) //65-70
		{
			Console.WriteLine("BC");
		}
		else if(marks >= 60) //60-65
		{
			Console.WriteLine("CC");
		}
		else if(marks >= 55) //55-60
		{
			Console.WriteLine("CD");
		}
		else if(marks >= 35) //35-55
		{
			Console.WriteLine("DD");
		}
		else // 0-35
		{
			Console.WriteLine("FF"); // Fail
		}


        //Using Switch-case
        Console.Write("Obtained Grade: ");

        switch (marks)
		{
			case >= 90:
				Console.WriteLine("AA");
				break;
			case >= 80:
				Console.WriteLine("AB");
				break;
			case >= 70:
				Console.WriteLine("BB");
				break;
			case >= 65:
				Console.WriteLine("BC");
				break;
			case >= 60:
				Console.WriteLine("CC");
				break;
			case >= 55:
				Console.WriteLine("CD");
				break;
			case >= 35:
				Console.WriteLine("DD");
				break;
			default:
				Console.WriteLine("FF");
				break;
		}
	}
}

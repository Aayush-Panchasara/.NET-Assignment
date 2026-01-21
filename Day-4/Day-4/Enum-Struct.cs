using System;
using System.Collections.Generic;
using System.Text;

namespace Day_4
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        OutForDelivery,
        Delivered,
        Cancelled
    }
    public struct Coordinate
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void DisplayCoordinate()
        {
            Console.WriteLine($"Coordinate: ({x},{y})");
        }
        public void ChangeCoordinate(int newX, int newY)
        {
            x = newX;
            y = newY;
            Console.WriteLine("Coordinate update successfully");
        }
    }
    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void DisplayPoint()
        {
            Console.WriteLine($"Point: ({x},{y})");
        }
        public void ChangePoint(int newX, int newY)
        {
            x = newX;
            y = newY;
            Console.WriteLine("Point updated successfully");
        }
    }
    class Enum_Struct
    {
        public static void Main()
        {
            //Order status

            //Console.WriteLine($"OrderStatus: {OrderStatus.Pending}, IntegerValue: {(int)OrderStatus.Pending}");
            //Console.WriteLine($"OrderStatus: {OrderStatus.OutForDelivery}, IntegerValue: {(int)OrderStatus.OutForDelivery}");
            //Console.WriteLine($"OrderStatus: {OrderStatus.Delivered}, IntegerValue: {(int)OrderStatus.Delivered}");
            //Console.WriteLine();
            //Console.WriteLine((int)OrderStatus.Shipped);
            //Console.WriteLine((OrderStatus)3);

            //Struct coordinate AND Struct & Class behaviour
            Coordinate cp = new Coordinate(4, 5);
            Coordinate cp2 = cp;
            Console.WriteLine("Structure Behaviour(Value type)");
            Console.Write("Before cp: ");
            cp.DisplayCoordinate();
            Console.Write("Before cp2: ");
            cp2.DisplayCoordinate();

            cp2.ChangeCoordinate(5, 7); //cp2 is updated

            Console.Write("After cp: ");
            cp.DisplayCoordinate();
            Console.Write("After cp2: ");
            cp2.DisplayCoordinate();

            Console.WriteLine();

            Point p = new Point(4, 5);
            Point p2 = p;
            Console.WriteLine("Class Behaviour(Reference type)");
            Console.Write("Before p: ");
            p.DisplayPoint();
            Console.Write("Before p2: ");
            p2.DisplayPoint();

            p2.ChangePoint(5, 7); //p2 is updated

            Console.Write("After p: ");
            p.DisplayPoint();
            Console.Write("Before p2: ");
            p2.DisplayPoint();


        }
    }
}

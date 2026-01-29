using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day3
{
    public class Employee
    {
        public virtual double CalculateSalary(int WorkingHour)
        {
            double result=0;
            return result;
        }
    }

    public class FullTimeEmployee : Employee
    {
        public double FixPay = 35000.00;
        public double Allowance = 5000.00;
        public double OvertimePayPerHour = 1000;
        public override double CalculateSalary(int OvertimeHour)
        {
            double salary = FixPay + Allowance + OvertimePayPerHour * OvertimeHour;

            return salary;
        }
    }
    public class PartTimeEmployee : Employee
    {
        public double FixPayPerHour = 900;
        public override double CalculateSalary(int WorkingHour)
        {
            double salary = FixPayPerHour * WorkingHour;

            return salary;
        }
    }
    class Employee_Hierarchy
    {
        public static void Main()
        {
            Employee partTime = new PartTimeEmployee();
            Console.WriteLine($"Part-time Employee salary: {partTime.CalculateSalary(10)}");

            Employee fullTime = new FullTimeEmployee();
            Console.WriteLine($"Full-time Employee salary: {fullTime.CalculateSalary(3)}");
        }
    }
}

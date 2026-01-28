using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day2
{
    //Assume that unit of temperature is Kelvin(K).
    public class Temperature_Sensor
    {
        private int _Temperature;
        private List<int> _History = new List<int>();


        public Temperature_Sensor(int temperature)
        {
            _Temperature = temperature;
            _History.Add(temperature);
        }

        public List<int> History
        {
            get
            {
                return _History; 
            }
        }

        public int Temperature
        {
            get
            {
                return _Temperature; 
            }
            set
            {
                if(value >= 0)
                {
                    _Temperature = value;
                    _History.Add(value);
                }
                else
                {
                    Console.WriteLine("Invalid Temperature value");
                }
            }
        }
    }
    class Temperature_Monitor
    {
        public static void Main(string[] args) {
            Temperature_Sensor room1 = new Temperature_Sensor(30);
            Console.WriteLine($"Current Temperature: {room1.Temperature}");
            room1.Temperature = 40;
            Console.WriteLine($"Current Temperature: {room1.Temperature}");
            room1.Temperature = 50;
            Console.WriteLine($"Current Temperature: {room1.Temperature}");
            room1.Temperature = -15;
            Console.WriteLine($"Current Temperature: {room1.Temperature}");

            Console.WriteLine("Temperature History");
            foreach (var item in room1.History)
            {
                Console.WriteLine(item);
            }

        }
    }
}

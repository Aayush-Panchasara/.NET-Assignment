
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Day_3
{
    class Loops_Ass1
    {
        public static void ListPrimeNumber(int num)
        {
            bool flag;
            for (int i = 2; i <= num; i++) { 
                flag = true;
                for(int j = 2; j <= i/2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) {
                    Console.Write($"{i}, ");
                }
            }
        }

        public static void StartGuessGame()
        {
            int userInput, randomInput;

            Random random = new Random();
            randomInput = random.Next(101);
            Console.Write("Guess the number between 1 to 100: ");
            userInput = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                
                if(userInput == randomInput)
                {
                    Console.WriteLine("Awesome!! You guessed it right.");
                    return;
                }
                else if(userInput > randomInput)
                {
                    Console.WriteLine("Wrong! Too High");
                }
                else
                {
                    Console.WriteLine("Wrong! Too Low");
                }
                Console.Write("Guess again: ");
                userInput = Convert.ToInt32(Console.ReadLine());
            }
        }

        public static void IterateCollection(ICollection c)
        {
            
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
        }
        public static void Main(string[] args)
        {
            //int num;

            //Console.WriteLine("Enter the number: ");
            //num = Convert.ToInt32(Console.ReadLine());
            //ListPrimeNumber(num);

            StartGuessGame();

            //ArrayList ar = new ArrayList { 1,2,3,"Aayush", true, 6.9};
            //IterateCollection(ar);

            //List<int> list = new List<int> {1,2,3,4,5,6,7 };
            //IterateCollection(list);

            //Dictionary<int, string> d = new Dictionary<int, string> { { 1,"India"},{ 2,"Australia"}, {3,"Japan"} };
            //IterateCollection(d);


        }
    }
}

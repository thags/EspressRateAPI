using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspressoItemsUserApp
{
    internal class UserInputController
    {
        public static void GetUserInput()
        {
            bool exitProgram = false;
            while (!exitProgram)
            {
                Console.WriteLine("\n --------------------------");
                Console.WriteLine("0 to exit");
                Console.WriteLine("V to view all");
                Console.WriteLine("A to add");
                Console.WriteLine("D to delete");
                Console.WriteLine("E to edit");
                Console.WriteLine("-------------------------- \n");

                string choice = GetUserMenuChoice();
                switch (choice)
                {
                    case "0":
                        exitProgram = true;
                        break;
                    case "S":
                        Console.Clear();
                        break;
                    case "F":
                        Console.Clear();
                        break;
                    case "R":
                        Console.Clear();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Incorrect input, try again");
                        WaitForUser();
                        break;
                }
            }
        }
        private static string GetUserMenuChoice() => Console.ReadLine().ToUpper();
        private static void WaitForUser()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

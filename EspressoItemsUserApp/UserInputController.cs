using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspressoItemsUserApp.Models;

namespace EspressoItemsUserApp
{
    internal class UserInputController
    {
        private protected TableVisualisationEngine displayTable = new TableVisualisationEngine();
        private protected APIController apiFetch = new APIController();
        public void GetUserInput()
        {
            bool exitProgram = false;
            while (!exitProgram)
            {
                Console.WriteLine("\n --------------------------");
                Console.WriteLine("0 to exit");
                Console.WriteLine("V to view");
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
                    case "V":
                        Console.Clear();
                        ViewAll();
                        break;
                    case "A":
                        Console.Clear();
                        break;
                    case "D":
                        Console.Clear();
                        break;
                    case "E":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Incorrect input, try again");
                        WaitForUser();
                        break;
                }
            }
        }
        private void ViewAll()
        {
            List<EspressoItem> espressos = apiFetch.GetItems();
            displayTable.ViewTable(espressos);
        }
        private string GetUserMenuChoice() => Console.ReadLine().ToUpper();
        private void WaitForUser()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

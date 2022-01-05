using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspressoItemsUserApp.Models;
using EspressoItemsUserApp.Models.DTO;

namespace EspressoItemsUserApp
{
    internal class UserInputController
    {
        private protected TableVisualisationEngine displayTable = new TableVisualisationEngine();
        private protected APIController api = new APIController();
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
                        Add();
                        break;
                    case "D":
                        Console.Clear();
                        List<EspressoToView> espressoView = ViewAll();
                        Delete(espressoView);
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
        private void Delete(List<EspressoToView> espressoViewed)
        {
            List<EspressoItem> espressos = api.GetItems();
            //TODO
            //Get user input for the ID of the item they want to delete
            int userChoice = GetUserRating();
            //Check that the ID they entered is actually an ID of an item viewed
            //Get the index of the item they chose (it will always be the number they entered minus 1
            //Send a call to the API to delete the API 
            api.DeleteItem(userChoice);
        }
        private void Add()
        {
            EspressoItem newItem = CreateEspressoItem();
            api.AddItem(newItem);
        }
        private List<EspressoToView> ViewAll()
        {
            List<EspressoItem> espressos = api.GetItems();
            List<EspressoToView> viewItems = displayTable.ParseToView(espressos);
            displayTable.ViewTable(viewItems);
            return viewItems;
        }
        private string GetUserMenuChoice() => Console.ReadLine().ToUpper();
        private void WaitForUser()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
        private EspressoItem CreateEspressoItem()
        {
            var item = new EspressoItem();
            Console.WriteLine("Input Espresso Name");
            item.Name = GetUserInputString();
            Console.WriteLine("Input Espresso Roaster");
            item.Roaster = GetUserInputString();
            item.Rating = GetUserRating();

            return item;
        }
        private string GetUserInputString()
        {
            return Console.ReadLine();
        }
        private int GetUserRating()
        {
            int rating;
            bool goodInput;
            bool inRange;
            do
            {
                Console.WriteLine("Input a rating 1-10");
                goodInput = int.TryParse(GetUserInputString(), out rating);
                if (rating > 0 && rating <= 10)
                {
                    inRange = true;
                }
                else
                {
                    inRange = false;
                }
            } while (!goodInput && !inRange);
            return rating;
        }
    }
}

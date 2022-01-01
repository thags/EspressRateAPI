using EspressoItemsUserApp.Models;
using System;
using System.Threading.Tasks;

namespace EspressoItemsUserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInputController userInput = new UserInputController();
            userInput.GetUserInput();
        }
    }
}
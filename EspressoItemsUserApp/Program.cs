using EspressoItemsUserApp.Models;
using System;
using System.Threading.Tasks;

namespace EspressoItemsUserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TableVisualisationEngine displayTable = new TableVisualisationEngine();
            APIController apiFetch = new APIController();
            List<EspressoItem> espressos = apiFetch.GetItemsAsync().Result;
            displayTable.ViewTable(espressos);
        }
    }
}
using ConsoleTableExt;
using System;
using System.Collections.Generic;
using EspressoItemsUserApp.Models;
using EspressoItemsUserApp.Models.DTO;

namespace EspressoItemsUserApp
{
    internal class TableVisualisationEngine
    {
        public void ViewTable<T>(List<T> tableData, string title = "") where T : class
        {
            if (tableData.Count == 0)
            {
                Console.WriteLine("Currently empty!");
            }
            else
            {
                ConsoleTableBuilder
               .From(tableData)
               .WithTitle(title)
               .WithFormat(ConsoleTableBuilderFormat.Alternative)
               .ExportAndWriteLine(TableAligntment.Center);
            }
            Console.Write("\n");
        }
        public List<EspressoToView> ParseToView(List<EspressoItem> listEspressoItems)
        {
            List<EspressoToView> finalList = new List<EspressoToView>();
            int id = 1;
            foreach (var espresso in listEspressoItems)
            {
                var newItem = new EspressoToView
                {
                    Id = id,
                    Rating = espresso.Rating,
                    Name = espresso.Name,
                    Roaster = espresso.Roaster,
                };
                id++;
                finalList.Add(newItem);
            }
            return finalList;
        }
    }
}

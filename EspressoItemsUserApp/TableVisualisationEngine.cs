using ConsoleTableExt;
using System;
using System.Collections.Generic;

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
    }
}

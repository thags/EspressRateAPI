using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspressoItemsUserApp.Models
{
    internal class EspressoItem
    {
        public long Id { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Roaster { get; set; }
    }
}

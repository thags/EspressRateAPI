using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EspressoItemsUserApp.Models
{
    internal class EspressoItem
    {
        public long id { get; set; }
        public int rating { get; set; }
        public string name { get; set; }
        public string roaster { get; set; }
    }
}

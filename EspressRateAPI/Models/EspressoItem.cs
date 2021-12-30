using System.ComponentModel.DataAnnotations;

namespace EspressRateAPI.Models
{
    public class EspressoItem
    {
        [Required]
        public long Id { get; set; }

        [Range(0, 100)]
        public int Rating { get; set; }

        public string Name { get; set; }
        public string Roaster { get; set; }




    }
}

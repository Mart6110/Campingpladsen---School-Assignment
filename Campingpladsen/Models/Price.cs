using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Campingpladsen.Models
{
    public class Price
    {
        public int ID { get; set; }
        [Required]
        public string Price_name { get; set; }
        [Required]
        public int High_Season_Price { get; set; }
        [Required]
        public int Low_Season_Price { get; set; }
    }
}

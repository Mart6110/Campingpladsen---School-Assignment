using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Campingpladsen.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        public int Total_Prise { get; set; }
        [Required]
        public int Adult { get; set; }
        [Required]
        public int child { get; set; }
        [Required]
        public int Dog { get; set; }
        [Required]
        public int Spot_Id { get; set; }
        [Required]
        public int Customer_id { get; set; }
    }
}

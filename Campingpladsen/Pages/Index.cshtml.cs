using Campingpladsen.Models;
using CampingPladsen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campingpladsen.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();
        PriceDataAccessLayer objprice = new PriceDataAccessLayer();
        OrderDataAccessLayer objorder = new OrderDataAccessLayer();
        public List<Customer> customer { get; set; }
        public List<Price> price { get; set; }
        public List<Order> order { get; set; }

        public void OnGet()
        {
            customer = objcustomer.GetAllCustomers().ToList();
            price = objprice.GetAllPrice().ToList();
            order = objorder.GetAllOrder().ToList();
        }
    }
}

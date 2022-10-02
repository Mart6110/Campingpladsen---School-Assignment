using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CampingPladsen.Models;

namespace Campingpladsen.Pages
{
    public class CustomerDetailsModel : PageModel
    {
        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();
        public Customer customer { get; set; }

        public ActionResult OnGet(int? id)
        {
            // If we return null we get a 404 status code
            if (id == null)
            {
                return NotFound();
            }
            customer = objcustomer.GetCustomerData(id);

            // If we return null we get a 404 status code
            if (customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

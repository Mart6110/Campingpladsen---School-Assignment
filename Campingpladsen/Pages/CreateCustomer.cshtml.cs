using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampingPladsen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Campingpladsen.Pages
{
    public class CreateCustomerModel : PageModel
    {
        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();

        [BindProperty] // Used to capture the data posted in our form object.
        public Customer customer { get; set; }

        public ActionResult OnPost()
        {
            if(!ModelState.IsValid) // If Modelstate is not valid we return page();
            {
                return Page();
            }

            objcustomer.AddCustomer(customer); // Adding the customer

            return RedirectToPage("Index"); // Redirectiong the user to Index
        }
        public void OnGet()
        {
        }
    }
}

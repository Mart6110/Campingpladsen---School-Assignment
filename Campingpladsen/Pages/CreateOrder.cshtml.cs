using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campingpladsen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Campingpladsen.Pages
{
    public class CreateOrderModel : PageModel
    {
        OrderDataAccessLayer objorder = new OrderDataAccessLayer();

        [BindProperty] // Used to capture the data posted in our form object.
        public Order order { get; set; }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid) // If Modelstate is not valid we return page();
            {
                return Page();
            }

            objorder.AddOrder(order); // Adding the order

            return RedirectToPage("Index"); // Redirectiong the user to Index
        }

        public void OnGet()
        {
        }
    }
}

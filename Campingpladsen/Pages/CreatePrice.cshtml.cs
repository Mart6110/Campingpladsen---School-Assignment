using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campingpladsen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Campingpladsen.Pages
{
    public class CreatePriceModel : PageModel
    {
        PriceDataAccessLayer objprice = new PriceDataAccessLayer();

        [BindProperty] // Used to capture the data posted in our form object.
        public Price price { get; set; }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid) // If Modelstate is not valid we return page();
            {
                return Page();
            }

            objprice.AddPrice(price); // Adding the customer

            return RedirectToPage("Index"); // Redirectiong the user to Index
        }
        public void OnGet()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campingpladsen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Campingpladsen.Pages
{
    public class EditPriceModel : PageModel
    {
        PriceDataAccessLayer objprice = new PriceDataAccessLayer();

        [BindProperty]
        public Price price { get; set; }
        public ActionResult OnGet(int? id)
        {
            // If we return null we get a 404 status code
            if (id == null)
            {
                return NotFound();
            }
            price = objprice.GetPriceData(id);

            // If we return null we get a 404 status code
            if (price == null)
            {
                return NotFound();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            // If ModelState is not valid we return page();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            objprice.UpdatePrice(price);

            return RedirectToPage("Index");
        }
    }
}

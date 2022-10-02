using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campingpladsen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Campingpladsen.Pages
{
    public class DeletePriceModel : PageModel
    {
        PriceDataAccessLayer objprice = new PriceDataAccessLayer();

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

        public ActionResult OnPost(int? id)
        {
            // If we return null we get a 404 status code
            if (id == null)
            {
                return NotFound();
            }

            objprice.DeletePrice(id); // Delete the price object

            return RedirectToPage("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campingpladsen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Campingpladsen.Pages
{
    public class EditOrderModel : PageModel
    {
        OrderDataAccessLayer objorder = new OrderDataAccessLayer();

        [BindProperty]
        public Order order { get; set; }
        public ActionResult OnGet(int? id)
        {
            // If we return null we get a 404 status code
            if (id == null)
            {
                return NotFound();
            }
            order = objorder.GetOrderData(id);

            // If we return null we get a 404 status code
            if (order == null)
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
            objorder.UpdateOrder(order);

            return RedirectToPage("Index");
        }
    }
}

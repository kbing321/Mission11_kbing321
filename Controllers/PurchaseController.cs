using Microsoft.AspNetCore.Mvc;
using Mission09_kbing321.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_kbing321.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Cart cart { get; set; }
        public PurchaseController(IPurchaseRepository ipr, Cart c)
        {
            repo = ipr;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (cart.Books.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }
            
            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Books.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearCart();

                return RedirectToPage("/PurchaseConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}

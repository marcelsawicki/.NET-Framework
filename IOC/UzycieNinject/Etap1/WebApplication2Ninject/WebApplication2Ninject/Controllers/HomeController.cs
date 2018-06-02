using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2Ninject.Models;

namespace WebApplication2Ninject.Controllers
{
    public class HomeController : Controller
    {
        Product[] products = {
            new Product { Name = "Kajak", Category="Sporty wodne", Price=275M },
            new Product { Name = "Kamizelka ratunkowa", Category="Sporty wodne", Price=48.95M },
            new Product { Name = "Piłka nożna", Category="Piłka nożna", Price=19.50M },
            new Product { Name = "Flaga narożna", Category="Piłka nożna", Price=34.95M }
        };
        // GET: Home
        public ActionResult Index()
        {
            LinqValueCalculator calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}
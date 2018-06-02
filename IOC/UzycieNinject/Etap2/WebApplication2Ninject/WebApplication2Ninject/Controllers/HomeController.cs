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
            new Product { ProductID=0, Name = "Kajak", Category="Sporty wodne", Price=275M },
            new Product { ProductID=1, Name = "Kamizelka ratunkowa", Category="Sporty wodne", Price=48.95M },
            new Product { ProductID=2, Name = "Piłka nożna", Category="Piłka nożna", Price=19.50M },
            new Product { ProductID=3, Name = "Flaga narożna", Category="Piłka nożna", Price=34.95M }
        };
        // GET: Home
        public ActionResult Index()
        {
            IValueCalculator calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }

        public ActionResult Lista()
        {
            return View(products);
        }
    }
}
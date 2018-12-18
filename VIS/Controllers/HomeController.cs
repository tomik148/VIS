using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIS.Models;

namespace VIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()
        {
            ViewBag.Recipes = Model1.Context.Recipes;
            return View();
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            Model1.Context.Orders.Add(order);
            Model1.Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Recipes()
        {
            return View(Model1.Context.Recipes);
        }
    }
}
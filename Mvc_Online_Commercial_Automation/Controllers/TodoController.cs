using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        Context Context = new Context();
        public ActionResult Index()
        {
            var values1 = Context.Carilers.Count();
            ViewBag.values1 = values1;

            var values2 = Context.Products.Count();
            ViewBag.values2 = values2;

            var values3 = Context.Categories.Count();    
            ViewBag.values3 = values3;

            var values4 = Context.Carilers.Select(x=>x.CariCity).Distinct().Count();
            ViewBag.values4 = values4;

            var list = Context.Todos.ToList();

            return View(list);
        }
    }
}
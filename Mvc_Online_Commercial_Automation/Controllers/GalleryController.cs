using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context context = new Context();
        public ActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
    }
}
using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails

        Context context = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = context.Products.Where(x=>x.ProductID==1).ToList();
            cs.Deger2 = context.Details.Where(x=>x.DetailsID==1).ToList();
            cs.Deger3 = context.Carilers.Where(x=>x.CariID==1).ToList();

            return View(cs);
        }
    }
}
using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Context context = new Context();
        public ActionResult Index()
        {
            var result = context.Products.Where(x => x.Status == true).ToList();
            return View(result);
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();


            ViewBag.deger1 = values;

           



            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ProductDelete(int id)
        {
            var values = context.Products.Find(id);
            context.Products.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult ProductUpdate(int id)
        {
            var values = context.Products.Find(id);
            List<SelectListItem> values2 = (from x in context.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryID.ToString()
                                            }).ToList();


            ViewBag.deger1 = values2;
            return View(values);
        }

        [HttpPost]
        public ActionResult ProductUpdate(Product product)
        {
            var values = context.Products.Find(product.ProductID);
          
            values.ProductName = product.ProductName;
            values.BrandName = product.BrandName;
            values.Stock = product.Stock;
            values.PurchasePrice = product.PurchasePrice;
            values.SalePrice = product.SalePrice;
            values.Status = product.Status;
            values.ProductImage = product.ProductImage;
            values.CategoryID = product.CategoryID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
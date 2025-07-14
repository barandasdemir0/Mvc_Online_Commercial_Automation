using Mvc_Online_Commercial_Automation.Models.Classes;
using PagedList;
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
        public ActionResult Index(/*int sayfa=1,*/string aranacak)
        {
            var result = from x in context.Products select x; /*ToPagedList(sayfa,4);*/
            if (!string.IsNullOrEmpty(aranacak))
            {
                result = result.Where(x => x.ProductName.Contains(aranacak) || x.BrandName.Contains(aranacak)); // Filtering products based on the search term 
            }
            return View(result.ToList());
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



        
        public ActionResult ListProduct()
        {
            var values = context.Products.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult ProductSale(int id)
        {
            List<SelectListItem> employeeList = (from x in context.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                     Value = x.EmployeeID.ToString()
                                                 }).ToList();

            ViewBag.employeeList = employeeList;

            var deger1 = context.Products.Find(id);
            ViewBag.productid = deger1.ProductID;
            ViewBag.price = deger1.SalePrice;

            return View();
        }

        [HttpPost]
        public ActionResult ProductSale(SalesTransaction sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesTransactions.Add(sales);
            context.SaveChanges();
            return RedirectToAction("Index","Sales");
        }










    }
}
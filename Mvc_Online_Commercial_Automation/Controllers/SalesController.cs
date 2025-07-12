using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales

        Context context = new Context();

        public ActionResult Index()
        {
            var salesTransactions = context.SalesTransactions.ToList();
            return View(salesTransactions);
        }


        [HttpGet]
        public ActionResult SaleAdd()
        {
            List<SelectListItem> productList = (from x in context.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductID.ToString()
                                                }).ToList();
            ViewBag.productList = productList;

            //buranın amacı, satış işlemi için gerekli olan ürün, cari ve çalışan bilgilerini dropdown list olarak kullanıcıya sunmaktır.


            List<SelectListItem> cariList = (from x in context.Carilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariName + " " + x.CariSurname,
                                                 Value = x.CariID.ToString()
                                             }).ToList();
            ViewBag.cariList = cariList;


            List<SelectListItem> employeeList = (from x in context.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                     Value = x.EmployeeID.ToString()
                                                 }).ToList();

            ViewBag.employeeList = employeeList;


            return View();
        }

        [HttpPost]
        public ActionResult SaleAdd(SalesTransaction sales)
        {
            sales.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesTransactions.Add(sales);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult SaleUpdate(int id)
        {

            var values = context.SalesTransactions.Find(id);
            List<SelectListItem> productList = (from x in context.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductID.ToString()
                                                }).ToList();
            ViewBag.productList = productList;

            //buranın amacı, satış işlemi için gerekli olan ürün, cari ve çalışan bilgilerini dropdown list olarak kullanıcıya sunmaktır.


            List<SelectListItem> cariList = (from x in context.Carilers.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariName + " " + x.CariSurname,
                                                 Value = x.CariID.ToString()
                                             }).ToList();
            ViewBag.cariList = cariList;


            List<SelectListItem> employeeList = (from x in context.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                     Value = x.EmployeeID.ToString()
                                                 }).ToList();

            ViewBag.employeeList = employeeList;

            return View(values);
        }

        [HttpPost]
        public ActionResult SaleUpdate(SalesTransaction sales)
        {
            var values = context.SalesTransactions.Find(sales.SatidID);


            values.ProductID = sales.ProductID;
            values.CariID = sales.CariID;
            values.EmployeeID = sales.EmployeeID;
            values.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            values.Quantity = sales.Quantity;
            values.Price = sales.Price;
            values.TotalPrice = sales.TotalPrice;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaleDetails(int id)
        {
            var values = context.SalesTransactions.Where(x => x.SatidID == id).ToList();
            return View(values);

        }
    }
}
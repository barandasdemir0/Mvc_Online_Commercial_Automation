using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class StaticController : Controller
    {

        Context context = new Context();
        // GET: Static
        public ActionResult Index()
        {

            var deger1 = context.Carilers.Count();
            ViewBag.d1 = deger1;

            var deger2 = context.Products.Count();
            ViewBag.d2 = deger2;

            var deger3 = context.Employees.Count();
            ViewBag.d3 = deger3;

            var deger4 = context.Categories.Count();
            ViewBag.d4 = deger4;

            var deger5 = context.Products.Sum(x => x.Stock);
            ViewBag.d5 = deger5;


            var deger6 = context.Products.Select(x => x.BrandName).Distinct().Count(); //distinct: benzersiz
            ViewBag.d6 = deger6;

            var deger7 = context.Products.Count(x => x.Stock < 20);
            ViewBag.d7 = deger7;

            var deger8 = context.Products.OrderByDescending(x => x.SalePrice).Select(y => y.ProductName).FirstOrDefault();// en yüksek fiyatlı ürünlerin markalarını listele
            ViewBag.d8 = deger8;


            var deger9 = context.Products.OrderBy(x => x.SalePrice).Select(y => y.ProductName).FirstOrDefault(); // en düşük fiyatlı ürünlerin markalarını listele
            ViewBag.d9 = deger9;





            var deger10 = context.Products.Count(x => x.ProductName == "Buzdolabi");
            ViewBag.d10 = deger10;

            var deger11 = context.Products.Count(x => x.ProductName == "Laptop");
            ViewBag.d11 = deger11;

            var deger12 = context.Products.GroupBy(x => x.BrandName).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = deger12;



            var deger13 = context.Products.Where(u => u.ProductID == (context.SalesTransactions.GroupBy(x => x.ProductID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault(); // en çok satılan ürünün ID'sini al
            ViewBag.d13 = deger13;

            var deger14 = context.SalesTransactions.Sum(x => x.TotalPrice);
            ViewBag.d14 = deger14;


            var deger15 = context.SalesTransactions.Count(x => x.Date == DateTime.Today);
            ViewBag.d15 = deger15;


            var deger16 = context.SalesTransactions.Where(x => x.Date == DateTime.Today).Sum(y => y.TotalPrice).ToString(); ;
            ViewBag.d16 = deger16;





            return View();
        }


        public ActionResult EasyTable()
        {
            var deger1 = context.Carilers.GroupBy(x => x.CariCity).Select(y => new GroupClass
            {
                City = y.Key,
                Total = y.Count()
            }).ToList();
            return View(deger1);
        }

        public PartialViewResult PartialEasy1()
        {
            var sorgu2 = context.Employees // Çalışanları departmanlarına göre grupla
                .GroupBy(x => x.Department.DepartmentName) // Departman adına göre grupla
                .Select(y => new GroupClass2 // yeni bir GroupClass nesnesi oluştur
                {
                    Department = y.Key, // Departman adını ata
                    Total = y.Count() // O departmandaki çalışan sayısını ata
                }).ToList(); // Liste olarak döndür


            return PartialView(sorgu2);
        }

        public PartialViewResult PartialEasy2()
        {

            var sorgu3 = context.Carilers.ToList(); // Liste olarak döndür

            return PartialView(sorgu3);
        }

        public PartialViewResult PartialEasy3()
        {
            var sorgu4 = context.Products.ToList(); // Liste olarak döndür
            return PartialView(sorgu4);
        }

        public PartialViewResult PartialEasy4()
        {
            var sorgu5 = context.Products.GroupBy(x=>x.BrandName).Select(y=> new GroupClass3
            {
                BrandName = y.Key, // Markayı ata
                Total = y.Count() // O markadaki ürün sayısını ata
            }).ToList(); // Liste olarak döndür
            return PartialView(sorgu5);
        }

    }
}
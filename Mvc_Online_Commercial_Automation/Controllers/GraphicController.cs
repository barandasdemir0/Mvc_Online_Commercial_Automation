using Mvc_Online_Commercial_Automation.Models.Classes;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult graphic2()
        {
            var createGraphic = new Chart(600,600);
            createGraphic.AddTitle(text: "Kategori Ürün Sayısı").AddLegend(title: "Stok").AddSeries("Değerler", xValue: new[] {"Bilgisayar","Küçük ev aleti","Mobilya"}, yValues: new[] { 200, 50, 20 }).Write();
            return File(createGraphic.ToWebImage().GetBytes(),"image/png");

           
        }
        Context context = new Context();
        public ActionResult graphic3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();

            var sonuclar = context.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stock));
            var graphic = new Chart(500, 500);
            graphic.AddTitle("Ürün Stok Sayfası").AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");


        }

        public ActionResult Graphic4()
        {
            return View();
        }


        public ActionResult VisualizeProductResult()
        {
            return Json(productList(), JsonRequestBehavior.AllowGet);
        }

        public List<ChartClass1> productList()
        {
            List<ChartClass1> cls1 = new List<ChartClass1>();
            cls1.Add(new ChartClass1()
            {
                ProductName = "Bilgisayar",
                Stock = 20
            });
            cls1.Add(new ChartClass1()
            {
                ProductName = "Beyaz Eşya",
                Stock = 50
            });
            cls1.Add(new ChartClass1()
            {
                ProductName = "Mobilya",
                Stock = 40
            });
            return cls1;
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(productList2(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Graphic5()
        {
            return View();
        }


        public List<ChartClass2> productList2()
        {
            List<ChartClass2> cls2 = new List<ChartClass2>();
            using (var context = new Context())
            {
                cls2 = context.Products.Select(x => new ChartClass2
                {
                    productName = x.ProductName,
                    stock = x.Stock
                }).ToList();
            }
            return cls2;
        }




      

        public ActionResult Graphic6()
        {
            return View();
        }
        public ActionResult Graphic7()
        {
            return View();
        }


     








    }
}



//Product product = new Product();
//product.Name = "Apple";
//product.Expiry = new DateTime(2008, 12, 28);
//product.Sizes = new string[] { "Small" };

//string json = JsonConvert.SerializeObject(product);
//{
//    "Name": "Apple",
//   "Expiry": "2008-12-28T00:00:00",
//   "Sizes": [
//     "Small"
//   ]
// }
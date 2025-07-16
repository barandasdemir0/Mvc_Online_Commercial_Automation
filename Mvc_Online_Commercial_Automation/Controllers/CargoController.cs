using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo

        Context context = new Context();
        public ActionResult Index(string aranacak)
        {
            var result = from x in context.CargoDetails select x; /*ToPagedList(sayfa,4);*/
            if (!string.IsNullOrEmpty(aranacak))
            {
                result = result.Where(x => x.CargoTrackingNumber.Contains(aranacak) || x.Employee.Contains(aranacak) || x.Cari.Contains(aranacak)); // Filtering products based on the search term 
            }
            return View(result.ToList());
        }


        [HttpGet]
        public ActionResult CargoAdd()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G" }; // karakter sayısını artırabilirsin
            string code;
            bool exists;

            do
            {
                int k1 = rnd.Next(karakterler.Length);
                int k2 = rnd.Next(karakterler.Length);
                int k3 = rnd.Next(karakterler.Length);

                int s1 = rnd.Next(100, 1000);
                int s2 = rnd.Next(10, 99);
                int s3 = rnd.Next(10, 99);

                code = $"{s1}{karakterler[k1]}{s2}{karakterler[k2]}{s3}{karakterler[k3]}";

                // kontrol: bu kod veritabanında var mı?
                exists = context.CargoDetails.Any(x => x.CargoTrackingNumber == code);

            } while (exists); // varsa yeni bir tane üret

            ViewBag.trackingCode = code;
            return View();
         
        }
        [HttpPost]
        public ActionResult CargoAdd(CargoDetail cargoDetail)
        {
            //var datetime = DateTime.Parse(cargoDetail.Date.ToShortDateString());
            context.CargoDetails.Add(cargoDetail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


       public ActionResult CargoDetails(string id)
        {
            var values = context.CargoTrackings.Where(x => x.CargoTrackingNumber == id).ToList();
            return View(values);
        }
    }
}
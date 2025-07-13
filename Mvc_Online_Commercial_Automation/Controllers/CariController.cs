using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari

        Context context = new Context();
        public ActionResult Index()
        {
            var values =  context.Carilers.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CariAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariAdd(Cari cari)
        {
            cari.status = true;
            if (!ModelState.IsValid)
            {
                return View("CariAdd"); // hatalıysa sayfayı geri göster
            }
           
            context.Carilers.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CariDelete(int id)
        {
            var values = context.Carilers.Find(id);
            values.status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult CariUpdate(int id)
        {
            var values = context.Carilers.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult CariUpdate(Cari cari)
        {
            var values = context.Carilers.Find(cari.CariID);
            values.CariName = cari.CariName;
            values.CariSurname = cari.CariSurname;
            values.CariCity = cari.CariCity;
            values.CariMail = cari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariSale(int id)
        {
            var detectedUser = context.SalesTransactions.Where(x => x.CariID == id).ToList();
            var detectedUserInfo = context.Carilers.Find(id);
            ViewBag.detection = detectedUserInfo.CariName + " " + detectedUserInfo.CariSurname;

            return View(detectedUser);
        }
    }
}
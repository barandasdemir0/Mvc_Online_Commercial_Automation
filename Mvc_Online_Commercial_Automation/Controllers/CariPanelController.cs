using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class CariPanelController : Controller
    {

        Context context = new Context();

        [Authorize]
        // GET: CariPanel
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var values = context.Carilers.Where(x => x.CariMail == mail).ToList();
            ViewBag.carimail = mail;
            var detectedid = context.Carilers.Where(x => x.CariMail == mail).Select(y=>y.CariID).FirstOrDefault();
            ViewBag.mid = detectedid;
            var totalBuy = context.SalesTransactions.Where(x => x.CariID == detectedid).Count();
            ViewBag.totalbuy = totalBuy;
            var totalMoney = context.SalesTransactions.Where(x => x.CariID == detectedid).Sum(y => y.TotalPrice);
            ViewBag.totalMoney = totalMoney;

            var TotalProduct = context.SalesTransactions.Where(x => x.CariID == detectedid).Sum(y => y.Quantity);
            ViewBag.totalproduct = TotalProduct;


            var adsoyad = context.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariName + " " +y.CariSurname).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;


            var gelenMesaj = context.Messages.Where(x => x.Receiver == mail).ToList();

            var city = context.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariCity).First
                ();
            ViewBag.city = city;

            return View(gelenMesaj);
        }

        [HttpGet]
        public ActionResult Order()
        {
            var mail = (string)Session["CariMail"];
            var detectedCari = context.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var degerler = context.SalesTransactions.Where(x => x.CariID == detectedCari).ToList();
            return View(degerler);
        }



        public ActionResult SendMessage()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Messages.Where(x => x.Sender == mail).ToList();
            var message = context.Messages.Where(x => x.Sender == mail).Count();
            ViewBag.count = message;
            var message1 = context.Messages.Where(x => x.Receiver == mail).Count();
            ViewBag.count1 = message1;
            return View(degerler);
        }

        public ActionResult OutCommingMessage()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.MesssageID).ToList();
            var message = context.Messages.Where(x => x.Receiver == mail).Count();
            ViewBag.count1 = message;
            var message1 = context.Messages.Where(x => x.Sender == mail).Count();
            ViewBag.count = message1;
            return View(degerler);

        }


        public ActionResult MessageDetails()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Messages.Where(x => x.Receiver == mail).ToList();
            var message = context.Messages.Where(x => x.Receiver == mail).Count();
            ViewBag.count1 = message;
            var message1 = context.Messages.Where(x => x.Sender == mail).Count();
            ViewBag.count = message1;
            return View(degerler);
        }








        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CariMail"];
            var degerler = context.Messages.Where(x => x.Receiver == mail).ToList();
            var message = context.Messages.Where(x => x.Receiver == mail).Count();
            ViewBag.count1 = message;
            var message1 = context.Messages.Where(x => x.Sender == mail).Count();
            ViewBag.count = message1;
            return View();
        }


        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["CariMail"];
            message.Sender = mail;
            message.Date = DateTime.Parse(DateTime.Now.ToLongDateString());
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTracking(string aranacak)
        {
            var result = from x in context.CargoDetails select x; /*ToPagedList(sayfa,4);*/

            result = result.Where(x => x.CargoTrackingNumber.Contains(aranacak) || x.Employee.Contains(aranacak) || x.Cari.Contains(aranacak)); // Filtering products based on the search term 

            return View(result.ToList());
        }


        public ActionResult CargoTakip(string id)
        {
            var values = context.CargoTrackings.Where(x => x.CargoTrackingNumber == id).ToList();
            return View(values);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult PartialInfo()
        {
            var mail = (string)Session["CariMail"];
            var detectedUser = context.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var detectedCari = context.Carilers.Find(detectedUser);
            return PartialView("PartialInfo", detectedCari);
        }

        public PartialViewResult PartialAnnouncement()
        {
            
            var detectedAnnouncement = context.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(detectedAnnouncement);
        }

        public ActionResult InfoUpdate(Cari cari)
        {
            var cariUser = context.Carilers.Find(cari.CariID);
            cariUser.CariName = cari.CariName;
            cariUser.CariSurname = cari.CariSurname;
            cariUser.CariCity = cari.CariCity;
            cariUser.CariMail = cari.CariMail;
            cariUser.Password = cari.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
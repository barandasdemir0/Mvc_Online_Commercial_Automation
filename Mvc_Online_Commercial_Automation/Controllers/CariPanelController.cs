using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var values = context.Carilers.Where(x => x.CariMail == mail).FirstOrDefault();
            ViewBag.carimail = mail;
            return View(values);
        }

        [HttpGet]
        public ActionResult Order()
        {
            var mail = (string)Session["CariMail"];
            var detectedCari = context.Carilers.Where(x => x.CariMail == mail).Select(y=>y.CariID).FirstOrDefault();
            var degerler = context.SalesTransactions.Where(x => x.CariID == detectedCari).ToList();
            return View(degerler);
        }
    }
}
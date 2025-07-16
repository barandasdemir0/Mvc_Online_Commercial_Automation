using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult partial1()
        {
                       return PartialView();
        }

        [HttpPost]
        public PartialViewResult partial1(Cari cari)
        {
            context.Carilers.Add(cari);
            context.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult Carilogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Carilogin(Cari Cari)
        {
            var bilgiler = context.Carilers.FirstOrDefault(x => x.CariMail == Cari.CariMail && x.Password == Cari.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false); //çerez eklemek için
                Session["CariMail"] = bilgiler.CariMail; // oturum açmak için session kullanıyoruz
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }
               
        }


        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
          
            var bilgiler = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Username, false);
                Session["Username"] = bilgiler.Username; // oturum açmak için session kullanıyoruz
                ViewBag.Username = bilgiler.Username;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index");
            }

          









        }




    }
}
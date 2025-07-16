using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Mvc_Online_Commercial_Automation.Models.Classes;
using PagedList;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        Context context = new Context();
        public ActionResult Index(int sayfa = 1) // sayfa parametresi ile kaçıncı sayfada olduğumuzu belirliyoruz
        {
            var values = context.Categories.ToList().ToPagedList(sayfa,5); // ToPagedList metodu ile sayfalama işlemi yapıyoruz, 5 tane veri gösterilecek şekilde ayarlıyoruz
            return View(values);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CategoryDelete(int id)
        {
            var values = context.Categories.Find(id);
            context.Categories.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var values = context.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            var values = context.Categories.Find(category.CategoryID);
            values.CategoryID = category.CategoryID;
            values.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deneme()
        {
            Class2 class2 = new Class2();
            class2.Categorys = new SelectList(context.Categories, "CategoryID", "CategoryName");
            class2.Products = new SelectList(context.Products, "ProductID", "ProductName");
            return View(class2);
        }

        public JsonResult BringProduct(int id)
        {
            var values = (from x in context.Products
                          join y in context.Categories on x.Category.CategoryID equals y.CategoryID
                          where x.Category.CategoryID == id
                          select new
                          {
                              Text = x.ProductName,
                              Value = x.ProductID.ToString()
                          }).ToList();
            return Json(values, JsonRequestBehavior.AllowGet);
        }


       
    }
}
using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice

        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Invoices.ToList();
            return View(values);
        }





        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult InvoiceUpdate(int id)
        {
            var values = context.Invoices.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult InvoiceUpdate(Invoice invoice)
        {
            var values = context.Invoices.Find(invoice.InvoiceID);
            values.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            values.InvoiceNumber = invoice.InvoiceNumber;
            values.TaxOffice = invoice.TaxOffice;
            values.DeliveredBy = invoice.DeliveredBy;
            values.ReceivedBy = invoice.ReceivedBy;
            values.Date = invoice.Date;
            values.Hours = invoice.Hours;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult InvoiceDetails(int id)
        {
            var values = context.InvoiceItems.Where(x => x.InvoiceID == id).ToList();
            return View(values);
        }



        [HttpGet]
        public ActionResult NewInvoiceItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewInvoiceItem(InvoiceItem invoiceItem)
        {
            context.InvoiceItems.Add(invoiceItem);
            context.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}
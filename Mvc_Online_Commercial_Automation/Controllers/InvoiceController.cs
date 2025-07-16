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

        public ActionResult Dynamic()
        {
            Class3 class3 = new Class3();
            class3.Values1 = context.Invoices.ToList();
            class3.Values2 = context.InvoiceItems.ToList();
            return View(class3);
        }

        public ActionResult SaveBill(string InvoiceSerialNumber,string InvoiceNumber,DateTime Date,string TaxOffice, string Hours,string DeliveredBy, string ReceivedBy , string TotalPrice, InvoiceItem[] invoiceItems)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceSerialNumber = InvoiceSerialNumber;
            invoice.InvoiceNumber = InvoiceNumber;
            invoice.Date = Date;
            invoice.TaxOffice = TaxOffice;
            invoice.Hours = Hours;
            invoice.DeliveredBy = DeliveredBy;
            invoice.ReceivedBy = ReceivedBy;
            invoice.TotalPrice = decimal.Parse( TotalPrice);
            context.Invoices.Add(invoice);
            foreach (var item in invoiceItems)
            {
                InvoiceItem invoiceItem = new InvoiceItem();
                invoiceItem.Description = item.Description;
                invoiceItem.Amount = item.Amount;
                invoiceItem.UnitPrice = item.UnitPrice;
                invoiceItem.TotalPrice = item.TotalPrice;
                context.InvoiceItems.Add(invoiceItem);
            }
           
            context.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }

    }
}
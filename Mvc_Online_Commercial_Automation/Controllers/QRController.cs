using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator createQR = new QRCodeGenerator();
                QRCodeGenerator.QRCode qr = createQR.CreateQrCode(kod,QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = qr.GetGraphic(10))
                {
                    image.Save(ms, ImageFormat.Png);
                    ViewBag.qr = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }

            }
                return View();
        }
    }
}
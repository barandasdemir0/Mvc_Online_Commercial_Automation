using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class SalesTransaction //satış hareketleri
    {
        [Key]
        public int SatidID { get; set; }
        //ÜRÜN
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
        //CARİ
        public virtual Cari Cariler { get; set; }
        public int CariID { get; set; }
        //EMPLOYEE
        public virtual Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
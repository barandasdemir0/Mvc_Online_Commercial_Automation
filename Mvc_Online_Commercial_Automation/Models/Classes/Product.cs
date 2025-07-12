using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BrandName { get; set; }
        public short Stock { get; set; } //shortun sql karşılığı smallint
        public decimal PurchasePrice { get; set; } //alış fiyatı
        public decimal SalePrice { get; set; } //satış fiyatı
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }

        public virtual Category Category { get; set; } //BURADA İLİŞKİ KURDUĞUMUZDA BİR ÜRÜNÜN SADECE 1 KATEGORİSİ OLABİLİR
       
        public ICollection<SalesTransaction> SalesTransaction { get; set; }

        public int CategoryID { get; set; } 

    }
}
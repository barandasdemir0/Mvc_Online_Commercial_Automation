using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class Invoice //fatura sınıfı
    {
        [Key]
        public int InvoiceID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNumber { get; set; } //seri no

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceNumber { get; set; } //sıra no

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxOffice { get; set; } //veri dairesi

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveredBy { get; set; } //teslim eden

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ReceivedBy { get; set; } //teslim alan
        public DateTime Date { get; set; } //tarih

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string Hours { get; set; } //saat

        public decimal TotalPrice { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }  //bir faturannın birden fazla kalemi olaiblir
    }
}
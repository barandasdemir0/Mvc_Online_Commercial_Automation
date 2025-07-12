using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class InvoiceItem //fatura kalem
    {
        [Key]
        public int InvoiceItemID{ get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; } //birfatura kalemin sadece bir faturası olabilir
    }
}
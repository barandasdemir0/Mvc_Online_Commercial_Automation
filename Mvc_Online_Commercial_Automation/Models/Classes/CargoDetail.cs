using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string CargoTrackingNumber { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string Employee { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(25)]
        public string Cari { get; set; }
        public DateTime Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string CargoTrackingNumber { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
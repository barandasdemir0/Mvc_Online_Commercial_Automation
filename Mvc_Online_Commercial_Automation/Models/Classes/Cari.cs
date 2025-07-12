using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public ICollection<SalesTransaction> SalesTransaction { get; set; }

    }
}
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
        [StringLength(30,ErrorMessage ="30 Karakterden Fazla olamaz")]
        [Required(ErrorMessage = "Cari adı boş bırakılamaz")]
        public string CariName { get; set; }

        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari adı boş bırakılamaz")]
        [StringLength(30, ErrorMessage = "30 Karakterden Fazla olamaz")]
        public string CariSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari adı boş bırakılamaz")]
        [StringLength(13, ErrorMessage = "13 Karakterden Fazla olamaz")]
        public string CariCity { get; set; }

        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari adı boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "50 Karakterden Fazla olamaz")]
        public string CariMail { get; set; }


        [Column(TypeName = "Varchar")]
        [Required(ErrorMessage = "Cari adı boş bırakılamaz")]
        [StringLength(20, ErrorMessage = "50 Karakterden Fazla olamaz")]
        public string Password { get; set; }

        public bool status { get; set; }
        public ICollection<SalesTransaction> SalesTransaction { get; set; }

    }
}
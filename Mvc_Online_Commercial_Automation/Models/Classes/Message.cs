using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class Message
    {

        [Key] //primary key olarak atıyoruz
        public int MesssageID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Sender { get; set; } //gönderici

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Receiver { get; set; } //alıcı


        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; } //konu


        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Content { get; set; } //İçerik


        [Column(TypeName = "Date")]
        public DateTime Date { get; set; } //zaman







    }
}
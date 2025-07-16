using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Models.Classes
{
    public class Class2
    {
        public IEnumerable <SelectListItem> Categorys { get; set; }
        public IEnumerable <SelectListItem> Products { get; set; }
    }
}
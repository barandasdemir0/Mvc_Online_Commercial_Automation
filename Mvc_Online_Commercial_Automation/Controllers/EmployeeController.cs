using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Employees.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> values = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();


            ViewBag.departments = values;
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {

          


            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult EmployeeUpdate(int id)
        {
            List<SelectListItem> values1 = (from x in context.Departments.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmentName,
                                                Value = x.DepartmentID.ToString()
                                            }).ToList();


            ViewBag.departments = values1;
            var values = context.Employees.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EmployeeUpdate(Employee employee)
        {

           
            var values = context.Employees.Find(employee.EmployeeID);
            values.EmployeeName = employee.EmployeeName;
            values.EmployeeSurname = employee.EmployeeSurname;
            values.EmployeeImage = employee.EmployeeImage;
            values.DepartmentID = employee.DepartmentID;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelDetails()
        {
                       var values = context.Employees.ToList();
            return View(values);
        }

      

    }
}
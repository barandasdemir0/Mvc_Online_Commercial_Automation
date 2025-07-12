using Mvc_Online_Commercial_Automation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Online_Commercial_Automation.Controllers
{
    public class DepartmentController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.Departments.Where(x => x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult DepartmentsAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmentsAdd(Department departments)
        {
            context.Departments.Add(departments);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmentsDelete(int id)
        {
            var values = context.Departments.Find(id);
            values.Status = false; // Silme işlemi yerine durumu false yapıyoruz
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DepartmentsUpdate(int id)
        {
            var values = context.Departments.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult DepartmentsUpdate(Department department)
        {
            var values = context.Departments.Find(department.DepartmentID);
            values.DepartmentName = department.DepartmentName;
            values.Status = department.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmentsDetails(int id)
        {
            var values = context.Employees.Where(x => x.DepartmentID == id).ToList();
            var detectedDepartment = context.Departments.Find(id);
            ViewBag.departmentName = detectedDepartment.DepartmentName;
            return View(values);
        }


        public ActionResult DepartmentsEmployeeDetails(int id)
        {
            var values = context.Employees.Find(id);
            ViewBag.employeName = values.EmployeeName;
            var detectedValue = context.SalesTransactions.Where(x => x.EmployeeID == id).ToList();
            //var values = context.Employees.Find(id);
            //return View(values);
            return View(detectedValue);
        }
    }
}
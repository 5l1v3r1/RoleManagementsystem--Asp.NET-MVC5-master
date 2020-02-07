using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Role_Management_System.DataServices.EmployeeServices;
using Role_Management_System.Models;
using WebMatrix.WebData;

namespace Role_Management_System.Controllers
{
    [Authorize(Roles ="Admin")]
  
    [HandleError]
    public class EmployeeController : Controller
    {
        [HttpGet]
        
        public ActionResult EmployeeList()
        {
            EmployeeViewModel empList = new EmployeeViewModel();
            var List = empList.GetEmployee();
            return View(List);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel create = new EmployeeViewModel();
                create.CreateEmployee(employee);
                WebSecurity.CreateUserAndAccount(employee.Email, employee.Salary, new { Fullname = employee.Department, Email = employee.Email});
                Roles.AddUserToRole(employee.Email, "Tedarikci");
                return RedirectToAction("EmployeeList", "Employee"); 
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("EmployeeList", "Employee");
            }
            EmployeeViewModel emp = new EmployeeViewModel();
            var getEmployee = emp.GetEmployeeById(Id.Value);
            return View(getEmployee);
        }
        [HttpPost]
        public ActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel update = new EmployeeViewModel();
                update.UpdateEmployee(emp);
                return RedirectToAction("EmployeeList", "Employee");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("EmployeeList", "Employee");
            }
            EmployeeViewModel del = new EmployeeViewModel();
            Employee getEmp = del.GetEmployeeById(Id.Value);
            return View(getEmp);
        }
        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeViewModel del = new EmployeeViewModel();
                 del.Delete(emp.Id);
                return RedirectToAction("EmployeeList", "Employee");
            }
            return View();
        }

	}
}
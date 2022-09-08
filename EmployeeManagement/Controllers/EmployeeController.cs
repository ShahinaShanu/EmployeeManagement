using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
   /* Route[("Controller/action")]*/  //attribute Route
    public class EmployeeController: Controller
    {
        public IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository) //dependency injection via constructor

        {
            _repository = repository;
        }
        public ViewResult Index()
        {
            ViewData["Message"] = "Manage Your Team";   //ViewData works on key value pair.
            ViewBag.Message = "Manage Your Employees";  //ViewBag works on dynamic Property.
            //SqlDBLayer _sqldblayer = new SqlDBLayer(Configuration);
            List<Employee> employees = _repository.GetEmployees();
            ViewData["Employees"] = employees;
            ViewBag.Employees = employees;
            return View(employees);

        }
        public ViewResult DeleteEmployee(int id)
        {
            return View("DeleteEmployee");
        }
        public ViewResult TestMethod(int myid, string name)
        {
            return View("DeleteEmployee");
        }
    }
}

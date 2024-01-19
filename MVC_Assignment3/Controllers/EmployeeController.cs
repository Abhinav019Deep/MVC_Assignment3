using Microsoft.AspNetCore.Mvc;
using MVC_Assignment3.Models;

namespace MVC_Assignment3.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> list = null;
        public EmployeeController()
        {
            if (list == null)
            {
                list = new List<Employee>()
            {
                new Employee() { Id =1, Name="Abhinav", Dept="IT", Salary=90000, JoiningDate=DateTime.Parse("12/12/2021") },

                new Employee() { Id =2, Name="Bala", Dept="IT", Salary=90000, JoiningDate=DateTime.Parse("12/12/2021") },

                new Employee() { Id =3, Name="Modi", Dept="IT", Salary=90000, JoiningDate=DateTime.Parse("12/12/2021") },
            };
            }
        }
        public IActionResult Index()
        {

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            list.Add(employee);
            //return View();
            return RedirectToAction("Index");

        }

        public IActionResult Display(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }


        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }


        }
        [HttpPost]
        public IActionResult Delete(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                list.Remove(temp);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }

        }

        [HttpPost]
        public IActionResult Edit(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Employee stu in list)
                {
                    if (stu.Id == temp.Id)
                    {
                        stu.Dept = employee.Dept;
                        stu.Salary = employee.Salary;
                        break;
                    }


                }
            }
            return RedirectToAction("Index");

        }

    }
}
